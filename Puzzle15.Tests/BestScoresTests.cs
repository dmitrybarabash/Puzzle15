using System;
using System.IO;
using NUnit.Framework;
using Puzzle15.Common;
using Puzzle15.DomainModel;

namespace Puzzle15.Tests
{
    [TestFixture]
    public class BestScoresTests
    {
        [Test]
        public void CanBeAdded_OneOfTheBestScores_AddsScore()
        {
            // Best scores
            var bestScores = new BestScores();
            bestScores.Add(new Score() { Name = "A", Moves = 1, Timer = new TimeSpan(0, 0, 10, 25) });
            bestScores.Add(new Score() { Name = "A", Moves = 2, Timer = new TimeSpan(0, 0, 10, 25) });
            bestScores.Add(new Score() { Name = "A", Moves = 3, Timer = new TimeSpan(0, 0, 10, 25) });
            bestScores.Add(new Score() { Name = "A", Moves = 4, Timer = new TimeSpan(0, 0, 10, 25) });
            bestScores.Add(new Score() { Name = "A", Moves = 5, Timer = new TimeSpan(0, 0, 10, 25) });
            bestScores.Add(new Score() { Name = "A", Moves = 6, Timer = new TimeSpan(0, 0, 10, 25) });
            bestScores.Add(new Score() { Name = "A", Moves = 7, Timer = new TimeSpan(0, 0, 10, 25) });
            bestScores.Add(new Score() { Name = "A", Moves = 8, Timer = new TimeSpan(0, 0, 10, 25) });
            bestScores.Add(new Score() { Name = "A", Moves = 9, Timer = new TimeSpan(0, 0, 10, 25) });
            bestScores.Add(new Score() { Name = "A", Moves = 10, Timer = new TimeSpan(0, 0, 10, 25) });
            // New score
            var score = new Score() { Name = "Dmitrik", Moves = 5, Timer = new TimeSpan(0, 0, 10, 25) };

            bool actual = bestScores.CanBeAdded(score);

            Assert.That(actual, Is.True);
        }

        [Test]
        public void CanBeAdded_NotOneOfTheBestScores_DoesntAddScore()
        {
            // Best scores
            var bestScores = new BestScores();
            bestScores.Add(new Score() { Name = "A", Moves = 1, Timer = new TimeSpan(0, 0, 10, 25) });
            bestScores.Add(new Score() { Name = "A", Moves = 2, Timer = new TimeSpan(0, 0, 10, 25) });
            bestScores.Add(new Score() { Name = "A", Moves = 3, Timer = new TimeSpan(0, 0, 10, 25) });
            bestScores.Add(new Score() { Name = "A", Moves = 4, Timer = new TimeSpan(0, 0, 10, 25) });
            bestScores.Add(new Score() { Name = "A", Moves = 5, Timer = new TimeSpan(0, 0, 10, 25) });
            bestScores.Add(new Score() { Name = "A", Moves = 6, Timer = new TimeSpan(0, 0, 10, 25) });
            bestScores.Add(new Score() { Name = "A", Moves = 7, Timer = new TimeSpan(0, 0, 10, 25) });
            bestScores.Add(new Score() { Name = "A", Moves = 8, Timer = new TimeSpan(0, 0, 10, 25) });
            bestScores.Add(new Score() { Name = "A", Moves = 9, Timer = new TimeSpan(0, 0, 10, 25) });
            bestScores.Add(new Score() { Name = "A", Moves = 10, Timer = new TimeSpan(0, 0, 10, 25) });
            // New score
            var score = new Score() { Name = "Dmitrik", Moves = 11, Timer = new TimeSpan(0, 0, 10, 25) };

            bool actual = bestScores.CanBeAdded(score);

            Assert.That(actual, Is.False);
        }

        [TestCase(0, 1U, 0, Result = true)]
        [TestCase(1, 0U, 0, Result = true)]
        [TestCase(1, 1U, 0, Result = true)]
        [TestCase(1, 2U, 1, Result = true)]
        [TestCase(2, 1U, 0, Result = true)]
        [TestCase(2, 2U, 1, Result = true)]
        [TestCase(2, 3U, 2, Result = true)]
        [TestCase(9, 5U, 4, Result = true)]
        [TestCase(9, 9U, 8, Result = true)]
        [TestCase(9, 10U, 9, Result = true)]
        [TestCase(10, 5U, 4, Result = true)]
        [TestCase(10, 10U, 9, Result = true)]
        [TestCase(10, 11U, 9, Result = false)]
        public bool Add_ExistingScores_Adds(int existingScores, uint moves, int expectedIndex)
        {
            var bestScores = new BestScores();
            for (uint i = 0; i < existingScores; i++)
                bestScores.Add(new Score() { Name = i.ToString(), Moves = i + 1, Timer = new TimeSpan(0, 1, 2, 3) });
            var score = new Score() { Name = "Dmitrik", Moves = moves, Timer = new TimeSpan(0, 0, 1, 30) };

            bestScores.Add(score);

            return bestScores.Scores[expectedIndex] == score;
        }

        [Test]
        public void Save_Nothing_Saves()
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
    }
}