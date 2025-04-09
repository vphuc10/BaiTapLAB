using System;
using System.Collections.Generic;

namespace QuanLyCoQuan
{
    class Nguoi
    {
        protected string hoTen, gioiTinh;
        protected int tuoi;
        public Nguoi()
        {
            hoTen = "";
            gioiTinh = "Nam";
            tuoi = 0;
        }
        public Nguoi(string ten, string gt, int t)
        {
            hoTen = ten;
            gioiTinh = gt;
            tuoi = t;
        }
        public virtual void In()
        {
            Console.WriteLine($"Ho ten: {hoTen}, Gioi tinh: {gioiTinh}, Tuoi: {tuoi}");
        }
        public string GetHoTen() => hoTen;
    }
    class CoQuan : Nguoi
    {
        private string donViCongTac;
        private double heSoLuong;
        private const double LUONG_CO_BAN = 1050000;
        public CoQuan() : base()
        {
            donViCongTac = "";
            heSoLuong = 0;
        }
        public CoQuan(string ten, string gt, int t, string dv, double hsl) : base(ten, gt, t)
        {
            donViCongTac = dv;
            heSoLuong = hsl;
        }
        public void Nhap()
        {
            Console.Write("Ho ten: "); hoTen = Console.ReadLine();
            Console.Write("Gioi tinh: "); gioiTinh = Console.ReadLine();
            Console.Write("Tuoi: ");
            if (!int.TryParse(Console.ReadLine(), out tuoi) || tuoi <= 0)
            {
                Console.WriteLine("Tuoi khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.Write("Don vi cong tac: "); donViCongTac = Console.ReadLine();
            Console.Write("He so luong: ");
            if (!double.TryParse(Console.ReadLine(), out heSoLuong) || heSoLuong < 0)
            {
                Console.WriteLine("He so luong khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
        }
        public override void In()
        {
            base.In();
            Console.WriteLine($"Don vi: {donViCongTac}, He so luong: {heSoLuong}, Luong: {TinhLuong():N0} VND");
            Console.WriteLine("-------------------");
        }
        public double TinhLuong()
        {
            return heSoLuong * LUONG_CO_BAN;
        }

        public string GetDonVi() => donViCongTac;
    }
    class QuanLyCoQuan
    {
        private List<CoQuan> danhSach;

        public QuanLyCoQuan()
        {
            danhSach = new List<CoQuan>();
        }
        public void NhapDanhSach()
        {
            Console.Write("Nhap so ca nhan: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("So ca nhan khong hop le. Vui long nhap lai.");
                NhapDanhSach();
                return;
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhap ca nhan {i + 1}:");
                CoQuan cq = new CoQuan();
                cq.Nhap();
                danhSach.Add(cq);
            }
        }
        public void HienThiPhongTaiChinh()
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sach rong!");
                return;
            }
            bool found = false;
            Console.WriteLine("Cac ca nhan o Phong tai chinh:");
            foreach (var cq in danhSach)
            {
                if (cq.GetDonVi().ToLower() == "phong tai chinh")
                {
                    cq.In();
                    found = true;
                }
            }
            if (!found) Console.WriteLine("Khong co ca nhan nao o Phong tai chinh!");
        }
        public void TimKiemTheoTen()
        {
            Console.Write("Nhap ho ten can tim: ");
            string ten = Console.ReadLine();
            bool found = false;
            Console.WriteLine("Ket qua tim kiem:");
            foreach (var cq in danhSach)
            {
                if (cq.GetHoTen().ToLower().Contains(ten.ToLower()))
                {
                    cq.In();
                    found = true;
                }
            }
            if (!found) Console.WriteLine("Khong tim thay!");
        }
        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n1. Nhap danh sach ca nhan");
                Console.WriteLine("2. Hien thi ca nhan o Phong tai chinh");
                Console.WriteLine("3. Tim kiem theo ho ten");
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
                    case 2: HienThiPhongTaiChinh(); break;
                    case 3: TimKiemTheoTen(); break;
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
            new QuanLyCoQuan().Menu();
        }
    }
}