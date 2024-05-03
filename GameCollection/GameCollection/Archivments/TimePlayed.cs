using System.ComponentModel.DataAnnotations;
using GameCollection.Games;

namespace GameCollection.Archivements;

public class TimePlayed: IArchivable, ITrackable
{
    private readonly Dictionary<int,TimeSpan>_archivmentSteps;
    private readonly TimeSpan _timePlayed;
    private DateTime _startTracking;
    

    public TimePlayed()
    {
        Name = "Time Played";
        _archivmentSteps=new Dictionary<int, TimeSpan>();
        _timePlayed = TimeSpan.Zero;
        InitArchivmentSteps();

    }

    private void InitArchivmentSteps()
    {
        var offset1 = new TimeSpan(1, 0, 0);
        for (int i = 0; i < 25; i++)
        {
            var level= i* offset1;
            _archivmentSteps.Add(i,i*offset1);
        }
    }

    public void StartTracking()
    {
        _startTracking=DateTime.UtcNow;
    }

    public void StopTracking()
    {
        var stop=DateTime.UtcNow;
        var timePlayed = stop.Subtract(_startTracking);
        _timePlayed.Add(timePlayed);
    }

    public int GetLevel()
    {
        var currentLevel = 0;
        foreach (var level in _archivmentSteps)
        {
            if (TimeSpan.Compare(_timePlayed,level.Value)>=1)
            {
                currentLevel = level.Key;
            }
        }
        return currentLevel;
    }

    public string Name { get; }
    public int Level { get; }
    public IArchivmentScore GetScore()
    {
        return new TimeScore(_timePlayed);
    }
}