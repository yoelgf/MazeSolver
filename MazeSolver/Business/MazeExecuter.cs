using MazeSolver.Business.Interfaces;
namespace MazeSolver.Business
{
    internal class MazeExecuter
    {
        private readonly IMazeReader reader;
        private readonly IMazeSolutionWriter writer;
        private readonly IAlgorithm algorithm;

        public MazeExecuter(IMazeReader reader, IMazeSolutionWriter writer, IAlgorithm algorithm)
        {
            this.reader = reader;
            this.writer = writer;
            this.algorithm = algorithm;
        }

        public void Execute()
        {
            var maze = this.reader.Read();
            var solution = this.algorithm.Solve(maze);
            this.writer.Write(solution);
        }
    }
}
