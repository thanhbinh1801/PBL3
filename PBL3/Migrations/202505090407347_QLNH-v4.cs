namespace PBL3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QLNHv4 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.MonAnNguyenLieux", new[] { "monAn_IDMonAn" });
            DropColumn("dbo.MonAnNguyenLieux", "IDMonAn");
            RenameColumn(table: "dbo.MonAnNguyenLieux", name: "monAn_IDMonAn", newName: "IDMonAn");
            DropPrimaryKey("dbo.MonAnNguyenLieux");
            AlterColumn("dbo.MonAnNguyenLieux", "IDMonAn", c => c.Int(nullable: false));
            AlterColumn("dbo.MonAnNguyenLieux", "IDMonAn", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.MonAnNguyenLieux", "IDMonAn");
            CreateIndex("dbo.MonAnNguyenLieux", "IDMonAn");
        }
        
        public override void Down()
        {
            DropIndex("dbo.MonAnNguyenLieux", new[] { "IDMonAn" });
            DropPrimaryKey("dbo.MonAnNguyenLieux");
            AlterColumn("dbo.MonAnNguyenLieux", "IDMonAn", c => c.Int());
            AlterColumn("dbo.MonAnNguyenLieux", "IDMonAn", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.MonAnNguyenLieux", "IDMonAn");
            RenameColumn(table: "dbo.MonAnNguyenLieux", name: "IDMonAn", newName: "monAn_IDMonAn");
            AddColumn("dbo.MonAnNguyenLieux", "IDMonAn", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.MonAnNguyenLieux", "monAn_IDMonAn");
        }
    }
}
