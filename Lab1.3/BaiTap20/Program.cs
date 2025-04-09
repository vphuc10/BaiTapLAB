using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; 
        Console.Write("Nhập số học sinh: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Số học sinh không hợp lệ.");
            return;
        }

        // Mảng lưu thông tin học sinh
        string[] hoTen = new string[n];
        bool[] laNam = new bool[n]; 
        double[] diemToan = new double[n];
        double[] diemLy = new double[n];
        double[] diemHoa = new double[n];
        double[] diemKyThuat = new double[n]; 
        double[] diemNuCong = new double[n];  

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nNhập thông tin học sinh {i + 1}:");
            Console.Write("Họ tên: ");
            hoTen[i] = Console.ReadLine();
            Console.Write("Giới tính (nam/nữ): ");
            string gioiTinh;
            do
            {
                gioiTinh = Console.ReadLine().ToLower();
                if (gioiTinh != "nam" && gioiTinh != "nữ")
                {
                    Console.WriteLine("Giới tính không hợp lệ. Vui lòng nhập 'nam' hoặc 'nữ': ");
                }
            } while (gioiTinh != "nam" && gioiTinh != "nữ");
            laNam[i] = (gioiTinh == "nam");
            Console.Write("Điểm Toán: ");
            if (!double.TryParse(Console.ReadLine(), out diemToan[i]) || diemToan[i] < 0 || diemToan[i] > 10)
            {
                Console.WriteLine("Điểm Toán không hợp lệ (0-10). Vui lòng nhập lại.");
                i--; 
                continue;
            }
            Console.Write("Điểm Lý: ");
            if (!double.TryParse(Console.ReadLine(), out diemLy[i]) || diemLy[i] < 0 || diemLy[i] > 10)
            {
                Console.WriteLine("Điểm Lý không hợp lệ (0-10). Vui lòng nhập lại.");
                i--; 
                continue;
            }
            Console.Write("Điểm Hóa: ");
            if (!double.TryParse(Console.ReadLine(), out diemHoa[i]) || diemHoa[i] < 0 || diemHoa[i] > 10)
            {
                Console.WriteLine("Điểm Hóa không hợp lệ (0-10). Vui lòng nhập lại.");
                i--; 
                continue;
            }
            if (laNam[i]) 
            {
                Console.Write("Điểm Kỹ Thuật: ");
                if (!double.TryParse(Console.ReadLine(), out diemKyThuat[i]) || diemKyThuat[i] < 0 || diemKyThuat[i] > 10)
                {
                    Console.WriteLine("Điểm Kỹ Thuật không hợp lệ (0-10). Vui lòng nhập lại.");
                    i--; 
                    continue;
                }
            }
            else 
            {
                Console.Write("Điểm Nữ Công: ");
                if (!double.TryParse(Console.ReadLine(), out diemNuCong[i]) || diemNuCong[i] < 0 || diemNuCong[i] > 10)
                {
                    Console.WriteLine("Điểm Nữ Công không hợp lệ (0-10). Vui lòng nhập lại.");
                    i--; 
                    continue;
                }
            }
        }
        Console.WriteLine("\nHọc sinh nam có điểm Kỹ Thuật >= 8:");
        bool foundNamKyThuat = false;
        for (int i = 0; i < n; i++)
        {
            if (laNam[i] && diemKyThuat[i] >= 8)
            {
                Console.WriteLine($"Họ tên: {hoTen[i]}, Điểm Kỹ Thuật: {diemKyThuat[i]}");
                foundNamKyThuat = true;
            }
        }
        if (!foundNamKyThuat)
        {
            Console.WriteLine("Không có học sinh nam nào có điểm Kỹ Thuật >= 8.");
        }
        Console.WriteLine("\nDanh sách học sinh nam:");
        bool foundNam = false;
        for (int i = 0; i < n; i++)
        {
            if (laNam[i])
            {
                Console.WriteLine($"Họ tên: {hoTen[i]}, Toán: {diemToan[i]}, Lý: {diemLy[i]}, Hóa: {diemHoa[i]}, Kỹ Thuật: {diemKyThuat[i]}");
                foundNam = true;
            }
        }
        if (!foundNam)
        {
            Console.WriteLine("Không có học sinh nam nào.");
        }
        Console.WriteLine("\nDanh sách học sinh nữ:");
        bool foundNu = false;
        for (int i = 0; i < n; i++)
        {
            if (!laNam[i])
            {
                Console.WriteLine($"Họ tên: {hoTen[i]}, Toán: {diemToan[i]}, Lý: {diemLy[i]}, Hóa: {diemHoa[i]}, Nữ Công: {diemNuCong[i]}");
                foundNu = true;
            }
        }
        if (!foundNu)
        {
            Console.WriteLine("Không có học sinh nữ nào.");
        }
        Console.ReadKey();
    }
}