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

        public GameStatus(bool isEnabled, PlayerInfo currentPlayer)
        {
            IsEnabled = isEnabled;
            CurrentPlayer = currentPlayer;
        }
    }
}
