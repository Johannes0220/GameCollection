using System.Dynamic;

namespace GameCollection.Games.TowerOfHanoi;

public class TowerOfHanoi
{
    public int disks { get; set; }
    public int minimumNumberOfMoves { get; set; }
    public List<int>[] stacks { get; set; }
    public int moves { get; set; }
    public int? source { get; set; }
    public TowerOfHanoiGameState state { get; set; }

    public void InitGame()
    {
        state = TowerOfHanoiGameState.ChooseSource;
        minimumNumberOfMoves = (int)Math.Pow(2, disks) - 1;
        stacks = new List<int>[3] { new List<int>(), new List<int>(), new List<int>() };
        for (int i = disks; i > 0; i--)
        {
            stacks[0].Add(i);
        }
        moves = 0;
        source = null;
    }

    public bool CheckWon()
    {
        return stacks[2].Count.Equals(disks);
    }

    public void UpdateGameState(int stack)
    {
        if (source is null && stacks[stack].Count > 0)
        {
            source = stack;
            state = TowerOfHanoiGameState.ChooseTarget;
        }
        else if (source is not null &&
                 (stacks[stack].Count is 0 || stacks[source.Value][^1] < stacks[stack][^1]))
        {
            stacks[stack].Add(stacks[source.Value][^1]);
            stacks[source.Value].RemoveAt(stacks[source.Value].Count - 1);
            source = null;
            moves++;
            state = TowerOfHanoiGameState.ChooseSource;
        }
        else if (source == stack)
        {
            source = null;
            state = TowerOfHanoiGameState.ChooseSource;
        }
        else if (stacks[stack].Count is not 0)
        {
            state = TowerOfHanoiGameState.InvalidTarget;
        }
    }
}