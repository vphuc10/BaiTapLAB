using System;

namespace QuanLyMaTran
{
    class MaTran
    {
        private int soDong, soCot;
        private double[,] mang;
        public MaTran()
        {
            soDong = 0;
            soCot = 0;
            mang = null;
        }
        public MaTran(int n, int m)
        {
            soDong = n;
            soCot = m;
            mang = new double[n, m];
        }
        public void Nhap()
        {
            Console.Write("Nhap so dong: ");
            if (!int.TryParse(Console.ReadLine(), out soDong) || soDong <= 0)
            {
                Console.WriteLine("So dong khong hop le.");
                Nhap();
                return;
            }
            Console.Write("Nhap so cot: ");
            if (!int.TryParse(Console.ReadLine(), out soCot) || soCot <= 0)
            {
                Console.WriteLine("So cot khong hop le.");
                Nhap();
                return;
            }
            mang = new double[soDong, soCot];
            Console.WriteLine("Nhap cac phan tu cua ma tran:");
            for (int i = 0; i < soDong; i++)
                for (int j = 0; j < soCot; j++)
                {
                    Console.Write($"A[{i},{j}] = ");
                    if (!double.TryParse(Console.ReadLine(), out mang[i, j]))
                    {
                        Console.WriteLine("Gia tri phan tu khong hop le.");
                        Nhap();
                        return;
                    }
                }
        }
        public void HienThi()
        {
            if (mang == null)
            {
                Console.WriteLine("Ma tran chua duoc khoi tao.");
                return;
            }
            for (int i = 0; i < soDong; i++)
            {
                for (int j = 0; j < soCot; j++)
                    Console.Write($"{mang[i, j],8}");
                Console.WriteLine();
            }
        }
        public MaTran Cong(MaTran mt)
        {
            if (soDong != mt.soDong || soCot != mt.soCot)
                throw new Exception("Hai ma tran khong cung cap!");
            MaTran ketQua = new MaTran(soDong, soCot);
            for (int i = 0; i < soDong; i++)
                for (int j = 0; j < soCot; j++)
                    ketQua.mang[i, j] = mang[i, j] + mt.mang[i, j];
            return ketQua;
        }
        public MaTran Hieu(MaTran mt)
        {
            if (soDong != mt.soDong || soCot != mt.soCot)
                throw new Exception("Hai ma tran khong cung cap!");
            MaTran ketQua = new MaTran(soDong, soCot);
            for (int i = 0; i < soDong; i++)
                for (int j = 0; j < soCot; j++)
                    ketQua.mang[i, j] = mang[i, j] - mt.mang[i, j];
            return ketQua;
        }
        public MaTran Tich(MaTran mt)
        {
            if (soCot != mt.soDong)
                throw new Exception("Khong the nhan hai ma tran nay!");
            MaTran ketQua = new MaTran(soDong, mt.soCot);
            for (int i = 0; i < soDong; i++)
                for (int j = 0; j < mt.soCot; j++)
                {
                    ketQua.mang[i, j] = 0;
                    for (int k = 0; k < soCot; k++)
                        ketQua.mang[i, j] += mang[i, k] * mt.mang[k, j];
                }
            return ketQua;
        }
        public MaTran Thuong(MaTran mt)
        {
            if (soDong != mt.soDong || soCot != mt.soCot)
                throw new Exception("Hai ma tran khong cung cap!");
            MaTran ketQua = new MaTran(soDong, soCot);
            for (int i = 0; i < soDong; i++)
                for (int j = 0; j < soCot; j++)
                    ketQua.mang[i, j] = mt.mang[i, j] - mang[i, j];
            return ketQua;
        }
    }
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            MaTran A = new MaTran();
            MaTran B = new MaTran();
            Console.WriteLine("Nhap ma tran A:");
            A.Nhap();
            Console.WriteLine("Nhap ma tran B:");
            B.Nhap();
            while (true)
            {
                Console.WriteLine("\nChon tac vu:");
                Console.WriteLine("1. Tinh tong hai ma tran");
                Console.WriteLine("2. Tinh tich hai ma tran");
                Console.WriteLine("3. Tinh hieu hai ma tran");
                Console.WriteLine("4. Tinh thuong hai ma tran");
                Console.WriteLine("5. Thoat");
                Console.Write("Chon: ");
                if (!int.TryParse(Console.ReadLine(), out int chon))
                {
                    Console.WriteLine("Lua chon khong hop le. Vui long nhap lai.");
                    continue;
                }
                if (chon == 5) break;
                Console.WriteLine("Ket qua:");
                try
                {
                    switch (chon)
                    {
                        case 1:
                            A.Cong(B).HienThi();
                            break;
                        case 2:
                            A.Tich(B).HienThi();
                            break;
                        case 3:
                            A.Hieu(B).HienThi();
                            break;
                        case 4:
                            A.Thuong(B).HienThi();
                            break;
                        default:
                            Console.WriteLine("Chon sai!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Loi: {ex.Message}");
                }
            }
        }
    }
}