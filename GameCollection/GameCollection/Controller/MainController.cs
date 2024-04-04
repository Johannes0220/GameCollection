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
        private readonly GameRepository _gameRepository;
        private readonly UserRepository _userRepository;

        public MainController(GameRepository gameRepository, UserRepository userRepository)
        {
            _gameRepository = gameRepository;
            _userRepository = userRepository;
        }

        public void RunGameCollection()
        {
            var gameChooserView = new GameChooserView(_gameRepository);
            var game = gameChooserView.Show();
            
        }
    }
}
