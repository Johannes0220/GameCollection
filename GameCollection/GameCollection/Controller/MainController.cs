using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games;
using GameCollection.User;
using GameCollection.Views;

namespace GameCollection.Controller
{
    public class MainController
    {
        private readonly IGameRepository _gameRepository;
        private readonly IUserService _userService;
        private readonly ArchivmentController _archivmentController;

        public MainController(IGameRepository gameRepository, IUserService userService, ArchivmentController archivmentController)
        {
            _gameRepository = gameRepository;
            _userService = userService;
            _archivmentController = archivmentController;
        }

        public void RunGameCollection()
        {
            var userView = new UserChooseAndCreateView(_userService);
            var user = userView.Show();
            while (true)
            {
                var mainView = new MainMenuView();
                var menu=mainView.ShowMainMenu();
                if (menu == 0)
                {

                    var gameChooserView = new GameChooserView(_gameRepository);
                    var game = gameChooserView.Show();
                    _archivmentController.RunArchivmentsForGame(game, user);
                    try
                    {
                        var activeGame = (IPlayable)Activator.CreateInstance(game);
                        user.GetArchivments(activeGame.GetType());
                        activeGame.StartGame();
                        _archivmentController.UpdateArchivmentsForGame(game, user);
                    }
                    catch (Exception e)
                    {
                        var ex = new Exception(
                            "Something went wrong with this game! Please contact the developers to fix the issue");
                        Console.WriteLine(ex);
                        Console.WriteLine(e.Message);
                        Console.WriteLine(e.StackTrace);
                    }
                }
                else
                {
                    var archivmentView = new ArchivmentView();
                    var gameList=_gameRepository.GetAllGames();
                    var game=archivmentView.ChooseGame(gameList);
                    try
                    {
                        var archivments = user.GetArchivments(game);
                        archivmentView.ShowArchivementsForGame(archivments, game);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("It seems like you have not played this game yet!");
                        Console.WriteLine("Returning to the main menu");
                        Thread.Sleep(3000);
                    }
                }
            }

        }
    }
}
