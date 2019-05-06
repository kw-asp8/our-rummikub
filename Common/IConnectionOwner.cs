using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public interface IConnectionOwner
    {
        void Handle(Connection connection, Packet packet);

        void HandleDisconnection(Connection connection);
    }
}
