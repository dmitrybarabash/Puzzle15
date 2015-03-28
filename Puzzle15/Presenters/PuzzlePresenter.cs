using System;
using System.Windows.Forms;
using Puzzle15.Common;
using Puzzle15.DomainModel;
using Puzzle15.Views;

namespace Puzzle15.Presenters
{
    public class PuzzlePresenter : BasePresenter<IPuzzleView>
    {
        private IPuzzle Model { get; set; }
        private IBestScores ModelScores { get; set; }

        public PuzzlePresenter(IPuzzle puzzleModel, IBestScores bestBestScoresModel, IPuzzleView puzzleView)
        {
            Model = puzzleModel;
            ModelScores = bestBestScoresModel;
            View = puzzleView;
            View.NewGame += OnNewGame;
            View.Timer += OnTimer;
            View.Move += OnMove;
            View.BestScores += OnBestScores;
        }

        private void UpdateButtons(bool active)
        {
            foreach (var control in View.Buttons)
            {
                var button = control as Button;
                button.Enabled = active;
                uint number = uint.Parse(button.Name.Remove(0, 10));
                uint cellValue = Model.Cells[(number - 1) / 4, (number - 1) % 4];
                button.Text = cellValue != Model.EmptyCellValue ? cellValue.ToString() : string.Empty;
                button.Visible = cellValue != Model.EmptyCellValue;
            }
        }

        private void OnNewGame(object sender, EventArgs e)
        {
            Model.Start();
            UpdateButtons(true);
            View.StartTimer();
            View.UpdateGameLabels(true);
        }

        private void OnTimer(object sender, EventArgs e)
        {
            View.LabelTimer = (DateTime.Now - Model.StartTime).ToString(@"hh\:mm\:ss");
        }

        private void OnMove(object sender, EventArgs e)
        {
            uint clickedNumber = uint.Parse((sender as Button).Name.Remove(0, 10));
            uint y = (clickedNumber - 1) / 4;
            uint x = (clickedNumber - 1) % 4;
            if (Model.IsMoveable(y, x))
            {
                Model.Move(y, x);
                UpdateButtons(true);
                View.LabelMoves = Model.MovesCounter.ToString();

                if (Model.IsDone())
                {
                    View.StopTimer();
                    var score = new Score() { Moves = Model.MovesCounter, Timer = DateTime.Now - Model.StartTime };

                    MessageBox.Show("Вы выиграли!\n\nВы сделали " + Model.MovesCounter + " " +
                        Utils.GetMovesWord(Model.MovesCounter) + " за " + View.LabelTimer + "!",
                        "Молодец!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ModelScores.Load();
                    if (ModelScores.CanBeAdded(score))
                    {
                        var bestScoredPlayerNameForm = new BestScoredPlayerNameForm();
                        if (bestScoredPlayerNameForm.ShowDialog() == DialogResult.OK)
                        {
                            score.Name = bestScoredPlayerNameForm.PlayerName;
                            ModelScores.Add(score);
                            ModelScores.Save();
                        }
                    }

                    Model.Init();
                    UpdateButtons(false);
                    View.StopTimer();
                    View.UpdateGameLabels(false);
                }
            }
        }
        private void OnBestScores(object sender, EventArgs e)
        {
            var bestScoresPresenter = new BestScoresPresenter(ModelScores, new BestScoresForm());
            ((Form)bestScoresPresenter.View).ShowDialog();
        }
    }
}
