using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    [Serializable]
    public class PlayerInfo
    {
        public string Nickname { get; private set; }

        public int Score { get; private set; }

        public PlayerInfo(string nickname, int score)
        {
            Nickname = nickname;
            Score = score;
        }
    }
}
