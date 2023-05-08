﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.IO;
using System.Xml;
using ExcelDataReader;
using ClosedXML.Excel;
using System.Runtime.Serialization.Formatters.Binary;

namespace FlowSERVER1 {


    /// <summary>
    /// Excel viewer form
    /// </summary>
    
    public partial class exlFORM : Form {

        public exlFORM instance;
        private String DirectoryName;
        private String TableName;

        private int _currentSheetIndex = 1;
        private int _changedIndex = 0;
        private byte[] _sheetsByte;
        private bool _isFromShared;
        private bool IsFromSharing;

        private MySqlConnection con = ConnectionModel.con;

        /// <summary>
        /// 
        /// Load user excel workbook sheet based on table name 
        /// 
        /// </summary>
        /// <param name="titleName"></param>
        /// <param name="_TableName"></param>
        /// <param name="_DirectoryName"></param>
        /// <param name="_UploaderName"></param>

        public exlFORM(String titleName, String _TableName, String _DirectoryName, String _UploaderName, bool isFromShared = false) {

            InitializeComponent();

            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;

            String _getName = "";
            bool _isShared = Regex.Match(_UploaderName, @"^([\w\-]+)").Value == "Shared";

            instance = this;
            label1.Text = titleName;
            DirectoryName = _DirectoryName;
            TableName = _TableName;
            _isFromShared = isFromShared;

            if (_isShared == true) {

                guna2Button7.Visible = true;
                guna2Button9.Visible = true;

                _getName = _UploaderName.Replace("Shared", "");
                label4.Text = "Shared To";
                guna2Button5.Visible = false;
                label3.Visible = true;
                label3.Text = getCommentSharedToOthers() != "" ? getCommentSharedToOthers() : "(No Comment)";
            }
            else {
                _getName = " " + _UploaderName;
                label4.Text = "Uploaded By";
                label3.Visible = true;
                label3.Text = getCommentSharedToMe() != "" ? getCommentSharedToMe() : "(No Comment)";
            }

            label2.Text = _getName;

            try {

                RetrievalAlert ShowAlert = new RetrievalAlert("Flowstorage is retrieving your workbook.","Loader");
                ShowAlert.Show();

                if (_TableName == "file_info_excel") {
                    generateSheet(LoaderModel.LoadFile("file_info_excel",DirectoryName,titleName));
                    _sheetsByte = LoaderModel.LoadFile("file_info_excel", DirectoryName, titleName);
                }
                else if (_TableName == "upload_info_directory") {
                    generateSheet(LoaderModel.LoadFile("upload_info_directory", DirectoryName, titleName));
                    _sheetsByte = LoaderModel.LoadFile("upload_info_directory", DirectoryName, titleName);
                } else if (_TableName == "folder_upload_info") {
                    generateSheet(LoaderModel.LoadFile("folder_upload_info", DirectoryName, titleName));
                    _sheetsByte = LoaderModel.LoadFile("folder_upload_info", DirectoryName, titleName);
                } else if (_TableName == "cust_sharing") {
                    generateSheet(LoaderModel.LoadFile("cust_sharing", DirectoryName, titleName,isFromShared));
                    _sheetsByte = LoaderModel.LoadFile("cust_sharing", DirectoryName, titleName);
                }
            }

            catch (Exception) {
                MessageBox.Show("Failed to load this workbook. It may be broken or unsupported format.","Flowstorage",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private string getCommentSharedToMe() {
            String returnComment = "";
            using (MySqlCommand command = new MySqlCommand("SELECT CUST_COMMENT FROM cust_sharing WHERE CUST_TO = @username AND CUST_FILE_PATH = @filename", con)) {
                command.Parameters.AddWithValue("@username", Form1.instance.label5.Text);
                command.Parameters.AddWithValue("@filename", EncryptionModel.Encrypt(label1.Text));
                using (MySqlDataReader readerComment = command.ExecuteReader()) {
                    while (readerComment.Read()) {
                        returnComment = EncryptionModel.Decrypt(readerComment.GetString(0));
                    }
                }
            }
            return returnComment;
        }

        private string getCommentSharedToOthers() {
            String returnComment = "";
            using (MySqlCommand command = new MySqlCommand("SELECT CUST_COMMENT FROM cust_sharing WHERE CUST_FROM = @username AND CUST_FILE_PATH = @filename", con)) {
                command.Parameters.AddWithValue("@username", Form1.instance.label5.Text);
                command.Parameters.AddWithValue("@filename", EncryptionModel.Encrypt(label1.Text));
                using (MySqlDataReader readerComment = command.ExecuteReader()) {
                    while (readerComment.Read()) {
                        returnComment = EncryptionModel.Decrypt(readerComment.GetString(0));
                    }
                }
            }
            return returnComment;
        }


        /// <summary>
        /// Essential variable to prevent sheetname duplication
        /// </summary>

        int onlyOnceVarible = 0; 

        /// <summary>
        /// Start generating workbook sheets
        /// </summary>
        /// <param name=""></param>
        private void generateSheet(Byte[] _getByte) {

            label7.Text = $"{FileSize.fileSize(_getByte):F2}Mb";

            try {

                onlyOnceVarible++;

                using (MemoryStream _toStream = new MemoryStream(_getByte)) {
                    using (XLWorkbook workBook = new XLWorkbook(_toStream)) {
                        var worksheetNames = workBook.Worksheets;
                        if (onlyOnceVarible == 1) {
                            guna2ComboBox1.Items.AddRange(worksheetNames.ToArray());
                        }

                        guna2ComboBox1.SelectedIndex = _changedIndex;
                        _currentSheetIndex = _changedIndex + 1;

                        IXLWorksheet workSheet = workBook.Worksheet(_currentSheetIndex);

                        DataTable dt = new DataTable();

                        bool firstRow = true;
                        foreach (IXLRangeRow row in workSheet.RangeUsed().Rows()) {
                            if (firstRow) {
                                foreach (IXLCell cell in row.Cells()) {
                                    dt.Columns.Add(cell.Value.ToString());
                                }
                                firstRow = false;
                            }
                            else {
                                dt.Rows.Add(row.Cells().Select(c => c.Value.ToString()).ToArray());
                            }
                        }

                        dataGridView1.DataSource = dt;
                    }
                }

            } catch (Exception) {
                
                try {

                    var _formatter = new BinaryFormatter();
                    var _stream = new MemoryStream(_getByte);
                    var _dataSource = _formatter.Deserialize(_stream);
                    dataGridView1.DataSource = _dataSource;

                } catch (Exception) {
                    MessageBox.Show("Failed to load this file.","Flowstorage",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }

            }
        }

        /// <summary>
        /// Change workbook sheet on combobox selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            _changedIndex = guna2ComboBox1.SelectedIndex;
            generateSheet(_sheetsByte);
        }

        private void Form5_Load(object sender, EventArgs e) {

        }
        
        private void guna2Button3_Click(object sender, EventArgs e) {
            this.guna2BorderlessForm1.BorderRadius = 12;
            this.WindowState = FormWindowState.Normal;
            guna2Button1.Visible = true;
            guna2Button3.Visible = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void label3_Click(object sender, EventArgs e) {

        }

        private void guna2Button1_Click(object sender, EventArgs e) {
            this.guna2BorderlessForm1.BorderRadius = 0;
            this.WindowState = FormWindowState.Maximized;
            guna2Button1.Visible = false;
            guna2Button3.Visible = true;
        }

        private void spreadsheet1_Load(object sender, EventArgs e) {

        }

        private void spreadsheet1_Click(object sender, EventArgs e) {

        }

        private void guna2Button4_Click(object sender, EventArgs e) {
            this.TopMost = false;
            if(TableName == "file_info_excel") {
                SaverModel.SaveSelectedFile(label1.Text,"file_info_excel",DirectoryName);
            } else if (TableName == "upload_info_directory") {
                SaverModel.SaveSelectedFile(label1.Text, "upload_info_directory", DirectoryName);
            } else if (TableName == "folder_upload_info") {
                SaverModel.SaveSelectedFile(label1.Text, "folder_upload_info", DirectoryName);
            }
            else if (TableName == "cust_sharing") {
                SaverModel.SaveSelectedFile(label1.Text, "cust_sharing", DirectoryName);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void spreadsheet1_Load_1(object sender, EventArgs e) {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e) {

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e) {

        }

        private void guna2Button8_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
            this.TopMost = false;
        }

        private void guna2Button5_Click(object sender, EventArgs e) {
            string[] parts = label1.Text.Split('.');
            string getExtension = "." + parts[1];
            shareFileFORM _showSharingFileFORM = new shareFileFORM(label1.Text, getExtension, IsFromSharing, TableName, DirectoryName);
            _showSharingFileFORM.Show();
        }

        private void _saveChangesUpdate(String textValues) {

            try {

                if (TableName == "file_info_excel") {
                    string updateQue = $"UPDATE file_info_excel SET CUST_FILE = @update WHERE CUST_USERNAME = @username AND CUST_FILE_PATH = @filename";
                    using (MySqlCommand command = new MySqlCommand(updateQue, con)) {
                        command.Parameters.Add("@update", MySqlDbType.LongText).Value = textValues;
                        command.Parameters.Add("@username", MySqlDbType.Text).Value = Form1.instance.label5.Text;
                        command.Parameters.Add("@filename", MySqlDbType.LongText).Value = EncryptionModel.Encrypt(label1.Text);
                        command.ExecuteNonQuery();
                    }

                }
                else if (TableName == "cust_sharing" && IsFromSharing == false) {

                    string updateQue = $"UPDATE cust_sharing SET CUST_FILE = @update WHERE CUST_TO = @username AND CUST_FILE_PATH = @filename";
                    using (MySqlCommand command = new MySqlCommand(updateQue, con)) {
                        command.Parameters.Add("@update", MySqlDbType.LongText).Value = textValues;
                        command.Parameters.Add("@username", MySqlDbType.Text).Value = Form1.instance.label5.Text;
                        command.Parameters.Add("@filename", MySqlDbType.LongText).Value = EncryptionModel.Encrypt(label1.Text);
                        command.ExecuteNonQuery();
                    }

                }
                else if (TableName == "cust_sharing" && IsFromSharing == true) {

                    string updateQue = $"UPDATE cust_sharing SET CUST_FILE = @update WHERE CUST_FROM = @username AND CUST_FILE_PATH = @filename";
                    using (MySqlCommand command = new MySqlCommand(updateQue, con)) {
                        command.Parameters.Add("@update", MySqlDbType.LongText).Value = textValues;
                        command.Parameters.Add("@username", MySqlDbType.Text).Value = Form1.instance.label5.Text;
                        command.Parameters.Add("@filename", MySqlDbType.LongText).Value = EncryptionModel.Encrypt(label1.Text);
                        command.ExecuteNonQuery();
                    }

                }
                else if (TableName == "upload_info_directory") {

                    string updateQue = $"UPDATE upload_info_directory SET CUST_FILE = @update WHERE CUST_USERNAME = @username AND CUST_FILE_PATH = @filename AND DIR_NAME = @dirname";
                    using (MySqlCommand command = new MySqlCommand(updateQue, con)) {
                        command.Parameters.Add("@update", MySqlDbType.LongBlob).Value = textValues;
                        command.Parameters.Add("@username", MySqlDbType.Text).Value = Form1.instance.label5.Text;
                        command.Parameters.Add("@dirname", MySqlDbType.Text).Value = EncryptionModel.Encrypt(DirectoryName);
                        command.Parameters.Add("@filename", MySqlDbType.LongText).Value = EncryptionModel.Encrypt(label1.Text);
                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception) {
                MessageBox.Show("Failed to save changes.", "Flowstorage", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e) {

            var _getDataSources = dataGridView1.DataSource;
            var _formatter = new BinaryFormatter();
            var _stream = new MemoryStream();
            _formatter.Serialize(_stream, _getDataSources);

            byte[] _getByte = _stream.ToArray();
            string _toBase64Encoded = Convert.ToBase64String(_getByte);
            string _encryptedString = EncryptionModel.Encrypt(_toBase64Encoded);

            _saveChangesUpdate(_encryptedString);

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            guna2Button6.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private async Task saveChangesComment(String updatedComment) {

            string query = "UPDATE cust_sharing SET CUST_COMMENT = @updatedComment WHERE CUST_FROM = @username AND CUST_FILE_PATH = @filename";
            using (var command = new MySqlCommand(query, con)) {
                command.Parameters.AddWithValue("@updatedComment", updatedComment);
                command.Parameters.AddWithValue("@username", Form1.instance.label5.Text);
                command.Parameters.AddWithValue("@filename", EncryptionModel.Encrypt(label1.Text));
                await command.ExecuteNonQueryAsync();
            }

        }

        private async void guna2Button9_Click(object sender, EventArgs e) {

            if (label3.Text != guna2TextBox4.Text) {
                await saveChangesComment(guna2TextBox4.Text);
            }

            label3.Text = guna2TextBox4.Text != String.Empty ? guna2TextBox4.Text : label3.Text;
            guna2Button7.Visible = true;
            guna2Button9.Visible = false;
            guna2TextBox4.Visible = false;
            label3.Visible = true;
            label3.Refresh();
        }

        private void guna2Button7_Click(object sender, EventArgs e) {
            guna2TextBox4.Enabled = true;
            guna2TextBox4.Visible = true;
            guna2Button7.Visible = false;
            guna2Button9.Visible = true;
            label3.Visible = false;
            guna2TextBox4.Text = label3.Text;
        }
    }
}
