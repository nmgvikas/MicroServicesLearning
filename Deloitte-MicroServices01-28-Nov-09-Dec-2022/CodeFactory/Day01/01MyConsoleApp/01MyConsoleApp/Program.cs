using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace _01MyConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ta-IN");
            await Console.Out.WriteLineAsync("Hello World!");
            await Console.Out.WriteLineAsync($"Today is {DateTime.Now.ToShortDateString()}");
            File.WriteAllText(@"C:\info.txt", $"Today is {DateTime.Now.ToShortDateString()}");

        }
    }
}
