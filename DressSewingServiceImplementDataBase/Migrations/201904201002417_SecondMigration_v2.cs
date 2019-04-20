namespace DressSewingServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration_v2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tailors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TailorFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Requests", "TailorId", c => c.Int());
            CreateIndex("dbo.Requests", "TailorId");
            AddForeignKey("dbo.Requests", "TailorId", "dbo.Tailors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "TailorId", "dbo.Tailors");
            DropIndex("dbo.Requests", new[] { "TailorId" });
            DropColumn("dbo.Requests", "TailorId");
            DropTable("dbo.Tailors");
        }
    }
}
