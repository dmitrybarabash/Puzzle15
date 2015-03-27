using System.Windows.Forms;
using Puzzle15.Common;
using Puzzle15.DomainModel;
using Puzzle15.Views;

namespace Puzzle15.Presenters
{
    public class BestScoresPresenter : BasePresenter<IBestScoresView>
    {
        private IBestScores Model { get; set; }

        public BestScoresPresenter(IBestScores bestScoresModel, IBestScoresView bestScoresView)
        {
            Model = bestScoresModel;
            View = bestScoresView;
            UpdateView();
        }

        private static string GetMovesWord(uint moves)
        {
            switch (moves % 10)
            {
                case 1:
                    return "ход";
                case 2:
                case 3:
                case 4:
                    return "хода";
                default:
                    return "ходов";
            }
        }

        private void UpdateView()
        {
            Model.Load();

            foreach (Label label in View.Labels)
            {
                if (label.Name.StartsWith("nameLabel"))
                {
                    int index = int.Parse(label.Name.Remove(0, 9)) - 1;
                    if (index < Model.Scores.Count)
                        label.Text = Model.Scores[index].Name;
                }
                if (label.Name.StartsWith("movesLabel"))
                {
                    int index = int.Parse(label.Name.Remove(0, 10)) - 1;
                    if (index < Model.Scores.Count)
                        label.Text = Model.Scores[index].Moves + " " + GetMovesWord(Model.Scores[index].Moves);
                }
                if (label.Name.StartsWith("timerLabel"))
                {
                    int index = int.Parse(label.Name.Remove(0, 10)) - 1;
                    if (index < Model.Scores.Count)
                        label.Text = Model.Scores[index].Timer.ToString(@"hh\:mm\:ss");
                }
            }
        }
    }
}