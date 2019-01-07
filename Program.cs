using System;
using System.IO;

namespace Warmup
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = new DirectoryInfo(args[0]);
            var files = directory.GetFiles("*.*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                using (var reader = new StreamReader(file.FullName))
                {
                    Console.Write($"Reading {file.FullName}...");
                    var content = reader.ReadToEnd();
                    Console.WriteLine($"done!");
                }                
            }
        }
    }
}
