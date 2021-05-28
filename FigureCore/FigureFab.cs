﻿using System.Collections.Generic;
using FigureCore;

public class FiguresData
{
    public string Name;
    public Dictionary<string, int> Data;

    public override string ToString()
    {
        return Name;
    }
}

static public class FigureFab
{
    public static Figure Make(FiguresData figData)
    {
        Figure fig = null;

        switch (figData.Name)
        {
            case "King":
                fig = new King(figData.Data["X"], figData.Data["Y"]);
                break;
            case "Queen":
                fig = new Queen(figData.Data["X"], figData.Data["Y"]);
                break;
            case "Rook":
                fig = new Rook(figData.Data["X"], figData.Data["Y"]);
                break;
            case "Bishop":
                fig = new Bishop(figData.Data["X"], figData.Data["Y"]);
                break;
            case "Knight":
                fig = new Knight(figData.Data["X"], figData.Data["Y"]);
                break;
        }

        return fig;
    }

    public static List<FiguresData> InitFiguresData()
    {
        var figuresData = new List<FiguresData>();

        figuresData.Add(new FiguresData
        {
            Name = "King",
            Data = new Dictionary<string, int>
                {
                    { "X", 1 },
                    { "Y", 1 }
                }
        });

        figuresData.Add(new FiguresData
        {
            Name = "Queen",
            Data = new Dictionary<string, int>
                {
                    { "X", 1 },
                    { "Y", 1 }
                }
        });

        figuresData.Add(new FiguresData
        {
            Name = "Rook",
            Data = new Dictionary<string, int>
                {
                    { "X", 1 },
                    { "Y", 1 }
                }
        });

        figuresData.Add(new FiguresData
        {
            Name = "Bishop",
            Data = new Dictionary<string, int>
                {
                    { "X", 1 },
                    { "Y", 1 }
                }
        });

        figuresData.Add(new FiguresData
        {
            Name = "Knight",
            Data = new Dictionary<string, int>
                {
                    { "X", 1 },
                    { "Y", 1 }
                }
        });

        return figuresData;
    }
}