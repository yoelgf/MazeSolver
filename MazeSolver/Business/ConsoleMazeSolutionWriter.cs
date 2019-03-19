using MazeSolver.Business.Interfaces;
using System;

namespace MazeSolver.Business
{
    internal class ConsoleMazeSolutionWriter : IMazeSolutionWriter
    {
        public void Write(MazeSolution mazeSolution)
        {

            Print2DArray(mazeSolution.Data);

        }


        public static void Print2DArray<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
