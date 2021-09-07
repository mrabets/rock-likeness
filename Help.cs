using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaper
{
    class Help
    {
        ConsoleTable table = new ConsoleTable("PC \\ User");
        String[] moves;
        String[] columns = { "PC \\ User" };

        public Help(String[] moves)
        {
            this.moves = moves;
            this.columns = this.columns.Concat(moves).ToArray();
        }

        public void DisplayRules()
        {
            Console.Clear();

            table.AddColumn(moves);

            for (int i = 0; i < moves.Length; i++)
            {
                List<String> row = new List<String>() { moves[i] };

                for (int j = 0; j < moves.Length; j++)
                {
                    row.Add(WinRules.GetResult(j + 1, i + 1));
                }

                table.AddRow(row.ToArray());
            }

            table.Write(Format.Alternative);
        }
    }
}
