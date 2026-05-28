using System;
using System.Xml.Serialization;
using Microsoft.VisualBasic;
using Spectre.Console;
using static Blackout.View;

namespace Blackout
{
    public class Controller
    {
        /// <summary>
        /// Determines the size of the grid based on
        /// the user's choice given on View's DifficultySelect().
        /// </summary>
        /// <param name="choice">
        /// Argument that uses the user's choice.
        /// </param>
        /// <param name="view">
        /// Argument that calls a variable of the View class.
        /// </param>
        /// <returns>
        /// A Tuple whose values depend on choice's value.
        /// If the user's choice is "Custom", calls methods that ask for further
        /// inputs.
        /// </returns>
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

        /// <summary>
        /// Method for the player's choice of gamemode.
        /// </summary>
        /// <param name="choice">
        /// The choice the player makes.
        /// </param>
        /// <param name="view">
        /// Calls for the View.cs code.
        /// </param>
        /// <returns>
        /// Returns the gamemode the player choose.
        /// </returns>
        public int DifficultyTouch(string choice, View view)
        {
            return choice switch
            {
                "[green]Easy[/]" => 2,
                "[yellow]Medium[/]" => 4,
                "[red]Hard[/]" => 10,
                "Custom" => view.RequestTouch(),
            };
        }

        /// <summary>
        /// Method that randomizes, depending on grid size, which cell are activated before the start of the game.
        /// </summary>
        /// <param name="size">
        /// Since the lenght and width are the same, size can be used to get the number of both.
        /// </param>
        /// <param name="touches">
        /// The amount of cells ativated before te start of the game.
        /// </param>
        public void SquareAssort(bool[,] size, int touches)
        {
            Random rng = new Random();

            int length = size.GetLength(0); // IA para saber como ler valores
            int width = size.GetLength(1); // das grids

            // Usado IA para saber como fazer os "touches" aleatórios
            for (int i = 0; i < touches; i++)
            {
                int randCellX = rng.Next(length);
                int randCellY = rng.Next(width);

                size[randCellX, randCellY] = true;

                if (randCellX > 0)
                    size[randCellX - 1, randCellY] = 
                        true;

                if (randCellX < length - 1)
                    size[randCellX + 1, randCellY] = 
                        true;

                if (randCellY > 0)
                    size[randCellX, randCellY - 1] = 
                        true;

                if (randCellY < width - 1)
                    size[randCellX, randCellY + 1] = 
                        true;
            }
        }

        /// <summary>
        /// Method for the initial position of the cursor.
        /// </summary>
        /// <param name="size">
        /// The number of collums and rows in the grid.
        /// </param>
        /// <returns>
        /// Returns the initial position for the cursor in the grid.
        /// </returns>
        public (int, int) InitialPos(bool[,] size)
        {
            int inputX = size.GetLength(0) / 2;
            int inputY = size.GetLength(1) / 2;  

            return (inputX, inputY);
        }

        /// <summary>
        /// Method to deativated cells.
        /// </summary>
        /// <param name="grid">
        /// Grid size.
        /// </param>
        /// <param name="x">
        /// The row.
        /// </param>
        /// <param name="y">
        /// The collum.
        /// </param>
        void Toggle(bool[,] grid, int x, int y)
        {
            grid[x, y] = !grid[x, y];
        }

        /// <summary>
        /// Method that deativates the cells based on location.
        /// </summary>
        /// <param name="size">
        /// Grid size.
        /// </param>
        /// <param name="cursor">
        /// In which cell the cursor is present.
        /// </param>
        public void FlipCell(bool[,] size, (int, int) cursor)
        {
            int length = size.GetLength(0);
            int width = size.GetLength(1);
            
            int cursorX = cursor.Item1;
            int cursorY = cursor.Item2;

            Toggle(size, cursorX, cursorY);

            if (cursorX > 0) 
            {
                Toggle(size, cursorX - 1, cursorY); // - para cima       
            }

            if (cursorX < length - 1) 
            {
                Toggle(size, cursorX + 1, cursorY);
                Toggle(size, cursorX + 1, cursorY + 1);
            }

            if (cursorY > 0)
            {
                Toggle(size, cursorX, cursorY - 1); // - para a esquerda
                Toggle(size, cursorX - 1, cursorY - 1);
            }

            if (cursorY < width - 1)
            { 
                Toggle(size, cursorX, cursorY + 1);
                Toggle(size, cursorX + 1, cursorY + 1);
            }

            if (cursorX > 0 && cursorY > 0) 
            {
                Toggle(size, cursorX - 1, cursorY -1);            
            }

            if (cursorX < length - 1 && cursorY < width - 1) 
            {
                Toggle(size, cursorX + 1, cursorY + 1);
            }

            if (cursorX > 0 && cursorY < width - 1) 
            {
                Toggle(size, cursorX - 1, cursorY + 1);            
            }

            if (cursorX < length - 1 && cursorY > 0) 
            {
                Toggle(size, cursorX + 1, cursorY - 1);
            }

            if (cursorX > 0 && cursorY < width - 1) 
            {
                Toggle(size, cursorX - 1, cursorY + 1);            
            }

            if (cursorX < length - 1 && cursorY > 0) 
            {
                Toggle(size, cursorX + 1, cursorY - 1);
            }
        }

        /// <summary>
        /// Method that verefies when user inputs to deactivate cells.
        /// </summary>
        /// <param name="size">
        /// Grid size.
        /// </param>
        /// <param name="cursor">
        /// Cursor position.
        /// </param>
        /// <returns>
        /// Returns the location of the cursor when the user inputs.
        /// </returns>
        public (int, int) HandleInput(bool[,] size, (int, int) cursor)
        {
            int cursorX = cursor.Item1;
            int cursorY = cursor.Item2;

            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    cursorX--;
                    break;

                case ConsoleKey.DownArrow:
                    cursorX++;
                    break;

                case ConsoleKey.LeftArrow:
                    cursorY--;
                    break;

                case ConsoleKey.RightArrow:
                    cursorY++;
                    break;
                
                case ConsoleKey.Enter:
                    FlipCell(size, cursor);
                    break;
            }
            
            cursorX = Math.Clamp(cursorX, 0, size.GetLength(0) - 1);
            cursorY = Math.Clamp(cursorY, 0, size.GetLength(1) - 1);

            return (cursorX, cursorY);
        }

        /// <summary>
        /// Method that checks for if the grid has been cleared.
        /// </summary>
        /// <param name="size">
        /// Grid size.
        /// </param>
        /// <returns>
        /// Returns false during the game, and true when the objective has been met.
        /// </returns>
        public bool CheckWin(bool[,] size)
        {
            int length = size.GetLength(0);
            int width = size.GetLength(1);

            for (int x = 0; x < length; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    if (size[x, y])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}