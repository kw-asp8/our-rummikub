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

        public int TileAmount { get; private set; }

        public PlayerInfo(string nickname, int score, int tileAmount)
        {
            Nickname = nickname;
            Score = score;
            TileAmount = tileAmount;
        }

        public override bool Equals(object obj)
        {
            return obj is PlayerInfo info &&
                   Nickname == info.Nickname;
        }

        public override int GetHashCode()
        {
            return -739948555 + EqualityComparer<string>.Default.GetHashCode(Nickname);
        }
    }
}
