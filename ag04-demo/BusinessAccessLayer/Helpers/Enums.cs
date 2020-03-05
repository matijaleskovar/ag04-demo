using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAccessLayer.Helpers
{
    public class Enums
    {
        public enum GameStatus
        {
            InProgress = 1,
            Done = 2
        }

        public enum ShipType
        {
            PatrolCraft = 1,
            Submarine = 2,
            Destroyer = 3,
            Battleship = 4
        }
    }
}
