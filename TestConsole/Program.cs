using System;
using Test.Model;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Arrange
            var w1 = new Worker();
            w1.SetAge(10);

            // Act
            var w2 = w1.Clone();

            Console.WriteLine("Done");
        }
    }
}
