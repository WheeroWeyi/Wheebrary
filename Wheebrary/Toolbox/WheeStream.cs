using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Wheebrary.Toolbox
{
    public static class WheeStream
    {
        //X rows from Y row
        public static List<string> ReadToList(string file, int start, int rows)
        {
            try
            {
                List<string> content = new List<string>();
                Stream stream;
                stream = new FileStream(file, FileMode.Open);
                StreamReader streamReader = new StreamReader(stream);
                int row = 0;
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    row++;
                    if (row < start || row > start + rows) continue;
                    content.Add(line);
                }
                streamReader.Close();
                return content;
            }
            catch
            {
                WheeConsole.WriteLine("[WheeStream] Something went wrong during reading file " + file, ConsoleColor.Red);
                return null;
            }
        }

        //whole file from row X
        public static List<string> ReadToListWithStart(string file, int start)
        {
            return ReadToList(file, start, 10000);
        }

        //first X rows
        public static List<string> ReadToListWithRows(string file, int rows)
        {
            return ReadToList(file, 0, rows);
        }

        //whole file
        public static List<string> ReadToList(string file)
        {
            return ReadToList(file, 0, int.MaxValue);
        }

        public static bool Write(string file, List<string> content, bool append)
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter(file, append);
                foreach (string line in content)
                {
                    streamWriter.WriteLine(line);
                }
                streamWriter.Close();
                return true;
            }
            catch
            {
                WheeConsole.WriteLine("[WheeStream] " + file + " something went wrong during writing!", ConsoleColor.Red);
                return false;
            }
        }

        public static bool Write(string file, List<string> content)
        {
            return Write(file, content, false);
        }

        public static bool Write(string file, string[] content, bool append)
        {
            return Write(file, content.ToList(), append);
        }

        public static bool Write(string file, string[] content)
        {
            return Write(file, content.ToList());
        }
    }
}
