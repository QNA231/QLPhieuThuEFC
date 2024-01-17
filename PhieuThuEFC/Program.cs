using PhieuThuEFC.Entities;
using PhieuThuEFC.IServices;
using PhieuThuEFC.Services;

static void Main()
{
    Console.InputEncoding = System.Text.Encoding.UTF8;
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    ILoaiNguyenLieuServices loaiNguyenLieuServices = new LoaiNguyenLieuServices();
    INguyenLieuServices nguyenLieuServices = new NguyenLieuServices();
    IPhieuThuServices phieuThuServices = new PhieuThuServices();
    IChiTietPhieuThuServices chiTietPhieuThuServices = new ChiTietPhieuThuServices();

    Console.WriteLine("------------Quan ly phieu thu------------");
    Console.WriteLine("1. Them loai nguyen lieu");
    Console.WriteLine("2. Them nguyen lieu");
    Console.WriteLine("3. Them phieu thu");
    Console.WriteLine("4. Xoa phieu thu");
    Console.WriteLine("5. Hien thi danh sach phieu thu theo thoi gian");
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("Chon: ");
    string s = Console.ReadLine();
    switch (s)
    {
        case "1":
            LoaiNguyenLieu loai = new LoaiNguyenLieu();
            loaiNguyenLieuServices.ThemLoaiNguyenLieu(loai);
            break;
        case "2":
            Console.WriteLine("Nhap Id loai muon them nguyen lieu: ");
            int loaiId = int.Parse(Console.ReadLine());
            nguyenLieuServices.ThemNguyenLieu(loaiId);
            break;
        case "3":
            PhieuThu phieu = new PhieuThu();
            phieuThuServices.ThemPhieuThu(phieu);
            string str;
            bool ok = false;
            while (!ok)
            {
                Console.WriteLine("Ban co muon them chi tiet phieu (Y/N): ");
                str = Console.ReadLine().ToLower();
                if(str == "y")
                {
                    ChiTietPhieuThu ct = new ChiTietPhieuThu();
                    ct.PhieuThuId = phieu.PhieuThuId;
                    Console.WriteLine("Nhap Id nguyen lieu: ");
                    ct.NguyenLieuId = int.Parse(Console.ReadLine());
                    chiTietPhieuThuServices.ThemChiTietPhieu(ct);

                    List<ChiTietPhieuThu> lstChiTiet = new List<ChiTietPhieuThu>();
                    lstChiTiet.Add(ct);
                    phieuThuServices.CapNhatDuLieu(lstChiTiet);
                }
                else
                {
                    ok = true;
                }
            }
            break;
        case "4":
            Console.WriteLine("Nhap Id phieu thu muon xoa: ");
            int phieuID = int.Parse(Console.ReadLine());
            phieuThuServices.XoaPhieuThu(phieuID);
            break;
        case "5":
            PhieuThu pt = new PhieuThu();
            phieuThuServices.HienThiThongTIn(pt);
            break;
    }
}
Main();