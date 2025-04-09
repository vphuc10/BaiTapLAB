using System;
using System.Collections.Generic;

namespace QuanLyDaGiac
{
    class DaGiac
    {
        protected int soCanh;
        protected int[] canh;
        public DaGiac()
        {
            soCanh = 0;
            canh = null;
        }
        public DaGiac(int n)
        {
            soCanh = n;
            canh = new int[n];
        }
        public virtual void Nhap()
        {
            Console.Write("Nhap so canh: ");
            if (!int.TryParse(Console.ReadLine(), out soCanh) || soCanh <= 0)
            {
                Console.WriteLine("So canh khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            canh = new int[soCanh];
            Console.WriteLine("Nhap do dai cac canh:");
            for (int i = 0; i < soCanh; i++)
            {
                Console.Write($"Canh {i + 1}: ");
                if (!int.TryParse(Console.ReadLine(), out canh[i]) || canh[i] <= 0)
                {
                    Console.WriteLine("Do dai canh khong hop le. Vui long nhap lai.");
                    Nhap();
                    return;
                }
            }
        }
        public virtual int TinhChuVi()
        {
            int chuVi = 0;
            if (canh != null)
            {
                foreach (int c in canh) chuVi += c;
            }
            return chuVi;
        }
        public virtual void InCacCanh()
        {
            Console.Write("Cac canh: ");
            if (canh != null)
            {
                foreach (int c in canh) Console.Write($"{c} ");
            }
            Console.WriteLine();
        }
    }
    class TamGiac : DaGiac
    {
        public TamGiac() : base(3) { }

        public override void Nhap()
        {
            soCanh = 3;
            canh = new int[3];
            Console.WriteLine("Nhap do dai 3 canh cua tam giac:");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Canh {i + 1}: ");
                if (!int.TryParse(Console.ReadLine(), out canh[i]) || canh[i] <= 0)
                {
                    Console.WriteLine("Do dai canh khong hop le. Vui long nhap lai.");
                    Nhap();
                    return;
                }
            }
            if (canh[0] + canh[1] <= canh[2] || canh[0] + canh[2] <= canh[1] || canh[1] + canh[2] <= canh[0])
            {
                Console.WriteLine("Ba canh khong tao thanh mot tam giac hop le. Vui long nhap lai.");
                Nhap();
            }
        }
        public override int TinhChuVi()
        {
            return canh[0] + canh[1] + canh[2];
        }
        public double TinhDienTich()
        {
            double p = TinhChuVi() / 2.0;
            return Math.Sqrt(p * (p - canh[0]) * (p - canh[1]) * (p - canh[2]));
        }
        public bool LaTamGiacPitago()
        {
            int[] canhSapXep = new int[3] { canh[0], canh[1], canh[2] };
            Array.Sort(canhSapXep);
            return canhSapXep[0] * canhSapXep[0] + canhSapXep[1] * canhSapXep[1] == canhSapXep[2] * canhSapXep[2];
        }
        public override void InCacCanh()
        {
            Console.Write($"Tam giac co cac canh: {canh[0]} {canh[1]} {canh[2]}");
            Console.WriteLine();
        }
    }
    class QuanLyTamGiac
    {
        private List<TamGiac> danhSach;

        public QuanLyTamGiac()
        {
            danhSach = new List<TamGiac>();
        }
        public void NhapDanhSach()
        {
            Console.Write("Nhap so tam giac: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("So tam giac khong hop le. Vui long nhap lai.");
                NhapDanhSach();
                return;
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhap tam giac {i + 1}:");
                TamGiac tg = new TamGiac();
                tg.Nhap();
                danhSach.Add(tg);
            }
        }
        public void InTamGiacPitago()
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sach rong!");
                return;
            }
            bool found = false;
            Console.WriteLine("Cac tam giac thoa man dinh ly Pitago:");
            foreach (var tg in danhSach)
            {
                if (tg.LaTamGiacPitago())
                {
                    tg.InCacCanh();
                    found = true;
                }
            }
            if (!found) Console.WriteLine("Khong co tam giac nao thoa man!");
        }
    }
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            QuanLyTamGiac ql = new QuanLyTamGiac();
            ql.NhapDanhSach();
            ql.InTamGiacPitago();
        }
    }
}