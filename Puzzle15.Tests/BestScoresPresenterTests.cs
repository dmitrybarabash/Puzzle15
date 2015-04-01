using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Puzzle15.Common;
using Puzzle15.DomainModel;
using Puzzle15.Presenters;
using Puzzle15.Views;

namespace Puzzle15.Tests
{
    [TestFixture]
    class BestScoresPresenterTests
    {
        [Test]
        public void LoadAndShowBestScores()
        {
            var bestScores = new BestScores();
            bestScores.Add(new Score() { Name = "Aaaaaaaaaa", Moves = 92, Timer = new TimeSpan(0, 0, 11, 25) });
            bestScores.Add(new Score() { Name = "Bbbbbbbbb", Moves = 102, Timer = new TimeSpan(0, 0, 12, 25) });
            bestScores.Add(new Score() { Name = "Cccccc", Moves = 103, Timer = new TimeSpan(0, 0, 13, 25) });
            bestScores.Add(new Score() { Name = "Dmitrik", Moves = 124, Timer = new TimeSpan(0, 0, 14, 25) });
            bestScores.Add(new Score() { Name = "Eeeeee", Moves = 135, Timer = new TimeSpan(0, 0, 15, 25) });
            bestScores.Add(new Score() { Name = "Ffffffffffff", Moves = 146, Timer = new TimeSpan(0, 0, 16, 25) });
            bestScores.Add(new Score() { Name = "Gggg", Moves = 147, Timer = new TimeSpan(0, 1, 17, 25) });
            bestScores.Add(new Score() { Name = "Hhhhhhh", Moves = 158, Timer = new TimeSpan(0, 1, 18, 25) });
            bestScores.Add(new Score() { Name = "Iiiiiiii", Moves = 159, Timer = new TimeSpan(0, 1, 19, 25) });
            bestScores.Add(new Score() { Name = "Jjjjjjj", Moves = 200, Timer = new TimeSpan(0, 1, 20, 25) });
            new BestScoresStorage(Utils.BestScoresStorageFileName).Save(bestScores);

            var bestScoresModel = new BestScores();
            var bestScoresView = new BestScoresForm();
            var bestScoresPresenter = new BestScoresPresenter(bestScoresModel, bestScoresView);

            // Способ 1
            var thread = new Thread(() => { bestScoresView.ShowDialog(); }) { IsBackground = true };
            thread.Start();
            // Способ 2
            //Task.Run(() => { bestScoresView.ShowDialog(); });

            for (int i = 0; i < bestScoresModel.Scores.Count; i++)
            {
                string name = bestScoresModel.Scores[i].Name;
                string moves = bestScoresModel.Scores[i].Moves + " " + Utils.GetMovesWord(bestScoresModel.Scores[i].Moves);
                string timer = bestScoresModel.Scores[i].Timer.ToString(@"hh\:mm\:ss");

                var labelNames = bestScoresPresenter.View.Labels.Find("nameLabel" + (i + 1).ToString(), false);
                var labelMoves = bestScoresPresenter.View.Labels.Find("movesLabel" + (i + 1).ToString(), false);
                var labelTimers = bestScoresPresenter.View.Labels.Find("timerLabel" + (i + 1).ToString(), false);

                if (name != labelNames[0].Text || moves != labelMoves[0].Text || timer != labelTimers[0].Text)
                    Assert.Fail();
            }
            Assert.Pass();
        }
    }
}
