using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyThiSinh
{
    struct HoTen
    {
        public string ho;
        public string tenDem;
        public string ten;
        public override string ToString()
        {
            return $"{ho} {tenDem} {ten}".Trim();
        }
    }
    struct QueQuan
    {
        public string xa;
        public string huyen;
        public string tinh;
        public override string ToString()
        {
            return $"{xa}, {huyen}, {tinh}";
        }
    }
    struct DiemThi
    {
        public double toan;
        public double ly;
        public double hoa;

        public override string ToString()
        {
            return $"Toán: {toan}, Lý: {ly}, Hóa: {hoa}";
        }
    }
    class Thisinh
    {
        public HoTen hoTen;
        public QueQuan queQuan;
        public string truong;
        public int tuoi;
        public string soBaoDanh;
        public DiemThi diemThi;
        public void Nhap()
        {
            Console.WriteLine("Nhap ho ten:");
            Console.Write("Ho: "); hoTen.ho = Console.ReadLine();
            Console.Write("Ten dem: "); hoTen.tenDem = Console.ReadLine();
            Console.Write("Ten: "); hoTen.ten = Console.ReadLine();
            Console.WriteLine("Nhap que quan:");
            Console.Write("Xa: "); queQuan.xa = Console.ReadLine();
            Console.Write("Huyen: "); queQuan.huyen = Console.ReadLine();
            Console.Write("Tinh: "); queQuan.tinh = Console.ReadLine();
            Console.Write("Nhap truong: "); truong = Console.ReadLine();
            Console.Write("Nhap tuoi: ");
            if (!int.TryParse(Console.ReadLine(), out tuoi) || tuoi <= 0)
            {
                Console.WriteLine("Tuoi khong hop le. Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.Write("Nhap so bao danh: "); soBaoDanh = Console.ReadLine();
            Console.WriteLine("Nhap diem thi:");
            Console.Write("Toan: ");
            if (!double.TryParse(Console.ReadLine(), out diemThi.toan) || diemThi.toan < 0 || diemThi.toan > 10 || diemThi.toan % 0.25 != 0)
            {
                Console.WriteLine("Diem Toan khong hop le (0-10, chinh xac den 1/4). Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.Write("Ly: ");
            if (!double.TryParse(Console.ReadLine(), out diemThi.ly) || diemThi.ly < 0 || diemThi.ly > 10 || diemThi.ly % 0.25 != 0)
            {
                Console.WriteLine("Diem Ly khong hop le (0-10, chinh xac den 1/4). Vui long nhap lai.");
                Nhap();
                return;
            }
            Console.Write("Hoa: ");
            if (!double.TryParse(Console.ReadLine(), out diemThi.hoa) || diemThi.hoa < 0 || diemThi.hoa > 10 || diemThi.hoa % 0.25 != 0)
            {
                Console.WriteLine("Diem Hoa khong hop le (0-10, chinh xac den 1/4). Vui long nhap lai.");
                Nhap();
                return;
            }
        }
        public void In()
        {
            Console.WriteLine($"Ho ten: {hoTen}");
            Console.WriteLine($"Que quan: {queQuan}");
            Console.WriteLine($"Truong: {truong}");
            Console.WriteLine($"Tuoi: {tuoi}");
            Console.WriteLine($"So bao danh: {soBaoDanh}");
            Console.WriteLine($"Diem thi: {diemThi}");
        }
        public double TinhTongDiem()
        {
            return diemThi.toan + diemThi.ly + diemThi.hoa;
        }
    }
    class QuanLyThisinh
    {
        private List<Thisinh> danhSachThisinh;
        public QuanLyThisinh()
        {
            danhSachThisinh = new List<Thisinh>();
        }
        public void DocVaInPhieuDiem()
        {
            Console.WriteLine("\n--- Nhap thong tin mot thi sinh tu phieu diem ---");
            Thisinh ts = new Thisinh();
            ts.Nhap();
            Console.WriteLine("\n--- Thong tin thi sinh vua nhap ---");
            ts.In();
        }
        public void NhapDanhSach(int n)
        {
            Console.WriteLine($"\n--- Nhap thong tin cho {n} thi sinh ---");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhap thong tin thi sinh thu {i + 1}:");
                Thisinh ts = new Thisinh();
                ts.Nhap();
                danhSachThisinh.Add(ts);
            }
        }
        public void TimKiemTongDiemLonHon15()
        {
            Console.WriteLine("\n--- Danh sach thi sinh co tong diem lon hon 15 ---");
            bool found = false;
            foreach (var ts in danhSachThisinh)
            {
                if (ts.TinhTongDiem() > 15)
                {
                    InThongTinBang(ts);
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("Khong co thi sinh nao co tong diem lon hon 15.");
            }
        }
        public void SapXepVaInDanhSachTheoTongDiem()
        {
            Console.WriteLine("\n--- Danh sach thi sinh sau khi sap xep theo tong diem giam dan ---");
            var danhSachSapXep = danhSachThisinh.OrderByDescending(ts => ts.TinhTongDiem()).ToList();
            if (danhSachSapXep.Count > 0)
            {
                Console.WriteLine("{0,-20} {1,-30} {2,-15} {3,-10} {4,-10} {5,-10}",
                                  "Ho Ten", "Que Quan", "So Bao Danh", "Toan", "Ly", "Hoa");
                Console.WriteLine(new string('-', 85));
                foreach (var ts in danhSachSapXep)
                {
                    InThongTinBang(ts);
                }
            }
            else
            {
                Console.WriteLine("Danh sach thi sinh rong!");
            }
        }
        private void InThongTinBang(Thisinh ts)
        {
            Console.WriteLine("{0,-20} {1,-30} {2,-15} {3,-10} {4,-10} {5,-10}",
                              ts.hoTen, ts.queQuan, ts.soBaoDanh, ts.diemThi.toan, ts.diemThi.ly, ts.diemThi.hoa);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            QuanLyThisinh qlts = new QuanLyThisinh();
            qlts.DocVaInPhieuDiem();
            Console.Write("\nNhap so luong thi sinh N: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                qlts.NhapDanhSach(n);
                qlts.TimKiemTongDiemLonHon15();
                qlts.SapXepVaInDanhSachTheoTongDiem();
            }
            else
            {
                Console.WriteLine("So luong thi sinh khong hop le.");
            }

            Console.ReadKey();
        }
    }
}