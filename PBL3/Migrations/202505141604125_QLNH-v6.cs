namespace PBL3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QLNHv6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DonHangs", "IDNguoiNhan", "dbo.Nguoidungs");
            DropIndex("dbo.DonHangs", new[] { "IDNguoiNhan" });
            AlterColumn("dbo.DonHangs", "IDNguoiNhan", c => c.Int());
            CreateIndex("dbo.DonHangs", "IDNguoiNhan");
            AddForeignKey("dbo.DonHangs", "IDNguoiNhan", "dbo.Nguoidungs", "IDUser");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DonHangs", "IDNguoiNhan", "dbo.Nguoidungs");
            DropIndex("dbo.DonHangs", new[] { "IDNguoiNhan" });
            AlterColumn("dbo.DonHangs", "IDNguoiNhan", c => c.Int(nullable: false));
            CreateIndex("dbo.DonHangs", "IDNguoiNhan");
            AddForeignKey("dbo.DonHangs", "IDNguoiNhan", "dbo.Nguoidungs", "IDUser", cascadeDelete: true);
        }
    }
}
