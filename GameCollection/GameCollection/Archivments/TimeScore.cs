namespace GameCollection.Archivements;

public class TimeScore : IArchivmentScore
{
    private readonly string Unit;
    private readonly TimeSpan Score;


    public TimeScore(TimeSpan time)
    {
        Unit = "Hours";
        Score = time;
    }

    public string GetScore()
    {
        return $"{Score.TotalHours}\t{Unit}";
    }
}