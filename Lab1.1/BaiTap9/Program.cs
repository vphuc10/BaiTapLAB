using System;
using System.Numerics;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap mot so nguyen duong: ");
        if (int.TryParse(Console.ReadLine(), out int n) && n >= 0)
        {
            BigInteger giaiThua = TinhGiaiThua(n);
            Console.WriteLine($"Giai thua cua {n} la: {giaiThua}");
        }
        else
        {
            Console.WriteLine("So nhap vao khong hop le hoac khong phai so nguyen duong.");
        }
        Console.ReadKey();
    }
    static BigInteger TinhGiaiThua(int n)
    {
        if (n == 0 || n == 1)
            return 1;

        BigInteger ketQua = 1;
        for (int i = 2; i <= n; i++)
        {
            ketQua *= i;
        }
        return ketQua;
    }
}