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
                DemSoAmDuong(mang, out int soAm, out int soDuong);
                Console.WriteLine($"So luong so am: {soAm}");
                Console.WriteLine($"So luong so duong: {soDuong}");
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
    static void DemSoAmDuong(int[] arr, out int soAm, out int soDuong)
    {
        soAm = 0;
        soDuong = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < 0)
            {
                soAm++;
            }
            else if (arr[i] > 0)
            {
                soDuong++;
            }
        }
    }
}