﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace FlowSERVER1 {
    /// <summary>
    /// File Loader Class
    /// </summary>
    public partial class LoaderModel {

        public static readonly MySqlCommand command = ConnectionModel.command;
        public static readonly MySqlConnection con = ConnectionModel.con;
        public static byte[] universalBytes { get; set; }
        public static bool stopFileRetrievalLoad { get; set; } = false;
        public static string originalFileName { get; set; }

        private static string fileName { get; set; }

        public static Byte[] LoadFile(String _TableName, String _DirectoryName,String _FileName, bool _isFromSharedTo = false) {

            try {

                fileName = _FileName;

                if (_TableName != "upload_info_directory" && _TableName != "folder_upload_info" && _TableName != "cust_sharing") {
                    RetrieveHomeDataAsync(_TableName);
                }

                else if (_TableName == "upload_info_directory") {
                    RetrieveDirectoryDataAsync(_DirectoryName);
                 
                }

                else if (_TableName == "folder_upload_info") {

                    string readGifFilesQuery = "SELECT CUST_FILE FROM folder_upload_info WHERE CUST_USERNAME = @username AND CUST_FILE_PATH = @filepath AND FOLDER_TITLE = @foldtitle";
                    using (MySqlCommand command = new MySqlCommand(readGifFilesQuery, con)) {
                        command.Parameters.AddWithValue("@username", Form1.instance.label5.Text);
                        command.Parameters.AddWithValue("@filepath", EncryptionModel.Encrypt(_FileName, "0123456789085746"));
                        command.Parameters.AddWithValue("@foldtitle", _DirectoryName);

                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {

                                var retrievalAlertFormsOne = Application.OpenForms.OfType<Form>().Where(form => form.Name == "RetrievalAlert").ToList();
                                retrievalAlertFormsOne.ForEach(form => form.Close());

                                if (stopFileRetrievalLoad) {
                                    reader.Close();
                                    var retrievalAlertForms = Application.OpenForms.OfType<Form>().Where(form => form.Name == "RetrievalAlert").ToList();
                                    retrievalAlertForms.ForEach(form => form.Close());
                                    stopFileRetrievalLoad = false;
                                }

                                var base64Encoded = reader.GetString(0);
                                var decryptValues = EncryptionModel.Decrypt(base64Encoded, "0123456789085746");
                                var bytes = Convert.FromBase64String(decryptValues);
                                universalBytes = bytes;
                            }
                        }
                    }

                } else if (_TableName == "cust_sharing" && _isFromSharedTo == true) {

                    string readGifFilesQuery = "SELECT CUST_FILE FROM cust_sharing WHERE CUST_FROM = @username AND CUST_FILE_PATH = @filepath";
                    using (MySqlCommand command = new MySqlCommand(readGifFilesQuery, con)) {
                        command.Parameters.AddWithValue("@username", Form1.instance.label5.Text);
                        command.Parameters.AddWithValue("@filepath", EncryptionModel.Encrypt(_FileName, "0123456789085746"));

                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {

                                var retrievalAlertFormsOne = Application.OpenForms.OfType<Form>().Where(form => form.Name == "RetrievalAlert").ToList();
                                retrievalAlertFormsOne.ForEach(form => form.Close());

                                if (stopFileRetrievalLoad) {
                                    reader.Close();
                                    var retrievalAlertForms = Application.OpenForms.OfType<Form>().Where(form => form.Name == "RetrievalAlert").ToList();
                                    retrievalAlertForms.ForEach(form => form.Close());
                                    stopFileRetrievalLoad = false;
                                }


                                var base64Encoded = reader.GetString(0);
                                var decryptValues = EncryptionModel.Decrypt(base64Encoded, "0123456789085746");
                                var bytes = Convert.FromBase64String(decryptValues);
                                universalBytes = bytes;
                            }
                        }
                    }
                }

                else if (_TableName == "cust_sharing") {
                    RetrieveSharedDataAsync();
                
                }

            } catch (Exception) {
                // @ ignore exception                
            }
            return universalBytes;
        }

        private static async void RetrieveDirectoryDataAsync(string directoryName) {

            string readGifFilesQuery = "SELECT CUST_FILE FROM upload_info_directory WHERE CUST_USERNAME = @username AND CUST_FILE_PATH = @filepath AND DIR_NAME = @dirname";

            using (MySqlCommand command = new MySqlCommand(readGifFilesQuery, con)) {
                command.Parameters.AddWithValue("@username", Form1.instance.label5.Text);
                command.Parameters.AddWithValue("@filepath", EncryptionModel.Encrypt(fileName, EncryptionKey.KeyValue));
                command.Parameters.AddWithValue("@dirname", EncryptionModel.Encrypt(directoryName,EncryptionKey.KeyValue));

                using (MySqlDataReader reader = (MySqlDataReader) await command.ExecuteReaderAsync()) {
                    if (await reader.ReadAsync()) {
                        CloseRetrievalAlertForms();

                        if (stopFileRetrievalLoad) {
                            reader.Close();
                            CloseRetrievalAlertForms();
                            stopFileRetrievalLoad = false;
                            return;
                        }

                        var base64Encoded = reader.GetString(0);
                        var decryptValues = EncryptionModel.Decrypt(base64Encoded, EncryptionKey.KeyValue);
                        var bytes = Convert.FromBase64String(decryptValues);
                        universalBytes = bytes;
                    }
                }
            }
        }

        private static async void RetrieveSharedDataAsync() {

            string readGifFilesQuery = "SELECT CUST_FILE FROM cust_sharing WHERE CUST_TO = @username AND CUST_FILE_PATH = @filepath";

            using (MySqlCommand command = new MySqlCommand(readGifFilesQuery, con)) {
                command.Parameters.AddWithValue("@username", Form1.instance.label5.Text);
                command.Parameters.AddWithValue("@filepath", EncryptionModel.Encrypt(fileName, EncryptionKey.KeyValue));

                using (MySqlDataReader reader = (MySqlDataReader) await command.ExecuteReaderAsync()) {
                    if (await reader.ReadAsync()) {
                        CloseRetrievalAlertForms();

                        if (stopFileRetrievalLoad) {
                            reader.Close();
                            CloseRetrievalAlertForms();
                            stopFileRetrievalLoad = false;
                            return;
                        }

                        var base64Encoded = reader.GetString(0);
                        var decryptedValues = EncryptionModel.Decrypt(base64Encoded, EncryptionKey.KeyValue);
                        var fileBytes = Convert.FromBase64String(decryptedValues);
                        universalBytes = fileBytes;
                    }
                }
            }
        }

        private static async void RetrieveHomeDataAsync(String TableName) {
            string readFilesQuery = $"SELECT CUST_FILE FROM {TableName} WHERE CUST_USERNAME = @username AND CUST_FILE_PATH = @filepath";
            using (MySqlCommand command = new MySqlCommand(readFilesQuery, con)) {
                command.Parameters.AddWithValue("@username", Form1.instance.label5.Text);
                command.Parameters.AddWithValue("@filepath", EncryptionModel.Encrypt(fileName, EncryptionKey.KeyValue));

                using (MySqlDataReader reader = (MySqlDataReader) await command.ExecuteReaderAsync()) {
                    if (await reader.ReadAsync()) {
                        CloseRetrievalAlertForms();
                        if (stopFileRetrievalLoad) {
                            reader.Close();
                            CloseRetrievalAlertForms();
                            stopFileRetrievalLoad = false;
                        }

                        string base64Encoded = reader.GetString(0);
                        string decryptedValues = EncryptionModel.Decrypt(base64Encoded, "0123456789085746");
                        byte[] bytes = Convert.FromBase64String(decryptedValues);
                        universalBytes = bytes;
                    }
                }
            }
        }

        private static void CloseRetrievalAlertForms() {
            var retrievalAlertForms = Application.OpenForms.OfType<Form>().Where(form => form.Name == "RetrievalAlert").ToList();
            retrievalAlertForms.ForEach(form => form.Close());
        }
    }
}

