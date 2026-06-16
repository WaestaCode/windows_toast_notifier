using System;
using System.Diagnostics;

namespace WaestaToastNotifier
{
    internal static class WaestaCore
    {
        internal const string Author = "waesta.js";
        private const int ExpectedHash = 927;

        internal static void AntiTamperCheck()
        {
            int sum = 0;
            foreach (char c in Author)
                sum += c;

            if (sum != ExpectedHash)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[FATAL] Waesta Integrity Violation. Executing kill sequence.");
                Console.ResetColor();
                Environment.Exit(0xDEAD);
            }
        }

        internal static void Banner(string title, string subtitle)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n========================================");
            Console.WriteLine($" {title}");
            Console.WriteLine($" Developer: {Author}");
            Console.WriteLine($" {subtitle}");
            Console.WriteLine("========================================\n");
            Console.ResetColor();
        }

        internal static void Info(string message) =>
            Log("INFO", message, ConsoleColor.Cyan);

        internal static void Success(string message) =>
            Log(" OK ", message, ConsoleColor.Green);

        internal static void Error(string message) =>
            Log("ERR ", message, ConsoleColor.Red);

        private static void Log(string level, string message, ConsoleColor color)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"{DateTime.Now:HH:mm:ss} ");
            Console.ForegroundColor = color;
            Console.WriteLine($"[{level}] {message}");
            Console.ResetColor();
        }
    }
}
