using System;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap mot so: ");
        if (double.TryParse(Console.ReadLine(), out double so))
        {
            if (so > 0)
            {
                Console.WriteLine($"{so} la so duong.");
            }
            else if (so < 0)
            {
                Console.WriteLine($"{so} la so am.");
            }
            else
            {
                Console.WriteLine($"{so} la so khong.");
            }
        }
        else
        {
            Console.WriteLine("Du lieu nhap vao khong hop le.");
        }

        Console.ReadKey();
    }
}