using System;
using System.Collections.Generic;
using System.Globalization;

// Lop HocSinh
class HocSinh
{
    private string hoTen;
    private int namSinh;
    private double tongDiem;
    public HocSinh() { }
    public void Nhap()
    {
        Console.Write("Nhap ho ten: ");
        hoTen = Console.ReadLine();
        Console.Write("Nhap nam sinh: ");
        namSinh = int.Parse(Console.ReadLine());
        Console.Write("Nhap tong diem: ");
        tongDiem = double.Parse(Console.ReadLine());
    }
    public void HienThi()
    {
        TextInfo textInfo = new CultureInfo("vi-VN", false).TextInfo;
        string hoTenChuHoa = textInfo.ToTitleCase(hoTen.ToLower());
        Console.WriteLine($"Ho ten: {hoTenChuHoa}, Nam sinh: {namSinh}, Tong diem: {tongDiem}");
    }
    public double LayTongDiem() { return tongDiem; }
    public int LayNamSinh() { return namSinh; }
}
class Program
{
    static void Main(string[] args)
    {
        List<HocSinh> danhSachHocSinh = new List<HocSinh>();

        Console.Write("Nhap so luong hoc sinh: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Nhap thong tin hoc sinh thu {i + 1}:");
            HocSinh hocSinh = new HocSinh();
            hocSinh.Nhap();
            danhSachHocSinh.Add(hocSinh);
        }
        danhSachHocSinh.Sort((hs1, hs2) => {
            int compareDiem = hs2.LayTongDiem().CompareTo(hs1.LayTongDiem());
            if (compareDiem == 0)
            {
                return hs1.LayNamSinh().CompareTo(hs2.LayNamSinh());
            }
            return compareDiem;
        });
        Console.WriteLine("\nDanh sach hoc sinh sau khi sap xep:");
        foreach (var hocSinh in danhSachHocSinh)
        {
            hocSinh.HienThi();
        }
    }
}