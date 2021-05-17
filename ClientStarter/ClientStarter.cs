//
// ClientStarter.cs
//
// Copyright 2017 OTSUKI Takashi
// SPDX-License-Identifier: Apache-2.0
//

using AIWolf.Lib;
using System;
using System.Reflection;

namespace AIWolf.Client
{
    /// <summary>
    /// Client starter class.
    /// </summary>
    public class ClientStarter
    {
        /// <summary>
        /// Main method.
        /// </summary>
        /// <param name="args">Arguments.</param>
        /// <remarks>
        /// Usage: [-h host] [-p port] [-t timeout] -c clientClass dllName [-r role] [-n name] [-d]
        /// </remarks>
        public static void Main(string[] args)
        {
            new ClientStarter(args).Start();
        }

        string host = "localhost";
        int port = 10000;
        string clsName;
        string dllName;
        Role roleRequest = Role.UNC; // No request by default.
        string playerName; // Obtained from the player by default.
        int timeout = -1; // No limit by default.
        bool useDefaultPlayer = false;

        ClientStarter(string[] args)
        {
            for (var i = 0; i < args.Length; i++)
            {
                if (args[i] == "-v")
                {
                    var v = Assembly.GetExecutingAssembly().GetName().Version;
                    Console.Error.WriteLine($"{v.Major}.{v.Minor}.{v.Build}");
                    Environment.Exit(0);
                }
                else if (args[i] == "-d")
                {
                    useDefaultPlayer = true;
                }
                else if (args[i] == "-p")
                {
                    i++;
                    if (i < args.Length || !args[i].StartsWith("-"))
                    {
                        if (!int.TryParse(args[i], out port))
                        {
                            Console.Error.WriteLine($"ClientStarter: Invalid port {args[i]}.");
                            Usage();
                        }
                    }
                    else
                    {
                        Usage();
                    }
                }
                else if (args[i] == "-h")
                {
                    i++;
                    if (i < args.Length || !args[i].StartsWith("-"))
                    {
                        host = args[i];
                    }
                    else
                    {
                        Usage();
                    }
                }
                else if (args[i] == "-c")
                {
                    i++;
                    if (i < args.Length || !args[i].StartsWith("-"))
                    {
                        clsName = args[i];
                    }
                    else
                    {
                        Usage();
                    }
                    i++;
                    if (i < args.Length || !args[i].StartsWith("-"))
                    {
                        dllName = args[i];
                    }
                    else
                    {
                        Usage();
                    }
                }
                else if (args[i] == "-r")
                {
                    i++;
                    if (i < args.Length || !args[i].StartsWith("-"))
                    {
                        if (!Enum.TryParse(args[i], out roleRequest))
                        {
                            Console.Error.WriteLine($"ClientStarter: Invalid role {args[i]}.");
                            Usage();
                        }
                    }
                    else
                    {
                        Usage();
                    }
                }
                else if (args[i] == "-n")
                {
                    i++;
                    if (i < args.Length || !args[i].StartsWith("-"))
                    {
                        playerName = args[i];
                    }
                    else
                    {
                        Usage();
                    }
                }
                else if (args[i] == "-t")
                {
                    i++;
                    if (i < args.Length || !args[i].StartsWith("-"))
                    {
                        if (!int.TryParse(args[i], out timeout))
                        {
                            Console.Error.WriteLine($"ClientStarter: Invalid timeout {args[i]}.");
                            Usage();
                        }
                    }
                    else
                    {
                        Usage();
                    }
                }
            }
            if (port < 0 || (!useDefaultPlayer && String.IsNullOrEmpty(clsName)))
            {
                Usage();
            }
        }

        void Start()
        {
            IPlayer player;
            if (useDefaultPlayer)
            {
                player = new DummyPlayer();
            }
            else
            {
                player = PlayerLoader.Load(className: clsName, dllName: dllName);
            }

            TcpipClient client = new TcpipClient(host, port, playerName, roleRequest, timeout);
            try
            {
                client.Connect(player);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"ClientStarter: Error in running player. {e.StackTrace}");
                throw;
            }
        }

        void Usage()
        {
            Console.Error.WriteLine("Usage: ClientStarter [-h host] [-p port] -c clientClass dllName [-r roleRequest] [-n name] [-t timeout] [-d] [-v]");
            Console.Error.WriteLine("            -h host : to specify server host");
            Console.Error.WriteLine("            -p port : to specify server port");
            Console.Error.WriteLine("            -c clientClass dllName : to specify the class of player and the dll containing it");
            Console.Error.WriteLine("            -r roleRequest : to specify player's role");
            Console.Error.WriteLine("            -n name : to specify player's name");
            Console.Error.WriteLine("            -d : to use dummy player");
            Console.Error.WriteLine("            -v : to print version");
            Environment.Exit(0);
        }
    }
}
