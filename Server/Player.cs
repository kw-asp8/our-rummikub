using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Player
    {
        private const int maxTileAmount = 20;

        public Connection Connection { get; private set; }
        public string Nickname { get; private set; }
        public List<Tile> HoldingTiles { get; set; } = new List<Tile>();
        public bool HasEnrolled { get; private set; } = false;
        public List<TileSet> ReleasedTileSets { get; private set; } = new List<TileSet>();

        public Player(Connection connection, string nickname)
        {
            this.Connection = connection;
            this.Nickname = nickname;
        }

        public void ClearGameData()
        {
            HoldingTiles.Clear();
            HasEnrolled = false;
            ReleasedTileSets.Clear();
        }

        public int GetTileAmount()
        {
            return HoldingTiles.Count;
        }

        public bool CanTakeTile()
        {
            return GetTileAmount() < maxTileAmount;
        }

        public void SetEnrolled()
        {
            HasEnrolled = true;
        }

        public int GetScore()
        {
            return (from tile in HoldingTiles
                    select (tile is JokerTile) ? 30 : (tile as NumberTile).Number)
                    .Sum();
        }

        public PlayerInfo ToInfo()
        {
            return new PlayerInfo(Nickname, GetScore(), HoldingTiles.Count);
        }
    }
}
