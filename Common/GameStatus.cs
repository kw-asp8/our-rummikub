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

        private Dictionary<string, int> holdingTilesNumDic;

        public GameStatus(bool isEnabled, PlayerInfo currentPlayer, Dictionary<string, int> holdingTilesNumDic)
        {
            IsEnabled = isEnabled;
            CurrentPlayer = currentPlayer;
            this.holdingTilesNumDic = holdingTilesNumDic;
        }

        public int GetHoldingTilesAmountOf(PlayerInfo player)
        {
            return holdingTilesNumDic[player.Nickname];
        }
    }
}
