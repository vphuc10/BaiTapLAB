using System;
using System.Collections.Generic;

namespace QuanLyBienLaiDien
{
    class KhachHang
    {
        private string hoTen, soNha, maCongTo;
        public void Nhap()
        {
            Console.Write("Ho ten chu ho: "); hoTen = Console.ReadLine();
            Console.Write("So nha: "); soNha = Console.ReadLine();
            Console.Write("Ma cong to: "); maCongTo = Console.ReadLine();
        }
        public void HienThi()
        {
            Console.WriteLine($"Ho ten: {hoTen}, So nha: {soNha}, Ma cong to: {maCongTo}");
        }
    }
    class BienLai
    {
        private int chiSoCu, chiSoMoi;
        private double soTienPhaiTra;
        private KhachHang khachHang;
        public BienLai()
        {
            khachHang = new KhachHang();
        }
        public void Nhap()
        {
            Console.WriteLine("Nhap thong tin khach hang:");
            khachHang.Nhap();
            Console.Write("Chi so cu: ");
            if (!int.TryParse(Console.ReadLine(), out chiSoCu))
            {
                Console.WriteLine("Chi so cu khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.Write("Chi so moi: ");
            if (!int.TryParse(Console.ReadLine(), out chiSoMoi))
            {
                Console.WriteLine("Chi so moi khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            TinhTien();
        }
        public void HienThi()
        {
            khachHang.HienThi();
            Console.WriteLine($"Chi so cu: {chiSoCu}, Chi so moi: {chiSoMoi}, Tien phai tra: {soTienPhaiTra} VND");
            Console.WriteLine("-------------------");
        }
        public void TinhTien()
        {
            int soDien = chiSoMoi - chiSoCu;
            if (soDien < 50)
                soTienPhaiTra = soDien * 1250;
            else if (soDien < 100)
                soTienPhaiTra = soDien * 1500;
            else
                soTienPhaiTra = soDien * 2000;
        }
    }
    class QuanLyBienLai
    {
        private List<BienLai> danhSach;

        public QuanLyBienLai()
        {
            danhSach = new List<BienLai>();
        }
        public void NhapDanhSach()
        {
            Console.Write("Nhap so ho su dung dien: ");
            if (!int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("So ho su dung dien khong hop le. Vui long nhap lai.");
                NhapDanhSach();
                return;
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhap thong tin bien lai {i + 1}:");
                BienLai bl = new BienLai();
                bl.Nhap();
                danhSach.Add(bl);
            }
        }
        public void HienThiDanhSach()
        {
            if (danhSach.Count == 0) { Console.WriteLine("Danh sach rong!"); return; }
            Console.WriteLine("\nDanh sach bien lai dien:");
            foreach (var bl in danhSach) bl.HienThi();
        }
        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n1. Nhap danh sach bien lai");
                Console.WriteLine("2. Hien thi danh sach bien lai");
                Console.WriteLine("3. Thoat");
                Console.Write("Chon: ");
                if (!int.TryParse(Console.ReadLine(), out int chon))
                {
                    Console.WriteLine("Lua chon khong hop le. Vui long nhap lai.");
                    continue;
                }
                if (chon == 3) break;
                switch (chon)
                {
                    case 1: NhapDanhSach(); break;
                    case 2: HienThiDanhSach(); break;
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
            new QuanLyBienLai().Menu();
        }
    }
}