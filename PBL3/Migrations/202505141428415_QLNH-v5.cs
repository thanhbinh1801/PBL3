namespace PBL3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class QLNHv5 : DbMigration
    {
        public override void Up()
        {
            // Xóa bảng MonAnNguyenLieux hiện tại
            DropTable("dbo.MonAnNguyenLieux");

            // Tạo bảng mới với cấu trúc đúng
            CreateTable(
                "dbo.MonAnNguyenLieux",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    IDMonAn = c.Int(nullable: false),
                    IDNguyenLieu = c.Int(nullable: false),
                    soLuong = c.Int(nullable: false),
                    donVi = c.String(),
                })
                .PrimaryKey(t => t.ID);

            // Tạo các quan hệ khóa ngoại, CHỈ ĐỊNH RÕ KHÓA CHÍNH
            AddForeignKey("dbo.MonAnNguyenLieux", "IDMonAn", "dbo.MonAns", "IDMonAn", cascadeDelete: true);
            AddForeignKey("dbo.MonAnNguyenLieux", "IDNguyenLieu", "dbo.NguyenLieux", "IDNguyenLieu", cascadeDelete: true);

            // Tạo các index cho khóa ngoại
            CreateIndex("dbo.MonAnNguyenLieux", "IDMonAn");
            CreateIndex("dbo.MonAnNguyenLieux", "IDNguyenLieu");
        }

        public override void Down()
        {
            // Xóa các index và khóa ngoại
            DropIndex("dbo.MonAnNguyenLieux", new[] { "IDNguyenLieu" });
            DropIndex("dbo.MonAnNguyenLieux", new[] { "IDMonAn" });
            DropForeignKey("dbo.MonAnNguyenLieux", "IDNguyenLieu", "dbo.NguyenLieux");
            DropForeignKey("dbo.MonAnNguyenLieux", "IDMonAn", "dbo.MonAns");

            // Xóa bảng mới
            DropTable("dbo.MonAnNguyenLieux");

            // Tạo lại bảng với cấu trúc cũ
            CreateTable(
                "dbo.MonAnNguyenLieux",
                c => new
                {
                    IDMonAn = c.Int(nullable: false, identity: true),
                    IDNguyenLieu = c.Int(nullable: false),
                    soLuong = c.Int(nullable: false),
                    donVi = c.String(),
                })
                .PrimaryKey(t => t.IDMonAn);
        }
    }
}