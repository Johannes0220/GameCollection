using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games;

namespace GameCollection.Views
{
    public class GameChooserView : BasicView
    {
        private readonly IGameRepository _gameRepository;
        private readonly List<Type> _gameList;

        public GameChooserView(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
            _gameList = _gameRepository.GetAllGames();
        }


        public Type Show()
        {
            Console.WriteLine("Choose the game you'd like to play!");

            for (int i = 0; i < _gameList.Count; i++)
            {
                Console.WriteLine("\t" + i + ". " + _gameList[i].Name);
            }

            var gameNum = ReadNumericInput("",0,_gameList.Count-1);
            Console.Clear();
            return _gameList[gameNum];
        }
    }
}
