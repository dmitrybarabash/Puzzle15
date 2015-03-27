using System;
using System.Windows.Forms;

namespace Puzzle15.Views
{
    public partial class PuzzleForm : Form, IPuzzleView
    {
        public PuzzleForm()
        {
            InitializeComponent();
            UpdateGameLabels(false);
        }

        #region IPuzzleView Implementation

        public string LabelTimer
        {
            get { return labelTimer.Text; }
            set { labelTimer.Text = value; }
        }

        public string LabelMoves
        {
            get { return labelMoves.Text; }
            set { labelMoves.Text = value; }
        }

        public TableLayoutControlCollection Buttons
        {
            get { return tableLayoutPanelCellButtons.Controls; }
        }

        public event EventHandler NewGame;

        public event EventHandler Timer;

        public new event EventHandler Move;

        public event EventHandler BestScores;

        public void StartTimer()
        {
            timerGame.Enabled = true;
        }

        public void StopTimer()
        {
            timerGame.Enabled = false;
        }

        public void UpdateGameLabels(bool active)
        {
            labelTimer.Text = "00:00:00";
            labelTimer.Enabled = active;
            labelMoves.Text = "0";
            labelMoves.Enabled = active;
        }

        #endregion

        private void buttonCell_Click(object sender, EventArgs e)
        {
            if (Move != null)
                Move(sender, EventArgs.Empty);
        }

        private void timerGame_Tick(object sender, EventArgs e)
        {
            if (Timer != null)
                Timer(this, EventArgs.Empty);
        }

        private void NewGameHandler(object sender, EventArgs e)
        {
            if (NewGame != null)
                NewGame(this, EventArgs.Empty);
        }

        private void BestScoresHandler(object sender, EventArgs e)
        {
            if (BestScores != null)
                BestScores(this, EventArgs.Empty);
        }

        private void AboutHandler(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void ExitHandler(object sender, EventArgs e)
        {
            Close();
        }
    }
}
