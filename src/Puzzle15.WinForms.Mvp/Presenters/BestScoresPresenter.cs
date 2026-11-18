using System.Windows.Forms;
using Puzzle15.Common;
using Puzzle15.Common.DomainModel;
using Puzzle15.WinForms.Mvp.Views;

namespace Puzzle15.WinForms.Mvp.Presenters;

public class BestScoresPresenter : BasePresenter<IBestScoresView>
{
    private const int NameColumn = 1;
    private const int MovesColumn = 2;
    private const int TimerColumn = 3;

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

        foreach (Label label in View.Labels)
        {
            TableLayoutPanelCellPosition position = View.Labels.Container.GetCellPosition(label);
            if (position.Row >= Model.BestScores.Count)
                continue;

            Score score = Model.BestScores[position.Row];
            switch (position.Column)
            {
                case NameColumn:
                    label.Text = score.Name;
                    break;
                case MovesColumn:
                    label.Text = Utils.FormatMoves(score.Moves);
                    break;
                case TimerColumn:
                    label.Text = Utils.FormatElapsedTime(score.Timer);
                    break;
            }
        }
    }
}
