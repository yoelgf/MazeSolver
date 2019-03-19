using MazeSolver.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace MazeSolver.Business
{
    internal class FileMazeReader : IMazeReader
    {
        private string path;

        public FileMazeReader(string filePath)
        {
            this.path = filePath;
        }

        public Maze Read()
        {
            List<string> data = File.ReadLines(this.path).ToList();

            string[] xyCordStart = data[1].Split(' ');
            var initialPos = Array.ConvertAll(xyCordStart, int.Parse);

            string[] xyCordStop = data[2].Split(' ');
            var finalPos = Array.ConvertAll(xyCordStop, int.Parse);

            string[] dim = data[0].Split(' ');
            var dimension = Array.ConvertAll(dim, int.Parse);
            data.RemoveRange(0, 3);



            char[,] mazeData = new char[dimension[1], dimension[0]];

            for (var i = 0; i < dimension[1]; i++)
            {
                var currentRow = data[i].Replace(" ", "").ToCharArray();
                for (var j = 0; j < dimension[0]; j++)
                {
                    mazeData[i, j] = currentRow[j];

                }

            }


            return new Maze
            {
                Dimension = dimension,
                FinalPosition = finalPos,
                InitialPosition = initialPos,
                Data = mazeData
            };
        }


    }
}
