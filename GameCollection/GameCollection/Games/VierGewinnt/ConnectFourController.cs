using System;
using System.Text.Json;

namespace GameCollection.Games.VierGewinnt;

public class ConnectFourController : IPlayable
{
    private readonly ConnectFourView _ConnectFourView;
    private readonly ConnectFour _ConnectFour;
    private IConnectFourBot _bot;
    private readonly ConnectFourDifficultyChooser _connectFourDifficultyChooser;
    private IGameResult result;
    public static readonly string Name = "Connect";
    public ConnectFourController()
    {
        _ConnectFourView = new ConnectFourView();
        _ConnectFour = new ConnectFour();
        _connectFourDifficultyChooser = new ConnectFourDifficultyChooser(_ConnectFourView);
    }
 
    public IGameResult StartGame()
    {
       
        try
        {
            _bot=_connectFourDifficultyChooser.GetDifficulty();
            _ConnectFour.InitGame();
            int input = 0;
            while (true)
            {

                if (_ConnectFour.player1Turn)
                {
                    if (DoPlayerTurn(out input)) break;
                }
                else
                {
                    if (DoBotTurn(input)) break;
                }

                if (_ConnectFour.CheckForDraw())
                {
                    _ConnectFourView.RenderBoard(_ConnectFour.board);
                    _ConnectFourView.DisplayDraw();
                }
                else
                {
                    _ConnectFour.SwitchPlayer();
                }
            }
            _ConnectFourView.DisplayReturnToGameMenu();
            Thread.Sleep(3000);
        }
        catch (Exception e)
        {
            //exception = e;
            throw;
        }
        finally
        {
            Console.CursorVisible = true;
            Console.Clear();
            //Console.WriteLine(exception?.ToString() ?? "Connect 4 was closed.");
        }

        return result;
    }

    private bool DoBotTurn(int input)
    {
        var move = _bot.getMove(_ConnectFour.board, input);
        _ConnectFour.SetInput(move);
        if (_ConnectFour.CheckFor4())
        {
            _ConnectFourView.RenderBoard(_ConnectFour.board);
            _ConnectFourView.DisplayLost();
            return true;
            result = new WinGameResult(false);
        }

        return false;
    }

    private bool DoPlayerTurn(out int input)
    {
        _ConnectFourView.RenderBoard(_ConnectFour.board);
        input = _ConnectFourView.GetPlayerInput(_ConnectFour.board);
        _ConnectFour.SetInput(input);
        if (_ConnectFour.CheckFor4())
        {
            _ConnectFourView.RenderBoard(_ConnectFour.board);
            _ConnectFourView.DisplayWon();
            return true;
            result = new WinGameResult(true);
        }

        return false;
    }
}