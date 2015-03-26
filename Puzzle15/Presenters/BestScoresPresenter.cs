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
        }
    }
}