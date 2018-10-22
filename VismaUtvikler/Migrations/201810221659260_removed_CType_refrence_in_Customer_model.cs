namespace VismaUtvikler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removed_CType_refrence_in_Customer_model : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerTypeCustomers", "CustomerType_Id", "dbo.CustomerTypes");
            DropForeignKey("dbo.CustomerTypeCustomers", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.CustomerTypeCustomers", new[] { "CustomerType_Id" });
            DropIndex("dbo.CustomerTypeCustomers", new[] { "Customer_Id" });
            AddColumn("dbo.Customers", "CustomerType_Id", c => c.Int());
            CreateIndex("dbo.Customers", "CustomerType_Id");
            AddForeignKey("dbo.Customers", "CustomerType_Id", "dbo.CustomerTypes", "Id");
            DropColumn("dbo.Customers", "CustomerTypeId");
            DropTable("dbo.CustomerTypeCustomers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CustomerTypeCustomers",
                c => new
                    {
                        CustomerType_Id = c.Int(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerType_Id, t.Customer_Id });
            
            AddColumn("dbo.Customers", "CustomerTypeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Customers", "CustomerType_Id", "dbo.CustomerTypes");
            DropIndex("dbo.Customers", new[] { "CustomerType_Id" });
            DropColumn("dbo.Customers", "CustomerType_Id");
            CreateIndex("dbo.CustomerTypeCustomers", "Customer_Id");
            CreateIndex("dbo.CustomerTypeCustomers", "CustomerType_Id");
            AddForeignKey("dbo.CustomerTypeCustomers", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CustomerTypeCustomers", "CustomerType_Id", "dbo.CustomerTypes", "Id", cascadeDelete: true);
        }
    }
}
