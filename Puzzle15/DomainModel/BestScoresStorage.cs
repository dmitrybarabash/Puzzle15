using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Puzzle15.DomainModel
{
    public class BestScoresStorage : IBestScoresStorage
    {
        private string FileName { get; set; }

        public BestScoresStorage(string fileName)
        {
            FileName = fileName;
        }

        public void Save(List<Score> scores)
        {
            var formatter = new BinaryFormatter();
            using (var fileStream = new FileStream(FileName,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(fileStream, scores);
            }
        }

        public List<Score> Load()
        {
            List<Score> result = null;
            if (!File.Exists(FileName)) return result;
            using (var fileStream = new FileStream(FileName, FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                result = (List<Score>)formatter.Deserialize(fileStream);
            }
            return result;
        }
    }
}