using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    [Serializable]
    public class GameStatus
    {
        public bool IsEnabled { get; private set; }
        public PlayerInfo CurrentPlayer { get; private set; }
        public List<Tile> HoldingTiles { get; private set; }

        private Dictionary<string, int> holdingTilesNumDic;

        public GameStatus(bool isEnabled, PlayerInfo currentPlayer, List<Tile> holdingTiles,
            Dictionary<string, int> holdingTilesNumDic)
        {
            IsEnabled = isEnabled;
            CurrentPlayer = currentPlayer;
            HoldingTiles = holdingTiles;
            this.holdingTilesNumDic = holdingTilesNumDic;
        }

        public int GetHoldingTilesAmountOf(PlayerInfo player)
        {
            return holdingTilesNumDic[player.Nickname];
        }
    }
}
