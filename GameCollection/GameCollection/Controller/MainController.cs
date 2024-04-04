﻿using System;
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
        private readonly UserRepository _userRepository;

        public MainController(IGameRepository gameRepository, UserRepository userRepository)
        {
            _gameRepository = gameRepository;
            _userRepository = userRepository;
        }

        public void RunGameCollection()
        {
            var userView = new UserChooseAndCreateView(_userRepository);
            var user = userView.Show();
            var gameChooserView = new GameChooserView(_gameRepository);
            var game = gameChooserView.Show();
            
        }
    }
}
