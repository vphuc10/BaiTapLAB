using System;
using System.Collections.Generic;

namespace QuanLyHinhTron
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
            Console.WriteLine($"Tam: ({x}, {y})");
        }
        public double KhoangCach(Diem d)
        {
            return Math.Sqrt(Math.Pow(x - d.x, 2) + Math.Pow(y - d.y, 2));
        }
        public double GetX() => x;
        public double GetY() => y;
    }
    class HinhTron
    {
        private Diem tam;
        private float banKinh;

        public HinhTron()
        {
            tam = new Diem();
            banKinh = 0;
        }
        public HinhTron(Diem d, float bk)
        {
            tam = d;
            banKinh = bk;
        }
        public void Nhap()
        {
            Console.WriteLine("Nhap thong tin tam:");
            tam.Nhap();
            Console.Write("Nhap ban kinh: ");
            if (!float.TryParse(Console.ReadLine(), out banKinh) || banKinh < 0)
            {
                Console.WriteLine("Ban kinh khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
        }
        public double TinhChuVi()
        {
            return 2 * Math.PI * banKinh;
        }
        public double TinhDienTich()
        {
            return Math.PI * banKinh * banKinh;
        }
        public void HienThi()
        {
            tam.In();
            Console.WriteLine($"Ban kinh: {banKinh}, Chu vi: {TinhChuVi():F2}, Dien tich: {TinhDienTich():F2}");
        }
        public bool GiaoVoi(HinhTron ht)
        {
            double khoangCachTam = tam.KhoangCach(ht.tam);
            return khoangCachTam < (banKinh + ht.banKinh) && khoangCachTam > Math.Abs(banKinh - ht.banKinh);
        }

        public Diem GetTam() => tam;
        public float GetBanKinh() => banKinh;
    }
    class QuanLyHinhTron
    {
        private List<HinhTron> danhSach;
        public QuanLyHinhTron()
        {
            danhSach = new List<HinhTron>();
        }
        public void NhapDanhSach()
        {
            Console.Write("Nhap so hinh tron: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("So hinh tron khong hop le. Vui long nhap lai.");
                NhapDanhSach();
                return;
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhap hinh tron {i + 1}:");
                HinhTron ht = new HinhTron();
                ht.Nhap();
                danhSach.Add(ht);
            }
        }
        public void HienThiHinhTronGiaoNhieuNhat()
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sach rong!");
                return;
            }
            int maxGiao = 0;
            HinhTron hinhMax = null;
            foreach (var ht1 in danhSach)
            {
                int demGiao = 0;
                foreach (var ht2 in danhSach)
                {
                    if (ht1 != ht2 && ht1.GiaoVoi(ht2))
                    {
                        demGiao++;
                    }
                }
                if (demGiao > maxGiao)
                {
                    maxGiao = demGiao;
                    hinhMax = ht1;
                }
            }
            if (hinhMax == null)
            {
                Console.WriteLine("Khong co hinh tron nao trong danh sach.");
            }
            else if (maxGiao == 0)
            {
                Console.WriteLine("Khong co hinh tron nao giao voi hinh khac!");
            }
            else
            {
                Console.WriteLine($"Hinh tron giao voi {maxGiao} hinh khac:");
                hinhMax.HienThi();
            }
        }
    }
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            QuanLyHinhTron ql = new QuanLyHinhTron();
            ql.NhapDanhSach();
            ql.HienThiHinhTronGiaoNhieuNhat();
        }
    }
}