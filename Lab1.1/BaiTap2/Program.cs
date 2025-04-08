using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap chieu dai: ");
        if (double.TryParse(Console.ReadLine(), out double chieuDai))
        {
            Console.Write("Nhap chieu rong: ");
            if (double.TryParse(Console.ReadLine(), out double chieuRong))
            {
                if (chieuDai > 0 && chieuRong > 0)
                {
                    double dienTich = chieuDai * chieuRong;
                    Console.WriteLine($"Dien tich: {dienTich}");
                }
                else
                {
                    Console.WriteLine("Chieu dai va chieu rong phai la so duong!");
                }
            }
            else
            {
                Console.WriteLine("Chieu rong khong hop le!");
            }
        }
        else
        {
            Console.WriteLine("Chieu dai khong hop le!");
        }
        Console.ReadKey();
    }
}