using System;
using System.Collections.Generic;

namespace QuanLyTaiLieu
{
    class TaiLieu
    {
        protected string maTaiLieu, tenNhaXuatBan;
        protected int soBanPhatHanh;

        public virtual void Nhap()
        {
            Console.Write("Ma tai lieu: "); maTaiLieu = Console.ReadLine();
            Console.Write("Ten nha xuat ban: "); tenNhaXuatBan = Console.ReadLine();
            Console.Write("So ban phat hanh: ");
            if (!int.TryParse(Console.ReadLine(), out soBanPhatHanh))
            {
                Console.WriteLine("So ban phat hanh khong hop le. Vui long nhap lai.");
                Nhap(); 
                return;
            }
        }
        public virtual void HienThi()
        {
            Console.WriteLine($"Ma: {maTaiLieu}, Nha xuat ban: {tenNhaXuatBan}, So ban: {soBanPhatHanh}");
        }

        public string GetLoai() => this.GetType().Name;
    }
    class Sach : TaiLieu
    {
        private string tenTacGia;
        private int soTrang;
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Ten tac gia: "); tenTacGia = Console.ReadLine();
            Console.Write("So trang: ");
            if (!int.TryParse(Console.ReadLine(), out soTrang))
            {
                Console.WriteLine("So trang khong hop le. Vui long nhap lai.");
                Nhap(); 
                return;
            }
        }
        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($"Tac gia: {tenTacGia}, So trang: {soTrang}");
        }
    }
    class TapChi : TaiLieu
    {
        private string soPhatHanh;
        private int thangPhatHanh;

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("So phat hanh: "); soPhatHanh = Console.ReadLine();
            Console.Write("Thang phat hanh: ");
            if (!int.TryParse(Console.ReadLine(), out thangPhatHanh))
            {
                Console.WriteLine("Thang phat hanh khong hop le. Vui long nhap lai.");
                Nhap(); 
                return;
            }
            if (thangPhatHanh < 1 || thangPhatHanh > 12)
            {
                Console.WriteLine("Thang phat hanh khong hop le (1-12). Vui long nhap lai.");
                Nhap();
                return;
            }
        }
        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($"So phat hanh: {soPhatHanh}, Thang: {thangPhatHanh}");
        }
    }
    class Bao : TaiLieu
    {
        private string ngayPhatHanh;
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Ngay phat hanh (dd/mm/yyyy): "); ngayPhatHanh = Console.ReadLine();
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($"Ngay phat hanh: {ngayPhatHanh}");
        }
    }
    class QuanLyTaiLieu
    {
        private List<TaiLieu> danhSach = new List<TaiLieu>();

        public void NhapMoi()
        {
            Console.Write("Chon loai (1-Sach, 2-Tap chi, 3-Bao): ");
            if (!int.TryParse(Console.ReadLine(), out int loai))
            {
                Console.WriteLine("Lua chon khong hop le. Vui long nhap lai.");
                return;
            }
            TaiLieu tl = loai switch
            {
                1 => new Sach(),
                2 => new TapChi(),
                3 => new Bao(),
                _ => null
            };
            if (tl == null)
            {
                Console.WriteLine("Loai khong hop le!");
                return;
            }
            tl.Nhap();
            danhSach.Add(tl);
        }
        public void HienThiDanhSach()
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sach rong!");
                return;
            }
            foreach (var tl in danhSach) tl.HienThi();
        }
        public void TimKiemTheoLoai()
        {
            Console.Write("Nhap loai can tim (Sach/TapChi/Bao): ");
            string loai = Console.ReadLine();
            bool found = false;
            foreach (var tl in danhSach)
            {
                if (tl.GetLoai().Equals(loai, StringComparison.OrdinalIgnoreCase))
                {
                    tl.HienThi();
                    found = true;
                }
            }
            if (!found) Console.WriteLine("Khong tim thay!");
        }
        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n1. Them tai lieu");
                Console.WriteLine("2. Hien thi danh sach");
                Console.WriteLine("3. Tim kiem theo loai");
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
                    case 2: HienThiDanhSach(); break;
                    case 3: TimKiemTheoLoai(); break;
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
            new QuanLyTaiLieu().Menu();
        }
    }
}