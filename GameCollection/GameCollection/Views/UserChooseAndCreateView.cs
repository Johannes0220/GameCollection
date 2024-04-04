using System;
using System.Collections.Generic;
using System.Linq;
using GameCollection.User;

namespace GameCollection.Views
{
    public class UserChooseAndCreateView
    {
        private readonly UserRepository _userRepository;
        public UserChooseAndCreateView(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User.User Show()
        {
            Console.WriteLine("Have you played Before?");
            Console.WriteLine("1: Yes");
            Console.WriteLine("2: No");

            var handledInput = HandleInput();
            if (handledInput.Equals(1))
            {
                return ShowChooseUser();
            }
            return ShowCreateUser();
        }

        private int HandleInput()
        {

            var valid = false;
            var input = Console.ReadLine();
            while (!valid)
            {
                valid = CheckValid(input);
            }
            return int.Parse(input);
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

            if (inputNum >= 0 && inputNum < 2)
            {
                return true;
            }

            Console.WriteLine(inputNum + " is not in the List");
            return false;

        }

        private User.User ShowChooseUser()
        {
            var users = _userRepository.GetAllUsers();
            Console.WriteLine("Available Users");
            
            for(int i=0; i<users.Count;i++)
            {
                Console.WriteLine($"{i}: {users[i].Name}");
            }
            
        }
        private User.User ShowCreateUser()
        {

        }


    }
}
