﻿using System;
using System.Net.Sockets;
using Shem.AsyncEvents;
using Shem.Commands;
using Shem.Utils;
using System.Collections.Generic;
using Shem.Replies;

namespace Shem.test
{
    class Program
    {
        static void Main(string[] args)
        {
            TorController tc;
            uint port;
            string hostname, password, tmp;
            List<GetInfoReply> infos;

            Logger.ConsoleLogLevel = LogTypes.INFO;
            Logger.FileLogLevel = LogTypes.INFO;


            hostname = "127.0.0.1"; // NOTE: ipv6 is NOT supported.
            port = 9051;
            password = "test";

            try
            {

                /* testing
                Console.Write("Write the server host: ");
                hostname = Console.ReadLine();
                Console.Write("Insert your freaking control port: ");
                tmp = Console.ReadLine();
                if(!uint.TryParse(tmp, out port))
                {
                    Console.WriteLine("BAD BOY.");
                    return;
                }
                Console.Write("Enter your password: ");
                password = Console.ReadLine();
                */

                tc = new TorController(hostname, port);

                tc.OnAsyncEvent += tc_OnAsyncEvent;

                if (tc.Authenticate(password))
                {
                    Console.WriteLine("Authenticated successfully!");

                    tc.SendCommand(new SetEvents(false, AsyncEvents.AsyncEvents.INFO, AsyncEvents.AsyncEvents.ERR, AsyncEvents.AsyncEvents.DEBUG));
                    infos = tc.GetInfo(Informations.process_pid, Informations.process_user, Informations.version);
                    foreach (GetInfoReply info in infos)
                    {
                        Console.WriteLine("{0} -> {1}", info.Name, info.Value);
                    }
                }
                else
                {
                    Console.WriteLine("Wrong password.");
                }

                Console.WriteLine("Press a key to close the connection.");
                Console.ReadKey();

                tc.Close();
            }
            catch (SocketException iwontuseit)
            {
                Console.WriteLine("Can't connect to the server at \"{0}:{1}\".", hostname, port);
            }

            Console.WriteLine("Press a key to close the program.");
            Console.ReadKey();
        }

        static void tc_OnAsyncEvent(AsyncEvents.AsyncEvent obj)
        {
            if (obj is LogEvent)
            {
                Console.WriteLine(string.Format("Event -> {0} -> {1}", obj.Event, ((LogEvent)obj).LogMessage));
            }
        }

        public static LogTypes List { get; set; }
    }
}
