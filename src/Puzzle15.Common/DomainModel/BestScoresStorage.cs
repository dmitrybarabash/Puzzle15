using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Puzzle15.DomainModel;

public class BestScoresStorage : IBestScoresStorage
{
    public BestScoresStorage(string fileName)
    {
        FileName = fileName;
    }

    #region IBestScoresStorage implementation

    public string FileName { get; set; }

    public void Save(IBestScores bestScores)
    {
        using var fileStream = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None);
        var serializer = new XmlSerializer(typeof(List<Score>));
        serializer.Serialize(fileStream, bestScores.Scores);
    }

    public void Load(IBestScores bestScores)
    {
        if (!File.Exists(FileName))
            return;

        using var fileStream = new FileStream(FileName, FileMode.Open);
        var serializer = new XmlSerializer(typeof(List<Score>));
        var scores = (List<Score>)serializer.Deserialize(fileStream);
        bestScores.Scores.Clear();
        bestScores.Scores.AddRange(scores);
    }

    #endregion
}
