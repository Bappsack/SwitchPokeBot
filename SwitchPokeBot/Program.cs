using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using Microsoft.IdentityModel.Tokens;
using WebSocketSharp;
using WebSocketSharp.Server;
using System.Windows.Forms;

namespace SwitchPokeBot
{

    class Program
    {
        public static bool botRunning { get; set; }
        public static Form1 form;
        public static SwitchInputSink switchInput;

        public static void Main(string[] args)
        {
            form = new Form1();
            Application.Run(form);
        }
    }
}
