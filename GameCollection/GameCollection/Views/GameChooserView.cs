using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games;

namespace GameCollection.Views
{
    public class GameChooserView
    {
        private readonly GameRepository _gameRepository;
        private readonly List<IPlayable> _gameList;

        public GameChooserView(GameRepository gameRepository)
        {
            _gameRepository = gameRepository;
            _gameList = _gameRepository.GetAllGames();
            Show();
        }

        public IPlayable Show()
        { 
        Console.WriteLine("Choose the game you'd like to play!");

            for (int i = 0; i < _gameList.Count; i++)
            {
                Console.WriteLine("\t" + i + ". " + _gameList[i].getName());
            }

            var gameNum=ReadInput();
            return _gameList[gameNum];
        }

        private int ReadInput()
        {
            var valid = false;
            var input = "Keine Eingabe";
            while (!valid)
            {
                Console.Write("Enter the Number of your Game: ");
                input = Console.ReadLine();
                valid = CheckValid(input);
            }

            return int.Parse(input);
        }

        private void StartMiniGame(string? input)
        {
            Console.WriteLine(_gameList[int.Parse(input)] + " wird gestartet!");
        }

        private bool CheckValid(string input)
        {
            var inputNum = 0;
            try
            {
                inputNum = int.Parse(input);
            }
            catch (Exception e)
            {
                Console.WriteLine(input + " is Not a Number");
                return false;
            }

            if (inputNum >= 0 && inputNum < _gameList.Count)
            {
                return true;
            }

            Console.WriteLine(inputNum + " is not in the List");
            return false;

        }
    }
}
