/* Abrarov.S.D 
  Chess-3
  15.03.2021
  */

using System;

namespace FigureCore
{

    public class Figure
    {
        protected int X1;
        protected int Y1;

        public Figure(int x1, int y1)
        {
            X1 = x1;
            Y1 = y1;
        }

        public bool Move(int x2, int y2)
        {
            if (CanMove(x2, y2))
            {
                X1 = x2;
                Y1 = y2;
                return true;
            }
            else
                return false;
        }

        public virtual bool CanMove(int x2, int y2)
        {
            return false;
        }
    }

    public class King : Figure
    {
        public King(int x1, int y1) : base(x1, y1) { }

        public override bool CanMove(int x2, int y2)
        {
            return (((Math.Abs(X1 - x2) <= 1) && (Math.Abs(y2 - Y1)) <= 1));
        }

    }

public class Queen : Figure
    {
        public Queen(int x1, int y1) : base(x1, y1) { }

        public override bool CanMove(int x2, int y2)
        {
            return (X1 == x2 || Y1 == y2) || (Math.Abs(x2 - X1) == (Math.Abs(y2 - Y1)));
        }
    }

public class Rook : Figure
    {
        public Rook(int x1, int y1) : base(x1, y1) { }

        public override bool CanMove(int x2, int y2)
        {
            return ((X1 == x2 || Y1 == y2) & (X1 != x2 || Y1 != y2));
        }
    }

public class Bishop : Figure
    {
        public Bishop(int x1, int y1) : base(x1, y1) { }

        public override bool CanMove(int x2, int y2)
        {
            return (Math.Abs(x2 - X1) == Math.Abs(y2 - Y1));
        }
    }

public class Knight : Figure
    {
        public Knight(int x1, int y1) : base(x1, y1) { }

        public override bool CanMove(int x2, int y2)
        {
            return (((Math.Abs(X1 - x2)) == 2) && (Math.Abs(Y1 - y2) == 1) || ((Math.Abs(X1 - x2)) == 1) && (Math.Abs(Y1 - y2) == 2));
        }
    }
}