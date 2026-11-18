using System;
using System.Windows.Forms;
using Puzzle15.Common;
using Puzzle15.Common.DomainModel;
using Puzzle15.WinForms.Mvp.Views;

namespace Puzzle15.WinForms.Mvp.Presenters;

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
        View.CellClicked += OnCellClicked;
        View.BestScores += OnBestScores;
    }

    private (uint y, uint x) GetCellPosition(Button button)
    {
        TableLayoutPanelCellPosition position = View.Buttons.Container.GetCellPosition(button);
        return ((uint)position.Row, (uint)position.Column);
    }

    private void UpdateButtons(bool active)
    {
        foreach (Button button in View.Buttons)
        {
            (uint y, uint x) = GetCellPosition(button);
            uint cellValue = Model.Puzzle[y, x];
            button.Enabled = active;
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
        View.LabelTimer = Utils.FormatElapsedTime(Model.Puzzle.ElapsedTime);
    }

    private void OnCellClicked(object sender, EventArgs e)
    {
        (uint y, uint x) = GetCellPosition((Button)sender);
        if (Model.TryMove(y, x, out Score finishedGameScore))
        {
            UpdateButtons(true);
            View.LabelMoves = Model.Puzzle.MovesCounter.ToString();

            if (finishedGameScore is not null)
            {
                View.StopTimer();
                View.LabelTimer = Utils.FormatElapsedTime(finishedGameScore.Timer);

                MessageBox.Show(Utils.GetWinMessage(finishedGameScore),
                    "Молодец!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Model.TryAddBestScore(finishedGameScore, () =>
                {
                    using var bestScoredPlayerNameForm = new BestScoredPlayerNameForm();
                    return bestScoredPlayerNameForm.ShowDialog() == DialogResult.OK ? bestScoredPlayerNameForm.PlayerName : null;
                });

                Model.Puzzle.Init();
                UpdateButtons(false);
                View.UpdateGameLabels(false);
            }
        }
    }

    private void OnBestScores(object sender, EventArgs e)
    {
        using var bestScoresForm = new BestScoresForm();
        new BestScoresPresenter(Model, bestScoresForm);
        bestScoresForm.ShowDialog();
    }
}
