﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Text.RegularExpressions;

namespace FlowSERVER1 {

    /// <summary>
    /// Presentation viewer form
    /// </summary>
    public partial class ptxFORM : Form {
        public static MySqlCommand command = ConnectionModel.command;
        public static MySqlConnection con = ConnectionModel.con;
        public static String _TableName;
        public static String _DirectoryName;
        private static bool _IsFromShared;

        /// <summary>
        /// 
        /// Load file based on table name
        /// 
        /// </summary>
        /// <param name="_Title"></param>
        /// <param name="_Table"></param>
        /// <param name="_Directory"></param>
        /// <param name="_UploaderName"></param>


        public ptxFORM(String _Title,String _Table, String _Directory,String _UploaderName, bool _isFromShared = false) {
            InitializeComponent();

            String _getName = "";
            bool _isShared = Regex.Match(_UploaderName, @"^([\w\-]+)").Value == "Shared";

            label1.Text = _Title;
            _TableName = _Table;
            _DirectoryName = _Directory;
            _IsFromShared = _isFromShared;

            if (_isShared == true) {
                _getName = _UploaderName;
                label3.Visible = true;
                label3.Text = getCommentSharedToOthers() != "" ? "Comment: '" + getCommentSharedToOthers() + "'" : "Comment: (No Comment)";
            }
            else {
                _getName = "Uploaded By " + _UploaderName;
                label3.Visible = true;
                label3.Text = getCommentSharedToMe() != "" ? "Comment: '" + getCommentSharedToMe() + "'" : "Comment: (No Comment)";
            }

            label2.Text = _getName;

            try {

                Thread ShowAlert = new Thread(() => new RetrievalAlert("Flowstorage is retrieving your presentation.", "Loader").ShowDialog());
                ShowAlert.Start();

                if (_TableName == "file_info_ptx") {   
                    setupPtx(LoaderModel.LoadFile("file_info_ptx",_DirectoryName,label1.Text));
                } else if (_TableName == "upload_info_directory") {
                    setupPtx(LoaderModel.LoadFile("upload_info_directory", _DirectoryName, label1.Text));
                }
                else if (_TableName == "folder_upload_info") { 
                    setupPtx(LoaderModel.LoadFile("folder_upload_info", _DirectoryName, label1.Text));
                }
                else if (_TableName == "cust_sharing") {
                    setupPtx(LoaderModel.LoadFile("cust_sharing", _DirectoryName, label1.Text,_isFromShared));
                }

            }  catch (Exception) {
                Form bgBlur = new Form();
                using (errorLoad displayError = new errorLoad()) {
                    bgBlur.StartPosition = FormStartPosition.Manual;
                    bgBlur.FormBorderStyle = FormBorderStyle.None;
                    bgBlur.Opacity = .24d;
                    bgBlur.BackColor = Color.Black;
                    bgBlur.WindowState = FormWindowState.Maximized;
                    bgBlur.TopMost = true;
                    bgBlur.Location = this.Location;
                    bgBlur.StartPosition = FormStartPosition.Manual;
                    bgBlur.ShowInTaskbar = false;
                    bgBlur.Show();

                    displayError.Owner = bgBlur;
                    displayError.ShowDialog();

                    bgBlur.Dispose();
                }
            }
        }

        private string getCommentSharedToMe() {
            String returnComment = "";
            using (MySqlCommand command = new MySqlCommand("SELECT CUST_COMMENT FROM cust_sharing WHERE CUST_TO = @username AND CUST_FILE_PATH = @filename", con)) {
                command.Parameters.AddWithValue("@username", Form1.instance.label5.Text);
                command.Parameters.AddWithValue("@filename", label1.Text);
                using (MySqlDataReader readerComment = command.ExecuteReader()) {
                    while (readerComment.Read()) {
                        returnComment = readerComment.GetString(0);
                    }
                }
            }
            return returnComment;
        }

        private string getCommentSharedToOthers() {
            String returnComment = "";
            using (MySqlCommand command = new MySqlCommand("SELECT CUST_COMMENT FROM cust_sharing WHERE CUST_FROM = @username AND CUST_FILE_PATH = @filename", con)) {
                command.Parameters.AddWithValue("@username", Form1.instance.label5.Text);
                command.Parameters.AddWithValue("@filename", label1.Text);
                using (MySqlDataReader readerComment = command.ExecuteReader()) {
                    while (readerComment.Read()) {
                        returnComment = readerComment.GetString(0);
                    }
                }
            }
            return returnComment;
        }

        public void setupPtx(Byte[] _getByte) {
            var _memoryStream = new MemoryStream(_getByte);
            LoadPtx(_memoryStream);
        }
        public void LoadPtx(Stream _getStream) {
            //var _ptxSetup = PdfDocument.Load(_getStream);
            officeViewer1.LoadFromStream(_getStream);
           
        }

        private void label2_Click(object sender, EventArgs e) {
        }

        private void guna2Button4_Click(object sender, EventArgs e) {
            this.TopMost = false;
            if (_TableName == "upload_info_directory") {
                SaverModel.SaveSelectedFile(label1.Text, "upload_info_directory", _DirectoryName);
            }
            else if (_TableName == "folder_upload_info") {
                SaverModel.SaveSelectedFile(label1.Text, "folder_upload_info", _DirectoryName);
            }
            else if (_TableName == "file_info_ptx") {
                SaverModel.SaveSelectedFile(label1.Text, "file_info_ptx", _DirectoryName);
            } else if (_TableName == "cust_sharing") {
                SaverModel.SaveSelectedFile(label1.Text, "cust_sharing", _DirectoryName,_IsFromShared);
            }
            this.TopMost = true;
        }

        private void guna2Button3_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Normal;
            guna2Button1.Visible = true;
            guna2Button3.Visible = false;
            label1.AutoSize = false;
            label2.AutoSize = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Maximized;
            guna2Button1.Visible = false;
            guna2Button3.Visible = true;
            label1.AutoSize = true;
            label2.AutoSize = true;
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void guna2Button2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void ptxFORM_Load(object sender, EventArgs e) {

        }

        private void officeViewer1_Click(object sender, EventArgs e) {

        }

        private void guna2Button8_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
            Application.OpenForms
              .OfType<Form>()
              .Where(form => String.Equals(form.Name, "bgBlurForm"))
              .ToList()
              .ForEach(form => form.Hide());
        }
    }
}
