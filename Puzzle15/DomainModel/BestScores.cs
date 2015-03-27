using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Puzzle15.DomainModel
{
    public class BestScores : IBestScores
    {
        public const int MaxCount = 10;
        public const string FileName = "Puzzle.dat";

        private List<Score> scores = new List<Score>();
        public List<Score> Scores { get { return scores; } }

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

        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fileStream = new FileStream(FileName,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(fileStream, Scores);
            }
        }

        public void Load()
        {
            if (!File.Exists(FileName)) return;
            using (var fileStream = new FileStream(FileName, FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                scores = (List<Score>)formatter.Deserialize(fileStream);
            }
        }
    }
}