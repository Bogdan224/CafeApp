using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Helpers
{
    public static class FileWorker
    {
        static private string path = @"D:\Programming\C#\CafeApp\CafeApp\";

        public static IEnumerable<string> ReadFromFile(string filename)
        {
            if (!File.Exists(path + filename))
            {
                File.Create(path + filename);
                File.OpenWrite(path + filename);
            }
            return File.ReadLines(path + filename).ToList();
        }
        public static void WriteToFile(string filename, string value)
        {
            if (!File.Exists(path + filename))
            {
                File.Create(path + filename);
                File.OpenWrite(path + filename);
            }
            File.WriteAllText(path + filename, value);
        }
        public static void AppendToFile(string filename, string value)
        {
            if (!File.Exists(path + filename))
            {
                File.OpenWrite(path + filename);
                File.Create(path + filename);
            }
            File.AppendAllText(path + filename, value);
        }
    }
}
