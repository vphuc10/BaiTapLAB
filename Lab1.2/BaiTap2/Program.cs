using System;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap so phan tu cua mang: ");
        if (int.TryParse(Console.ReadLine(), out int n))
        {
            if (n > 0)
            {
                int[] mang = new int[n];
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"Nhap phan tu thu {i + 1}: ");
                    if (!int.TryParse(Console.ReadLine(), out mang[i]))
                    {
                        Console.WriteLine("Gia tri nhap khong hop le. Vui long nhap so nguyen.");
                        return;
                    }
                }
                Console.WriteLine("Cac so nguyen to trong mang:");
                for (int i = 0; i < n; i++)
                {
                    if (KiemTraNguyenTo(mang[i]))
                    {
                        Console.WriteLine($"Chi so {i}: {mang[i]}");
                    }
                }
            }
            else
            {
                Console.WriteLine("So phan tu cua mang phai la mot so nguyen duong.");
            }
        }
        else
        {
            Console.WriteLine("Gia tri nhap khong hop le. Vui long nhap so nguyen.");
        }
        Console.ReadKey();
    }
    static bool KiemTraNguyenTo(int n)
    {
        if (n <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0) return false;
        }
        return true;
    }
}