using System;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap mot so nguyen: ");
        if (int.TryParse(Console.ReadLine(), out int so))
        {
            if (so % 2 == 0)
            {
                Console.WriteLine($"{so} la so chan.");
            }
            else
            {
                Console.WriteLine($"{so} khong phai so chan.");
            }
        }
        else
        {
            Console.WriteLine("Du lieu nhap vao khong hop le.");
        }
        Console.ReadKey();
    }
}