using System;
using System.Collections.Generic;

namespace QuanLyTuyenSinh
{
    class ThiSinh
    {
        protected string soBaoDanh, hoTen, diaChi;
        protected float diem1, diem2, diem3;
        protected int uuTien; 

        public virtual void Nhap()
        {
            Console.Write("So bao danh: "); soBaoDanh = Console.ReadLine();
            Console.Write("Ho ten: "); hoTen = Console.ReadLine();
            Console.Write("Dia chi: "); diaChi = Console.ReadLine();
            Console.Write("Uu tien: ");
            if (!int.TryParse(Console.ReadLine(), out uuTien))
            {
                Console.WriteLine("Uu tien khong hop le. Vui long nhap lai.");
                Nhap(); 
                return;
            }
        }
        public virtual void HienThi()
        {
            Console.WriteLine($"SBD: {soBaoDanh}, Ho ten: {hoTen}, Dia chi: {diaChi}, Uu tien: {uuTien}");
        }
        public string GetSBD() => soBaoDanh;
        public virtual float TongDiem() => diem1 + diem2 + diem3 + uuTien; 
        public virtual float DiemChuan() => 0;
    }
    class ThiSinhA : ThiSinh
    {
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Diem Toan: ");
            if (!float.TryParse(Console.ReadLine(), out diem1))
            {
                Console.WriteLine("Diem Toan khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.Write("Diem Ly: ");
            if (!float.TryParse(Console.ReadLine(), out diem2))
            {
                Console.WriteLine("Diem Ly khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.Write("Diem Hoa: ");
            if (!float.TryParse(Console.ReadLine(), out diem3))
            {
                Console.WriteLine("Diem Hoa khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
        }
        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($"Toan: {diem1}, Ly: {diem2}, Hoa: {diem3}, Tong: {TongDiem()}");
        }
        public override float DiemChuan() => 15;
    }
    class ThiSinhB : ThiSinh
    {
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Diem Toan: ");
            if (!float.TryParse(Console.ReadLine(), out diem1))
            {
                Console.WriteLine("Diem Toan khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.Write("Diem Hoa: ");
            if (!float.TryParse(Console.ReadLine(), out diem2))
            {
                Console.WriteLine("Diem Hoa khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.Write("Diem Sinh: ");
            if (!float.TryParse(Console.ReadLine(), out diem3))
            {
                Console.WriteLine("Diem Sinh khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
        }
        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($"Toan: {diem1}, Hoa: {diem2}, Sinh: {diem3}, Tong: {TongDiem()}");
        }

        public override float DiemChuan() => 16;
    }
    class ThiSinhC : ThiSinh
    {
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Diem Van: ");
            if (!float.TryParse(Console.ReadLine(), out diem1))
            {
                Console.WriteLine("Diem Van khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.Write("Diem Su: ");
            if (!float.TryParse(Console.ReadLine(), out diem2))
            {
                Console.WriteLine("Diem Su khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.Write("Diem Dia: ");
            if (!float.TryParse(Console.ReadLine(), out diem3))
            {
                Console.WriteLine("Diem Dia khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
        }
        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($"Van: {diem1}, Su: {diem2}, Dia: {diem3}, Tong: {TongDiem()}");
        }

        public override float DiemChuan() => 13.5f;
    }
    class TuyenSinh
    {
        private List<ThiSinh> danhSach = new List<ThiSinh>();

        public void NhapMoi()
        {
            Console.Write("Chon khoi (1-A, 2-B, 3-C): ");
            if (!int.TryParse(Console.ReadLine(), out int khoi)) 
            {
                Console.WriteLine("Lua chon khoi khong hop le. Vui long nhap lai.");
                return;
            }
            ThiSinh ts = khoi switch
            {
                1 => new ThiSinhA(),
                2 => new ThiSinhB(),
                3 => new ThiSinhC(),
                _ => null
            };
            if (ts == null) { Console.WriteLine("Khoi khong hop le!"); return; }
            ts.Nhap();
            danhSach.Add(ts);
        }
        public void HienThiTrungTuyen()
        {
            if (danhSach.Count == 0) { Console.WriteLine("Danh sach rong!"); return; }
            Console.WriteLine("\nDanh sach thi sinh trung tuyen:");
            bool coThiSinhTrungTuyen = false;
            foreach (var ts in danhSach)
            {
                if (ts.TongDiem() >= ts.DiemChuan())
                {
                    ts.HienThi();
                    coThiSinhTrungTuyen = true;
                }
            }
            if (!coThiSinhTrungTuyen)
            {
                Console.WriteLine("Khong co thi sinh nao trung tuyen.");
            }
        }
        public void TimKiemTheoSBD()
        {
            Console.Write("Nhap SBD can tim: ");
            string sbd = Console.ReadLine();
            bool found = false;
            foreach (var ts in danhSach)
            {
                if (ts.GetSBD().Equals(sbd, StringComparison.OrdinalIgnoreCase)) 
                {
                    Console.WriteLine("\nThong tin thi sinh tim thay:");
                    ts.HienThi();
                    found = true;
                    break; 
                }
            }
            if (!found) Console.WriteLine($"Khong tim thay thi sinh co SBD '{sbd}'.");
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n1. Them thi sinh");
                Console.WriteLine("2. Hien thi thi sinh trung tuyen");
                Console.WriteLine("3. Tim kiem theo SBD");
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
                    case 2: HienThiTrungTuyen(); break;
                    case 3: TimKiemTheoSBD(); break;
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
            new TuyenSinh().Menu();
        }
    }
}