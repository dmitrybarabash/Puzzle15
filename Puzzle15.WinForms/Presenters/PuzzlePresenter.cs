using System;
using System.Windows.Forms;
using Puzzle15.Common;
using Puzzle15.DomainModel;
using Puzzle15.Views;

namespace Puzzle15.Presenters
{
    public class PuzzlePresenter : BasePresenter<IPuzzleView>
    {
        private IPuzzleDomainModel Model { get; set; }

        public PuzzlePresenter(IPuzzleDomainModel domainModel, IPuzzleView puzzleView)
        {
            // Сохраняем внедряемые ссылки на модель и представление
            Model = domainModel;
            View = puzzleView;
            // Подписываемся на события представления
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
                uint cellValue = Model.Puzzle[(number - 1) / Model.Puzzle.FieldSideSize, (number - 1) % Model.Puzzle.FieldSideSize];
                button.Text = cellValue.ToString();
                button.Visible = cellValue != Model.Puzzle.EmptyCellValue;
            }
        }

        private void OnNewGame(object sender, EventArgs e)
        {
            Model.Puzzle.Start();
            UpdateButtons(true);
            View.StartTimer();
            View.UpdateGameLabels(true);
        }

        private void OnTimer(object sender, EventArgs e)
        {
            View.LabelTimer = (DateTime.Now - Model.Puzzle.StartTime).ToString(@"hh\:mm\:ss");
        }

        private void OnMove(object sender, EventArgs e)
        {
            uint clickedNumber = uint.Parse((sender as Button).Name.Remove(0, 10));
            uint y = (clickedNumber - 1) / Model.Puzzle.FieldSideSize;
            uint x = (clickedNumber - 1) % Model.Puzzle.FieldSideSize;
            if (Model.Puzzle.IsMoveable(y, x))
            {
                Model.Puzzle.Move(y, x);
                UpdateButtons(true);
                View.LabelMoves = Model.Puzzle.MovesCounter.ToString();

                if (Model.Puzzle.IsDone())
                {
                    View.StopTimer();
                    var score = new Score
                    {
                        Moves = Model.Puzzle.MovesCounter,
                        Timer = DateTime.Now - Model.Puzzle.StartTime
                    };

                    MessageBox.Show("Вы выиграли!\n\nВы сделали " + Model.Puzzle.MovesCounter + " " +
                        Utils.GetMovesWord(Model.Puzzle.MovesCounter) + " за " + View.LabelTimer + "!",
                        "Молодец!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        Model.BestScoresStorage.Load(Model.BestScores);
                        if (Model.BestScores.CanBeAdded(score))
                        {
                            var bestScoredPlayerNameForm = new BestScoredPlayerNameForm();
                            if (bestScoredPlayerNameForm.ShowDialog() == DialogResult.OK)
                            {
                                score.Name = bestScoredPlayerNameForm.PlayerName;
                                Model.BestScores.Add(score);
                                Model.BestScoresStorage.Save(Model.BestScores);
                            }
                        }
                    }
                    catch
                    {
                        // Ничего не делаем, пользователю ничего не говорим.
                        // Не получилось прочитать/записать файл с рекордами — окей, просто пропускаем эту часть.
                    }

                    Model.Puzzle.Init();
                    UpdateButtons(false);
                    View.StopTimer();
                    View.UpdateGameLabels(false);
                }
            }
        }

        private void OnBestScores(object sender, EventArgs e)
        {
            var bestScoresPresenter = new BestScoresPresenter(Model, new BestScoresForm());
            ((Form)bestScoresPresenter.View).ShowDialog();
        }
    }
}
