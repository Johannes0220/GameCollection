using System;
using System.Collections.Generic;
using System.Linq;
using GameCollection.User;

namespace GameCollection.Views
{
    public class UserChooseAndCreateView : BasicView
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

            var handledInput = ReadNumericInput("Choose the Number: ", 1, 2);
            Console.Clear();
            if (handledInput.Equals(1))
            {
                return ShowChooseUser();
            }
            return ShowCreateUser();
        }

        private User.User ShowChooseUser()
        {
            var users = _userRepository.GetAllUsers();
            
            
            Console.WriteLine("Available Users");
            
            for(int i=0; i<users.Count;i++)
            {
                Console.WriteLine($"{i}: {users[i].Name}");
            }

            var input = ReadNumericInput("Choose your User: ", 0, users.Count-1);
            Console.Clear();
            return users[input];
        }
        private User.User ShowCreateUser()
        {
            Console.WriteLine("Create a new User!");
            var name = ReadTextInput("What shall your new Users name be? ");
            Console.Clear();
            Console.WriteLine($"User \"{name}\" was created sucessfully");
            Thread.Sleep(2000);
            Console.Clear();
            return _userRepository.CreateUser(name);
        }


    }
}
