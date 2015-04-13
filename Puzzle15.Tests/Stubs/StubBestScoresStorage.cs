using System;
using System.Collections.Generic;
using Puzzle15.DomainModel;

namespace Puzzle15.Tests.Stubs
{
    public class StubBestScoresStorage : IBestScoresStorage
    {
        private readonly List<Score> scores;

        public StubBestScoresStorage(string fileName)
        {
            FileName = fileName;
            scores = new List<Score>()
            {
                new Score() { Name = "Aaaaaaaaaa", Moves = 92, Timer = new TimeSpan(0, 0, 11, 25) },
                new Score() { Name = "Bbbbbbbbb", Moves = 102, Timer = new TimeSpan(0, 0, 12, 25) },
                new Score() { Name = "Cccccc", Moves = 103, Timer = new TimeSpan(0, 0, 13, 25) },
                new Score() { Name = "Dmitrik", Moves = 124, Timer = new TimeSpan(0, 0, 14, 25) },
                new Score() { Name = "Eeeeee", Moves = 135, Timer = new TimeSpan(0, 0, 15, 25) },
                new Score() { Name = "Ffffffffffff", Moves = 146, Timer = new TimeSpan(0, 0, 16, 25) },
                new Score() { Name = "Gggg", Moves = 147, Timer = new TimeSpan(0, 1, 17, 25) },
                new Score() { Name = "Hhhhhhh", Moves = 158, Timer = new TimeSpan(0, 1, 18, 25) },
                new Score() { Name = "Iiiiiiii", Moves = 159, Timer = new TimeSpan(0, 1, 19, 25) },
                new Score() { Name = "Jjjjjjj", Moves = 200, Timer = new TimeSpan(0, 1, 20, 25) }
            };
        }

        #region IBestScoresStorage implementation

        public string FileName { get; set; }

        public void Save(IBestScores bestScores)
        {
            scores.Clear();
            scores.AddRange(bestScores.Scores);
        }

        public void Load(IBestScores bestScores)
        {
            bestScores.Scores.Clear();
            bestScores.Scores.AddRange(scores);
        }

        #endregion
    }
}