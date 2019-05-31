using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ServerMain
    {
        static void Main(string[] args)
        {
            GameServer server = new GameServer();

            server.Start();
            Console.WriteLine("Server has been started!");

            while (true)
            {
                //Console.Write("> ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "stop":
                        server.Stop();
                        Console.WriteLine("Server has been stopped!");
                        return;
                    case "end":
                        server.Game.End();
                        server.CancelTurnTimer();
                        server.SendGameOver();
                        Console.WriteLine("The game has been ended.");
                        break;
                    default:
                        Console.WriteLine("'" + input + "' is not a valid command!");
                        break;
                }
            }
        }
    }
}
