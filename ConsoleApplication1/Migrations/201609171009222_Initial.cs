namespace ConsoleApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CurrentOrderId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.CurrentOrderId)
                .Index(t => t.CurrentOrderId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CustomerId = c.Int(nullable: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.Customer_Id)
                .Index(t => t.CustomerId)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "Customer_Id", "dbo.Customer");
            DropForeignKey("dbo.Customer", "CurrentOrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Order", new[] { "Customer_Id" });
            DropIndex("dbo.Order", new[] { "CustomerId" });
            DropIndex("dbo.Customer", new[] { "CurrentOrderId" });
            DropTable("dbo.Order");
            DropTable("dbo.Customer");
        }
    }
}
