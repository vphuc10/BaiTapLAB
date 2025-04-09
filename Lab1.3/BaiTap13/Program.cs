using System;
using System.Collections.Generic;

namespace QuanLyPhuongTien
{
    class PTGT
    {
        protected string hangSanXuat, mau;
        protected int namSanXuat;
        protected double giaBan;
        public virtual void Nhap()
        {
            Console.Write("Hang san xuat: "); hangSanXuat = Console.ReadLine();
            Console.Write("Nam san xuat: ");
            if (!int.TryParse(Console.ReadLine(), out namSanXuat))
            {
                Console.WriteLine("Nam san xuat khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.Write("Gia ban: ");
            if (!double.TryParse(Console.ReadLine(), out giaBan))
            {
                Console.WriteLine("Gia ban khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.Write("Mau: "); mau = Console.ReadLine();
        }
        public virtual void HienThi()
        {
            Console.WriteLine($"Hang: {hangSanXuat}, Nam: {namSanXuat}, Gia: {giaBan}, Mau: {mau}");
        }

        public string GetMau() => mau;
        public int GetNamSanXuat() => namSanXuat;
    }
    class OTo : PTGT
    {
        private int soChoNgoi;
        private string kieuDongCo;
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("So cho ngoi: ");
            if (!int.TryParse(Console.ReadLine(), out soChoNgoi))
            {
                Console.WriteLine("So cho ngoi khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.Write("Kieu dong co: "); kieuDongCo = Console.ReadLine();
        }
        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($"So cho: {soChoNgoi}, Dong co: {kieuDongCo}");
            Console.WriteLine("-------------------");
        }
    }
    class XeMay : PTGT
    {
        private string congSuat;
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Cong suat: "); congSuat = Console.ReadLine();
        }
        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($"Cong suat: {congSuat}");
            Console.WriteLine("-------------------");
        }
    }
    class XeTai : PTGT
    {
        private double trongTai;
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Trong tai: ");
            if (!double.TryParse(Console.ReadLine(), out trongTai))
            {
                Console.WriteLine("Trong tai khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
        }
        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($"Trong tai: {trongTai}");
            Console.WriteLine("-------------------");
        }
    }
    class QLPTGT
    {
        private List<PTGT> danhSach;

        public QLPTGT()
        {
            danhSach = new List<PTGT>();
        }
        public void NhapDangKy()
        {
            Console.Write("Chon loai (1-OTo, 2-XeMay, 3-XeTai): ");
            if (!int.TryParse(Console.ReadLine(), out int loai))
            {
                Console.WriteLine("Lua chon khong hop le. Vui long nhap lai.");
                return;
            }
            PTGT pt = loai switch
            {
                1 => new OTo(),
                2 => new XeMay(),
                3 => new XeTai(),
                _ => null
            };
            if (pt == null) { Console.WriteLine("Loai khong hop le!"); return; }
            pt.Nhap();
            danhSach.Add(pt);
            Console.WriteLine("Dang ky thanh cong!");
        }
        public void TimKiem()
        {
            Console.Write("Chon kieu tim (1-Theo mau, 2-Theo nam): ");
            if (!int.TryParse(Console.ReadLine(), out int kieuTim))
            {
                Console.WriteLine("Lua chon khong hop le. Vui long nhap lai.");
                return;
            }
            bool found = false;
            if (kieuTim == 1)
            {
                Console.Write("Nhap mau can tim: ");
                string mauTim = Console.ReadLine();
                foreach (var pt in danhSach)
                {
                    if (pt.GetMau().ToLower().Equals(mauTim.ToLower()))
                    {
                        pt.HienThi();
                        found = true;
                    }
                }
            }
            else if (kieuTim == 2)
            {
                Console.Write("Nhap nam san xuat can tim: ");
                if (!int.TryParse(Console.ReadLine(), out int namTim))
                {
                    Console.WriteLine("Nam khong hop le. Vui long nhap lai.");
                    return;
                }
                foreach (var pt in danhSach)
                {
                    if (pt.GetNamSanXuat() == namTim)
                    {
                        pt.HienThi();
                        found = true;
                    }
                }
            }
            else
            {
                Console.WriteLine("Kieu tim kiem khong hop le!");
                return;
            }

            if (!found) Console.WriteLine("Khong tim thay!");
        }
        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n1. Nhap dang ky phuong tien");
                Console.WriteLine("2. Tim kiem phuong tien");
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
                    case 1: NhapDangKy(); break;
                    case 2: TimKiem(); break;
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
            new QLPTGT().Menu();
        }
    }
}