using System;
using System.Collections.Generic;

namespace Competitive_Programming
{
    class Program
    {
        static public char[] grid = { '-', '-', '-', '-', '-', '-', '-', '-', '-' };
        static public int activePlayer = 1;
        static public int nextMovePos;
        static public string message = "Player 1 Turn. Enter Your Move(1-9):";
        static public List<int> possibleMoves = new List<int>();

        static void Main(string[] args)
        {
            possibleMoves.Add(0);
            possibleMoves.Add(1);
            possibleMoves.Add(2);
            possibleMoves.Add(3);
            possibleMoves.Add(4);
            possibleMoves.Add(5);
            possibleMoves.Add(6);
            possibleMoves.Add(7);
            possibleMoves.Add(8);
            for (; ; )
            {
                drawGrid();
                nextMovePos = Convert.ToInt32(Console.ReadLine()) - 1;
                if (possibleMoves.Contains(nextMovePos))
                {
                    setMoveAt(nextMovePos);
                    if (gameWon())
                    {
                        winGame();
                        break;
                    }
                    else if (possibleMoves.Count == 0)
                    {
                        endGame();
                        break;
                    }
                    else
                    {
                        changePlayerTurn();
                    }
                }
                else
                {
                    message = "Entered Location is filled or incorrect, please enter an empty location";
                }
                Console.Clear();



            }

        }



        static void setMoveAt(int i)
        {
            if (activePlayer == 1)
            {
                grid[i] = 'X';
            }
            else if (activePlayer == 2)
            {
                grid[i] = 'O';
            }
            possibleMoves.Remove(i);
        }

        static void drawGrid()
        {
            Console.WriteLine(grid[0] + "|" + grid[1] + "|" + grid[2]);
            Console.WriteLine(grid[3] + "|" + grid[4] + "|" + grid[5]);
            Console.WriteLine(grid[6] + "|" + grid[7] + "|" + grid[8]);
            Console.WriteLine();
            Console.WriteLine(message);

        }

        static void changePlayerTurn()
        {
            if (activePlayer == 1)
            {
                activePlayer = 2;
                message = "Player 2 Turn. Enter Your Move(1-9):";
            }
            else if (activePlayer == 2)
            {
                activePlayer = 1;
                message = "Player 1 Turn. Enter Your Move(1-9):";
            }
        }

        static void endGame()
        {
            Console.Clear();
            message = "No more possible moves. Game Drawn";
            drawGrid();
            Console.ReadKey();
        }

        static bool gameWon()
        {
            bool gameWon = false;
            for (int i = 0; i <= 6; i += 3)
            {
                if (grid[i] == grid[i + 1] && grid[i + 1] == grid[i + 2] && grid[i] != '-')
                {
                    gameWon = true;
                }
            }
            for (int i = 0; i <= 2; i += 1)
            {
                if (grid[i] == grid[i + 3] && grid[i + 3] == grid[i + 6] && grid[i] != '-')
                {
                    gameWon = true;
                }
            }
            if (grid[0] == grid[4] && grid[4] == grid[8] && grid[0] != '-')
            {
                gameWon = true;
            }
            if (grid[2] == grid[4] && grid[4] == grid[6] && grid[2] != '-')
            {
                gameWon = true;
            }
            return gameWon;
        }

        static void winGame()
        {
            Console.Clear();
            message = "Player " + activePlayer + " won The Game.";
            drawGrid();
            Console.ReadKey();
        }



    }
}
