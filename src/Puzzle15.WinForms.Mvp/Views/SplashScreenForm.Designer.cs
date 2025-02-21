namespace Puzzle15.WinForms.Mvp.Views
{
    partial class SplashScreenForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreenForm));
            closeTimer = new System.Windows.Forms.Timer(components);
            opacityTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // closeTimer
            // 
            closeTimer.Enabled = true;
            closeTimer.Interval = 5000;
            closeTimer.Tick += closeTimer_Tick;
            // 
            // opacityTimer
            // 
            opacityTimer.Enabled = true;
            opacityTimer.Interval = 1;
            opacityTimer.Tick += opacityTimer_Tick;
            // 
            // SplashScreenForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(200, 203);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "SplashScreenForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Пятнашки";
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer closeTimer;
        private System.Windows.Forms.Timer opacityTimer;
    }
}