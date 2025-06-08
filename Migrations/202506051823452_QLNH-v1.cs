using System.Data.Entity.Migrations;

public partial class InitialCreate : DbMigration
{
    public override void Up()
    {
        // Tạo bảng BanAn
        CreateTable(
            "dbo.BanAns",
            c => new
            {
                IDBan = c.Int(nullable: false, identity: true),
                trangThaiBanAn = c.Int(nullable: false)
            })
            .PrimaryKey(t => t.IDBan);

        // Tạo bảng KhoNguyenLieu
        CreateTable(
            "dbo.KhoNguyenLieus",
            c => new
            {
                IDKho = c.Int(nullable: false, identity: true),
                tenKho = c.String()
            })
            .PrimaryKey(t => t.IDKho);

        // Tạo bảng Nguoidung
        CreateTable(
            "dbo.Nguoidungs",
            c => new
            {
                IDUser = c.Int(nullable: false, identity: true),
                tenTaiKhoan = c.String(nullable: false),
                tenNguoiDung = c.String(nullable: false),
                matKhau = c.String(nullable: false),
                email = c.String(nullable: false),
                phanQuyen = c.Int(nullable: false)
            })
            .PrimaryKey(t => t.IDUser);

        // Tạo bảng MonAn
        CreateTable(
            "dbo.MonAns",
            c => new
            {
                IDMonAn = c.Int(nullable: false, identity: true),
                tenMonAn = c.String(nullable: false),
                giaBan = c.Double(nullable: false),
                trangThai = c.Int(nullable: false)
            })
            .PrimaryKey(t => t.IDMonAn);

        // Tạo bảng NguyenLieu
        CreateTable(
            "dbo.NguyenLieus",
            c => new
            {
                IDNguyenLieu = c.Int(nullable: false, identity: true),
                tenNguyenLieu = c.String(nullable: false),
                donViTinh = c.String(),
                soLuong = c.Int(nullable: false),
                giaNhap = c.Double(nullable: false),
                hanSuDung = c.DateTime(nullable: false),
                IDKho = c.Int(nullable: false)
            })
            .PrimaryKey(t => t.IDNguyenLieu)
            .ForeignKey("dbo.KhoNguyenLieus", t => t.IDKho, cascadeDelete: true);

        // Tạo bảng DonHang
        CreateTable(
            "dbo.DonHangs",
            c => new
            {
                IDDonHang = c.Int(nullable: false, identity: true),
                moTa = c.String(),
                IDBan = c.Int(nullable: false),
                IDNguoiTao = c.Int(nullable: false),
                IDNguoiNhan = c.Int(),
                thoiGianTao = c.DateTime(nullable: false),
                trangThai = c.Int(nullable: false)
            })
            .PrimaryKey(t => t.IDDonHang)
            .ForeignKey("dbo.BanAns", t => t.IDBan, cascadeDelete: true)
            .ForeignKey("dbo.Nguoidungs", t => t.IDNguoiTao)
            .ForeignKey("dbo.Nguoidungs", t => t.IDNguoiNhan);

        // Tạo bảng MonAnNguyenLieu
        CreateTable(
            "dbo.MonAnNguyenLieus",
            c => new
            {
                ID = c.Int(nullable: false, identity: true),
                IDMonAn = c.Int(nullable: false),
                tenNguyenLieu = c.String(nullable: false),
                soLuong = c.Int(nullable: false),
                donVi = c.String()
            })
            .PrimaryKey(t => t.ID)
            .ForeignKey("dbo.MonAns", t => t.IDMonAn, cascadeDelete: true);

        // Tạo bảng DonHangChiTiet
        CreateTable(
            "dbo.DonHangChiTiets",
            c => new
            {
                IDDonHangChiTiet = c.Int(nullable: false, identity: true),
                IDDonHang = c.Int(nullable: false),
                IDMonAn = c.Int(nullable: false),
                soLuong = c.Int(nullable: false)
            })
            .PrimaryKey(t => t.IDDonHangChiTiet)
            .ForeignKey("dbo.DonHangs", t => t.IDDonHang, cascadeDelete: true)
            .ForeignKey("dbo.MonAns", t => t.IDMonAn, cascadeDelete: true);
    }

    public override void Down()
    {
        DropTable("dbo.DonHangChiTiets");
        DropTable("dbo.MonAnNguyenLieus");
        DropTable("dbo.DonHangs");
        DropTable("dbo.NguyenLieus");
        DropTable("dbo.MonAns");
        DropTable("dbo.Nguoidungs");
        DropTable("dbo.KhoNguyenLieus");
        DropTable("dbo.BanAns");
    }
}