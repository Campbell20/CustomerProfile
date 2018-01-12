namespace CustomerProfile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerFirstName = c.String(nullable: false, maxLength: 25),
                        CustomerLastName = c.String(nullable: false, maxLength: 25),
                        Line1 = c.String(nullable: false, maxLength: 25),
                        Line2 = c.String(maxLength: 25),
                        City = c.String(nullable: false, maxLength: 50),
                        State = c.String(nullable: false, maxLength: 50),
                        ZipCode = c.Int(nullable: false),
                        Country = c.String(maxLength: 3),
                        ImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.ImageId, cascadeDelete: true)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerDatas", "ImageId", "dbo.Images");
            DropIndex("dbo.CustomerDatas", new[] { "ImageId" });
            DropTable("dbo.Images");
            DropTable("dbo.CustomerDatas");
        }
    }
}
