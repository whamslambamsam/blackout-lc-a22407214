using System;
using System.Xml.Serialization;
using Microsoft.VisualBasic;
using Spectre.Console;
using static Blackout.View;

namespace Blackout
{
    public class Controller
    {
        /// Foi usado AI para dar debug e concertar um erro com looping de inputs
        /// A lógica e concepção foi feita por nós, apenas foi usado Inteligência
        /// Artificial para evitar o erro.
        public (int, int) GridBuilder(string choice, View view)
        {
            return choice switch
            {
                "[green]Easy[/]" => (3, 3),
                "[yellow]Medium[/]" => (5, 5),
                "[red]Hard[/]" => (8, 8),
                "Custom" => (view.RequestRow(), view.RequestColumn()),
            };
        }
    }
}