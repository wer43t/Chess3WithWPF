/* Abraros.S.D 
  Chess-3
  15.03.2021
  */

using FigureCore;
using System;

namespace chess_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string figName = Console.ReadLine();
            int x1 = Convert.ToInt32(Console.ReadLine());
            int y1 = Convert.ToInt32(Console.ReadLine());
            int x2 = Convert.ToInt32(Console.ReadLine());
            int y2 = Convert.ToInt32(Console.ReadLine());

            bool isValid = false;
            Figure figure;

            switch (figName)
            {
                case "N":
                    figure = new Knight(x1, y1);
                    break;
                case "Q":
                    figure = new Queen(x1, y1);
                    break;
                case "B":
                    figure = new Bishop(x1, y1);
                    break;
                case "K":
                    figure = new King(x1, y1);
                    break;
                case "R":
                    figure = new Rook(x1, y1);
                    break;
                default:
                    return;
            }
            isValid = figure.Move(x2, y2);
            Console.WriteLine(isValid ? "YES" : "NO");
        }
    }
}
