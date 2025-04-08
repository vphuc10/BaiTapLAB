using System;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap mot nam: ");
        if (int.TryParse(Console.ReadLine(), out int nam))
        {
            bool laNamNhuan = (nam % 4 == 0 && nam % 100 != 0) || (nam % 400 == 0);

            if (laNamNhuan)
            {
                Console.WriteLine($"{nam} la nam nhuan.");
            }
            else
            {
                Console.WriteLine($"{nam} khong phai nam nhuan.");
            }
        }
        else
        {
            Console.WriteLine("Nam nhap vao khong hop le.");
        }
        Console.ReadKey();
    }
}