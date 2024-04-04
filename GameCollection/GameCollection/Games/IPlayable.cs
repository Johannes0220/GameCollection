using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games
{
    public interface IPlayable
    {
        string getName();

        void StartGame();
    }
}
