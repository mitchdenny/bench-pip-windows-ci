using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Warmup
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length % 2 != 0) throw new InvalidOperationException();

            var files = new List<FileInfo>();

            for (var argIndex = 0; argIndex < args.Length; argIndex = argIndex + 2)
            {
                if (args[argIndex] == "-d")
                {
                    var directory = new DirectoryInfo(args[argIndex + 1]);
                    var additionalFiles = directory.GetFiles("*.*", SearchOption.TopDirectoryOnly);
                    files.AddRange(additionalFiles);
                }
                else
                {
                    var directory = new DirectoryInfo(args[argIndex + 1]);
                    var additionalFiles = directory.GetFiles("*.*", SearchOption.AllDirectories);
                    files.AddRange(additionalFiles);
                }
            }

            Console.WriteLine($"Starting warm-up of {files.Count} files.");
            return;

            for (var fileIndex = 0; fileIndex < files.Count; fileIndex++)
            {
                using (var reader = new StreamReader(files[fileIndex].FullName))
                {
                    var stopwatch = new Stopwatch();
                    stopwatch.Start();
                    Console.Write($"Reading {fileIndex} of {files.Count} => {files[fileIndex].FullName}...");
                    var content = reader.ReadToEnd();
                    stopwatch.Stop();
                    Console.WriteLine($"done ({stopwatch.ElapsedMilliseconds})!");
                }                
            }
        }
    }
}
