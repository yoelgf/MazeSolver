namespace MazeSolver.Business.Interfaces
{
    interface IAlgorithm
    {
        MazeSolution Solve(Maze maze);
    }
}
