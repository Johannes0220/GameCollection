namespace GameCollection.Games;

public class ScoreGameResult:IScoreGameResult
{
    public ScoreGameResult(int score)
    {
        Score = score;
    }

    public int Score { get; }
}