﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games
{
    public interface IPlayable
    {
        static string Name { get; }
        IGameResult StartGame();
    }
}