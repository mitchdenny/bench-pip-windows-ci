using System;
using System.Diagnostics;
using System.IO;

namespace Warmup
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = new DirectoryInfo(args[0]);
            var files = directory.GetFiles("*.*", SearchOption.AllDirectories);

            for (var fileIndex = 0; fileIndex < files.Length; fileIndex++)
            {
                using (var reader = new StreamReader(files[fileIndex].FullName))
                {
                    var stopwatch = new Stopwatch();
                    stopwatch.Start();
                    Console.Write($"Reading {fileIndex} of {files.Length} => {files[fileIndex].FullName}...");
                    var content = reader.ReadToEnd();
                    stopwatch.Stop();
                    Console.WriteLine($"done ({stopwatch.ElapsedMilliseconds})!");
                }                
            }
        }
    }
}
