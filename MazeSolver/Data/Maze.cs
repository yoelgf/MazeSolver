namespace MazeSolver.Business
{
    internal class Maze
    {
        public int[] InitialPosition { get; set; }
        public int[] FinalPosition { get; set; }
        public int[] Dimension { get; set; }
        public char[,] Data { get; set; }
    }
}
