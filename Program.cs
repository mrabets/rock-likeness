using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Collections;

namespace RockPaper
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckArgumnets(args);

            string answer = "";

            do
            {
                int computerMoveIndex = RandomNumberGenerator.GetInt32(1, args.Length + 1);
                string hmac_key = Hmac.GetRandom128bitKey();
                string hmac = Hmac.GetHash(args[computerMoveIndex - 1], hmac_key);

                Console.WriteLine($"\nHMAC: {hmac}");

                PrintMenu(args);

                Console.Write("\nEnter your move: ");
                string choice = Convert.ToString(Console.ReadLine());

                if (choice == "?")
                {
                    var help = new Help(args);
                    help.DisplayRules();
                    continue;
                }

                int playerMoveIndex = 0;

                try
                {
                    playerMoveIndex = Int32.Parse(choice);

                    if (playerMoveIndex < 0 || playerMoveIndex > args.Length)
                        throw new ArgumentException();
                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid input");
                    continue;
                }

                if (playerMoveIndex == 0)
                    Environment.Exit(1);                

                var playerMove = args[playerMoveIndex - 1];
                var computerMove = args[computerMoveIndex - 1];

                Console.WriteLine($"Your move: {playerMove}");
                Console.WriteLine($"Computer move: {computerMove}");

                string result = WinRules.GetResult(playerMoveIndex, computerMoveIndex);
                Console.WriteLine(result);

                Console.WriteLine($"HMAC key: {hmac_key}");

                Console.WriteLine("\nContinue? (Yes/No):");

                answer = Console.ReadLine().ToUpper();
            }
            while (answer != "NO");
        }

        static void CheckArgumnets(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Length must be more or equal 3");
                Environment.Exit(1);
            }

            if (args.Length % 2 == 0)
            {
                Console.WriteLine("Length must be odd");
                Environment.Exit(1);
            }

            if (args.Length != args.Distinct().Count())
            {
                Console.WriteLine("Elements should not be duplicated");
                Environment.Exit(1);
            }
        }

        static void PrintMenu(String[] moves)
        {
            Console.WriteLine("\nAvailable moves:\n");

            for (int i = 0; i < moves.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {moves[i]}");
            }

            Console.WriteLine("0 - Exit");
            Console.WriteLine("? - Help");
        }
    }
}
