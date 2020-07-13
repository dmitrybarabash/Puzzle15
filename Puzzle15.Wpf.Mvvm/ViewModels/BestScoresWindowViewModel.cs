using Puzzle15.Common;
using Puzzle15.DomainModel;

namespace Puzzle15.Wpf.Mvvm.ViewModels
{
    public class BestScoresWindowViewModel : BaseViewModel
    {
        private IPuzzleDomainModel Model => (System.Windows.Application.Current as App).Model;

        public BestScoresWindowViewModel()
        {
            // Загружаем лучшие результаты из файла
            try
            {
                Model.BestScoresStorage.Load(Model.BestScores);
            }
            catch
            {
                // Ничего не делаем, пользователю ничего не говорим.
                // Не получилось прочитать файл с рекордами — ок, просто пропускаем эту часть.
                return;
            }
        }

        private string GetBestScoreName(int orderNumber) =>
            Model.BestScores.Count >= orderNumber ? Model.BestScores[orderNumber - 1].Name : "<best player>";

        public string BestScoreName1 => GetBestScoreName(1);
        public string BestScoreName2 => GetBestScoreName(2);
        public string BestScoreName3 => GetBestScoreName(3);
        public string BestScoreName4 => GetBestScoreName(4);
        public string BestScoreName5 => GetBestScoreName(5);
        public string BestScoreName6 => GetBestScoreName(6);
        public string BestScoreName7 => GetBestScoreName(7);
        public string BestScoreName8 => GetBestScoreName(8);
        public string BestScoreName9 => GetBestScoreName(9);
        public string BestScoreName10 => GetBestScoreName(10);

        private string GetBestScoreMoves(int orderNumber) =>
            Model.BestScores.Count >= orderNumber
                ? $"{Model.BestScores[orderNumber - 1].Moves} {Utils.GetMovesWord(Model.BestScores.Scores[orderNumber - 1].Moves)}"
                : "0 ходов";

        public string BestScoreMoves1 => GetBestScoreMoves(1);
        public string BestScoreMoves2 => GetBestScoreMoves(2);
        public string BestScoreMoves3 => GetBestScoreMoves(3);
        public string BestScoreMoves4 => GetBestScoreMoves(4);
        public string BestScoreMoves5 => GetBestScoreMoves(5);
        public string BestScoreMoves6 => GetBestScoreMoves(6);
        public string BestScoreMoves7 => GetBestScoreMoves(7);
        public string BestScoreMoves8 => GetBestScoreMoves(8);
        public string BestScoreMoves9 => GetBestScoreMoves(9);
        public string BestScoreMoves10 => GetBestScoreMoves(10);

        private string GetBestScoreTimer(int orderNumber) =>
            Model.BestScores.Count >= orderNumber ? Model.BestScores[orderNumber - 1].Timer.ToString(@"hh\:mm\:ss") : "00:00:00";

        public string BestScoreTimer1 => GetBestScoreTimer(1);
        public string BestScoreTimer2 => GetBestScoreTimer(2);
        public string BestScoreTimer3 => GetBestScoreTimer(3);
        public string BestScoreTimer4 => GetBestScoreTimer(4);
        public string BestScoreTimer5 => GetBestScoreTimer(5);
        public string BestScoreTimer6 => GetBestScoreTimer(6);
        public string BestScoreTimer7 => GetBestScoreTimer(7);
        public string BestScoreTimer8 => GetBestScoreTimer(8);
        public string BestScoreTimer9 => GetBestScoreTimer(9);
        public string BestScoreTimer10 => GetBestScoreTimer(10);
    }
}
