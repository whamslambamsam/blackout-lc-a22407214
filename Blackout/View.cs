using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using Spectre.Console;

namespace Blackout
{
    public class View
    {
        public string DifficultySelect()
        {
            var table = new Table();
                table.AddColumn("Difficulty");
                table.AddColumn("Size");
                table.AddRow("[green]Easy[/]", "3 x 3");
                table.AddRow("[yellow]Medium[/]", "5 x 5");
                table.AddRow("[red]Hard[/]", "8 x 8");
                table.AddRow("Custom", "? x ?");
            AnsiConsole.Write(table);

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[blue]Select difficulty:[/] ")
                    .AddChoices("[green]Easy[/]", 
                    "[yellow]Medium[/]", 
                    "[red]Hard[/]", 
                    "Custom")
                    );
            
            AnsiConsole.MarkupLine($"[blue]Difficulty chosen:[/] {choice}");
            // Green square - U+1F7E9; White square - U+2B1C; Yellow square - U+1F7E8;
            
            return choice;
        }

        public string ReturnChoice()
        {
            string input = DifficultySelect();
            return input;
        }
    }
}