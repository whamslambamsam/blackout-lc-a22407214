using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using Spectre.Console;

namespace Blackout
{
    public class Model
    {
        /// <summary>
        /// Método usado para criar a grid
        /// dependendo da dificuldade que o jogador selecionou.
        /// </summary>
        /// <param name="length">
        /// Largura total da grid.
        /// </param>
        /// <param name="width">
        /// Altura total da grid.
        /// </param>
        /// <returns>
        /// As dimensões da grid criada para o jogador.
        /// </returns>
        /// <remarks>
        /// Foi usado AI para perceber como é que poderiamos fazer as grids.
        /// </remarks>
        public bool[,] GridSize(int length, int width)
        {
            bool[,] grid = new bool[length, width];
            return grid;
        }
    }
}