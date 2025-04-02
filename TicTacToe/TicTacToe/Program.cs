using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Program
    {
        private static string[,] map = new string[3,3] {
            { " ", " ", " " }, 
            { " ", " ", " " }, 
            { " ", " ", " " }
        };
        private static IDictionary<string, (int,int)> inputCoordPairs = new Dictionary<string, (int,int)>()
        {
            {"A",(0,0)},{"B",(0,1)},{"C",(0,2)},
            {"D",(1,0)},{"E",(1,1)},{"F",(1,2)},
            {"G",(2,0)},{"H",(2,1)},{"I",(2,2)}
        };

        private static string player = "X";

        static void Main(string[] args)
        {
            bool win = false;

            while (win == false)
            {
                MapGeneration();

                Console.WriteLine("      ");
                Console.WriteLine("------");
                Console.WriteLine("A|B|C");
                Console.WriteLine("------");
                Console.WriteLine("D|E|F");
                Console.WriteLine("------");
                Console.WriteLine("G|H|I");
                Console.WriteLine("------");
                Console.WriteLine("Pick a move: ");
                MakeMove(Console.ReadLine()); // pick move


                // Player Switching for now
                player = player == "X" ? "O" : "X";
                //TODO: AI MOVES

                
                win = CheckWinCondition(); // check win condition

            }
            Console.WriteLine("      ");
            Console.WriteLine("Congratulations! " + player + " won!!");
            Console.ReadLine();
        }

        static bool CheckWinCondition()
        {
            for (int i = 0; i < 3; i++) // Check Horizontal
            {
                if (map[i,0] == map[i,1] && map[i,0] == map[i,2] && map[i,0] != " ") return true;
            }
            for (int i = 0; i < 3; i++) // Check Vertical
            {
                if (map[0,i] == map[1,i] && map[0,i] == map[2,i] && map[0,i] != " ") return true;
            }
            // Check Diagonal 
            if (map[0,0] == map[1,1] && map[0,0] == map[2,2] && map[0,0] != " ") return true;
            if (map[0,2] == map[1,1] && map[0,2] == map[2,0] && map[0,2] != " ") return true;
            return false;
        }

        static void MakeMove(string move)
        {
            try
            {
                if (map[inputCoordPairs[move.ToUpper()].Item1, inputCoordPairs[move.ToUpper()].Item2] == " ")
                    map[inputCoordPairs[move.ToUpper()].Item1, inputCoordPairs[move.ToUpper()].Item2] = player;
                else
                {
                    Console.WriteLine("Invalid Move");
                    Console.ReadLine();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        static void MapGeneration()
        {
            Console.Clear();
            // Map Gen
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    Console.Write(map[i, k] + "|");
                }
                Console.WriteLine();
                Console.WriteLine("------");
            }
        }
    }
}
