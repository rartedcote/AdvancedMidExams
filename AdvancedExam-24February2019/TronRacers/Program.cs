using System;

namespace TronRacers
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] playArea = new char[size, size];

            int playerOneRow = 0;
            int playerOneCol = 0;
            int playerTwoRow = 0;
            int playerTwoCol = 0;

            for (int row = 0; row < size; row++)
            {
                char[] playLine = Console.ReadLine().ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    playArea[row, col] = playLine[col];

                    if (playArea[row, col] == 'f')
                    {
                        playerOneRow = row;
                        playerOneCol = col;
                    }

                    else if (playArea[row, col] == 's')
                    {
                        playerTwoRow = row;
                        playerTwoCol = col;
                    }
                }
            }

            while (true)
            {
                string[] directions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                switch (directions[0])
                {
                    case "up":
                        playerOneRow--;

                        if (IsInUpRowBounds(playerOneRow))
                        {
                            PlayerOneCheck(playerOneRow, playerOneCol, playArea);
                        }

                        else
                        {
                            playerOneRow = size - 1;
                            PlayerOneCheck(playerOneRow, playerOneCol, playArea);
                        }
                        break;

                    case "down":
                        playerOneRow++;

                        if (IsInDownRowBounds(playerOneRow, playArea))
                        {
                            PlayerOneCheck(playerOneRow, playerOneCol, playArea);
                        }

                        else
                        {
                            playerOneRow = 0;
                            PlayerOneCheck(playerOneRow, playerOneCol, playArea);
                        }
                        break;

                    case "left":
                        playerOneCol--;

                        if (IsInLeftColBounds(playerOneCol))
                        {
                            PlayerOneCheck(playerOneRow, playerOneCol, playArea);
                        }

                        else
                        {
                            playerOneCol = size - 1;
                            PlayerOneCheck(playerOneRow, playerOneCol, playArea);
                        }
                        break;

                    case "right":
                        playerOneCol++;

                        if (IsInRightColBounds(playerOneCol, playArea))
                        {
                            PlayerOneCheck(playerOneRow, playerOneCol, playArea);
                        }

                        else
                        {
                            playerOneCol = 0;
                            PlayerOneCheck(playerOneRow, playerOneCol, playArea);
                        }
                        break;
                }

                switch (directions[1])
                {
                    case "up":
                        playerTwoRow--;

                        if (IsInUpRowBounds(playerTwoRow))
                        {
                            PlayerTwoCheck(playerTwoRow, playerTwoCol, playArea);
                        }

                        else
                        {
                            playerTwoRow = size - 1;
                            PlayerTwoCheck(playerTwoRow, playerTwoCol, playArea);
                        }
                        break;

                    case "down":
                        playerTwoRow++;

                        if (IsInDownRowBounds(playerTwoRow, playArea))
                        {
                            PlayerTwoCheck(playerTwoRow, playerTwoCol, playArea);
                        }

                        else
                        {
                            playerTwoRow = 0;
                            PlayerTwoCheck(playerTwoRow, playerTwoCol, playArea);
                        }
                        break;

                    case "left":
                        playerTwoCol--;

                        if (IsInLeftColBounds(playerTwoCol))
                        {
                            PlayerTwoCheck(playerTwoRow, playerTwoCol, playArea);
                        }

                        else
                        {
                            playerTwoCol = size - 1;
                            PlayerTwoCheck(playerTwoRow, playerTwoCol, playArea);
                        }
                        break;

                    case "right":
                        playerTwoCol++;

                        if (IsInRightColBounds(playerTwoCol, playArea))
                        {
                            PlayerTwoCheck(playerTwoRow, playerTwoCol, playArea);
                        }

                        else
                        {
                            playerTwoCol = 0;
                            PlayerTwoCheck(playerTwoRow, playerTwoCol, playArea);
                        }
                        break;
                }
            }
        }

        private static void PlayerTwoCheck(int playerTwoRow, int playerTwoCol, char[,] playArea)
        {
            if (playArea[playerTwoRow, playerTwoCol] == 'f')
            {
                playArea[playerTwoRow, playerTwoCol] = 'x';
                PrintArea(playArea);
                Environment.Exit(0);
            }

            else
            {
                playArea[playerTwoRow, playerTwoCol] = 's';
            }
        }

        private static bool IsInRightColBounds(int playerOneCol, char[,] playArea)
        {
            return playerOneCol <= playArea.GetLength(1) - 1;
        }

        private static bool IsInLeftColBounds(int playerOneCol)
        {
            return playerOneCol >= 0;
        }

        private static bool IsInDownRowBounds(int playerOneRow, char[,] playArea)
        {
            return playerOneRow <= playArea.GetLength(0) - 1;
        }

        private static void PlayerOneCheck(int playerOneRow, int playerOneCol, char[,] playArea)
        {
            if (playArea[playerOneRow, playerOneCol] == 's')
            {
                playArea[playerOneRow, playerOneCol] = 'x';
                PrintArea(playArea);
                Environment.Exit(0);
            }

            else
            {
                playArea[playerOneRow, playerOneCol] = 'f';
            }
        }

        private static void PrintArea(char[,] playArea)
        {
            for (int row = 0; row < playArea.GetLength(0); row++)
            {
                for (int col = 0; col < playArea.GetLength(1); col++)
                {
                    Console.Write($"{playArea[row, col]}");
                }

                Console.WriteLine();
            }
        }

        private static bool IsInUpRowBounds(int playerOneRow)
        {
            return playerOneRow >= 0;
        }
    }
}