using System;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap so thu nhat (a): ");
        if (int.TryParse(Console.ReadLine(), out int a))
        {
            Console.Write("Nhap so thu hai (b): ");
            if (int.TryParse(Console.ReadLine(), out int b))
            {
                Console.WriteLine($"Truoc khi hoan vi: a = {a}, b = {b}");
                HoanVi(ref a, ref b);
                Console.WriteLine($"Sau khi hoan vi: a = {a}, b = {b}");
            }
            else
            {
                Console.WriteLine("Gia tri nhap cho b khong hop le. Vui long nhap so nguyen.");
            }
        }
        else
        {
            Console.WriteLine("Gia tri nhap cho a khong hop le. Vui long nhap so nguyen.");
        }
        Console.ReadKey();
    }
    static void HoanVi(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}