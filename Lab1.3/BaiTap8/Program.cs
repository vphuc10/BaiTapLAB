using System;
using System.Collections.Generic;
using System.Globalization;

namespace QuanLyTheMuon
{
    class SinhVien
    {
        private string hoTen, lop, maSV;
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
            Console.Write("Lop: "); lop = Console.ReadLine();
            Console.Write("Ma SV: "); maSV = Console.ReadLine();
        }
        public void HienThi()
        {
            Console.WriteLine($"Ho ten: {hoTen}, Nam sinh: {namSinh}, Lop: {lop}, Ma SV: {maSV}");
        }

        public string GetMaSV() => maSV;
    }
    class TheMuon
    {
        private string soPhieuMuon, soHieuSach;
        private DateTime ngayMuon, hanTra;
        private SinhVien sinhVien;
        public TheMuon()
        {
            sinhVien = new SinhVien();
        }
        public void Nhap()
        {
            Console.Write("So phieu muon: "); soPhieuMuon = Console.ReadLine();
            Console.Write("Ngay muon (dd/MM/yyyy): ");
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayMuon))
            {
                Console.WriteLine("Ngay muon khong hop le. Vui long nhap lai theo dinh dang dd/MM/yyyy.");
                Nhap();
                return;
            }
            Console.Write("Han tra (dd/MM/yyyy): ");
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out hanTra))
            {
                Console.WriteLine("Han tra khong hop le. Vui long nhap lai theo dinh dang dd/MM/yyyy.");
                Nhap();
                return;
            }
            Console.Write("So hieu sach: "); soHieuSach = Console.ReadLine();
            Console.WriteLine("Nhap thong tin sinh vien:");
            sinhVien.Nhap();
        }
        public void HienThi()
        {
            sinhVien.HienThi();
            Console.WriteLine($"So phieu: {soPhieuMuon}, Ngay muon: {ngayMuon:dd/MM/yyyy}, Han tra: {hanTra:dd/MM/yyyy}, So hieu sach: {soHieuSach}");
            Console.WriteLine("-------------------");
        }
        public string GetMaSV() => sinhVien.GetMaSV();
        public DateTime GetHanTra() => hanTra;
    }
    class QuanLyTheMuon
    {
        private List<TheMuon> danhSach;
        private DateTime ngayHienTai = new DateTime(2025, 4, 9); // Ngày hiện tại: 09/04/2025

        public QuanLyTheMuon()
        {
            danhSach = new List<TheMuon>();
        }
        public void NhapDanhSach()
        {
            Console.Write("Nhap so the muon: ");
            if (!int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("So the muon khong hop le. Vui long nhap lai.");
                NhapDanhSach();
                return;
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhap thong tin the muon {i + 1}:");
                TheMuon tm = new TheMuon();
                tm.Nhap();
                danhSach.Add(tm);
            }
        }
        public void TimKiemTheoMaSV()
        {
            Console.Write("Nhap ma SV can tim: ");
            string maSV = Console.ReadLine();
            bool found = false;
            foreach (var tm in danhSach)
            {
                if (tm.GetMaSV().Equals(maSV))
                {
                    tm.HienThi();
                    found = true;
                    break;
                }
            }
            if (!found) Console.WriteLine("Khong tim thay!");
        }
        public void HienThiDenHanTra()
        {
            if (danhSach.Count == 0) { Console.WriteLine("Danh sach rong!"); return; }
            Console.WriteLine("\nDanh sach the muon den han tra:");
            bool found = false;
            foreach (var tm in danhSach)
            {
                if (tm.GetHanTra() <= ngayHienTai)
                {
                    tm.HienThi();
                    found = true;
                }
            }
            if (!found) Console.WriteLine("Khong co the muon nao den han tra sach!");
        }
        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n1. Nhap danh sach the muon");
                Console.WriteLine("2. Tim kiem theo ma SV");
                Console.WriteLine("3. Hien thi sinh vien den han tra");
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
                    case 2: TimKiemTheoMaSV(); break;
                    case 3: HienThiDenHanTra(); break;
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
            new QuanLyTheMuon().Menu();
        }
    }
}