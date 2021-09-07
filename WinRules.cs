using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaper
{
    class WinRules
    {
        public static int CalculateWinner(int playerMove, int computerMove)
        {
            return (Math.Abs(playerMove - computerMove) % 2)
                switch
            {
                0 => playerMove == computerMove
                    ? -1
                    : new[] { playerMove, computerMove }.Min(),
                1 => new[] { playerMove, computerMove }.Max(),
                _ => throw new Exception("Invalid value")
            };
        }

        public static String GetResult(int playerMove, int computerMove)
        {
            var result = CalculateWinner(playerMove, computerMove);
            var resultMessage = result == -1
           ? "DRAW"
           : (result == playerMove) ? "WIN" : "LOSE";

            return resultMessage;
        }
    }
}
