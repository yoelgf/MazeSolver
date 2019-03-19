using MazeSolver.Business.Interfaces;

namespace MazeSolver.Business
{
    internal class RecursiveSolver : IAlgorithm
    {
        private int startX, startY; // Starting X and Y values of maze
        private int endX, endY;     // Ending X and Y values of maze
        private int width, height;
        private bool[,] wasHere;
        private char[,] finalSolution;


        public MazeSolution Solve(Maze maze)
        {

            startX = maze.InitialPosition[0];
            startY = maze.InitialPosition[1];
            endX = maze.FinalPosition[0];
            endY = maze.FinalPosition[1];
            width = maze.Dimension[0];
            height = maze.Dimension[1];

            this.wasHere = new bool[height, width];
            this.finalSolution = maze.Data;

            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    if (finalSolution[i, j] == '1') finalSolution[i, j] = '#';
                    else if (finalSolution[i, j] == '0') finalSolution[i, j] = ' ';
                    wasHere[i, j] = false;

                }

            }

            finalSolution[endY, endX] = 'E';
            bool hasSolution = recursiveSolve(startX, startY);
            finalSolution[startY, startX] = 'S';
            if (hasSolution == false)
            {
                char[,] noSolution = { { 'N', 'O', ' ', ' ', ' ', ' ', ' ', ' ' }, { 'S', 'O', 'L', 'U', 'T', 'I', 'O', 'N' } };
                return new MazeSolution
                {
                    Data = noSolution
                };
            }



            return new MazeSolution
            {
                Data = finalSolution
            };

        }



        private bool recursiveSolve(int x, int y)
        {

            if (x == width) x = 0;
            else if (x < 0) x = width - 1;
            else if (y == height) y = 0;
            else if (y < 0) y = height - 1;

            if (finalSolution[y, x] == 'E') return true;
            if (finalSolution[y, x] == '#' || wasHere[y, x]) return false;
            wasHere[y, x] = true;

            if (recursiveSolve(x + 1, y))
            {
                finalSolution[y, x] = 'X';
                return true;
            }

            if (recursiveSolve(x, y + 1))
            {
                finalSolution[y, x] = 'X';
                return true;
            }

            if (recursiveSolve(x - 1, y))
            {
                finalSolution[y, x] = 'X';
                return true;
            }

            if (recursiveSolve(x, y - 1))
            {
                finalSolution[y, x] = 'X';
                return true;
            }

            return false;
        }

    }
}


