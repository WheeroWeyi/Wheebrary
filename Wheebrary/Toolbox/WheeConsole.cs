using System;

namespace Wheebrary.Toolbox
{
    public static class WheeConsole
    {
        public static ConsoleColor DefaultColor { get; private set; } = ConsoleColor.Gray;
        private static string _log = "";

        public static void SetForegroundColor(ConsoleColor newColor)
        {
            DefaultColor = newColor;
        }

        public static void SetTitle(string newTitle)
        {
            Console.Title = newTitle;
        }

        public static void Write(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();

            _log += text;
        }

        public static void Write(string text)
        {
            Write(text, DefaultColor);
        }

        public static void Write(float text, ConsoleColor color)
        {
            Write(text.ToString(), color);
        }

        public static void Write(float text)
        {
            Write(text.ToString(), DefaultColor);
        }

        public static void WriteLine(string text, ConsoleColor color)
        {
            Write(text + "\n", color);
        }

        public static void WriteLine(float text, ConsoleColor color)
        {
            Write(text.ToString() + "\n", color);
        }

        public static void WriteLine(float text)
        {
            Write(text.ToString() + "\n", DefaultColor);
        }

        public static void WriteLine(string text)
        {
            Write(text + "\n", DefaultColor);
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static void SaveLog(string file)
        {
            string[] log = _log.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            WheeStream.Write(file, log);
        }
    }
}
