using System;
using System.Text.Json;

namespace GameCollection.Games.VierGewinnt;

public class ConnectFourController : IPlayable
{
    private readonly ConnectFourView _ConnectFourView;
    private readonly ConnectFour _ConnectFour;
    private IConnectFourBot _bot;

    public ConnectFourController()
    {
        _ConnectFourView = new ConnectFourView();
        _ConnectFour = new ConnectFour();
    }
    public string GetName()
    {
        throw new NotImplementedException();
    }

    public void StartGame()
    {
        try
        {
            var difficulty= _ConnectFourView.GetDifficulty();
            if (difficulty.Equals(0))
            {
                _bot = new ConnectFourRandomBot();
            }
            else
            {
                _bot = new ConnectFourBlockBot();
            }

            _ConnectFour.InitGame();
            int input = 0;
            while (true)
            {

                if (_ConnectFour.player1Turn)
                {

                    _ConnectFourView.RenderBoard(_ConnectFour.board);
                    input = _ConnectFourView.GetPlayerInput(_ConnectFour.board);
                    _ConnectFour.SetInput(input);
                    if (_ConnectFour.CheckFor4())
                    {
                        _ConnectFourView.RenderBoard(_ConnectFour.board);
                        _ConnectFourView.DisplayWon();
                        break;
                    }
                }
                else
                {
                    var move = _bot.getMove(_ConnectFour.board, input);
                    _ConnectFour.SetInput(move);
                    if (_ConnectFour.CheckFor4())
                    {
                        _ConnectFourView.RenderBoard(_ConnectFour.board);
                        _ConnectFourView.DisplayLost();
                        break;
                    }
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

    }
}