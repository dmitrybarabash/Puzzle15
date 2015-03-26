using System.Collections;
using System.Collections.Generic;

namespace Puzzle15.DomainModel
{
    public class BestScores : IBestScores
    {
        private const int MaxCount = 10;

        private List<Score> Scores { get; set; }

        public int Count { get { return Scores.Count; } }

        public BestScores()
        {
            Scores = new List<Score>();
        }

        #region IEnumerable implementation

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Score> GetEnumerator()
        {
            foreach (var score in Scores)
                yield return score;
        }

        #endregion

        public bool CanBeAdded(Score score)
        {
            var tmp = new List<Score>(Scores);
            tmp.Add(score);
            tmp.Sort();
            return !(tmp.Count == MaxCount + 1 && tmp[MaxCount] == score);
        }

        public void Add(Score score)
        {
            if (CanBeAdded(score))
            {
                Scores.Add(score);
                Scores.Sort();
                if (Count == MaxCount + 1)
                    Scores.RemoveAt(MaxCount);
            }
        }
    }
}