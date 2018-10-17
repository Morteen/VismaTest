namespace VismaUtvikler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterd_CustomerClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CustomerTypeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "CustomerTypeId");
        }
    }
}
