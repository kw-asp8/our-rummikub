using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    [Serializable]
    public class RoomStatus
    {
        public List<PlayerInfo> Players { get; private set; }

        public RoomStatus(List<PlayerInfo> players)
        {
            Players = players;
        }
    }
}
