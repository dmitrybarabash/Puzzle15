using System;
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
    public partial class BestScoredPlayerNameForm : Form
    {
        public BestScoredPlayerNameForm()
        {
            InitializeComponent();
        }

        public string PlayerName { get { return nameTextBox.Text.Trim(); } }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            buttonOk.Enabled = PlayerName.Length > 0;
        }
    }
}
