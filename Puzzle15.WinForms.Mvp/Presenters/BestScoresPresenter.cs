using System.Windows.Forms;
using Puzzle15.Common;
using Puzzle15.DomainModel;
using Puzzle15.WinForms.Mvp.Views;

namespace Puzzle15.WinForms.Mvp.Presenters
{
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
            try
            {
                Model.BestScoresStorage.Load(Model.BestScores);
            }
            catch
            {
                // Ничего не делаем, пользователю ничего не говорим.
                // Не получилось прочитать файл с рекордами — окей, просто пропускаем эту часть.
                return;
            }

            foreach (Label label in View.Labels)
            {
                if (label.Name.StartsWith("nameLabel"))
                {
                    int index = int.Parse(label.Name.Remove(0, 9)) - 1;
                    if (index < Model.BestScores.Count)
                        label.Text = Model.BestScores[index].Name;
                }
                if (label.Name.StartsWith("movesLabel"))
                {
                    int index = int.Parse(label.Name.Remove(0, 10)) - 1;
                    if (index < Model.BestScores.Count)
                        label.Text =
                            Model.BestScores[index].Moves + " " +
                            Utils.GetMovesWord(Model.BestScores.Scores[index].Moves);
                }
                if (label.Name.StartsWith("timerLabel"))
                {
                    int index = int.Parse(label.Name.Remove(0, 10)) - 1;
                    if (index < Model.BestScores.Count)
                        label.Text = Model.BestScores[index].Timer.ToString(@"hh\:mm\:ss");
                }
            }
        }
    }
}