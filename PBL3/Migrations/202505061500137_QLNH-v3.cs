namespace PBL3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class QLNHv3 : DbMigration
    {
        public override void Up()
        {
            // Xóa các khóa ngoại cũ (nếu tồn tại)
            DropForeignKey("dbo.DonHangs", "IDNguoiTao", "dbo.Nguoidungs");
            DropForeignKey("dbo.DonHangs", "IDNguoiNhan", "dbo.Nguoidungs");

            // Xóa các chỉ mục cũ
            DropIndex("dbo.DonHangs", new[] { "IDNguoiTao" });
            DropIndex("dbo.DonHangs", new[] { "IDNguoiNhan" });

            // Đảm bảo các cột IDNguoiTao và IDNguoiNhan tồn tại và được định nghĩa chính xác
            AlterColumn("dbo.DonHangs", "IDNguoiTao", c => c.Int(nullable: false));
            AlterColumn("dbo.DonHangs", "IDNguoiNhan", c => c.Int(nullable: false));

            // Tạo lại chỉ mục mới
            CreateIndex("dbo.DonHangs", "IDNguoiTao");
            CreateIndex("dbo.DonHangs", "IDNguoiNhan");

            // Thêm lại các khóa ngoại chính xác
            AddForeignKey("dbo.DonHangs", "IDNguoiTao", "dbo.Nguoidungs", "IDUser", cascadeDelete: false);
            AddForeignKey("dbo.DonHangs", "IDNguoiNhan", "dbo.Nguoidungs", "IDUser", cascadeDelete: false);
        }

        public override void Down()
        {
            // Xóa các khóa ngoại mới
            DropForeignKey("dbo.DonHangs", "IDNguoiTao", "dbo.Nguoidungs");
            DropForeignKey("dbo.DonHangs", "IDNguoiNhan", "dbo.Nguoidungs");

            // Xóa các chỉ mục mới
            DropIndex("dbo.DonHangs", new[] { "IDNguoiTao" });
            DropIndex("dbo.DonHangs", new[] { "IDNguoiNhan" });

            // Đặt lại các cột IDNguoiTao và IDNguoiNhan về trạng thái nullable
            AlterColumn("dbo.DonHangs", "IDNguoiTao", c => c.Int());
            AlterColumn("dbo.DonHangs", "IDNguoiNhan", c => c.Int());

            // Thêm lại các chỉ mục cũ
            CreateIndex("dbo.DonHangs", "IDNguoiTao");
            CreateIndex("dbo.DonHangs", "IDNguoiNhan");

            // Thêm lại các khóa ngoại cũ
            AddForeignKey("dbo.DonHangs", "IDNguoiTao", "dbo.Nguoidungs", "IDUser");
            AddForeignKey("dbo.DonHangs", "IDNguoiNhan", "dbo.Nguoidungs", "IDUser");
        }
    }
}
