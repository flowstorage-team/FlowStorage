﻿namespace FlowSERVER1 {
    partial class ValidateRecoveryEmail {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValidateRecoveryEmail));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFieldPin = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblAlert = new System.Windows.Forms.Label();
            this.txtFieldEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFieldRecoveryKey = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2VSeparator1 = new Guna.UI2.WinForms.Guna2VSeparator();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 25;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(11, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Password Recovery";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(53, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 48;
            this.label3.Text = "PIN";
            // 
            // txtFieldPin
            // 
            this.txtFieldPin.BackColor = System.Drawing.Color.Transparent;
            this.txtFieldPin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtFieldPin.BorderRadius = 8;
            this.txtFieldPin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFieldPin.DefaultText = "";
            this.txtFieldPin.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFieldPin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFieldPin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFieldPin.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFieldPin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtFieldPin.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFieldPin.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFieldPin.ForeColor = System.Drawing.Color.White;
            this.txtFieldPin.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFieldPin.Location = new System.Drawing.Point(47, 189);
            this.txtFieldPin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtFieldPin.MaxLength = 3;
            this.txtFieldPin.Name = "txtFieldPin";
            this.txtFieldPin.PasswordChar = '*';
            this.txtFieldPin.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtFieldPin.PlaceholderText = "Enter your PIN key";
            this.txtFieldPin.SelectedText = "";
            this.txtFieldPin.Size = new System.Drawing.Size(162, 44);
            this.txtFieldPin.TabIndex = 47;
            this.txtFieldPin.TextChanged += new System.EventHandler(this.guna2TextBox4_TextChanged);
            // 
            // lblAlert
            // 
            this.lblAlert.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAlert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.lblAlert.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(1)))));
            this.lblAlert.Location = new System.Drawing.Point(149, 342);
            this.lblAlert.Name = "lblAlert";
            this.lblAlert.Size = new System.Drawing.Size(136, 20);
            this.lblAlert.TabIndex = 19;
            this.lblAlert.Text = "Account not found";
            this.lblAlert.Visible = false;
            // 
            // txtFieldEmail
            // 
            this.txtFieldEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFieldEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtFieldEmail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtFieldEmail.BorderRadius = 8;
            this.txtFieldEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFieldEmail.DefaultText = "";
            this.txtFieldEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFieldEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFieldEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFieldEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFieldEmail.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtFieldEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFieldEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtFieldEmail.ForeColor = System.Drawing.Color.White;
            this.txtFieldEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFieldEmail.Location = new System.Drawing.Point(47, 112);
            this.txtFieldEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtFieldEmail.Name = "txtFieldEmail";
            this.txtFieldEmail.PasswordChar = '\0';
            this.txtFieldEmail.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtFieldEmail.PlaceholderText = "Enter your email address";
            this.txtFieldEmail.SelectedText = "";
            this.txtFieldEmail.Size = new System.Drawing.Size(273, 44);
            this.txtFieldEmail.TabIndex = 16;
            this.txtFieldEmail.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            // 
            // guna2Button2
            // 
            this.guna2Button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2Button2.Animated = true;
            this.guna2Button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.guna2Button2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(3)))), ((int)(((byte)(153)))));
            this.guna2Button2.BorderRadius = 10;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(0)))), ((int)(((byte)(179)))));
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Location = new System.Drawing.Point(47, 385);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(331, 51);
            this.guna2Button2.TabIndex = 15;
            this.guna2Button2.Text = "Next";
            this.guna2Button2.TextOffset = new System.Drawing.Point(0, -2);
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(52, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Email";
            // 
            // txtFieldRecoveryKey
            // 
            this.txtFieldRecoveryKey.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFieldRecoveryKey.BackColor = System.Drawing.Color.Transparent;
            this.txtFieldRecoveryKey.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtFieldRecoveryKey.BorderRadius = 8;
            this.txtFieldRecoveryKey.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFieldRecoveryKey.DefaultText = "";
            this.txtFieldRecoveryKey.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFieldRecoveryKey.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFieldRecoveryKey.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFieldRecoveryKey.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFieldRecoveryKey.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtFieldRecoveryKey.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFieldRecoveryKey.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtFieldRecoveryKey.ForeColor = System.Drawing.Color.White;
            this.txtFieldRecoveryKey.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFieldRecoveryKey.Location = new System.Drawing.Point(47, 269);
            this.txtFieldRecoveryKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtFieldRecoveryKey.Name = "txtFieldRecoveryKey";
            this.txtFieldRecoveryKey.PasswordChar = '\0';
            this.txtFieldRecoveryKey.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtFieldRecoveryKey.PlaceholderText = "Enter your backup recovery key";
            this.txtFieldRecoveryKey.SelectedText = "";
            this.txtFieldRecoveryKey.Size = new System.Drawing.Size(331, 44);
            this.txtFieldRecoveryKey.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(52, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 49;
            this.label1.Text = "Recovery Key";
            // 
            // guna2VSeparator1
            // 
            this.guna2VSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.guna2VSeparator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.guna2VSeparator1.Location = new System.Drawing.Point(420, 57);
            this.guna2VSeparator1.Name = "guna2VSeparator1";
            this.guna2VSeparator1.Size = new System.Drawing.Size(10, 425);
            this.guna2VSeparator1.TabIndex = 52;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Separator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.guna2Separator1.Location = new System.Drawing.Point(0, 51);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(684, 10);
            this.guna2Separator1.TabIndex = 51;
            // 
            // guna2Button1
            // 
            this.guna2Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button1.Animated = true;
            this.guna2Button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.guna2Button1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(3)))), ((int)(((byte)(153)))));
            this.guna2Button1.BorderRadius = 6;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(0)))), ((int)(((byte)(179)))));
            this.guna2Button1.Font = new System.Drawing.Font("Dubai", 14.25F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.Location = new System.Drawing.Point(632, 10);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(38, 31);
            this.guna2Button1.TabIndex = 53;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // ValidateRecoveryEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(682, 482);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.guna2VSeparator1);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.txtFieldRecoveryKey);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFieldPin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.lblAlert);
            this.Controls.Add(this.txtFieldEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ValidateRecoveryEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password-Recovery";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAlert;
        public Guna.UI2.WinForms.Guna2TextBox txtFieldEmail;
        public Guna.UI2.WinForms.Guna2Button guna2Button2;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtFieldPin;
        public Guna.UI2.WinForms.Guna2TextBox txtFieldRecoveryKey;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2VSeparator guna2VSeparator1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        public Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}