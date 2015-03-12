using System;
using System.Windows.Forms;

namespace Puzzle15
{
    public class PuzzlePresenter
    {
        private readonly Puzzle model = new Puzzle();
        private readonly IPuzzleView view;

        public PuzzlePresenter(IPuzzleView puzzleView)
        {
            view = puzzleView;
            view.NewGame += OnNewGame;
            view.Timer += OnTimer;
            view.Move += OnMove;
        }

        private void UpdateButtons(bool active)
        {
            foreach (var control in view.Buttons)
            {
                var button = control as Button;
                button.Enabled = active;
                uint number = uint.Parse(button.Name.Remove(0, 10));
                uint cellValue = model.Cells[(number - 1) / 4, (number - 1) % 4];
                button.Text = cellValue != model.EmptyCellValue ? cellValue.ToString() : string.Empty;
                button.Visible = cellValue != model.EmptyCellValue;
            }
        }

        private void OnNewGame(object sender, EventArgs e)
        {
            model.Start();
            UpdateButtons(true);
            view.StartTimer();
            view.UpdateGameLabels(true);
        }

        private void OnTimer(object sender, EventArgs e)
        {
            view.LabelTimer = (DateTime.Now - model.StartTime).ToString(@"hh\:mm\:ss");
        }

        private void OnMove(object sender, EventArgs e)
        {
            uint clickedNumber = uint.Parse((sender as Button).Name.Remove(0, 10));
            uint y = (clickedNumber - 1) / 4;
            uint x = (clickedNumber - 1) % 4;
            if (model.IsMoveable(y, x))
            {
                model.Move(y, x);
                UpdateButtons(true);
                view.LabelMoves = model.MovesCounter.ToString();

                if (model.IsDone())
                {
                    view.StopTimer();
                    MessageBox.Show("You won!\n\nYou've made " + model.MovesCounter + " moves for " + view.LabelTimer + "!",
                        "Great work!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    model.Init();
                    UpdateButtons(false);
                    view.StopTimer();
                    view.UpdateGameLabels(false);
                }
            }
        }
    }
}
