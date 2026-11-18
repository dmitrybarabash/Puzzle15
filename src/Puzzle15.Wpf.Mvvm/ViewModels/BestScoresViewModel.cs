using System.Collections.Generic;
using Puzzle15.Common;
using Puzzle15.Common.DomainModel;

namespace Puzzle15.Wpf.Mvvm.ViewModels;

public class BestScoresViewModel : BaseViewModel
{
    public BestScoresViewModel(IPuzzleDomainModel model)
    {
        // Загружаем лучшие результаты из файла
        model.TryLoadBestScores();

        // Окно всегда показывает BestScores.MaxCount строк, свободные места занимает заглушка с нулевым результатом
        var rows = new List<BestScoreRowViewModel>();
        for (int i = 0; i < BestScores.MaxCount; i++)
        {
            Score score = i < model.BestScores.Count ? model.BestScores[i] : new Score { Name = "<best player>" };
            rows.Add(new BestScoreRowViewModel(
                i + 1, score.Name, Utils.FormatMoves(score.Moves), Utils.FormatElapsedTime(score.Timer)));
        }
        Rows = rows;
    }


    #region Binding properties (свойства привязки)

    //
    // Свойство привязки строк таблицы рекордов
    //
    public IReadOnlyList<BestScoreRowViewModel> Rows { get; }

    #endregion
}
