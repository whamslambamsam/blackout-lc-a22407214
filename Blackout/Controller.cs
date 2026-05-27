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
        /// Determina as dimensões da grelha com base
        /// na dificuldade selecionada pelo utilizador.
        /// </summary>
        /// <param name="choice">
        /// Dificuldade escolhida pelo utilizador.
        /// </param>
        /// <param name="view">
        /// Instância responsável pela interação com o utilizador.
        /// </param>
        /// <returns>
        /// Um tuplo contendo o número de linhas e colunas da grelha.
        /// </returns>
        /// <remarks>
        /// Foi usado AI para dar debug e concertar um erro com looping de inputs
        /// A lógica e concepção foi feita por nós, apenas foi usado Inteligência
        /// Artificial para evitar o erro.
        /// </remarks>
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

        public int DifficultyTouch(string choice, View view)
        {
            return choice switch
            {
                "[green]Easy[/]" => 2,
                "[yellow]Medium[/]" => 4,
                "[red]Hard[/]" => 6,
                "Custom" => view.RequestTouch(),
            };
        }

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
    }
}