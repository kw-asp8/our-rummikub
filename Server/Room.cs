using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Room
    {
        public const int MaxPlayers = 4;

        private Game game;
        public List<Player> Players { get; private set; } = new List<Player>();

        public Room(Game game)
        {
            this.game = game;
        }
        
        public bool IsEmpty()
        {
            return Players.Count == 0;
        }

        public Player FirstPlayer()
        {
            return Players[0];
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            if (game.IsEnabled && player == game.CurrentPlayer)
            {
                game.Rollback();
                game.NextTurn();
            }
            Players.Remove(player);
        }

        public RoomStatus ToStatus()
        {
            List<PlayerInfo> players =
                (from player in Players
                 select player.ToInfo())
                 .ToList();
            return new RoomStatus(players);
        }
    }
}
