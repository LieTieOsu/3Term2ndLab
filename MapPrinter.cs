namespace Kse.Algorithms.Samples
{
    using System;
    using System.Collections.Generic;

    public class MapPrinter
    {
        public void Print(string[,] maze, List<Point> way)
        {
            PrintTopLine();
            for (var pathedI = 0; pathedI <= way.Count - 1; pathedI++)
            {
                var newX = way[pathedI].Column;
                var newY = way[pathedI].Row;
                maze[newX, newY] = "$";
            }

            maze[way[0].Column, way[0].Row] = "A";
            maze[way[way.Count - 1].Column, way[way.Count - 1].Row] = "B";

            for (var row = 0; row < maze.GetLength(1); row++)
            {
                Console.Write($"{row}\t");
                for (var column = 0; column < maze.GetLength(0); column++)
                {
                    Console.Write(maze[column, row]);
                }

                Console.WriteLine();
            }

            void PrintTopLine()
            {
                Console.Write($" \t");
                for (int i = 0; i < maze.GetLength(0); i++)
                {
                    Console.Write(i % 10 == 0? i / 10 : " ");
                }
    
                Console.Write($"\n \t");
                for (int i = 0; i < maze.GetLength(0); i++)
                {
                    Console.Write(i % 10);
                }
    
                Console.WriteLine("\n");
            }
        }
    }
}
© 2022 GitHub, Inc.
Terms
Privacy
Security
