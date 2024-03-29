﻿using MineField.Core.Dependencies;

namespace MineField.Infrastructure
{

    public sealed class GameConfiguration : IGameConfiguration
    {
        public short Lives { get; set; }

        public short NoOfMines { get; set; }

        internal bool IsValid()
        {
            if (Lives == 0)
                return false;

            if (NoOfMines == 0)
                return false;

            return true;
        }
    }


}
