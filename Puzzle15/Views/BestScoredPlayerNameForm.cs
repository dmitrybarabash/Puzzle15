using System;
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
