using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][,] betTable = new int[12][,];

            betTable[0] = new int[2, 3] {
                {1,2,3 },
                {0,1,0 }
            };
            betTable[1] = new int[2, 3] {
                {4,5,6 },
                {1,0,1 }
            };
            betTable[2] = new int[2, 3] {
                {7,8,9 },
                {0,1,0 }
            };
            betTable[3] = new int[2, 3] {
                {10,11,12 },
                {1,1,0 }
            };
            betTable[4] = new int[2, 3] {
                {13,14,15 },
                {1,0,1 }
            };
            betTable[5] = new int[2, 3] {
                {16,17,18 },
                {0,1,0 }
            };
            betTable[6] = new int[2, 3] {
                {19,20,21 },
                {0,1,0 }
            };
            betTable[7] = new int[2, 3] {
                {22,23,24 },
                {1,0,1 }
            };
            betTable[8] = new int[2, 3] {
                {25,26,27 },
                {0,1,0 }
            };
            betTable[9] = new int[2, 3] {
                {28,29,30 },
                {1,1,0 }
            };
            betTable[10] = new int[2, 3] {
                {31,32,33 },
                {1,0,1 }
            };
            betTable[11] = new int[2, 3] {
                {34,35,36 },
                {0,1,0 }
            };


            Random rnd = new Random();
            int number = rnd.Next(1, 38);
            //Console.WriteLine($"{number}");
            //Console.WriteLine($"{Convert.ToString(betTable[4][0,1])}");

            if (number < 37)
            {
                var returns = findNumber(betTable, number);
                
                //Console.WriteLine($"the row that it is in is number {returns.Item1}");
                //Console.WriteLine($"the column that the number is in is: {returns.Item2}");
                //display the winning number
                Console.WriteLine($"the number that won is {number}");

                //find even or odd and display
                string eOro = evenOrOdd(number);

                Console.WriteLine($"the winning number is an {eOro}");
                //display winning color
                Console.WriteLine($"the winning color is {returns.Item3}");
                //decide high or low and display
                string highLow = highOrLow(number);
                Console.WriteLine($"the winning number is considered {highLow}");

                //display the row that was won
                string row = decideRows(returns.Item1);
                Console.WriteLine($"The winning number is in the {row} row of 12");
                //decide the columns that won
                string column = decideColumn(returns.Item2);
                Console.WriteLine($"The winning number is in the {column} column.");

                //determine the street
                Console.WriteLine($"the winning street is {betTable[returns.Item1][0,0]}, {betTable[returns.Item1][0,1]}, " +
                    $"{betTable[returns.Item1][0,2]}");

                //determine the double rows
                doubleRows(returns.Item1, betTable);

                //determine the splits
                splits(returns.Item1, returns.Item2, betTable);
                //determine the corners
                corners(returns.Item1, returns.Item2, betTable);
                //corners(0, 1, betTable);
               // int letsSee = 0 - 1;
                //Console.WriteLine($"{letsSee}");
            }
            else if (number == 37)
            {
                Console.WriteLine("The only winning bet is the one on single 0");
            }
            else if (number == 38)
            {
                Console.WriteLine("The only winning bet is the one on double 0");

            }

        }

        private static string decideRows(int row)
        {
            if (row < 4)
            {
                return "First";
            }
            else if (row > 3 && row < 8)
            {
                return "Second";
            }
            else
            {
                return "Third";
            }
        }

        private static void corners(int row, int column, int[][,] betTable)
        {
            int rowPlus = row + 1;
            int rowMinus = row - 1;
            int columnPlus = column + 1;
            int columnMinus = column - 1;

            Console.Write("The winning corners are: ");

            if (columnPlus < 3 && rowPlus < 12 )
            {
                //clockwise down
                Console.Write($"{betTable[row][0, column]}, {betTable[row][0, columnPlus]}, {betTable[rowPlus][0, columnPlus]}, {betTable[rowPlus][0, column]}");
                Console.WriteLine("and");
            }
            if (rowMinus >= 0 && columnPlus < 3 )
            {
                //clockwise up
                Console.Write($"{betTable[row][0, column]}, {betTable[rowMinus][0, column]}, {betTable[rowMinus][0, columnPlus]}, {betTable[row][0, columnPlus]}");
                Console.WriteLine("and");
            }
            if (columnMinus >= 0 && rowPlus < 12)
            {
                //counterclockwise down
                Console.Write($"{betTable[row][0, column]}, {betTable[row][0, columnMinus]}, {betTable[rowPlus][0, columnMinus]}, {betTable[rowPlus][0, column]}");
                Console.WriteLine("and");
            }
            if (columnMinus >= 0 && rowMinus >= 0)
            {
                //counterclockwise up
                Console.Write($"{betTable[row][0, column]}, {betTable[row][0, columnMinus]}, {betTable[rowMinus][0, columnMinus]}, {betTable[rowMinus][0, column]}");

            }
            
        }

        private static void splits(int row, int column, int[][,] betTable)
        {
            Console.Write("The winning splits are: ");
            if (column == 0)
            {
                if (row > 0 && row < 11)
                {
                    Console.Write($"{betTable[row][0,column]}, {betTable[row][0,column + 1]} or {betTable[row][0, column]}, {betTable[row + 1][0, column]} or " +
                        $"{betTable[row][0, column]}, {betTable[row - 1][0, column]}");
                }
                else if (row == 0)
                {
                    Console.Write($"{betTable[row][0, column]}, {betTable[row][0, column + 1]} or {betTable[row][0, column]}, {betTable[row + 1][0, column]}");
                }
                else if (row == 11)
                {
                    Console.Write($"{betTable[row][0, column]}, {betTable[row][0, column + 1]} or {betTable[row][0, column]}, {betTable[row - 1][0, column]}");
                }
            }

            else if (column == 1)
            {
                if (row > 0 && row < 11)
                {
                    Console.Write($"{betTable[row][0, column]}, {betTable[row][0, column + 1]} or {betTable[row][0, column]}, {betTable[row + 1][0, column]} or " +
                        $"{betTable[row][0, column]}, {betTable[row - 1][0, column]} or {betTable[row][0, column]}, {betTable[row][0, column - 1]}");
                }
                else if (row == 0)
                {
                    Console.Write($"{betTable[row][0, column]}, {betTable[row][0, column + 1]} or {betTable[row][0, column]}, {betTable[row + 1][0, column]} or " +
                       $" or {betTable[row][0, column]}, {betTable[row][0, column - 1]}");
                }
                else if (row == 11)
                {
                    Console.Write($"{betTable[row][0, column]}, {betTable[row][0, column + 1]} or " +
                       $"{betTable[row][0, column]}, {betTable[row - 1][0, column]} or {betTable[row][0, column]}, {betTable[row][0, column - 1]}");
                }
            }
            else if (column == 2)
            {
                if (row > 0 && row < 11)
                {
                    Console.Write($"{betTable[row][0, column]}, {betTable[row + 1][0, column]} or " +
                       $"{betTable[row][0, column]}, {betTable[row - 1][0, column]} or {betTable[row][0, column]}, {betTable[row][0, column - 1]}");
                }
                else if (row == 0)
                {
                    Console.Write($" {betTable[row][0, column]}, {betTable[row + 1][0, column]} or " +
                       $"{betTable[row][0, column]}, {betTable[row][0, column - 1]}");
                }
                else if (row == 11)
                {
                    Console.Write($"{betTable[row][0, column]}, {betTable[row - 1][0, column]} or {betTable[row][0, column]}, {betTable[row][0, column - 1]}");
                }
            }
            Console.WriteLine("");
        }

        private static void doubleRows(int row, int[][,] betTable)
        {
            Console.Write("The winning double rows are: ");
            if (row == 0)
            {
                //Console.Write("The w");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{betTable[row][0, i]}, ");
                }
                Console.Write(" and ");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{betTable[row + 1][0, i]}, ");
                }
            }

            if (row == 11)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{betTable[row -1][0, i]}, ");
                }
                Console.Write(" and ");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{betTable[row][0, i]}, ");
                }
            }
            else if(row > 0 && row < 11)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{betTable[row][0, i]}, ");
                }
                Console.Write(" and ");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{betTable[row + 1][0, i]}, ");
                }

                Console.Write(" or ");

                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{betTable[row - 1][0, i]}, ");
                }
                Console.Write(" and ");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{betTable[row][0, i]}, ");
                }
            }

            Console.WriteLine("");
        }

        private static string decideColumn(int columnNumber)
        {
            if (columnNumber == 0)
            {
                return "First";
            }
            else if (columnNumber == 1)
            {
                return "Second";
            }
            else
            {
                return "Third";
            }
        }

        private static string highOrLow(int number)
        {
            if (number < 19)
            {
                return "Low";
            }
            else
            {
                return "High";
            }
        }

        // Using Tuple
        static (int, int, string) findNumber(int[][,] table, int randomNumber) 
        {
            int first = 0;
            int middle = 3;
            string last = "black";

            if (randomNumber < 37)
            {
                for (int i = 0; i < 12; i++)
                {
                    for (int p = 0; p < 3; p++)
                    {
                        if (table[i][0, p] == randomNumber)
                        {
                            first = i;
                            middle = p;
                            if (table[i][1, p] == 0)
                            {
                                last = "red";
                            }
                            else
                            {
                                last = "black";
                            }

                        }
                    }
                }

            }

            return (first, middle, last); 
        }

        private static string evenOrOdd(int number)
        {
            if (number%2 == 1)
            {
                return "odd";
            }
            else
            {
                return "even";
            }
        }
    }
}
