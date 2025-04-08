using System;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap so thu nhat: ");
        if (!double.TryParse(Console.ReadLine(), out double so1))
        {
            Console.WriteLine("So thu nhat khong hop le.");
            Console.ReadKey();
            return;
        }

        Console.Write("Nhap so thu hai: ");
        if (!double.TryParse(Console.ReadLine(), out double so2))
        {
            Console.WriteLine("So thu hai khong hop le.");
            Console.ReadKey();
            return;
        }

        double tong = so1 + so2;
        double tich = so1 * so2;

        Console.WriteLine($"Tong cua {so1} va {so2} la: {tong}");
        Console.WriteLine($"Tich cua {so1} va {so2} la: {tich}");
        Console.ReadKey();
    }
}