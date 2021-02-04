using System.Threading;
using NUnit.Framework;
using Puzzle15.Common;
using Puzzle15.WinForms.Mvp.Presenters;
using Puzzle15.WinForms.Mvp.Views;
using Puzzle15.WinForms.Mvp.UnitTests.Stubs;

namespace Puzzle15.WinForms.Mvp.UnitTests.Presenters
{
    [TestFixture]
    class BestScoresPresenterTests
    {
        [Test]
        public void LoadAndShowBestScores()
        {
            var model = new StubPuzzleDomainModel();
            var view = new BestScoresForm();
            var presenter = new BestScoresPresenter(model, view);

            // Способ 1
            var thread = new Thread(() => { view.ShowDialog(); }) { IsBackground = true };
            thread.Start();
            // Способ 2
            //Task.Run(() => { view.ShowDialog(); });

            for (int i = 0; i < model.BestScores.Count; i++)
            {
                string name = model.BestScores[i].Name;
                string moves = model.BestScores[i].Moves + " " + Utils.GetMovesWord(model.BestScores[i].Moves);
                string timer = model.BestScores[i].Timer.ToString(@"hh\:mm\:ss");

                var labelNames = presenter.View.Labels.Find("nameLabel" + (i + 1), false);
                var labelMoves = presenter.View.Labels.Find("movesLabel" + (i + 1), false);
                var labelTimers = presenter.View.Labels.Find("timerLabel" + (i + 1), false);

                if (name != labelNames[0].Text || moves != labelMoves[0].Text || timer != labelTimers[0].Text)
                    Assert.Fail();
            }
            Assert.Pass();
        }
    }
}
