namespace PBL3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QLNHv2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonHangChiTiets", "trangThai", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonHangChiTiets", "trangThai");
        }
    }
}
