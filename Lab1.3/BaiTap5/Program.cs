using System;
using System.Collections.Generic;

namespace QuanLyKhachSan
{
    class Nguoi
    {
        private string hoTen, cmnd;
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
            Console.Write("CMND: "); cmnd = Console.ReadLine();
        }
        public void HienThi()
        {
            Console.WriteLine($"Ho ten: {hoTen}, Nam sinh: {namSinh}, CMND: {cmnd}");
        }
        public string GetHoTen() => hoTen;
    }
    class KhachTro
    {
        private int soNgayTro;
        private string loaiPhong;
        private double giaPhong;
        private Nguoi khach;
        public KhachTro()
        {
            khach = new Nguoi();
        }
        public void Nhap()
        {
            Console.Write("So ngay tro: ");
            if (!int.TryParse(Console.ReadLine(), out soNgayTro))
            {
                Console.WriteLine("So ngay tro khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.Write("Loai phong: "); loaiPhong = Console.ReadLine();
            Console.Write("Gia phong: ");
            if (!double.TryParse(Console.ReadLine(), out giaPhong))
            {
                Console.WriteLine("Gia phong khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.WriteLine("Nhap thong tin khach:");
            khach.Nhap();
        }
        public void HienThi()
        {
            khach.HienThi();
            Console.WriteLine($"So ngay tro: {soNgayTro}, Loai phong: {loaiPhong}, Gia: {giaPhong}");
            Console.WriteLine("-------------------");
        }
        public double TinhTien() => soNgayTro * giaPhong;
        public string GetTenKhach() => khach.GetHoTen();
    }
    class KhachSan
    {
        private List<KhachTro> danhSach;

        public KhachSan()
        {
            danhSach = new List<KhachTro>();
        }
        public void NhapDanhSach()
        {
            Console.Write("Nhap so khach tro: ");
            if (!int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("So khach tro khong hop le. Vui long nhap lai.");
                NhapDanhSach();
                return;
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhap thong tin khach tro {i + 1}:");
                KhachTro kt = new KhachTro();
                kt.Nhap();
                danhSach.Add(kt);
            }
        }
        public void HienThiDanhSach()
        {
            if (danhSach.Count == 0) { Console.WriteLine("Danh sach rong!"); return; }
            foreach (var kt in danhSach) kt.HienThi();
        }
        public void TimKiemTheoTen()
        {
            Console.Write("Nhap ten can tim: ");
            string ten = Console.ReadLine();
            bool found = false;
            foreach (var kt in danhSach)
            {
                if (kt.GetTenKhach().ToLower().Contains(ten.ToLower()))
                {
                    kt.HienThi();
                    found = true;
                }
            }
            if (!found) Console.WriteLine("Khong tim thay!");
        }
        public void TinhTienThanhToan()
        {
            Console.Write("Nhap ten khach thanh toan: ");
            string ten = Console.ReadLine();
            bool found = false;
            foreach (var kt in danhSach)
            {
                if (kt.GetTenKhach().ToLower().Equals(ten.ToLower()))
                {
                    kt.HienThi();
                    Console.WriteLine($"Tong tien phai tra: {kt.TinhTien()}");
                    found = true;
                    break;
                }
            }
            if (!found) Console.WriteLine("Khong tim thay khach!");
        }
        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n1. Nhap danh sach khach tro");
                Console.WriteLine("2. Hien thi danh sach");
                Console.WriteLine("3. Tim kiem theo ten");
                Console.WriteLine("4. Tinh tien thanh toan");
                Console.WriteLine("5. Thoat");
                Console.Write("Chon: ");
                if (!int.TryParse(Console.ReadLine(), out int chon))
                {
                    Console.WriteLine("Lua chon khong hop le. Vui long nhap lai.");
                    continue;
                }
                if (chon == 5) break;
                switch (chon)
                {
                    case 1: NhapDanhSach(); break;
                    case 2: HienThiDanhSach(); break;
                    case 3: TimKiemTheoTen(); break;
                    case 4: TinhTienThanhToan(); break;
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
            new KhachSan().Menu();
        }
    }
}