using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bang cuu chuong tu 1 den 10 (xep ngang):");
        for (int i = 1; i <= 10; i++)
        {
            Console.Write($"Bang {i}\t");
        }
        Console.WriteLine();
        for (int j = 1; j <= 10; j++)
        {
            for (int i = 1; i <= 10; i++)
            {
                int ketQua = i * j;
                Console.Write($"{i}x{j}={ketQua}\t");
            }
            Console.WriteLine();
        }
        Console.ReadKey();
    }
}