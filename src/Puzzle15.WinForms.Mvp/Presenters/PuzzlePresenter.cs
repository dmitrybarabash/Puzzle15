using System;
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
        // Начинаем с собранного поля и показываем его в представлении
        Model.Puzzle.Init();
        UpdateField(false);
        ResetGameLabels(false);
    }

    private void UpdateField(bool enabled)
    {
        for (uint y = 0; y < Model.Puzzle.FieldSideSize; y++)
        {
            for (uint x = 0; x < Model.Puzzle.FieldSideSize; x++)
            {
                uint cellValue = Model.Puzzle[y, x];
                View.ShowCell(y, x, cellValue.ToString(), cellValue != Model.Puzzle.EmptyCellValue);
            }
        }
        View.SetFieldEnabled(enabled);
    }

    private void ResetGameLabels(bool enabled)
    {
        View.ShowElapsedTime(Utils.FormatElapsedTime(TimeSpan.Zero));
        View.ShowMoves("0");
        View.SetGameLabelsEnabled(enabled);
    }

    private void OnNewGame(object sender, EventArgs e)
    {
        Model.Puzzle.Start();
        UpdateField(true);
        ResetGameLabels(true);
        View.StartTimer();
    }

    private void OnTimer(object sender, EventArgs e)
    {
        View.ShowElapsedTime(Utils.FormatElapsedTime(Model.Puzzle.ElapsedTime));
    }

    private void OnCellClicked(object sender, CellClickedEventArgs e)
    {
        if (Model.TryMove(e.Y, e.X, out Score finishedGameScore))
        {
            UpdateField(true);
            View.ShowMoves(Model.Puzzle.MovesCounter.ToString());

            if (finishedGameScore is not null)
            {
                View.StopTimer();
                View.ShowElapsedTime(Utils.FormatElapsedTime(finishedGameScore.Timer));

                View.ShowWinMessage(Utils.GetWinMessage(finishedGameScore));
                Model.TryAddBestScore(finishedGameScore, View.AskPlayerName);

                Model.Puzzle.Init();
                UpdateField(false);
                ResetGameLabels(false);
            }
        }
    }

    private void OnBestScores(object sender, EventArgs e)
    {
        using IBestScoresView bestScoresView = View.CreateBestScoresView();
        new BestScoresPresenter(Model, bestScoresView);
        bestScoresView.ShowModal();
    }
}
