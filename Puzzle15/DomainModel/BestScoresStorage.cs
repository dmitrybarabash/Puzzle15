using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Puzzle15.DomainModel
{
    public class BestScoresStorage : IBestScoresStorage
    {
        public BestScoresStorage(string fileName)
        {
            FileName = fileName;
        }

        #region IBestScoresStorage Implementation

        public string FileName { get; set; }

        public void Save(IBestScores bestScores)
        {
            var formatter = new BinaryFormatter();
            using (var fileStream = new FileStream(FileName,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(fileStream, bestScores.Scores);
            }
        }

        public void Load(IBestScores bestScores)
        {
            if (!File.Exists(FileName)) return;

            using (var fileStream = new FileStream(FileName, FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                var scores = (List<Score>)formatter.Deserialize(fileStream);
                bestScores.Scores.Clear();
                bestScores.Scores.AddRange(scores);
            }
        }

        #endregion
    }
}