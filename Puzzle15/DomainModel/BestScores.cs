using System.Collections.Generic;

namespace Puzzle15.DomainModel
{
    public class BestScores : IBestScores
    {
        public const int MaxCount = 10;

        #region IBestScores implementation

        private List<Score> scores = new List<Score>();
        public List<Score> Scores { get { return scores; } }

        public int Count { get { return Scores.Count; } }

        public Score this[int index]
        {
            get { return Scores[index]; }
            set { Scores[index] = value; }
        }

        public bool CanBeAdded(Score score)
        {
            var tempScores = new List<Score>(Scores);
            tempScores.Add(score);
            tempScores.Sort();
            return !(tempScores.Count == MaxCount + 1 && tempScores[MaxCount] == score);
        }

        public void Add(Score score)
        {
            if (CanBeAdded(score))
            {
                Scores.Add(score);
                Scores.Sort();
                if (Scores.Count == MaxCount + 1)
                    Scores.RemoveAt(MaxCount);
            }
        }

        #endregion
    }
}