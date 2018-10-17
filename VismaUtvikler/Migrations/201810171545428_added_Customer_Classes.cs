namespace VismaUtvikler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_Customer_Classes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerToTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        CustomerTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.CustomerTypes", t => t.CustomerTypeId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.CustomerTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerToTypes", "CustomerTypeId", "dbo.CustomerTypes");
            DropForeignKey("dbo.CustomerToTypes", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CustomerToTypes", new[] { "CustomerTypeId" });
            DropIndex("dbo.CustomerToTypes", new[] { "CustomerId" });
            DropTable("dbo.CustomerToTypes");
        }
    }
}
