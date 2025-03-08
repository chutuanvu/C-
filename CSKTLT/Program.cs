using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSKTLT
{
    struct sinhVien
    {
        public int maSv;
        public int maLop;
        public string tenSv;
        public int namSinh;
        public float diemToan;
        public float diemVan;
        public float diemAnh;

        public int Tuoi()
        {
            return 2024 - namSinh;
        }
        public float diemTb()
        {
            float diemTb = (diemToan + diemVan + diemAnh) / 3;
            diemTb = (float)Math.Round(diemTb, 2);
            return diemTb;
        }
        public string ghiChu()
        {
            if (diemTb() < 5)
                return "Học lại";
            else
                return "";
        }
    }
    class Program
    {
        static List<sinhVien> danhSachsinhVien = new List<sinhVien>();
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            string teptin = @"D:\thongtin.txt";
            if (File.Exists(teptin))
            {
                using (StreamReader sr = new StreamReader(teptin))
                {
                    string Doctep;
                    while ((Doctep = sr.ReadLine()) != null)
                    {
                        string[] thongTin = Doctep.Split('\t');
                        sinhVien sinhVien = new sinhVien();
                        sinhVien.maSv = int.Parse(thongTin[0]);
                        sinhVien.maLop = int.Parse(thongTin[1]);
                        sinhVien.tenSv = thongTin[2];
                        sinhVien.namSinh = int.Parse(thongTin[3]);
                        sinhVien.diemToan = float.Parse(thongTin[4]);
                        sinhVien.diemVan = float.Parse(thongTin[5]);
                        sinhVien.diemAnh = float.Parse(thongTin[6]);
                        danhSachsinhVien.Add(sinhVien);
                    }
                }
            }
            bool tiepTuc = true;
            while (tiepTuc)
            {
                Console.WriteLine("\t\tCHƯƠNG TRÌNH QUẢN LÝ SINH VIÊN \t\t");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Xóa sinh viên");
                Console.WriteLine("3. Hiển thị danh sách sinh viên");
                Console.WriteLine("4. Tìm kiếm sinh viên");
                Console.WriteLine("5. Sắp xếp danh sách sinh viên");
                Console.WriteLine("6. Thông kê");
                Console.WriteLine("7. Lưu thông tin sinh viên");
                Console.WriteLine("8. Thoát");
                Console.Write("Vui lòng chọn chức năng (1-8): ");
                int chon;
                bool chonHopLe = int.TryParse(Console.ReadLine(), out chon);
                Console.WriteLine();
                if (!chonHopLe || chon < 1 || chon > 8)
                {
                    Console.WriteLine("Vui lòng chọn số phù hợp với chức năng bạn định sử dụng!");
                    Console.WriteLine();
                    continue;
                }
                switch (chon)
                {
                    case 1:
                        Them();
                        break;
                    case 2:
                        Xoa();
                        break;
                    case 3:
                        Hien();
                        break;
                    case 4:
                        Tim();
                        break;
                    case 5:
                        Xep();
                        break;
                    case 6:
                        Thongke();
                        break;
                    case 7:
                        Luu();
                        break;
                    case 8:
                        tiepTuc = false;
                        break;
                }
                Console.WriteLine();
            }
        }
        static void Them()
        {
            Console.WriteLine("\t\tTHÊM SINH VIÊN\t\t");
            Console.Write("Nhập số lượng sinh viên cần thêm: ");
            int soLuong;
            while (!int.TryParse(Console.ReadLine(), out soLuong) || soLuong <= 0)
            {
                Console.WriteLine("Số lượng sinh viên cần thêm phải là một số nguyên dương.");
                Console.Write("Nhập số lượng sinh viên cần thêm: ");
            }

            for (int i = 0; i < soLuong; i++)
            {
                sinhVien sinhVien = new sinhVien();
                Console.WriteLine("Nhập thông tin sinh viên thứ " + (i + 1) + ":");
                Console.Write("Nhập mã sinh viên: ");
                int maSv;
                while (!int.TryParse(Console.ReadLine(), out maSv) || maSv.ToString().Length != 8)
                {
                    Console.Write("Mã sinh viên phải có 8 số: ");
                }
                while (danhSachsinhVien.Exists(sv => sv.maSv == maSv))
                {
                    Console.WriteLine("Mã sinh viên đã tồn tại.");
                    Console.Write("Nhập mã sinh viên: ");
                    while (!int.TryParse(Console.ReadLine(), out maSv) || maSv.ToString().Length != 8)
                    {
                        Console.Write("Mã sinh viên phải có 8 số: ");
                    }
                }
                sinhVien.maSv = maSv;
                Console.Write("Nhập mã lớp: ");
                int maLop;
                while (!int.TryParse(Console.ReadLine(), out maLop) || maLop.ToString().Length != 6)
                {
                    Console.WriteLine("Mã lớp phải có 6 chữ số: ");
                    Console.Write("Nhập mã lớp: ");
                }
                sinhVien.maLop = maLop;
                Console.Write("Nhập tên sinh viên: ");
                string tenSv = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(tenSv))
                {
                    Console.WriteLine("Tên sinh viên không được để trống!");
                    Console.Write("Nhập tên sinh viên: ");
                    tenSv = Console.ReadLine();
                }
                sinhVien.tenSv = tenSv;
                Console.Write("Nhập năm sinh: ");
                int namSinh;
                while (!int.TryParse(Console.ReadLine(), out namSinh) || namSinh < 1990 || namSinh > 2024)
                {
                    Console.WriteLine("Năm sinh từ 1990 đến 2024!");
                    Console.Write("Nhập năm sinh: ");

                }
                sinhVien.namSinh = namSinh;
                Console.Write("Nhập điểm toán: ");
                float diemToan;
                while (!float.TryParse(Console.ReadLine(), out diemToan) || diemToan < 0 || diemToan > 10)
                {
                    Console.WriteLine("Điểm toán không hợp lệ!.");
                    Console.Write("Nhập điểm toán: ");
                }
                sinhVien.diemToan = diemToan;
                Console.Write("Nhập điểm văn: ");
                float diemVan;
                while (!float.TryParse(Console.ReadLine(), out diemVan) || diemVan < 0 || diemVan > 10)
                {
                    Console.WriteLine("Điểm văn không hợp lệ!.");
                    Console.Write("Nhập điểm văn: ");
                }
                sinhVien.diemVan = diemVan;
                Console.Write("Nhập điểm anh: ");
                float diemAnh;
                while (!float.TryParse(Console.ReadLine(), out diemAnh) || diemAnh < 0 || diemAnh > 10)
                {
                    Console.WriteLine("Điểm anh không hợp lệ!.");
                    Console.Write("Nhập điểm anh: ");
                }
                sinhVien.diemAnh = diemAnh;
                danhSachsinhVien.Add(sinhVien);
                Console.WriteLine("Thêm sinh viên thành công!");
            }
        }
        static void Xoa()
        {
            Console.WriteLine("\t\tXÓA SINH VIÊN\t\t");
            Console.Write("Nhập mã sinh viên cần xóa: ");
            string maSv = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(maSv))
            {
                int xoa = danhSachsinhVien.FindIndex(sv => sv.maSv == Convert.ToInt32(maSv));
                if (xoa != -1)
                {
                    danhSachsinhVien.RemoveAt(xoa);
                    Console.WriteLine("Xóa sinh viên thành công!");
                }
                else
                {
                    Console.WriteLine("Không tìm thấy sinh viên có mã {0} trong danh sách!", maSv);
                }
            }
            else
            {
                Console.WriteLine("Mã sinh viên không được để trống");
            };

        }
        static void Hien()
        {
            Console.WriteLine("\t\tDANH SÁCH SINH VIÊN\t\t");
            Console.WriteLine("{0,-15}{1,-20}{2,-10}{3,-10}{4,-10}", "Mã sinh viên", "Tên sinh viên", "Tuổi", "Điểm", "Ghi chú");
            foreach (sinhVien sinhVien in danhSachsinhVien)
            {
                Console.WriteLine("{0,-15}{1,-20}{2,-10}{3,-10}{4,-10}", sinhVien.maSv, sinhVien.tenSv, sinhVien.Tuoi(), sinhVien.diemTb(), sinhVien.ghiChu());
            }
        }
        static void Tim()
        {
            Console.WriteLine("\t\tTÌM KIẾM SINH VIÊN\t\t");
            Console.Write("Nhập từ khóa tìm kiếm: ");
            string Tim = Console.ReadLine();
            Console.WriteLine("\t\tKẾT QUẢ TÌM KIẾM\t\t");
            Console.WriteLine("{0,-15}{1,-20}{2,-10}{3,-10}{4,-10}", "Mã sinh viên", "Tên sinh viên", "Tuổi", "Điểm", "Ghi chú");
            foreach (sinhVien sinhVien in danhSachsinhVien)
            {
                if (sinhVien.tenSv.ToLower().Contains(Tim.ToLower()))
                {
                    Console.WriteLine("{0,-15}{1,-20}{2,-10}{3,-10}{4,-10}", sinhVien.maSv, sinhVien.tenSv, sinhVien.Tuoi(), sinhVien.diemTb(), sinhVien.ghiChu());
                }
            }
        }
        static void Xep()
        {
            Console.WriteLine("\t\tSẮP XẾP DANH SÁCH SINH VIÊN\t\t");
            Console.WriteLine("1. Sắp xếp theo điểm từ thấp đến cao");
            Console.WriteLine("2. Sắp xếp theo điểm từ cao đến thấp");
            Console.WriteLine("3. Sắp xếp theo tên A-Z");
            Console.WriteLine("4. Sắp xếp theo tên Z-A");
            Console.Write("Vui lòng chọn cách sắp xếp (1-4): ");
            int chon;
            bool chonHopLe = int.TryParse(Console.ReadLine(), out chon);
            Console.WriteLine();
            if (!chonHopLe || chon < 1 || chon > 4)
            {
                Console.WriteLine("Vui lòng chọn cách sắp xếp hợp lệ!");
                Console.WriteLine();
                return;
            }
            List<sinhVien> Xep;
            switch (chon)
            {
                case 1:
                    Xep = danhSachsinhVien.OrderBy(sv => sv.diemTb()).ToList();
                    Console.WriteLine("Đã sắp xếp sinh viên theo điểm từ thấp đến cao!");
                    break;
                case 2:
                    Xep = danhSachsinhVien.OrderByDescending(sv => sv.diemTb()).ToList();
                    Console.WriteLine("Đã sắp xếp sinh viên theo điểm từ cao đến thấp!");
                    break;
                case 3:
                    Xep = danhSachsinhVien.OrderBy(sv => sv.tenSv).ToList();
                    Console.WriteLine("Đã sắp xếp sinh viên theo bảng chữ cái từ A-Z!");
                    break;
                case 4:
                    Xep = danhSachsinhVien.OrderByDescending(sv => sv.tenSv).ToList();
                    Console.WriteLine("Đã sắp xếp sinh viên theo bảng chữ cái từ Z-A!");
                    break;
                default:
                    return;
            }
            Console.WriteLine("\t\tDANH SÁCH SINH VIÊN\t\t");
            Console.WriteLine("{0,-15}{1,-20}{2,-10}{3,-10}{4,-10}", "Mã sinh viên", "Tên sinh viên", "Tuổi", "Điểm", "Ghi chú");
            foreach (sinhVien sinhVien in Xep)
            {
                Console.WriteLine("{0,-15}{1,-20}{2,-10}{3,-10}{4,-10}", sinhVien.maSv, sinhVien.tenSv, sinhVien.Tuoi(), sinhVien.diemTb(), sinhVien.ghiChu());
            }
        }
        static void Thongke()
        {
            Console.WriteLine("\t\tTHỐNG KÊ SINH VIÊN\t\t");
            Console.WriteLine("{0,-15}{1,-20}{2,-10}", "Mã sinh viên", "Tên sinh viên", "Điểm");

            if (danhSachsinhVien.Count > 0)
            {
                sinhVien Caonhat = danhSachsinhVien.OrderByDescending(sv => sv.diemTb()).First();
                sinhVien Thapnhat = danhSachsinhVien.OrderBy(sv => sv.diemTb()).First();
                List<sinhVien> Hoclai = danhSachsinhVien.Where(sv => sv.diemTb() < 5).ToList();
                Console.WriteLine("Sinh viên có điểm số cao nhất:");
                Console.WriteLine("{0,-15}{1,-20}{2,-10}", Caonhat.maSv, Caonhat.tenSv, Caonhat.diemTb());
                Console.WriteLine("Sinh viên có điểm số thấp nhất:");
                Console.WriteLine("{0,-15}{1,-20}{2,-10}", Thapnhat.maSv, Thapnhat.tenSv, Thapnhat.diemTb());
                Console.WriteLine("Danh sách sinh viên phải học lại:");
                foreach (sinhVien sinhVien in Hoclai)
                {
                    Console.WriteLine("{0,-15}{1,-20}{2,-10}", sinhVien.maSv, sinhVien.tenSv, sinhVien.diemTb(), sinhVien.ghiChu());
                }
            }
        }
        static void Luu()
        {
            Console.WriteLine("\t\tLƯU THÔNG TIN SINH VIÊN VÀO FILE\t\t");
            if (danhSachsinhVien.Count == 0)
            {
                Console.WriteLine("Thông tin sinh viên trống!");
                return;
            }
            string teptin = @"D:\thongTin.txt";
            using (StreamWriter luu = new StreamWriter(teptin))
            {
                foreach (sinhVien sinhVien in danhSachsinhVien)
                {
                    string Doctep = $"{sinhVien.maSv}\t{sinhVien.maLop}\t{sinhVien.tenSv}\t{sinhVien.namSinh}\t{sinhVien.diemToan}\t{sinhVien.diemVan}\t{sinhVien.diemAnh}";
                    luu.WriteLine(Doctep);
                }
            }
            Console.WriteLine("Lưu thông tin sinh viên vào file thành công!");
        }
    }
}