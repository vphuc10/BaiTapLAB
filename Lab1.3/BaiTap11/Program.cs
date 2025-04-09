using System;

namespace QuanLySoPhuc
{
    class SoPhuc
    {
        private double phanThuc, phanAo;
        public SoPhuc()
        {
            phanThuc = 0;
            phanAo = 0;
        }
        public SoPhuc(double a, double b)
        {
            phanThuc = a;
            phanAo = b;
        }
        public void Nhap()
        {
            Console.Write("Nhap phan thuc: ");
            if (!double.TryParse(Console.ReadLine(), out phanThuc))
            {
                Console.WriteLine("Phan thuc khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.Write("Nhap phan ao: ");
            if (!double.TryParse(Console.ReadLine(), out phanAo))
            {
                Console.WriteLine("Phan ao khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
        }
        public void HienThi()
        {
            if (phanAo >= 0)
                Console.WriteLine($"{phanThuc} + {phanAo}i");
            else
                Console.WriteLine($"{phanThuc} - {Math.Abs(phanAo)}i");
        }
        public SoPhuc Cong(SoPhuc sp)
        {
            return new SoPhuc(phanThuc + sp.phanThuc, phanAo + sp.phanAo);
        }
        public SoPhuc Hieu(SoPhuc sp)
        {
            return new SoPhuc(phanThuc - sp.phanThuc, phanAo - sp.phanAo);
        }
        public SoPhuc Nhan(SoPhuc sp)
        {
            double thuc = phanThuc * sp.phanThuc - phanAo * sp.phanAo;
            double ao = phanThuc * sp.phanAo + phanAo * sp.phanThuc;
            return new SoPhuc(thuc, ao);
        }
        public SoPhuc Chia(SoPhuc sp)
        {
            double mau = sp.phanThuc * sp.phanThuc + sp.phanAo * sp.phanAo;
            if (mau == 0) throw new DivideByZeroException("Khong chia duoc cho so phuc bang 0!");
            double thuc = (phanThuc * sp.phanThuc + phanAo * sp.phanAo) / mau;
            double ao = (phanAo * sp.phanThuc - phanThuc * sp.phanAo) / mau;
            return new SoPhuc(thuc, ao);
        }
    }
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            SoPhuc A = new SoPhuc();
            SoPhuc B = new SoPhuc();

            Console.WriteLine("Nhap so phuc A:");
            A.Nhap();
            Console.WriteLine("Nhap so phuc B:");
            B.Nhap();
            while (true)
            {
                Console.WriteLine("\nChon tac vu:");
                Console.WriteLine("1. Tinh tong hai so phuc");
                Console.WriteLine("2. Tinh hieu hai so phuc");
                Console.WriteLine("3. Tinh tich hai so phuc");
                Console.WriteLine("4. Tinh thuong hai so phuc");
                Console.WriteLine("5. Thoat");
                Console.Write("Chon: ");
                if (!int.TryParse(Console.ReadLine(), out int chon))
                {
                    Console.WriteLine("Lua chon khong hop le. Vui long nhap lai.");
                    continue;
                }
                if (chon == 5) break;
                Console.Write("Ket qua: ");
                switch (chon)
                {
                    case 1:
                        A.Cong(B).HienThi();
                        break;
                    case 2:
                        A.Hieu(B).HienThi();
                        break;
                    case 3:
                        A.Nhan(B).HienThi();
                        break;
                    case 4:
                        try
                        {
                            A.Chia(B).HienThi();
                        }
                        catch (DivideByZeroException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    default:
                        Console.WriteLine("Chon sai!");
                        break;
                }
            }
        }
    }
}