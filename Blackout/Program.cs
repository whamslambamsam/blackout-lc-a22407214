using System;
using Spectre.Console;

namespace Blackout
{
    public class Program
    {
        private static void Main(string[] args)
        {
            View viewer = new View();
            Controller control = new Controller();

            viewer.DifficultySelect();
            control.GridBuilder();
            viewer.Load();
        }
    }
}
