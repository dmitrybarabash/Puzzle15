using System;
using NUnit.Framework;
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
    }
}