using System;
using Spectre.Console;

namespace Blackout
{
    public class View
    {
        public void DifficultySelect()
        {
            var table = new Table();
                table.AddColumn("Difficulty");
                table.AddColumn("Size");
                table.AddRow("[green]Easy[/]", "3 x 3");
                table.AddRow("[yellow]Medium[/]", "5 x 5");
                table.AddRow("[red]Hard[/]", "8 x 8");
                table.AddRow("Custom", "? x ?");
            AnsiConsole.Write(table);
        }
    }
}