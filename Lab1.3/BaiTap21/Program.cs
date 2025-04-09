using System;
using System.Collections.Generic;

namespace QuanLyHocSinh
{
    class HocSinh
    {
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public double DiemToan { get; set; }
        public double DiemLy { get; set; }
        public double DiemHoa { get; set; }
        public double DiemMonThem { get; set; }
        public HocSinh()
        {
            HoTen = "";
            GioiTinh = "";
            DiemToan = 0;
            DiemLy = 0;
            DiemHoa = 0;
            DiemMonThem = 0;
        }
        public void Nhap()
        {
            Console.Write("Nhap ho ten: ");
            HoTen = Console.ReadLine();

            Console.Write("Nhap gioi tinh (Nam/Nu): ");
            GioiTinh = Console.ReadLine();
            while (GioiTinh.ToLower() != "nam" && GioiTinh.ToLower() != "nu")
            {
                Console.WriteLine("Gioi tinh khong hop le. Vui long nhap lai (Nam/Nu): ");
                GioiTinh = Console.ReadLine();
            }
            Console.Write("Nhap diem Toan: ");
            if (!double.TryParse(Console.ReadLine(), out DiemToan) || DiemToan < 0 || DiemToan > 10)
            {
                Console.WriteLine("Diem Toan khong hop le (0-10). Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.Write("Nhap diem Ly: ");
            if (!double.TryParse(Console.ReadLine(), out DiemLy) || DiemLy < 0 || DiemLy > 10)
            {
                Console.WriteLine("Diem Ly khong hop le (0-10). Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.Write("Nhap diem Hoa: ");
            if (!double.TryParse(Console.ReadLine(), out DiemHoa) || DiemHoa < 0 || DiemHoa > 10)
            {
                Console.WriteLine("Diem Hoa khong hop le (0-10). Vui long nhap lai.");
                Nhap();
                return;
            }
            if (GioiTinh.ToLower() == "nam")
            {
                Console.Write("Nhap diem Kĩ thuật: ");
                if (!double.TryParse(Console.ReadLine(), out DiemMonThem) || DiemMonThem < 0 || DiemMonThem > 10)
                {
                    Console.WriteLine("Diem Kĩ thuật khong hop le (0-10). Vui long nhap lai.");
                    Nhap();
                    return;
                }
            }
            else
            {
                Console.Write("Nhap diem Nữ công: ");
                if (!double.TryParse(Console.ReadLine(), out DiemMonThem) || DiemMonThem < 0 || DiemMonThem > 10)
                {
                    Console.WriteLine("Diem Nữ công khong hop le (0-10). Vui long nhap lai.");
                    Nhap();
                    return;
                }
            }
        }
        public void HienThiThongTin()
        {
            Console.WriteLine($"Ho ten: {HoTen}, Gioi tinh: {GioiTinh}, Toan: {DiemToan}, Ly: {DiemLy}, Hoa: {DiemHoa}, {(GioiTinh.ToLower() == "nam" ? "Kĩ thuật" : "Nữ công")}: {DiemMonThem}");
        }
    }
    class QuanLyHocSinh
    {
        private List<HocSinh> danhSachHocSinh;

        public QuanLyHocSinh()
        {
            danhSachHocSinh = new List<HocSinh>();
        }
        public void NhapDanhSach(int n)
        {
            Console.WriteLine($"\n--- Nhap thong tin cho {n} hoc sinh ---");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhap thong tin hoc sinh thu {i + 1}:");
                HocSinh hs = new HocSinh();
                hs.Nhap();
                danhSachHocSinh.Add(hs);
                Console.WriteLine("--------------------");
            }
        }
        public void HienThiHocSinhNamKThuatLonHonHoacBang8()
        {
            Console.WriteLine("\n--- Hoc sinh nam co diem Kĩ thuat >= 8 ---");
            bool found = false;
            foreach (var hs in danhSachHocSinh)
            {
                if (hs.GioiTinh.ToLower() == "nam" && hs.DiemMonThem >= 8)
                {
                    hs.HienThiThongTin();
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("Khong tim thay hoc sinh nam nao co diem Kĩ thuat >= 8.");
            }
        }
        public void InDanhSachTheoGioiTinh()
        {
            Console.WriteLine("\n--- Danh sach hoc sinh (Nam truoc, Nu sau) ---");
            Console.WriteLine("--- Hoc sinh Nam ---");
            foreach (var hs in danhSachHocSinh)
            {
                if (hs.GioiTinh.ToLower() == "nam")
                {
                    hs.HienThiThongTin();
                }
            }
            Console.WriteLine("\n--- Hoc sinh Nu ---");
            foreach (var hs in danhSachHocSinh)
            {
                if (hs.GioiTinh.ToLower() == "nu")
                {
                    hs.HienThiThongTin();
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            QuanLyHocSinh qlhs = new QuanLyHocSinh();
            Console.Write("Nhap so luong hoc sinh n: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                qlhs.NhapDanhSach(n);
                qlhs.HienThiHocSinhNamKThuatLonHonHoacBang8();
                qlhs.InDanhSachTheoGioiTinh();
            }
            else
            {
                Console.WriteLine("So luong hoc sinh khong hop le.");
            }
            Console.ReadKey();
        }
    }
}