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
                        return; // Thoát khỏi Main nếu có lỗi nhập liệu
                    }
                }
                int tongChan = TongSoChan(mang);
                Console.WriteLine($"Tong cac so chan trong mang la: {tongChan}");
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
    static int TongSoChan(int[] arr)
    {
        int tong = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] % 2 == 0)
            {
                tong += arr[i];
            }
        }
        return tong;
    }
}