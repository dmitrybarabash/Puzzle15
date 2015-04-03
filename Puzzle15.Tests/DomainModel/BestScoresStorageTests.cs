using System;
using System.IO;
using NUnit.Framework;
using Puzzle15.Common;
using Puzzle15.DomainModel;

namespace Puzzle15.Tests.DomainModel
{
    [TestFixture]
    public class BestScoresStorageTests
    {
        [Test]
        public void Save_10BestScores_Saves()
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
            bool actual = File.Exists(Utils.BestScoresStorageFileName);

            Assert.That(actual, Is.True);
        }

        [Test]
        public void Load_10BestScores_Loads()
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

            var bestScoresStorage = new BestScoresStorage(Utils.BestScoresStorageFileName);
            bestScoresStorage.Save(bestScores);

            var loadBestScores = new BestScores();
            bestScoresStorage.Load(loadBestScores);

            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // Вариант на случай отсутствия перегруженного метода Score.Equals
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //if (bestScores.Count != loadBestScores.Count)
            //    Assert.Fail();
            //bool equals = true;
            //for (int i = 0; i < bestScores.Count; i++)
            //{
            //    if (bestScores[i].Name != loadBestScores[i].Name ||
            //        bestScores[i].Moves != loadBestScores[i].Moves ||
            //        bestScores[i].Timer != loadBestScores[i].Timer)
            //    {
            //        equals = false;
            //        break;
            //    }
            //}
            //Assert.That(equals, Is.True);

            Assert.That(loadBestScores.Scores, Is.EqualTo(bestScores.Scores));
        }
    }
}