using System;
using System.IO;
using MoxiWorks.Platform;
namespace MoxiWorks.Test
{
    public class StubDataLoader
    {
        public static string LoadJsonFile(string filename)
        {
            var dir = Path.Combine( $"TestData/{filename}");
            Console.WriteLine(dir);
            return File.ReadAllText(dir);
        }
    }
}