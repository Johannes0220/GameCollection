using GameCollection.Archivements;

namespace GameCollection.Archivments.Incrementable;

public class GamesWon : IIncrementable
{
    public string Name { get; }
    public int Level { get; }

    private int winCnt = 0;
    public IArchivmentScore GetScore()
    {
        
    }

    public void Increment()
    {
        winCnt++;
    }
}