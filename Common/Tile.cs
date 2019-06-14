using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public interface Tile
    {
        bool IsFromTable { get; set; }
    }

    [Serializable]
    public class NumberTile : Tile
    {
        public bool IsFromTable { get; set; } = false;
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

        public override bool Equals(object obj)
        {
            return obj is NumberTile tile &&
                   Color == tile.Color &&
                   Number == tile.Number;
        }

        public override int GetHashCode()
        {
            var hashCode = 442369656;
            hashCode = hashCode * -1521134295 + Color.GetHashCode();
            hashCode = hashCode * -1521134295 + Number.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(NumberTile lhs, NumberTile rhs)
        {
            if (Object.ReferenceEquals(lhs, null))
            {
                if (Object.ReferenceEquals(rhs, null))
                {
                    return true;
                }
                return false;
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(NumberTile lhs, NumberTile rhs)
        {
            return !(lhs == rhs);
        }
    }

    [Serializable]
    public class JokerTile : Tile
    {
        public bool IsFromTable { get; set; } = false;
        public TileColor Color { get; private set; }

        public JokerTile(TileColor color)
        {
            this.Color = color;
        }

        public TileColor getColor()
        {
            return Color;
        }

        public override bool Equals(object obj)
        {
            return obj is JokerTile tile &&
                   Color == tile.Color;
        }

        public override int GetHashCode()
        {
            return -1200350280 + Color.GetHashCode();
        }

        public static bool operator ==(JokerTile lhs, JokerTile rhs)
        {
            if (Object.ReferenceEquals(lhs, null))
            {
                if (Object.ReferenceEquals(rhs, null))
                {
                    return true;
                }
                return false;
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(JokerTile lhs, JokerTile rhs)
        {
            return !(lhs == rhs);
        }
    }

    [Serializable]
    public enum TileColor
    {
        RED, YELLOW, BLUE, BLACK
    }
}
