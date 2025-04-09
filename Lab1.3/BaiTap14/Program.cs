using System;

namespace QuanLyPhanSo
{
    class PhanSo
    {
        private int tuSo, mauSo;
        public PhanSo()
        {
            tuSo = 0;
            mauSo = 1;
        }
        public PhanSo(int tu, int mau)
        {
            tuSo = tu;
            if (mau == 0) throw new ArgumentException("Mau so khong the bang 0!");
            mauSo = mau;
        }
        public void Nhap()
        {
            Console.Write("Nhap tu so: ");
            if (!int.TryParse(Console.ReadLine(), out tuSo))
            {
                Console.WriteLine("Tu so khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.Write("Nhap mau so: ");
            if (!int.TryParse(Console.ReadLine(), out mauSo))
            {
                Console.WriteLine("Mau so khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            if (mauSo == 0)
            {
                Console.WriteLine("Mau so khong the bang 0!");
                Nhap();
                return;
            }
        }
        public void HienThi()
        {
            Console.WriteLine($"{tuSo}/{mauSo}");
        }
        private int UCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public void RutGon()
        {
            int ucln = UCLN(tuSo, mauSo);
            tuSo /= ucln;
            mauSo /= ucln;
            if (mauSo < 0)
            {
                tuSo = -tuSo;
                mauSo = -mauSo;
            }
        }
        public PhanSo Cong(PhanSo ps)
        {
            int tu = tuSo * ps.mauSo + ps.tuSo * mauSo;
            int mau = mauSo * ps.mauSo;
            PhanSo ketQua = new PhanSo(tu, mau);
            ketQua.RutGon();
            return ketQua;
        }
        public PhanSo Tru(PhanSo ps)
        {
            int tu = tuSo * ps.mauSo - ps.tuSo * mauSo;
            int mau = mauSo * ps.mauSo;
            PhanSo ketQua = new PhanSo(tu, mau);
            ketQua.RutGon();
            return ketQua;
        }
        public PhanSo Nhan(PhanSo ps)
        {
            int tu = tuSo * ps.tuSo;
            int mau = mauSo * ps.mauSo;
            PhanSo ketQua = new PhanSo(tu, mau);
            ketQua.RutGon();
            return ketQua;
        }
        public PhanSo Chia(PhanSo ps)
        {
            if (ps.tuSo == 0) throw new DivideByZeroException("Khong the chia cho 0!");
            int tu = tuSo * ps.mauSo;
            int mau = mauSo * ps.tuSo;
            PhanSo ketQua = new PhanSo(tu, mau);
            ketQua.RutGon();
            return ketQua;
        }
    }
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            PhanSo A = new PhanSo();
            PhanSo B = new PhanSo();

            Console.WriteLine("Nhap phan so A:");
            A.Nhap();
            Console.WriteLine("Nhap phan so B:");
            B.Nhap();
            while (true)
            {
                Console.WriteLine("\nChon tac vu:");
                Console.WriteLine("1. Cong hai phan so");
                Console.WriteLine("2. Tru hai phan so");
                Console.WriteLine("3. Nhan hai phan so"); 
                Console.WriteLine("4. Chia hai phan so");
                Console.WriteLine("5. Thoat");
                Console.Write("Chon: ");
                if (!int.TryParse(Console.ReadLine(), out int chon))
                {
                    Console.WriteLine("Lua chon khong hop le. Vui long nhap lai.");
                    continue;
                }
                if (chon == 5) break;
                Console.Write("Ket qua: ");
                try
                {
                    switch (chon)
                    {
                        case 1:
                            A.Cong(B).HienThi();
                            break;
                        case 2:
                            A.Tru(B).HienThi();
                            break;
                        case 3: 
                            A.Nhan(B).HienThi();
                            break;
                        case 4:
                            A.Chia(B).HienThi();
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