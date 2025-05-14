namespace PBL3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QLNHv4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DonHangs", "nguoiNhan_IDUser", "dbo.Nguoidungs");
            DropForeignKey("dbo.DonHangs", "nguoiTao_IDUser", "dbo.Nguoidungs");
            DropForeignKey("dbo.DonHangs", "Nguoidung_IDUser", "dbo.Nguoidungs");
            DropForeignKey("dbo.DonHangs", "Nguoidung_IDUser1", "dbo.Nguoidungs");
            DropIndex("dbo.DonHangs", new[] { "Nguoidung_IDUser" });
            DropIndex("dbo.DonHangs", new[] { "Nguoidung_IDUser1" });
            DropIndex("dbo.DonHangs", new[] { "nguoiNhan_IDUser" });
            DropIndex("dbo.DonHangs", new[] { "nguoiTao_IDUser" });
            DropColumn("dbo.DonHangs", "IDNguoiNhan");
            DropColumn("dbo.DonHangs", "IDNguoiTao");
            DropColumn("dbo.DonHangs", "IDNguoiNhan");
            DropColumn("dbo.DonHangs", "IDNguoiTao");
            RenameColumn(table: "dbo.DonHangs", name: "nguoiNhan_IDUser", newName: "IDNguoiNhan");
            RenameColumn(table: "dbo.DonHangs", name: "nguoiTao_IDUser", newName: "IDNguoiTao");
            RenameColumn(table: "dbo.DonHangs", name: "Nguoidung_IDUser", newName: "IDNguoiNhan");
            RenameColumn(table: "dbo.DonHangs", name: "Nguoidung_IDUser1", newName: "IDNguoiTao");
            AddColumn("dbo.DonHangs", "IDBan", c => c.Int(nullable: false));
            AlterColumn("dbo.DonHangs", "IDNguoiNhan", c => c.Int(nullable: false));
            AlterColumn("dbo.DonHangs", "IDNguoiTao", c => c.Int(nullable: false));
            AlterColumn("dbo.DonHangs", "IDNguoiNhan", c => c.Int(nullable: false));
            AlterColumn("dbo.DonHangs", "IDNguoiTao", c => c.Int(nullable: false));
            CreateIndex("dbo.DonHangs", "IDBan");
            CreateIndex("dbo.DonHangs", "IDNguoiTao");
            CreateIndex("dbo.DonHangs", "IDNguoiNhan");
            AddForeignKey("dbo.DonHangs", "IDBan", "dbo.BanAns", "IDBan", cascadeDelete: true);
            AddForeignKey("dbo.DonHangs", "IDNguoiNhan", "dbo.Nguoidungs", "IDUser", cascadeDelete: true);
            AddForeignKey("dbo.DonHangs", "IDNguoiTao", "dbo.Nguoidungs", "IDUser", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DonHangs", "IDNguoiTao", "dbo.Nguoidungs");
            DropForeignKey("dbo.DonHangs", "IDNguoiNhan", "dbo.Nguoidungs");
            DropForeignKey("dbo.DonHangs", "IDBan", "dbo.BanAns");
            DropIndex("dbo.DonHangs", new[] { "IDNguoiNhan" });
            DropIndex("dbo.DonHangs", new[] { "IDNguoiTao" });
            DropIndex("dbo.DonHangs", new[] { "IDBan" });
            AlterColumn("dbo.DonHangs", "IDNguoiTao", c => c.Int());
            AlterColumn("dbo.DonHangs", "IDNguoiNhan", c => c.Int());
            AlterColumn("dbo.DonHangs", "IDNguoiTao", c => c.Int());
            AlterColumn("dbo.DonHangs", "IDNguoiNhan", c => c.Int());
            DropColumn("dbo.DonHangs", "IDBan");
            RenameColumn(table: "dbo.DonHangs", name: "IDNguoiTao", newName: "Nguoidung_IDUser1");
            RenameColumn(table: "dbo.DonHangs", name: "IDNguoiNhan", newName: "Nguoidung_IDUser");
            RenameColumn(table: "dbo.DonHangs", name: "IDNguoiTao", newName: "nguoiTao_IDUser");
            RenameColumn(table: "dbo.DonHangs", name: "IDNguoiNhan", newName: "nguoiNhan_IDUser");
            AddColumn("dbo.DonHangs", "IDNguoiTao", c => c.Int(nullable: false));
            AddColumn("dbo.DonHangs", "IDNguoiNhan", c => c.Int(nullable: false));
            AddColumn("dbo.DonHangs", "IDNguoiTao", c => c.Int(nullable: false));
            AddColumn("dbo.DonHangs", "IDNguoiNhan", c => c.Int(nullable: false));
            CreateIndex("dbo.DonHangs", "nguoiTao_IDUser");
            CreateIndex("dbo.DonHangs", "nguoiNhan_IDUser");
            CreateIndex("dbo.DonHangs", "Nguoidung_IDUser1");
            CreateIndex("dbo.DonHangs", "Nguoidung_IDUser");
            AddForeignKey("dbo.DonHangs", "Nguoidung_IDUser1", "dbo.Nguoidungs", "IDUser");
            AddForeignKey("dbo.DonHangs", "Nguoidung_IDUser", "dbo.Nguoidungs", "IDUser");
            AddForeignKey("dbo.DonHangs", "nguoiTao_IDUser", "dbo.Nguoidungs", "IDUser");
            AddForeignKey("dbo.DonHangs", "nguoiNhan_IDUser", "dbo.Nguoidungs", "IDUser");
        }
    }
}
