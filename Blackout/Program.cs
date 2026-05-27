using System;
using Spectre.Console;

namespace Blackout
{
    public class Program
    {
        /// <summary>
        /// O Main reune cada class da abordagem MVC,
        /// partilhando variáveis usadas em diferentes métodos.
        /// </summary>
        private static void Main(string[] args)
        {
            View viewer = new View();
            Controller control = new Controller();
            Model model = new Model();

            Console.WriteLine();
            
            string choice = viewer.DifficultySelect();
            (int rows, int cols) = control.GridBuilder(choice, viewer);
            int touch = control.DifficultyTouch(choice, viewer);

            viewer.Load(rows, cols);
            bool[,] dimensions = model.GridSize(rows, cols);
            control.SquareAssort(dimensions, touch);
            viewer.GridDraw(dimensions);
        }
    }
}