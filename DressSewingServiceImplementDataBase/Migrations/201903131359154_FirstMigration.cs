namespace DressSewingServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Designers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DesignerFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DesignerId = c.Int(nullable: false),
                        DressId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        DateImplement = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Designers", t => t.DesignerId, cascadeDelete: true)
                .ForeignKey("dbo.Dresses", t => t.DressId, cascadeDelete: true)
                .Index(t => t.DesignerId)
                .Index(t => t.DressId);
            
            CreateTable(
                "dbo.Dresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DressName = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DressMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DressId = c.Int(nullable: false),
                        MaterialId = c.Int(nullable: false),
                        MaterialName = c.String(),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dresses", t => t.DressId, cascadeDelete: true)
                .ForeignKey("dbo.Materials", t => t.MaterialId, cascadeDelete: true)
                .Index(t => t.DressId)
                .Index(t => t.MaterialId);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaterialName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StoreMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        MaterialId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materials", t => t.MaterialId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.StoreId)
                .Index(t => t.MaterialId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "DressId", "dbo.Dresses");
            DropForeignKey("dbo.StoreMaterials", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.StoreMaterials", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.DressMaterials", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.DressMaterials", "DressId", "dbo.Dresses");
            DropForeignKey("dbo.Requests", "DesignerId", "dbo.Designers");
            DropIndex("dbo.StoreMaterials", new[] { "MaterialId" });
            DropIndex("dbo.StoreMaterials", new[] { "StoreId" });
            DropIndex("dbo.DressMaterials", new[] { "MaterialId" });
            DropIndex("dbo.DressMaterials", new[] { "DressId" });
            DropIndex("dbo.Requests", new[] { "DressId" });
            DropIndex("dbo.Requests", new[] { "DesignerId" });
            DropTable("dbo.Stores");
            DropTable("dbo.StoreMaterials");
            DropTable("dbo.Materials");
            DropTable("dbo.DressMaterials");
            DropTable("dbo.Dresses");
            DropTable("dbo.Requests");
            DropTable("dbo.Designers");
        }
    }
}
