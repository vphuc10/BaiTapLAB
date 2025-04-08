using System;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap ten cua ban: ");
        string ten = Console.ReadLine();

        Console.Write("Nhap tuoi cua ban: ");
        int tuoi = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Xin chao {ten}, ban {tuoi} tuoi!");

        Console.ReadKey();
    }
}