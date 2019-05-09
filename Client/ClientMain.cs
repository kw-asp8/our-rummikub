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
            Client client = new Client();
            client.RunInitialForm();
        }
    }
}
