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

                int soLonThuHai = TimSoLonThuHai(mang);
                if (soLonThuHai != int.MinValue)
                {
                    Console.WriteLine($"So lon thu hai trong mang la: {soLonThuHai}");
                }
                else
                {
                    Console.WriteLine("Khong tim thay so lon thu hai (mang co it hon 2 phan tu duy nhat).");
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
    static int TimSoLonThuHai(int[] arr)
    {
        if (arr.Length < 2)
        {
            return int.MinValue;
        }
        int max = int.MinValue;
        int secondMax = int.MinValue;

        foreach (int num in arr)
        {
            if (num > max)
            {
                secondMax = max;
                max = num;
            }
            else if (num > secondMax && num < max)
            {
                secondMax = num;
            }
        }

        if (secondMax == int.MinValue && arr.Distinct().Count() >= 2)
        {
            int firstMax = arr.Max();
            secondMax = arr.Where(x => x < firstMax).DefaultIfEmpty(int.MinValue).Max();
        }
        else if (secondMax == int.MinValue && arr.Distinct().Count() < 2)
        {
            return int.MinValue;
        }
        return secondMax;
    }
}