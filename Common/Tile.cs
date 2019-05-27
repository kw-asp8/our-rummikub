﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public interface Tile { }

    public class NumberTile : Tile
    {
        public TileColor Color { get; private set; }
        public int Number { get; private set; }

        public NumberTile(TileColor color, int number)
        {
            this.Color = color;
            this.Number = number;
        }

        public TileColor getColor()
        {
            return Color;
        }
    }

    public class JokerTile : Tile { }

    public enum TileColor
    {
        RED, YELLOW, BLUE, BLACK
    }
}
