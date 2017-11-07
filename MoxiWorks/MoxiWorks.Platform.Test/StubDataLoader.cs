using System;
using System.IO;
using NUnit.Framework;
namespace MoxiWorks.Platform.Test
{
    public class StubDataLoader
    {
        public static string LoadJsonFile(string filename)
        {
            var dir = Path.Combine(TestContext.CurrentContext.TestDirectory, $"TestData/{filename}");
            Console.WriteLine(dir);
            return File.ReadAllText(dir);
        }
    }
}