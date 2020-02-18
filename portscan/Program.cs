using System;
using System.Net.Sockets;

namespace portscan
{
    class Program
    {
        private static bool Scan(string host, int port)
        {
            TcpClient tcpClient = new TcpClient { };
            try
            {
                tcpClient.Connect(host, port);
                tcpClient.Close();
                return true;
            }
            catch
            {
                tcpClient.Close();
                return false;
            }
        }

        private static void Help()
        {
            string help = "\n\tUsage: portscan.exe <ip address> <port>" +
                "\n\tExample: portscan.exe 192.168.1.2 22\n";
            Console.WriteLine(help);
        }

        static void Main(string[] args)
        {
            if(args.Length != 2)
            {
                Console.WriteLine("[-] Incorrect arguments supplied");
                Help();
                Environment.Exit(1);
            }
            else
            {
                int port = 0;
                try
                {
                    port = Int32.Parse(args[1]);
                }
                catch
                {
                    Console.WriteLine("[!] Port argument is not a valid port number");
                    Help();
                    Environment.Exit(1);
                }
                if(Scan(args[0], port))
                {
                    Console.WriteLine("[+] Port open");
                }
                else
                {
                    Console.WriteLine("[-] Port closed");
                }
            }
        }
    }
}
