namespace GameCollection.Archivements;

public class WinScore : IArchivmentScore
{
    private readonly int _winCnt;
    private string _unit;

    public WinScore(int winCnt, string unit)
    {
        _winCnt = winCnt;
        _unit = unit;
    }
    public string GetScore()
    {
        return $"{_winCnt}\t{_unit}";
    }

    string IArchivmentScore.Unit
    {
        get {return _unit;}
    }
}