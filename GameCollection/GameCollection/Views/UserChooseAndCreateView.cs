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

        public override User.User Show()
        {
            Console.WriteLine("Have you played Before?");
            Console.WriteLine("1: Yes");
            Console.WriteLine("2: No");

            var handledInput = ReadNumericInput("", 1, 2);
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
            
        }
        private User.User ShowCreateUser()
        {

        }


    }
}
