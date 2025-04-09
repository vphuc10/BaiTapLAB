using System;
using System.Collections.Generic;

namespace QuanLyTamGiacDiem
{
    class Diem
    {
        private double x, y;
        public Diem()
        {
            x = 0;
            y = 0;
        }
        public Diem(double hoanhDo, double tungDo)
        {
            x = hoanhDo;
            y = tungDo;
        }
        public void Nhap()
        {
            Console.Write("Nhap hoanh do: ");
            if (!double.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Hoanh do khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.Write("Nhap tung do: ");
            if (!double.TryParse(Console.ReadLine(), out y))
            {
                Console.WriteLine("Tung do khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
        }
        public void In()
        {
            Console.WriteLine($"({x}, {y})");
        }
        public double KhoangCach(Diem d)
        {
            return Math.Sqrt(Math.Pow(x - d.x, 2) + Math.Pow(y - d.y, 2));
        }

        public double GetX() => x;
        public double GetY() => y;
    }
    class TamGiac
    {
        private Diem d1, d2, d3;

        public TamGiac()
        {
            d1 = new Diem();
            d2 = new Diem();
            d3 = new Diem();
        }
        public TamGiac(Diem diem1, Diem diem2, Diem diem3)
        {
            d1 = diem1;
            d2 = diem2;
            d3 = diem3;
        }
        public void Nhap()
        {
            Console.WriteLine("Nhap diem 1:");
            d1.Nhap();
            Console.WriteLine("Nhap diem 2:");
            d2.Nhap();
            Console.WriteLine("Nhap diem 3:");
            d3.Nhap();
            if (TinhDienTich() == 0)
            {
                Console.WriteLine("Ba diem thang hang, khong tao thanh tam giac hop le. Vui long nhap lai.");
                Nhap();
            }
        }
        public double TinhChuVi()
        {
            double canh1 = d1.KhoangCach(d2);
            double canh2 = d2.KhoangCach(d3);
            double canh3 = d3.KhoangCach(d1);
            return canh1 + canh2 + canh3;
        }
        public double TinhDienTich()
        {
            double s = Math.Abs(d1.GetX() * (d2.GetY() - d3.GetY()) +
                               d2.GetX() * (d3.GetY() - d1.GetY()) +
                               d3.GetX() * (d1.GetY() - d2.GetY())) / 2.0;
            return s;
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
        public void TinhTong()
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sach rong!");
                return;
            }
            double tongChuVi = 0;
            double tongDienTich = 0;
            foreach (var tg in danhSach)
            {
                tongChuVi += tg.TinhChuVi();
                tongDienTich += tg.TinhDienTich();
            }
            Console.WriteLine($"Tong chu vi: {tongChuVi}");
            Console.WriteLine($"Tong dien tich: {tongDienTich}");
        }
    }
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            QuanLyTamGiac ql = new QuanLyTamGiac();
            ql.NhapDanhSach();
            ql.TinhTong();
        }
    }
}