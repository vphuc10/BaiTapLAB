using System;
using System.Collections.Generic;

namespace QuanLyKhuPho
{
    class Nguoi
    {
        private string cmnd, hoTen, ngheNghiep;
        private int tuoi, namSinh;
        public void Nhap()
        {
            Console.Write("CMND: "); cmnd = Console.ReadLine();
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
            Console.Write("Nghe nghiep: "); ngheNghiep = Console.ReadLine();
        }
        public void HienThi()
        {
            Console.WriteLine($"CMND: {cmnd}, Ho ten: {hoTen}, Tuoi: {tuoi}, Nam sinh: {namSinh}, Nghe: {ngheNghiep}");
        }

        public string GetHoTen() => hoTen;
    }
    class HoDan
    {
        private int soThanhVien, soNha;
        private List<Nguoi> thanhVien;
        public HoDan()
        {
            thanhVien = new List<Nguoi>();
        }
        public void Nhap()
        {
            Console.Write("So nha: ");
            if (!int.TryParse(Console.ReadLine(), out soNha))
            {
                Console.WriteLine("So nha khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.Write("So thanh vien: ");
            if (!int.TryParse(Console.ReadLine(), out soThanhVien))
            {
                Console.WriteLine("So thanh vien khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.WriteLine("Nhap thong tin cho tung thanh vien:");
            for (int i = 0; i < soThanhVien; i++)
            {
                Console.WriteLine($"Thanh vien {i + 1}:");
                Nguoi nguoi = new Nguoi();
                nguoi.Nhap();
                thanhVien.Add(nguoi);
            }
        }
        public void HienThi()
        {
            Console.WriteLine($"So nha: {soNha}, So thanh vien: {soThanhVien}");
            Console.WriteLine("Danh sach thanh vien:");
            foreach (var tv in thanhVien) tv.HienThi();
            Console.WriteLine("-------------------");
        }
        public int GetSoNha() => soNha;
        public bool ContainsTen(string ten)
        {
            foreach (var tv in thanhVien)
                if (tv.GetHoTen().ToLower().Contains(ten.ToLower()))
                    return true;
            return false;
        }
    }
    class KhuPho
    {
        private List<HoDan> danhSach;

        public KhuPho()
        {
            danhSach = new List<HoDan>();
        }
        public void NhapDanhSach()
        {
            Console.Write("Nhap so ho dan: ");
            if (!int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("So ho dan khong hop le. Vui long nhap lai.");
                NhapDanhSach();
                return;
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhap thong tin ho dan {i + 1}:");
                HoDan ho = new HoDan();
                ho.Nhap();
                danhSach.Add(ho);
            }
        }
        public void HienThiDanhSach()
        {
            if (danhSach.Count == 0) { Console.WriteLine("Danh sach rong!"); return; }
            foreach (var ho in danhSach) ho.HienThi();
        }
        public void TimKiem()
        {
            Console.Write("Chon kieu tim (1-Theo ten, 2-Theo so nha): ");
            if (!int.TryParse(Console.ReadLine(), out int kieuTim))
            {
                Console.WriteLine("Lua chon kieu tim khong hop le. Vui long nhap lai.");
                return;
            }
            bool found = false;
            if (kieuTim == 1)
            {
                Console.Write("Nhap ten can tim: ");
                string ten = Console.ReadLine();
                foreach (var ho in danhSach)
                {
                    if (ho.ContainsTen(ten))
                    {
                        ho.HienThi();
                        found = true;
                    }
                }
            }
            else if (kieuTim == 2)
            {
                Console.Write("Nhap so nha can tim: ");
                if (!int.TryParse(Console.ReadLine(), out int soNhaTim))
                {
                    Console.WriteLine("So nha khong hop le. Vui long nhap lai.");
                    return;
                }
                foreach (var ho in danhSach)
                {
                    if (ho.GetSoNha() == soNhaTim)
                    {
                        ho.HienThi();
                        found = true;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Kieu tim khong hop le.");
                return;
            }

            if (!found) Console.WriteLine("Khong tim thay!");
        }
        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n1. Nhap danh sach ho dan");
                Console.WriteLine("2. Hien thi danh sach");
                Console.WriteLine("3. Tim kiem");
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
                    case 2: HienThiDanhSach(); break;
                    case 3: TimKiem(); break;
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
            new KhuPho().Menu();
        }
    }
}