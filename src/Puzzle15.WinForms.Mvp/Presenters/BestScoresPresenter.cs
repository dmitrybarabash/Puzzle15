using Puzzle15.Common;
using Puzzle15.Common.DomainModel;
using Puzzle15.WinForms.Mvp.Views;

namespace Puzzle15.WinForms.Mvp.Presenters;

public class BestScoresPresenter : BasePresenter<IBestScoresView>
{
    private IPuzzleDomainModel Model { get; set; }

    public BestScoresPresenter(IPuzzleDomainModel domainModel, IBestScoresView bestScoresView)
    {
        // Сохраняем внедряемые ссылки на модель и представление
        Model = domainModel;
        View = bestScoresView;
        // Синхронизируем представление с текущим состоянием модели
        UpdateView();
    }

    private void UpdateView()
    {
        if (!Model.TryLoadBestScores())
            return;

        for (int index = 0; index < Model.BestScores.Count; index++)
        {
            Score score = Model.BestScores[index];
            View.ShowScore(index, score.Name, Utils.FormatMoves(score.Moves), Utils.FormatElapsedTime(score.Timer));
        }
    }
}
