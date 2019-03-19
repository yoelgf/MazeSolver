using MazeSolver.Business.Interfaces;
using System;
using System.IO;


namespace MazeSolver.Business
{
    internal class FileMazeSolutionWriter : IMazeSolutionWriter

    {
        public string path { get; set; }

        public FileMazeSolutionWriter(string filePath)
        {
            this.path = filePath;
        }


        public void Write(MazeSolution mazeSolution)
        {

            Print2DArray(mazeSolution.Data);
            Console.ReadLine();
        }


        public void Print2DArray<T>(T[,] matrix)
        {

            using (StreamWriter file = File.AppendText(path))
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        file.Write(matrix[i, j]);
                    }
                    file.WriteLine();
                }

                file.Close();
            }

        }
    }
}
