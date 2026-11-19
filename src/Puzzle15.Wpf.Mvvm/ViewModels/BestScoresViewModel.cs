using System.Collections.Generic;
using Puzzle15.Common;
using Puzzle15.Common.DomainModel;
using Puzzle15.Wpf.Mvvm.Services;

namespace Puzzle15.Wpf.Mvvm.ViewModels;

public class BestScoresViewModel : BaseViewModel
{
    public BestScoresViewModel(IPuzzleDomainModel model, IDialogService dialogService)
    {
        // Загружаем лучшие результаты из файла. Если файл не прочитался, в памяти осталась прежняя таблица:
        // она может быть устаревшей или содержать несохранённый результат, поэтому её не показываем.
        int loadedCount = 0;
        if (model.TryLoadBestScores())
            loadedCount = model.BestScores.Count;
        else
            dialogService.ShowWarning(Utils.GetLoadBestScoresErrorMessage(model.BestScoresStorage.FileName));

        // Окно всегда показывает BestScores.MaxCount строк, свободные места занимает заглушка с нулевым результатом
        var rows = new List<BestScoreRowViewModel>();
        for (int i = 0; i < BestScores.MaxCount; i++)
        {
            Score score = i < loadedCount ? model.BestScores[i] : new Score { Name = "<best player>" };
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
