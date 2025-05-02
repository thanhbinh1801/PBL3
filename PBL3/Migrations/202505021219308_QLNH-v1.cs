namespace PBL3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QLNHv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BanAns",
                c => new
                    {
                        IDBan = c.Int(nullable: false, identity: true),
                        trangThaiBanAn = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDBan);
            
            CreateTable(
                "dbo.DonHangs",
                c => new
                    {
                        IDDonHang = c.Int(nullable: false, identity: true),
                        moTa = c.String(),
                        IDNguoiTao = c.Int(nullable: false),
                        IDNguoiNhan = c.Int(nullable: false),
                        thoiGianTao = c.DateTime(nullable: false),
                        trangThai = c.Int(nullable: false),
                        Nguoidung_IDUser = c.Int(),
                        Nguoidung_IDUser1 = c.Int(),
                        nguoiNhan_IDUser = c.Int(),
                        nguoiTao_IDUser = c.Int(),
                    })
                .PrimaryKey(t => t.IDDonHang)
                .ForeignKey("dbo.Nguoidungs", t => t.Nguoidung_IDUser)
                .ForeignKey("dbo.Nguoidungs", t => t.Nguoidung_IDUser1)
                .ForeignKey("dbo.Nguoidungs", t => t.nguoiNhan_IDUser)
                .ForeignKey("dbo.Nguoidungs", t => t.nguoiTao_IDUser)
                .Index(t => t.Nguoidung_IDUser)
                .Index(t => t.Nguoidung_IDUser1)
                .Index(t => t.nguoiNhan_IDUser)
                .Index(t => t.nguoiTao_IDUser);
            
            CreateTable(
                "dbo.DonHangChiTiets",
                c => new
                    {
                        IDDonHangChiTiet = c.Int(nullable: false, identity: true),
                        IDDonHang = c.Int(nullable: false),
                        IDMonAn = c.Int(nullable: false),
                        soLuong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDDonHangChiTiet)
                .ForeignKey("dbo.DonHangs", t => t.IDDonHang, cascadeDelete: true)
                .ForeignKey("dbo.MonAns", t => t.IDMonAn, cascadeDelete: true)
                .Index(t => t.IDDonHang)
                .Index(t => t.IDMonAn);
            
            CreateTable(
                "dbo.MonAns",
                c => new
                    {
                        IDMonAn = c.Int(nullable: false, identity: true),
                        tenMonAn = c.String(),
                        giaBan = c.Double(nullable: false),
                        trangThai = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDMonAn);
            
            CreateTable(
                "dbo.MonAnNguyenLieux",
                c => new
                    {
                        IDMonAn = c.Int(nullable: false, identity: true),
                        IDNguyenLieu = c.Int(nullable: false),
                        soLuong = c.Int(nullable: false),
                        donVi = c.String(),
                        monAn_IDMonAn = c.Int(),
                    })
                .PrimaryKey(t => t.IDMonAn)
                .ForeignKey("dbo.MonAns", t => t.monAn_IDMonAn)
                .ForeignKey("dbo.NguyenLieux", t => t.IDNguyenLieu, cascadeDelete: true)
                .Index(t => t.IDNguyenLieu)
                .Index(t => t.monAn_IDMonAn);
            
            CreateTable(
                "dbo.NguyenLieux",
                c => new
                    {
                        IDNguyenLieu = c.Int(nullable: false, identity: true),
                        tenNguyenLieu = c.String(),
                        donViTinh = c.String(),
                        soLuong = c.Int(nullable: false),
                        giaNhap = c.Double(nullable: false),
                        hanSuDung = c.DateTime(nullable: false),
                        IDKho = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDNguyenLieu)
                .ForeignKey("dbo.KhoNguyenLieux", t => t.IDKho, cascadeDelete: true)
                .Index(t => t.IDKho);
            
            CreateTable(
                "dbo.KhoNguyenLieux",
                c => new
                    {
                        IDKho = c.Int(nullable: false, identity: true),
                        tenKho = c.String(),
                    })
                .PrimaryKey(t => t.IDKho);
            
            CreateTable(
                "dbo.Nguoidungs",
                c => new
                    {
                        IDUser = c.Int(nullable: false, identity: true),
                        tenTaiKhoan = c.String(nullable: false),
                        tenNguoiDung = c.String(nullable: false),
                        matKhau = c.String(nullable: false),
                        email = c.String(nullable: false),
                        phanQuyen = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DonHangs", "nguoiTao_IDUser", "dbo.Nguoidungs");
            DropForeignKey("dbo.DonHangs", "nguoiNhan_IDUser", "dbo.Nguoidungs");
            DropForeignKey("dbo.DonHangs", "Nguoidung_IDUser1", "dbo.Nguoidungs");
            DropForeignKey("dbo.DonHangs", "Nguoidung_IDUser", "dbo.Nguoidungs");
            DropForeignKey("dbo.MonAnNguyenLieux", "IDNguyenLieu", "dbo.NguyenLieux");
            DropForeignKey("dbo.NguyenLieux", "IDKho", "dbo.KhoNguyenLieux");
            DropForeignKey("dbo.MonAnNguyenLieux", "monAn_IDMonAn", "dbo.MonAns");
            DropForeignKey("dbo.DonHangChiTiets", "IDMonAn", "dbo.MonAns");
            DropForeignKey("dbo.DonHangChiTiets", "IDDonHang", "dbo.DonHangs");
            DropIndex("dbo.NguyenLieux", new[] { "IDKho" });
            DropIndex("dbo.MonAnNguyenLieux", new[] { "monAn_IDMonAn" });
            DropIndex("dbo.MonAnNguyenLieux", new[] { "IDNguyenLieu" });
            DropIndex("dbo.DonHangChiTiets", new[] { "IDMonAn" });
            DropIndex("dbo.DonHangChiTiets", new[] { "IDDonHang" });
            DropIndex("dbo.DonHangs", new[] { "nguoiTao_IDUser" });
            DropIndex("dbo.DonHangs", new[] { "nguoiNhan_IDUser" });
            DropIndex("dbo.DonHangs", new[] { "Nguoidung_IDUser1" });
            DropIndex("dbo.DonHangs", new[] { "Nguoidung_IDUser" });
            DropTable("dbo.Nguoidungs");
            DropTable("dbo.KhoNguyenLieux");
            DropTable("dbo.NguyenLieux");
            DropTable("dbo.MonAnNguyenLieux");
            DropTable("dbo.MonAns");
            DropTable("dbo.DonHangChiTiets");
            DropTable("dbo.DonHangs");
            DropTable("dbo.BanAns");
        }
    }
}
