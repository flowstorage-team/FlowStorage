﻿using FlowSERVER1.Global;
using FlowSERVER1.Helper;
using System;
using System.Windows.Forms;

namespace FlowSERVER1 {
    public partial class ApkForm : Form {

        private string _tableName { get; set; }
        private string _directoryName { get; set; }
        private bool _isFromSharing { get; set; }
        private bool _isFromShared { get; set; }

        public ApkForm(String fileName, String uploaderName, String tableName, String directoryName, bool isFromShared = false, bool isFromSharing = false) {

            InitializeComponent();

            this.lblFileName.Text = fileName;
            this._tableName = tableName;
            this._directoryName = directoryName;
            this._isFromSharing = isFromSharing;
            this._isFromShared = isFromShared;

            if (_isFromShared == true) {

                guna2Button7.Visible = true;
                btnEditComment.Visible = true;

                label6.Text = "Shared To";
                btnShareFile.Visible = false;
                lblUserComment.Visible = true;
                lblUserComment.Text = GetComment.getCommentSharedToOthers(fileName: fileName) != "" ? GetComment.getCommentSharedToOthers(fileName: fileName) : "(No Comment)";
            }
            else {
                label6.Text = "Uploaded By";
                lblUserComment.Visible = true;
                lblUserComment.Text = GetComment.getCommentSharedToMe(fileName: fileName) != "" ? GetComment.getCommentSharedToMe(fileName: fileName) : "(No Comment)";
            }

            if (GlobalsTable.publicTablesPs.Contains(tableName)) {
                label6.Text = "Uploaded By";
                string comment = GetComment.getCommentPublicStorage(tableName: tableName, fileName: fileName, uploaderName: uploaderName);
                lblUserComment.Visible = true;
                lblUserComment.Text = string.IsNullOrEmpty(comment) ? "(No Comment)" : comment;
            }

            lblUploaderName.Text = uploaderName;
        }

        private void guna2Button2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e) {

        }

        private void apkFORM_Load(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }
        private void guna2Button4_Click(object sender, EventArgs e) {

            try {

                RetrievalAlert ShowAlert = new RetrievalAlert("Flowstorage is retrieving your APK data.", "Saver");
                ShowAlert.Show();

                SaverModel.SaveSelectedFile(lblFileName.Text, _tableName, _directoryName);

            }
            catch (Exception) {
                MessageBox.Show("Failed to download this file.", "Flowstorage", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e) {
            string getExtension = lblFileName.Text.Substring(lblFileName.Text.Length - 4);
            new shareFileFORM(lblFileName.Text, getExtension,
                _isFromSharing, _tableName, _directoryName).Show();
        }

        private async void guna2Button7_Click(object sender, EventArgs e) {

            if (lblUserComment.Text != txtFieldComment.Text) {
                await new UpdateComment().SaveChangesComment(txtFieldComment.Text, lblFileName.Text);
            }

            lblUserComment.Text = txtFieldComment.Text != String.Empty ? txtFieldComment.Text : lblUserComment.Text;
            btnEditComment.Visible = true;
            guna2Button7.Visible = false;
            txtFieldComment.Visible = false;
            lblUserComment.Visible = true;
            lblUserComment.Refresh();
        }

        private void guna2Button3_Click(object sender, EventArgs e) {
            txtFieldComment.Enabled = true;
            txtFieldComment.Visible = true;
            btnEditComment.Visible = false;
            guna2Button7.Visible = true;
            lblUserComment.Visible = false;
            txtFieldComment.Text = lblUserComment.Text;
        }

        private void label7_Click(object sender, EventArgs e) {

        }
    }
}
