namespace PBL3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class UpdateMonAnNguyenLieu : DbMigration
    {
        public override void Up()
        {
            // Bỏ khóa chính hiện tại (nếu có)
            DropPrimaryKey("dbo.MonAnNguyenLieux");

            // Bỏ khóa ngoại và chỉ mục cũ liên kết giữa MonAnNguyenLieu và MonAns
            DropForeignKey("dbo.MonAnNguyenLieux", "monAn_IDMonAn", "dbo.MonAns");
            DropIndex("dbo.MonAnNguyenLieux", new[] { "monAn_IDMonAn" });

            // Xóa cột IDMonAn nếu có
            DropColumn("dbo.MonAnNguyenLieux", "IDMonAn");

            // Đổi tên cột từ monAn_IDMonAn thành IDMonAn
            RenameColumn(table: "dbo.MonAnNguyenLieux", name: "monAn_IDMonAn", newName: "IDMonAn");

            // Đảm bảo cột IDMonAn là không nullable (trước khi thêm khóa chính)
            AlterColumn("dbo.MonAnNguyenLieux", "IDMonAn", c => c.Int(nullable: false));

            // Thêm khóa chính mới (composite key với IDMonAn và IDNguyenLieu)
            AddPrimaryKey("dbo.MonAnNguyenLieux", new[] { "IDMonAn", "IDNguyenLieu" });

            // Tạo lại chỉ mục cho cột IDMonAn
            CreateIndex("dbo.MonAnNguyenLieux", "IDMonAn");

            // Thêm lại khóa ngoại giữa MonAnNguyenLieux và MonAns
            AddForeignKey("dbo.MonAnNguyenLieux", "IDMonAn", "dbo.MonAns", "IDMonAn", cascadeDelete: true);
        }

        public override void Down()
        {
            // Xóa khóa ngoại và chỉ mục mới
            DropForeignKey("dbo.MonAnNguyenLieux", "IDMonAn", "dbo.MonAns");
            DropIndex("dbo.MonAnNguyenLieux", new[] { "IDMonAn" });

            // Bỏ khóa chính kết hợp và quay lại khóa chính cũ (chỉ có IDMonAn)
            DropPrimaryKey("dbo.MonAnNguyenLieux");
            AlterColumn("dbo.MonAnNguyenLieux", "IDMonAn", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.MonAnNguyenLieux", "IDMonAn");

            // Đổi lại tên cột IDMonAn thành monAn_IDMonAn
            RenameColumn(table: "dbo.MonAnNguyenLieux", name: "IDMonAn", newName: "monAn_IDMonAn");

            // Thêm lại cột IDMonAn nếu cần (do đã xóa trong Up)
            AddColumn("dbo.MonAnNguyenLieux", "IDMonAn", c => c.Int(nullable: false, identity: true));

            // Tạo lại chỉ mục và khóa ngoại theo tên cột cũ
            CreateIndex("dbo.MonAnNguyenLieux", "monAn_IDMonAn");
            AddForeignKey("dbo.MonAnNguyenLieux", "monAn_IDMonAn", "dbo.MonAns", "IDMonAn");
        }
    }
}
