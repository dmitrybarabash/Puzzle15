namespace Puzzle15.Views
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreenForm));
            this.closeTimer = new System.Windows.Forms.Timer(this.components);
            this.opacityTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // closeTimer
            // 
            this.closeTimer.Enabled = true;
            this.closeTimer.Interval = 5000;
            this.closeTimer.Tick += new System.EventHandler(this.closeTimer_Tick);
            // 
            // opacityTimer
            // 
            this.opacityTimer.Enabled = true;
            this.opacityTimer.Interval = 1;
            this.opacityTimer.Tick += new System.EventHandler(this.opacityTimer_Tick);
            // 
            // SplashScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Puzzle15.Properties.Resources.Puzzle15;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(204, 207);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplashScreenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пятнашки";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer closeTimer;
        private System.Windows.Forms.Timer opacityTimer;
    }
}