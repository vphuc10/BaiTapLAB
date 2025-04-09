using System;
using System.Collections.Generic;

namespace QuanLyCanBo
{
    class CanBo
    {
        protected string hoTen, gioiTinh, diaChi;
        protected int namSinh;

        public virtual void Nhap()
        {
            Console.Write("Ho ten: "); hoTen = Console.ReadLine();
            Console.Write("Nam sinh: ");
            if (!int.TryParse(Console.ReadLine(), out namSinh))
            {
                Console.WriteLine("Nam sinh khong hop le. Vui long nhap lai.");
                Nhap(); // Recursive call to re-enter input
                return;
            }
            Console.Write("Gioi tinh: "); gioiTinh = Console.ReadLine();
            Console.Write("Dia chi: "); diaChi = Console.ReadLine();
        }

        public virtual void HienThi()
        {
            Console.WriteLine($"Ho ten: {hoTen}, Nam sinh: {namSinh}, Gioi tinh: {gioiTinh}, Dia chi: {diaChi}");
        }

        public string GetHoTen() => hoTen;
    }

    class CongNhan : CanBo
    {
        private string bac;
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Bac: "); bac = Console.ReadLine();
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($"Bac: {bac}");
        }
    }

    class KySu : CanBo
    {
        private string nganh;
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nganh dao tao: "); nganh = Console.ReadLine();
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($"Nganh: {nganh}");
        }
    }

    class NhanVien : CanBo
    {
        private string congViec;
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Cong viec: "); congViec = Console.ReadLine();
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($"Cong viec: {congViec}");
        }
    }

    class QLCB
    {
        private List<CanBo> danhSach = new List<CanBo>();

        public void NhapMoi()
        {
            Console.Write("Chon loai (1-Cong nhan, 2-Ky su, 3-Nhan vien): ");
            if (!int.TryParse(Console.ReadLine(), out int loai))
            {
                Console.WriteLine("Lua chon khong hop le. Vui long nhap lai.");
                return;
            }
            CanBo cb = loai switch
            {
                1 => new CongNhan(),
                2 => new KySu(),
                3 => new NhanVien(),
                _ => null
            };
            if (cb == null) { Console.WriteLine("Loai khong hop le!"); return; }
            cb.Nhap();
            danhSach.Add(cb);
        }

        public void TimKiem()
        {
            Console.Write("Nhap ten can tim: ");
            string ten = Console.ReadLine();
            bool found = false;
            foreach (var cb in danhSach)
            {
                if (cb.GetHoTen().ToLower().Contains(ten.ToLower()))
                {
                    cb.HienThi();
                    found = true;
                }
            }
            if (!found) Console.WriteLine("Khong tim thay!");
        }

        public void HienThiDanhSach()
        {
            if (danhSach.Count == 0) { Console.WriteLine("Danh sach rong!"); return; }
            foreach (var cb in danhSach) cb.HienThi();
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n1. Them can bo");
                Console.WriteLine("2. Tim kiem theo ten");
                Console.WriteLine("3. Hien thi danh sach");
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
                    case 1: NhapMoi(); break;
                    case 2: TimKiem(); break;
                    case 3: HienThiDanhSach(); break;
                    default: Console.WriteLine("Chon sai!"); break;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args) // Added string[] args for completeness
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            new QLCB().Menu();
        }
    }
}