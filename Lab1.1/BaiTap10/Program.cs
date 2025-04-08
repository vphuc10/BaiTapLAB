using System;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap mot so nguyen duong: ");
        if (int.TryParse(Console.ReadLine(), out int n) && n > 1)
        {
            bool laSoNguyenTo = KiemTraSoNguyenTo(n);
            if (laSoNguyenTo)
            {
                Console.WriteLine($"{n} la so nguyen to.");
            }
            else
            {
                Console.WriteLine($"{n} khong phai so nguyen to.");
            }
        }
        else
        {
            Console.WriteLine("So nhap vao khong hop le hoac khong phai so nguyen duong lon hon 1.");
        }
        Console.ReadKey();
    }
    static bool KiemTraSoNguyenTo(int n)
    {
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}