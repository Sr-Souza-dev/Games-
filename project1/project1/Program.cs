using System;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


namespace Project1 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculadora cal = new Calculadora(7, 15);

            Console.WriteLine(String.Format("O resultado é: {0:c}", cal.Soma()));
        }
    }
}