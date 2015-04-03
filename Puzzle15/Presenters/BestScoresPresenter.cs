using System.Windows.Forms;
using Puzzle15.Common;
using Puzzle15.DomainModel;
using Puzzle15.Views;

namespace Puzzle15.Presenters
{
    public class BestScoresPresenter : BasePresenter<IBestScoresView>
    {
        private IPuzzleDomainModel Model { get; set; }

        public BestScoresPresenter(IPuzzleDomainModel domainModel, IBestScoresView bestScoresView)
        {
            Model = domainModel;
            View = bestScoresView;
            UpdateView();
        }

        private void UpdateView()
        {
            Model.BestScoresStorage.Load(Model.BestScores);

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
                        label.Text = Model.BestScores[index].Moves + " " + Utils.GetMovesWord(Model.BestScores.Scores[index].Moves);
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