namespace VismaUtvikler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removed_Customer_refrence_in_CustomerType_model : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "CustomerType_Id", "dbo.CustomerTypes");
            DropIndex("dbo.Customers", new[] { "CustomerType_Id" });
            DropColumn("dbo.Customers", "CustomerType_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CustomerType_Id", c => c.Int());
            CreateIndex("dbo.Customers", "CustomerType_Id");
            AddForeignKey("dbo.Customers", "CustomerType_Id", "dbo.CustomerTypes", "Id");
        }
    }
}
