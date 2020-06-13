using System.IO.Compression;
using System;
using DSharpPlus;

namespace KhepriBot2
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new Bot();
            bot.RunAsync().GetAwaiter().GetResult();         
        }
    }
}
