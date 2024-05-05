using GameCollection.Games;
using GameCollection.Games.Memory;

public class MemoryController : IPlayable
{
    Exception? exception = null;


    bool pendingConfirmation = false;
    private readonly MemoryView _memoryView;
    private readonly Memory _memory;
    public static readonly string Name = "Memory";
    public MemoryController()
    {
        _memoryView = new MemoryView();
        _memory = new Memory();
    }
    
    public IGameResult StartGame()
    {
        try
        {
            _memory.InitializeAndShuffleBoard(5, 10);

            int minWidth = _memory.board.GetLength(1) * 3 + 4;
            int minHeight = _memory.board.GetLength(0) * 2 + 13;

            while (!_memory.AllTilesVisible())
            {
                _memoryView.EnsureConsoleSize(minWidth, minHeight);

                _memoryView.Render(_memory.board, (0, 0), null, null);
                var firstSelection = _memoryView.GetSelection(_memory.board, null);
                var secondSelection = _memoryView.GetSelection(_memory.board, firstSelection);
                _memoryView.Render(_memory.board, (0, 0), firstSelection, secondSelection);
                _memoryView.WaitForConfirmation();
                _memory.CheckPair(firstSelection, secondSelection);
            }

            _memoryView.Render(_memory.board, (0, 0), null, null);
            _memoryView.RenderWinMessage();
            Thread.Sleep(3000);
        }
        catch (Exception e)
        {
            exception = e;
            throw;
        }

        return new WinGameResult(true);
    }
}
