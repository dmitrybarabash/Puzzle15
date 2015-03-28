using System;
using NUnit.Framework;
using Puzzle15.DomainModel;

namespace Puzzle15.Tests
{
    [TestFixture]
    class ScoreTests
    {
        [Test]
        public void CompareTo_EqualObject_Returns0()
        {
            var score = new Score() { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
            var anotherScore = new Score() { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
            const int expected = 0;

            var actual = score.CompareTo(anotherScore);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CompareTo_ObjectWithGreaterMoves_ReturnsMinus1()
        {
            var score = new Score() { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
            var anotherScore = new Score() { Name = "Dmitrik", Moves = 200, Timer = new TimeSpan(0, 0, 1, 30) };
            const int expected = -1;

            var actual = score.CompareTo(anotherScore);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CompareTo_ObjectWithEqualMovesAndGreaterTimer_ReturnsMinus1()
        {
            var score = new Score() { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
            var anotherScore = new Score() { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 3, 00) };
            const int expected = -1;

            var actual = score.CompareTo(anotherScore);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CompareTo_ObjectWithLessMoves_Returns1()
        {
            var score = new Score() { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
            var anotherScore = new Score() { Name = "Dmitrik", Moves = 50, Timer = new TimeSpan(0, 0, 1, 30) };
            const int expected = 1;

            var actual = score.CompareTo(anotherScore);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CompareTo_ObjectWithEqualMovesAndLessTimer_ReturnsMinus1()
        {
            var score = new Score() { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 1, 30) };
            var anotherScore = new Score() { Name = "Dmitrik", Moves = 100, Timer = new TimeSpan(0, 0, 0, 45) };
            const int expected = 1;

            var actual = score.CompareTo(anotherScore);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
