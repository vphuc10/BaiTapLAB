using System;
using System.Collections.Generic;

namespace QuanLyHocSinh
{
    class Nguoi
    {
        private string hoTen, queQuan, gioiTinh;
        private int tuoi, namSinh;
        public void Nhap()
        {
            Console.Write("Ho ten: "); hoTen = Console.ReadLine();
            Console.Write("Tuoi: ");
            if (!int.TryParse(Console.ReadLine(), out tuoi))
            {
                Console.WriteLine("Tuoi khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.Write("Nam sinh: ");
            if (!int.TryParse(Console.ReadLine(), out namSinh))
            {
                Console.WriteLine("Nam sinh khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.Write("Que quan: "); queQuan = Console.ReadLine();
            Console.Write("Gioi tinh: "); gioiTinh = Console.ReadLine();
        }
        public void HienThi()
        {
            Console.WriteLine($"Ho ten: {hoTen}, Tuoi: {tuoi}, Nam sinh: {namSinh}, Que: {queQuan}, Gioi tinh: {gioiTinh}");
        }

        public string GetQueQuan() => queQuan;
        public int GetNamSinh() => namSinh;
        public string GetGioiTinh() => gioiTinh;
    }
    class HSHocSinh
    {
        private string lop, khoaHoc, kyHoc;
        private Nguoi hocSinh;
        public HSHocSinh()
        {
            hocSinh = new Nguoi();
        }
        public void Nhap()
        {
            Console.Write("Lop: "); lop = Console.ReadLine();
            Console.Write("Khoa hoc: "); khoaHoc = Console.ReadLine();
            Console.Write("Ky hoc: "); kyHoc = Console.ReadLine();
            Console.WriteLine("Nhap thong tin hoc sinh:");
            hocSinh.Nhap();
        }
        public void HienThi()
        {
            Console.WriteLine($"Lop: {lop}, Khoa: {khoaHoc}, Ky: {kyHoc}");
            hocSinh.HienThi();
            Console.WriteLine("-------------------");
        }

        public string GetQueQuan() => hocSinh.GetQueQuan();
        public int GetNamSinh() => hocSinh.GetNamSinh();
        public string GetGioiTinh() => hocSinh.GetGioiTinh();
    }
    class QuanLyHocSinh
    {
        private List<HSHocSinh> danhSach;

        public QuanLyHocSinh()
        {
            danhSach = new List<HSHocSinh>();
        }
        public void NhapDanhSach()
        {
            Console.Write("Nhap so hoc sinh: ");
            if (!int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("So hoc sinh khong hop le. Vui long nhap lai.");
                NhapDanhSach();
                return;
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhap thong tin hoc sinh {i + 1}:");
                HSHocSinh hs = new HSHocSinh();
                hs.Nhap();
                danhSach.Add(hs);
            }
        }
        public void HienThiNu1985()
        {
            if (danhSach.Count == 0) { Console.WriteLine("Danh sach rong!"); return; }
            Console.WriteLine("\nDanh sach hoc sinh nu sinh nam 1985:");
            bool found = false;
            foreach (var hs in danhSach)
            {
                if (hs.GetGioiTinh().ToLower() == "nu" && hs.GetNamSinh() == 1985)
                {
                    hs.HienThi();
                    found = true;
                }
            }
            if (!found) Console.WriteLine("Khong co hoc sinh nu sinh nam 1985!");
        }
        public void TimKiemTheoQue()
        {
            Console.Write("Nhap que quan can tim: ");
            string que = Console.ReadLine();
            bool found = false;
            foreach (var hs in danhSach)
            {
                if (hs.GetQueQuan().ToLower().Contains(que.ToLower()))
                {
                    hs.HienThi();
                    found = true;
                }
            }
            if (!found) Console.WriteLine("Khong tim thay!");
        }
        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n1. Nhap danh sach hoc sinh");
                Console.WriteLine("2. Hien thi hoc sinh nu sinh 1985");
                Console.WriteLine("3. Tim kiem theo que quan");
                Console.WriteLine("4. Thoat");
                Console.Write("Chon: ");
                if (!int.TryParse(Console.ReadLine(), out int chon))
                {
                    Console.WriteLine("Lua chon khong hop le. Vui long nhap lai.");
                    continue;
                }
                if (chon == 4) break;
                switch (chon)
                {
                    case 1: NhapDanhSach(); break;
                    case 2: HienThiNu1985(); break;
                    case 3: TimKiemTheoQue(); break;
                    default: Console.WriteLine("Chon sai!"); break;
                }
            }
        }
    }
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            new QuanLyHocSinh().Menu();
        }
    }
}