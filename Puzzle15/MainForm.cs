using System;
using System.Windows.Forms;

namespace Puzzle15
{
    public partial class MainForm : Form
    {
        private Puzzle puzzle = new Puzzle();
        private DateTime gameStartTime;
        private uint movesCounter;

        public MainForm()
        {
            InitializeComponent();
        }

        private void UpdateButtons(bool active)
        {
            foreach (var control in tableLayoutPanelCellButtons.Controls)
            {
                var button = control as Button;
                button.Enabled = active;
                int number = int.Parse(button.Name.Remove(0, 10));
                int cellValue = puzzle.Cells[(number - 1) / 4, (number - 1) % 4];
                button.Text = cellValue != puzzle.EmptyCellValue ? cellValue.ToString() : string.Empty;
                button.Visible = cellValue != puzzle.EmptyCellValue;
            }
        }

        private void UpdateGameState(bool active)
        {
            if (active)
            {
                gameStartTime = DateTime.Now;
                timerGame.Enabled = true;
                movesCounter = 0;
            }

            labelTime.Enabled = active;
            labelTime.Text = "00:00:00";
            labelMoves.Text = "0";
            labelMoves.Enabled = active;
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            puzzle.Start();
            UpdateButtons(true);
            UpdateGameState(true);
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonCell_Click(object sender, EventArgs e)
        {
            int clickedNumber = int.Parse((sender as Button).Name.Remove(0, 10));
            int y = (clickedNumber - 1) / 4;
            int x = (clickedNumber - 1) % 4;
            if (puzzle.IsMoveable(y, x))
            {
                puzzle.Move(y, x);
                UpdateButtons(true);
                labelMoves.Text = (++movesCounter).ToString();

                if (puzzle.IsDone())
                {
                    timerGame.Enabled = false;
                    MessageBox.Show("You won!\n\nYou've made " + movesCounter + " moves for " + labelTime.Text + "!",
                        "Great work!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    puzzle.Init();
                    UpdateButtons(false);
                    UpdateGameState(false);
                }
            }
        }

        private void timerGame_Tick(object sender, EventArgs e)
        {
            labelTime.Text = (DateTime.Now - gameStartTime).ToString(@"hh\:mm\:ss");
        }
    }
}
