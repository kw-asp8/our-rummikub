using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    static class ClientMain
    {
        [STAThread]
        static void Main()
        {
            GameClient client = new GameClient();
            client.RunInitialForm();
        }
    }
}
