using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap nhiet do (C): ");
        if (double.TryParse(Console.ReadLine(), out double celsius))
        {
            double fahrenheit = (celsius * 9 / 5) + 32;
            Console.WriteLine($"Nhiet do (F): {fahrenheit}");
        }
        else
        {
            Console.WriteLine("Nhiet do khong hop le.");
        }
        Console.ReadKey(); 
    }
}