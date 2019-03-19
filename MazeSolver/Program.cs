namespace MazeSolver
{
    using MazeSolver.Business;
    using System;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Introduce file path or type exit");
                var filePath = Console.ReadLine();
                if (filePath == "exit") Environment.Exit(0);
                while (File.Exists(filePath) == false)
                {
                    Console.WriteLine("Wrong File Path,try again or type exit");
                    filePath = Console.ReadLine();
                    if (filePath == "exit") Environment.Exit(0);
                }
                var executer = new MazeExecuter(new FileMazeReader(filePath), new ConsoleMazeSolutionWriter(), new RecursiveSolver());
                executer.Execute();
                Console.ReadLine();

            }

        }
    }
}
