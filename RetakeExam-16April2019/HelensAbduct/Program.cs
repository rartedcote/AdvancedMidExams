using System;
using System.Linq;

namespace HelensAbduct
{
    class Program
    {
        static int parisRow;
        static int parisCol;

        static void Main(string[] args)
        {
            int parisEnergy = int.Parse(Console.ReadLine());
            int numRows = int.Parse(Console.ReadLine());
            char[][] playField = new char[numRows][];

            InitializePlayField(playField);

            GetParisLocation(playField);
            
            while (true)
            {
                string[] directionSpawnPoint = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string parisDirection = directionSpawnPoint[0];
                int enemyRow = int.Parse(directionSpawnPoint[1]);
                int enemyCol = int.Parse(directionSpawnPoint[2]);

                playField[enemyRow][enemyCol] = 'S';

                switch (parisDirection)
                {
                    case "up":

                        parisEnergy--;

                        if (IsEnergyZero(parisEnergy))
                        {
                            if (IsInDownRowBounds(parisRow))
                            {
                                playField[parisRow][parisCol] = '-';
                                parisRow--;
                            }

                            playField[parisRow][parisCol] = 'X';
                            Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
                            PrintPlayField(playField);
                            return;
                        }

                        if (IsInDownRowBounds(parisRow))
                        {
                            playField[parisRow][parisCol] = '-';
                            parisRow--;

                            if (playField[parisRow][parisCol] == 'S')
                            {
                                parisEnergy -= 2;

                                if (IsEnergyZero(parisEnergy))
                                {
                                    playField[parisRow][parisCol] = 'X';
                                    Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
                                    PrintPlayField(playField);
                                    return;
                                }

                                else
                                {
                                    playField[parisRow][parisCol] = 'P';
                                }
                            }

                            else if (playField[parisRow][parisCol] == 'H')
                            {
                                playField[parisRow][parisCol] = '-';
                                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {parisEnergy}");
                                PrintPlayField(playField);
                                return;
                            }

                            else
                            {
                                playField[parisRow][parisCol] = 'P';
                            }
                        }

                        break;

                    case "down":

                        parisEnergy--;

                        if (IsEnergyZero(parisEnergy))
                        {
                            if (IsInUpRowBounds(parisRow, playField))
                            {
                                playField[parisRow][parisCol] = '-';
                                parisRow++;
                            }

                            playField[parisRow][parisCol] = 'X';
                            Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
                            PrintPlayField(playField);
                            return;
                        }

                        if (IsInUpRowBounds(parisRow, playField))
                        {
                            playField[parisRow][parisCol] = '-';
                            parisRow++;

                            if (playField[parisRow][parisCol] == 'S')
                            {
                                parisEnergy -= 2;

                                if (IsEnergyZero(parisEnergy))
                                {
                                    playField[parisRow][parisCol] = 'X';
                                    Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
                                    PrintPlayField(playField);
                                    return;
                                }

                                else
                                {
                                    playField[parisRow][parisCol] = 'P';
                                }
                            }

                            else if (playField[parisRow][parisCol] == 'H')
                            {
                                playField[parisRow][parisCol] = '-';
                                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {parisEnergy}");
                                PrintPlayField(playField);
                                return;
                            }

                            else
                            {
                                playField[parisRow][parisCol] = 'P';
                            }
                        }

                        break;

                    case "left":

                        parisEnergy--;

                        if (IsEnergyZero(parisEnergy))
                        {
                            if (IsInLeftBounds(parisCol))
                            {
                                playField[parisRow][parisCol] = '-';
                                parisCol--;
                            }

                            playField[parisRow][parisCol] = 'X';
                            Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
                            PrintPlayField(playField);
                            return;
                        }

                        if (IsInLeftBounds(parisCol))
                        {
                            playField[parisRow][parisCol] = '-';
                            parisCol--;

                            if (playField[parisRow][parisCol] == 'S')
                            {
                                parisEnergy -= 2;

                                if (IsEnergyZero(parisEnergy))
                                {
                                    playField[parisRow][parisCol] = 'X';
                                    Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
                                    PrintPlayField(playField);
                                    return;
                                }

                                else
                                {
                                    playField[parisRow][parisCol] = 'P';
                                }
                            }

                            else if (playField[parisRow][parisCol] == 'H')
                            {
                                playField[parisRow][parisCol] = '-';
                                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {parisEnergy}");
                                PrintPlayField(playField);
                                return;
                            }

                            else
                            {
                                playField[parisRow][parisCol] = 'P';
                            }
                        }

                        break;

                    case "right":

                        parisEnergy--;

                        if (IsEnergyZero(parisEnergy))
                        {
                            if (IsInRightBounds(parisCol, playField[parisRow]))
                            {
                                playField[parisRow][parisCol] = '-';
                                parisCol++;
                            }

                            playField[parisRow][parisCol] = 'X';
                            Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
                            PrintPlayField(playField);
                            return;
                        }

                        if (IsInRightBounds(parisCol, playField[parisRow]))
                        {
                            playField[parisRow][parisCol] = '-';
                            parisCol++;

                            if (playField[parisRow][parisCol] == 'S')
                            {
                                parisEnergy -= 2;

                                if (IsEnergyZero(parisEnergy))
                                {
                                    playField[parisRow][parisCol] = 'X';
                                    Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
                                    PrintPlayField(playField);
                                    return;
                                }

                                else
                                {
                                    playField[parisRow][parisCol] = 'P';
                                }
                            }

                            else if (playField[parisRow][parisCol] == 'H')
                            {
                                playField[parisRow][parisCol] = '-';
                                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {parisEnergy}");
                                PrintPlayField(playField);
                                return;
                            }

                            else
                            {
                                playField[parisRow][parisCol] = 'P';
                            }
                        }

                        break;
                }
            }
        }

        private static bool IsInRightBounds(int parisCol, char[] currentCol)
        {
            return parisCol + 1 <= currentCol.Length - 1;
        }

        private static bool IsInLeftBounds(int parisCol)
        {
            return parisCol - 1 >= 0;
        }

        private static bool IsInUpRowBounds(int parisRow, char[][] playField)
        {
            return parisRow + 1 <= playField.Length - 1;
        }

        private static bool IsEnergyZero(int parisEnergy)
        {
            return parisEnergy <= 0;
        }

        private static void PrintPlayField(char[][] playField)
        {
            foreach (var col in playField)
            {
                Console.WriteLine(string.Join("", col));
            }
        }

        private static bool IsInDownRowBounds(int parisRow)
        {
            return parisRow - 1 >= 0;
        }

        private static void GetParisLocation(char[][] playField)
        {
            for (int row = 0; row < playField.Length; row++)
            {
                if (playField[row].Contains('P'))
                {
                    parisRow = row;
                    parisCol = Array.IndexOf(playField[row], 'P');
                    break;
                }
            }
        }

        private static void InitializePlayField(char[][] playField)
        {
            for (int row = 0; row < playField.Length; row++)
            {
                char[] fieldLine = Console.ReadLine().ToCharArray();
                playField[row] = new char[fieldLine.Length];

                for (int col = 0; col < playField[row].Length; col++)
                {
                    playField[row][col] = fieldLine[col];
                }
            }
        }
    }
}