﻿using GameCollection.Archivements;

namespace GameCollection.Archivments.Incrementable;

public class GamesWon : IIncrementable
{
    public string Name { get; }
    public int Level { get; }

    private int winCnt = 0;
    public IArchivmentScore GetScore()
    {
        return new WinScore(winCnt, "Wins");
    }

    public void Increment(int? score)
    {
        if (score.HasValue)
        {
            winCnt += score.Value;
        }
        else
        {
            score++;
        }
    }
}