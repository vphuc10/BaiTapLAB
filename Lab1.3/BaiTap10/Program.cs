using System;

namespace XuLyVanBan
{
    class VanBan
    {
        private string chuoi;
        public VanBan()
        {
            chuoi = "";
        }

        public VanBan(string st)
        {
            chuoi = st;
        }
        public int DemSoTu()
        {
            if (string.IsNullOrEmpty(chuoi)) return 0;
            string[] tu = chuoi.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return tu.Length;
        }
        public int DemKyTuH()
        {
            if (string.IsNullOrEmpty(chuoi)) return 0;
            int dem = 0;
            foreach (char c in chuoi.ToLower())
            {
                if (c == 'h') dem++;
            }
            return dem;
        }
        public string ChuanHoa()
        {
            if (string.IsNullOrEmpty(chuoi)) return "";
            // Loại bỏ khoảng trắng thừa và chuẩn hóa
            string[] tu = chuoi.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            chuoi = string.Join(" ", tu);
            return chuoi;
        }
        public void Nhap()
        {
            Console.Write("Nhap van ban: ");
            chuoi = Console.ReadLine();
        }
        public void HienThi()
        {
            Console.WriteLine($"Van ban: {chuoi}");
        }
    }
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            VanBan vb = new VanBan();
            while (true)
            {
                Console.WriteLine("\n1. Nhap van ban");
                Console.WriteLine("2. Dem so tu");
                Console.WriteLine("3. Dem so ky tu H");
                Console.WriteLine("4. Chuan hoa van ban");
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
                    case 1:
                        vb.Nhap();
                        vb.HienThi();
                        break;
                    case 2:
                        Console.WriteLine($"So tu: {vb.DemSoTu()}");
                        break;
                    case 3:
                        Console.WriteLine($"So ky tu H: {vb.DemKyTuH()}");
                        break;
                    case 4:
                        vb.ChuanHoa();
                        Console.WriteLine($"Van ban chuan hoa: {vb.chuoi}");
                        break;
                    default:
                        Console.WriteLine("Chon sai!");
                        break;
                }
            }
        }
    }
}