namespace GameCollection.Archivements;

public class TimeScore : IArchivmentScore
{
    private readonly string _unit;
    private readonly TimeSpan _timePlayed;


    public TimeScore(TimeSpan time)
    {
        _unit = "Hours";
        _timePlayed = time;
    }


    string IArchivmentScore.Unit
    {
        get { return _unit; }
    }
    public string GetScore()
    {
        return $"{_timePlayed.TotalHours}\t{_unit}";
    }
}