namespace Puzzle15.WinForms.Mvp.Views
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            buttonOk = new System.Windows.Forms.Button();
            groupBox = new System.Windows.Forms.GroupBox();
            linkLabelWebsite = new System.Windows.Forms.LinkLabel();
            linkLabelEmail = new System.Windows.Forms.LinkLabel();
            pictureBoxLogo = new System.Windows.Forms.PictureBox();
            labelCopyright = new System.Windows.Forms.Label();
            labelProductName = new System.Windows.Forms.Label();
            groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // buttonOk
            // 
            buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            buttonOk.Location = new System.Drawing.Point(232, 234);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new System.Drawing.Size(112, 36);
            buttonOk.TabIndex = 0;
            buttonOk.Text = "OK";
            buttonOk.UseVisualStyleBackColor = true;
            // 
            // groupBox
            // 
            groupBox.Controls.Add(linkLabelWebsite);
            groupBox.Controls.Add(linkLabelEmail);
            groupBox.Controls.Add(pictureBoxLogo);
            groupBox.Controls.Add(labelCopyright);
            groupBox.Controls.Add(labelProductName);
            groupBox.Location = new System.Drawing.Point(24, 21);
            groupBox.Name = "groupBox";
            groupBox.Size = new System.Drawing.Size(528, 196);
            groupBox.TabIndex = 1;
            groupBox.TabStop = false;
            // 
            // linkLabelWebsite
            // 
            linkLabelWebsite.AutoSize = true;
            linkLabelWebsite.Location = new System.Drawing.Point(189, 118);
            linkLabelWebsite.Name = "linkLabelWebsite";
            linkLabelWebsite.Size = new System.Drawing.Size(176, 17);
            linkLabelWebsite.TabIndex = 3;
            linkLabelWebsite.TabStop = true;
            linkLabelWebsite.Text = "https://www.barabash.com";
            linkLabelWebsite.LinkClicked += linkLabelWebsite_LinkClicked;
            // 
            // linkLabelEmail
            // 
            linkLabelEmail.AutoSize = true;
            linkLabelEmail.Location = new System.Drawing.Point(189, 153);
            linkLabelEmail.Name = "linkLabelEmail";
            linkLabelEmail.Size = new System.Drawing.Size(148, 17);
            linkLabelEmail.TabIndex = 3;
            linkLabelEmail.TabStop = true;
            linkLabelEmail.Text = "dmitry@barabash.com";
            linkLabelEmail.LinkClicked += linkLabelEmail_LinkClicked;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image = (System.Drawing.Image)resources.GetObject("pictureBoxLogo.Image");
            pictureBoxLogo.Location = new System.Drawing.Point(24, 31);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new System.Drawing.Size(139, 140);
            pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBoxLogo.TabIndex = 2;
            pictureBoxLogo.TabStop = false;
            // 
            // labelCopyright
            // 
            labelCopyright.AutoSize = true;
            labelCopyright.Location = new System.Drawing.Point(188, 82);
            labelCopyright.Name = "labelCopyright";
            labelCopyright.Size = new System.Drawing.Size(289, 17);
            labelCopyright.TabIndex = 1;
            labelCopyright.Text = "Copyright (c) 2015-2025, Дмитрий Барабаш";
            // 
            // labelProductName
            // 
            labelProductName.AutoSize = true;
            labelProductName.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            labelProductName.Location = new System.Drawing.Point(183, 22);
            labelProductName.Name = "labelProductName";
            labelProductName.Size = new System.Drawing.Size(246, 46);
            labelProductName.TabIndex = 0;
            labelProductName.Text = "Пятнашки 1.4";
            // 
            // AboutForm
            // 
            AcceptButton = buttonOk;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = buttonOk;
            ClientSize = new System.Drawing.Size(577, 286);
            Controls.Add(groupBox);
            Controls.Add(buttonOk);
            Font = new System.Drawing.Font("Tahoma", 8F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutForm";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "О программе";
            groupBox.ResumeLayout(false);
            groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.LinkLabel linkLabelEmail;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.LinkLabel linkLabelWebsite;
    }
}