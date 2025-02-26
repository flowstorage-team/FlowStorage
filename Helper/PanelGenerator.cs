﻿using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FlowSERVER1.Helper {
    public class PanelGenerator {
        private string _todayDate { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");

        public void GeneratePanel(string parameterName, int length, List<(string,string, string)> filesInfo, List<EventHandler> onPressed, List<EventHandler> onPressedMoreButton, List<Image> pictureImage, bool isFromPs = false, bool moreButtonVisible = true, bool isFromDirectory = false) {

            for(int i=0; i<length; i++) {

                var panelPic_Q = new Guna2Panel() {
                    Name = $"{parameterName + i}",
                    Width = 200, 
                    Height = 222, 
                    BorderColor = GlobalStyle.BorderColor,
                    BorderThickness = 1,
                    BorderRadius = 8,
                    BackColor = GlobalStyle.TransparentColor,
                    Location = new Point(600, Globals.PANEL_GAP_TOP)
                };

                Globals.PANEL_GAP_TOP += Globals.PANEL_GAP_HEIGHT;

                if(!isFromDirectory) {
                    HomePage.instance.flwLayoutHome.Controls.Add(panelPic_Q);
                } else {
                    DirectoryForm.instance.flwLayoutDirectory.Controls.Add(panelPic_Q);
                }

                var panelF = (Guna2Panel)panelPic_Q;

                Label dateLab = new Label();
                panelF.Controls.Add(dateLab);
                dateLab.Name = $"LabG{i}";
                dateLab.BackColor = GlobalStyle.TransparentColor;
                dateLab.Font = GlobalStyle.DateLabelFont;
                dateLab.ForeColor = GlobalStyle.DarkGrayColor;
                dateLab.Visible = true;
                dateLab.Enabled = true;
                dateLab.Location = GlobalStyle.DateLabelLoc;
                dateLab.Text = filesInfo[i].Item2;

                Guna2CircleButton seperatorButton = new Guna2CircleButton();
                if(isFromPs) {
                    panelF.Controls.Add(seperatorButton);
                }
                seperatorButton.Location = GlobalStyle.PsSeperatorBut;
                seperatorButton.Size = GlobalStyle.PsSeperatorButSize;
                seperatorButton.FillColor = GlobalStyle.DarkGrayColor;
                seperatorButton.BringToFront();

                Label psButtonTag = new Label();
                if(isFromPs) {
                    panelF.Controls.Add(psButtonTag);
                }
                psButtonTag.Name = $"ButTag{i}";
                psButtonTag.Font = GlobalStyle.PsLabelTagFont;
                psButtonTag.BackColor = GlobalStyle.TransparentColor; 
                psButtonTag.ForeColor = isFromPs == true ? GlobalStyle.psBackgroundColorTag[filesInfo[i].Item3] : GlobalStyle.TransparentColor;
                psButtonTag.Visible = isFromPs == true;
                psButtonTag.Location = GlobalStyle.PsLabelTagLoc;
                psButtonTag.Text = isFromPs == true ? filesInfo[i].Item3 : String.Empty;
                psButtonTag.BringToFront();

                Label titleLab = new Label();
                panelF.Controls.Add(titleLab);
                titleLab.Name = $"titleImgL{i}"; 
                titleLab.Font = GlobalStyle.TitleLabelFont;
                titleLab.ForeColor = GlobalStyle.GainsboroColor;
                titleLab.Visible = true;
                titleLab.Enabled = true;
                titleLab.Location = GlobalStyle.TitleLabelLoc;
                titleLab.AutoEllipsis = true;
                titleLab.Width = 160; 
                titleLab.Height = 20; 
                titleLab.Text = filesInfo[i].Item1;

                Guna2PictureBox picMain_Q = new Guna2PictureBox();
                panelF.Controls.Add(picMain_Q);
                picMain_Q.Name = "ImgG" + i;
                picMain_Q.SizeMode = PictureBoxSizeMode.CenterImage;
                picMain_Q.BorderRadius = 8;
                picMain_Q.Width = 190; 
                picMain_Q.Height = 145; 
                picMain_Q.Visible = true;
                picMain_Q.Click += onPressed[i];

                picMain_Q.Anchor = AnchorStyles.None;

                int picMain_Q_x = (panelF.Width - picMain_Q.Width) / 2;

                picMain_Q.Location = new Point(picMain_Q_x, 10);

                picMain_Q.MouseHover += (_senderM, _ev) => {
                    panelF.ShadowDecoration.Enabled = true;
                    panelF.ShadowDecoration.BorderRadius = 8;
                };

                picMain_Q.MouseLeave += (_senderQ, _evQ) => {
                    panelF.ShadowDecoration.Enabled = false;
                };

                Guna2Button remBut = new Guna2Button();
                panelF.Controls.Add(remBut);
                remBut.Name = "Rem" + i;
                remBut.Width = 29;
                remBut.Height = 26;
                remBut.ImageOffset = GlobalStyle.GarbageOffset;
                remBut.FillColor = GlobalStyle.TransparentColor;
                remBut.BorderRadius = 6;
                remBut.BorderThickness = 1;
                remBut.BorderColor = GlobalStyle.TransparentColor;
                remBut.Image = GlobalStyle.GarbageImage; 
                remBut.Visible = moreButtonVisible;
                remBut.BringToFront();
                remBut.Location = GlobalStyle.GarbageButtonLoc; 
                remBut.Enabled = moreButtonVisible;

                remBut.Click += onPressedMoreButton[i];

                var img = ((Guna2PictureBox)panelF.Controls["ImgG" + i]);
                img.Image = pictureImage[i];

            };
        }

        /*private void GeneratePanelUpload(string fileName, string parameterName, int itemCurr, List<EventHandler> onPressed, List<EventHandler> onPressedMoreButton, List<Image> pictureImage, bool isFromPs = false, bool moreButtonVisible = true, bool isFromDirectory = false) {

            var mainPanel = new Guna2Panel() {
                Name = parameterName + itemCurr,
                Width = 200,
                Height = 222,
                BorderColor = GlobalStyle.BorderColor,
                BorderThickness = 1,
                BorderRadius = 8,
                BackColor = GlobalStyle.TransparentColor,
                Location = new Point(600, Globals.PANEL_GAP_TOP)
            };

            Globals.PANEL_GAP_TOP += Globals.PANEL_GAP_HEIGHT;
            if (!isFromDirectory) {
                HomePage.instance.flwLayoutHome.Controls.Add(mainPanel);
            }
            else {
                DirectoryForm.instance.flwLayoutDirectory.Controls.Add(mainPanel);
            }
            var mainPanelTxt = mainPanel;

            var textboxPic = new Guna2PictureBox();
            mainPanelTxt.Controls.Add(textboxPic);
            textboxPic.Name = "TxtBox" + itemCurr;
            textboxPic.BorderRadius = 8;
            textboxPic.Width = 190;
            textboxPic.Height = 145;
            textboxPic.SizeMode = PictureBoxSizeMode.CenterImage;
            textboxPic.Enabled = true;
            textboxPic.Visible = true;

            textboxPic.Anchor = AnchorStyles.None;

            int textboxPic_x = (mainPanelTxt.Width - textboxPic.Width) / 2;
            textboxPic.Location = new Point(textboxPic_x, 10);

            Label dateLabTxt = new Label();
            mainPanelTxt.Controls.Add(dateLabTxt);
            dateLabTxt.Name = "LabTxtUp" + itemCurr;
            dateLabTxt.Font = GlobalStyle.DateLabelFont;
            dateLabTxt.ForeColor = GlobalStyle.DarkGrayColor;
            dateLabTxt.Visible = true;
            dateLabTxt.Enabled = true;
            dateLabTxt.Location = GlobalStyle.DateLabelLoc;
            dateLabTxt.Text = _todayDate;

            Guna2CircleButton seperatorButton = new Guna2CircleButton();
            if (isFromPs) {
                panelF.Controls.Add(seperatorButton);
            }
            seperatorButton.Location = GlobalStyle.PsSeperatorBut;
            seperatorButton.Size = GlobalStyle.PsSeperatorButSize;
            seperatorButton.FillColor = GlobalStyle.DarkGrayColor;
            seperatorButton.BringToFront();

            Label psButtonTag = new Label();
            if (isFromPs) {
                panelF.Controls.Add(psButtonTag);
            }
            psButtonTag.Name = $"ButTag{i}";
            psButtonTag.Font = GlobalStyle.PsLabelTagFont;
            psButtonTag.BackColor = GlobalStyle.TransparentColor;
            psButtonTag.ForeColor = isFromPs == true ? GlobalStyle.psBackgroundColorTag[filesInfo[i].Item3] : GlobalStyle.TransparentColor;
            psButtonTag.Visible = isFromPs == true;
            psButtonTag.Location = GlobalStyle.PsLabelTagLoc;
            psButtonTag.Text = isFromPs == true ? filesInfo[i].Item3 : String.Empty;
            psButtonTag.BringToFront();

            Label titleLab = new Label();
            mainPanelTxt.Controls.Add(titleLab);
            titleLab.Name = "LabVidUp" + itemCurr;
            titleLab.Font = GlobalStyle.TitleLabelFont;
            titleLab.ForeColor = GlobalStyle.GainsboroColor;
            titleLab.Visible = true;
            titleLab.Enabled = true;
            titleLab.Location = GlobalStyle.TitleLabelLoc;
            titleLab.Width = 160;
            titleLab.Height = 20;
            titleLab.AutoEllipsis = true;
            titleLab.Text = fileName;

            Guna2Button remButTxt = new Guna2Button();
            mainPanelTxt.Controls.Add(remButTxt);
            remButTxt.Name = "RemTxtBut" + itemCurr;
            remButTxt.Width = 29;
            remButTxt.Height = 26;
            remButTxt.ImageOffset = GlobalStyle.GarbageOffset;
            remButTxt.FillColor = GlobalStyle.TransparentColor;
            remButTxt.BorderRadius = 6;
            remButTxt.BorderThickness = 1;
            remButTxt.BorderColor = GlobalStyle.TransparentColor;
            remButTxt.Image = GlobalStyle.GarbageImage;
            remButTxt.Visible = true;
            remButTxt.Location = GlobalStyle.GarbageButtonLoc;
            remButTxt.BringToFront();

            remButTxt.Click += (sender_tx, e_tx) => {
                lblFileNameOnPanel.Text = titleLab.Text;
                lblFileTableName.Text = tableName;
                lblFilePanelName.Text = mainPanelTxt.Name;
                pnlFileOptions.Visible = true;
            };

            textboxPic.MouseHover += (_senderM, _ev) => {
                mainPanel.ShadowDecoration.Enabled = true;
                mainPanel.ShadowDecoration.BorderRadius = 8;
            };

            textboxPic.MouseLeave += (_senderQ, _evQ) => {
                mainPanel.ShadowDecoration.Enabled = false;
            };
        }*/

    }
}
