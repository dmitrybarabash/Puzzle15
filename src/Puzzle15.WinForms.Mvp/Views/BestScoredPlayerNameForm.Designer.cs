namespace Puzzle15.WinForms.Mvp.Views
{
    partial class BestScoredPlayerNameForm
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
            buttonOk = new System.Windows.Forms.Button();
            buttonCancel = new System.Windows.Forms.Button();
            nameGroupBox = new System.Windows.Forms.GroupBox();
            nameTextBox = new System.Windows.Forms.TextBox();
            nameLabel = new System.Windows.Forms.Label();
            infoLabel = new System.Windows.Forms.Label();
            nameGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // buttonOk
            // 
            buttonOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            buttonOk.Enabled = false;
            buttonOk.Location = new System.Drawing.Point(159, 165);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new System.Drawing.Size(120, 36);
            buttonOk.TabIndex = 1;
            buttonOk.Text = "OK";
            buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            buttonCancel.Location = new System.Drawing.Point(285, 165);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(120, 36);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // nameGroupBox
            // 
            nameGroupBox.Controls.Add(nameTextBox);
            nameGroupBox.Controls.Add(nameLabel);
            nameGroupBox.Controls.Add(infoLabel);
            nameGroupBox.Location = new System.Drawing.Point(23, 12);
            nameGroupBox.Name = "nameGroupBox";
            nameGroupBox.Size = new System.Drawing.Size(382, 134);
            nameGroupBox.TabIndex = 2;
            nameGroupBox.TabStop = false;
            nameGroupBox.Text = "Имя:";
            // 
            // nameTextBox
            // 
            nameTextBox.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            nameTextBox.Location = new System.Drawing.Point(113, 84);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new System.Drawing.Size(244, 24);
            nameTextBox.TabIndex = 0;
            nameTextBox.TextChanged += nameTextBox_TextChanged;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(22, 87);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(73, 17);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Ваше имя:";
            // 
            // infoLabel
            // 
            infoLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            infoLabel.Location = new System.Drawing.Point(22, 33);
            infoLabel.Name = "infoLabel";
            infoLabel.Size = new System.Drawing.Size(335, 48);
            infoLabel.TabIndex = 0;
            infoLabel.Text = "Похоже, что ваш результат попал в десятку лучших. Это надо увековечить!";
            // 
            // BestScoredPlayerNameForm
            // 
            AcceptButton = buttonOk;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new System.Drawing.Size(429, 224);
            Controls.Add(nameGroupBox);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOk);
            Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BestScoredPlayerNameForm";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Имя";
            nameGroupBox.ResumeLayout(false);
            nameGroupBox.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox nameGroupBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label infoLabel;
    }
}