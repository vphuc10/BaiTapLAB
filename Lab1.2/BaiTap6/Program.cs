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
                double[] mang = new double[n];
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"Nhap phan tu thu {i + 1}: ");
                    if (!double.TryParse(Console.ReadLine(), out mang[i]))
                    {
                        Console.WriteLine("Gia tri nhap khong hop le. Vui long nhap so thuc.");
                        return; // Thoát khỏi Main nếu có lỗi nhập liệu
                    }
                }
                SapXepTangDan(mang);
                Console.WriteLine("Mang sau khi sap xep tang dan:");
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"Phan tu {i + 1}: {mang[i]}");
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
    static void SapXepTangDan(double[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[i] > arr[j])
                {
                    double temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
        }
    }
}