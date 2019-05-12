namespace DressSewingServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MessageInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageId = c.String(),
                        FromMailAddress = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                        DateDelivery = c.DateTime(nullable: false),
                        DesignerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Designers", t => t.DesignerId)
                .Index(t => t.DesignerId);
            
            AddColumn("dbo.Designers", "Mail", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MessageInfoes", "DesignerId", "dbo.Designers");
            DropIndex("dbo.MessageInfoes", new[] { "DesignerId" });
            DropColumn("dbo.Designers", "Mail");
            DropTable("dbo.MessageInfoes");
        }
    }
}
