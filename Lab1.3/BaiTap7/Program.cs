using System;
using System.Collections.Generic;

namespace QuanLyLuongCBGV
{
    class Nguoi
    {
        private string hoTen, queQuan, cmnd;
        private int namSinh;
        public void Nhap()
        {
            Console.Write("Ho ten: "); hoTen = Console.ReadLine();
            Console.Write("Nam sinh: ");
            if (!int.TryParse(Console.ReadLine(), out namSinh))
            {
                Console.WriteLine("Nam sinh khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.Write("Que quan: "); queQuan = Console.ReadLine();
            Console.Write("CMND: "); cmnd = Console.ReadLine();
        }
        public void HienThi()
        {
            Console.WriteLine($"Ho ten: {hoTen}, Nam sinh: {namSinh}, Que: {queQuan}, CMND: {cmnd}");
        }

        public string GetQueQuan() => queQuan;
    }
    class CBGV
    {
        private double luongCung, thuong, phat, luongThucLinh;
        private Nguoi canBo;
        public CBGV()
        {
            canBo = new Nguoi();
        }
        public void Nhap()
        {
            Console.WriteLine("Nhap thong tin can bo:");
            canBo.Nhap();
            Console.Write("Luong cung: ");
            if (!double.TryParse(Console.ReadLine(), out luongCung))
            {
                Console.WriteLine("Luong cung khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.Write("Thuong: ");
            if (!double.TryParse(Console.ReadLine(), out thuong))
            {
                Console.WriteLine("Thuong khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.Write("Phat: ");
            if (!double.TryParse(Console.ReadLine(), out phat))
            {
                Console.WriteLine("Phat khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            TinhLuongThucLinh();
        }
        public void HienThi()
        {
            canBo.HienThi();
            Console.WriteLine($"Luong cung: {luongCung}, Thuong: {thuong}, Phat: {phat}, Luong thuc linh: {luongThucLinh}");
            Console.WriteLine("-------------------");
        }
        public void TinhLuongThucLinh()
        {
            luongThucLinh = luongCung + thuong - phat;
        }

        public double GetLuongThucLinh() => luongThucLinh;
        public string GetQueQuan() => canBo.GetQueQuan();
    }
    class QuanLyCBGV
    {
        private List<CBGV> danhSach;

        public QuanLyCBGV()
        {
            danhSach = new List<CBGV>();
        }
        public void NhapDanhSach()
        {
            Console.Write("Nhap so can bo giao vien: ");
            if (!int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("So can bo giao vien khong hop le. Vui long nhap lai.");
                NhapDanhSach();
                return;
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhap thong tin CBGV {i + 1}:");
                CBGV cbgv = new CBGV();
                cbgv.Nhap();
                danhSach.Add(cbgv);
            }
        }
        public void TimKiemTheoQue()
        {
            Console.Write("Nhap que quan can tim: ");
            string que = Console.ReadLine();
            bool found = false;
            foreach (var cbgv in danhSach)
            {
                if (cbgv.GetQueQuan().ToLower().Contains(que.ToLower()))
                {
                    cbgv.HienThi();
                    found = true;
                }
            }
            if (!found) Console.WriteLine("Khong tim thay!");
        }
        public void HienThiLuongTren5Trieu()
        {
            if (danhSach.Count == 0) { Console.WriteLine("Danh sach rong!"); return; }
            Console.WriteLine("\nDanh sach CBGV co luong tren 5 trieu:");
            bool found = false;
            foreach (var cbgv in danhSach)
            {
                if (cbgv.GetLuongThucLinh() > 5000000)
                {
                    cbgv.HienThi();
                    found = true;
                }
            }
            if (!found) Console.WriteLine("Khong co CBGV nao luong tren 5 trieu!");
        }
        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n1. Nhap danh sach CBGV");
                Console.WriteLine("2. Tim kiem theo que quan");
                Console.WriteLine("3. Hien thi CBGV luong tren 5 trieu");
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
                    case 2: TimKiemTheoQue(); break;
                    case 3: HienThiLuongTren5Trieu(); break;
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
            new QuanLyCBGV().Menu();
        }
    }
}