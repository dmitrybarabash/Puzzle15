﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle15.Views
{
    public partial class SplashScreenForm : Form
    {
        public SplashScreenForm()
        {
            InitializeComponent();
            ClientSize = new Size(BackgroundImage.Size.Width * 3 / 2, BackgroundImage.Size.Height * 3 / 2);
            Opacity = 0;
        }

        private void closeTimer_Tick(object sender, EventArgs e)
        {
            Close();
        }

        private void opacityTimer_Tick(object sender, EventArgs e)
        {
            if ((int)(Opacity += 0.005d) == 1)
                opacityTimer.Stop();
        }
    }
}
