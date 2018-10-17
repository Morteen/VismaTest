namespace VismaUtvikler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populate_CustomerTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CustomerTypes(CustomerTypeName,Description)VALUES('Flyselskap','Contrary to popular belief, Lorem Ipsum is not simply random text')");
            Sql("INSERT INTO CustomerTypes(CustomerTypeName,Description)VALUES('GAT prospects','Lorem Ipsum is simply dummy text of the printing and typesetting industry. ')");
            Sql("INSERT INTO CustomerTypes(CustomerTypeName,Description)VALUES('GATgo','Lorem Ipsum is simply dummy text of the printing and typesetting industry. ')");
            Sql("INSERT INTO CustomerTypes(CustomerTypeName,Description)VALUES('GAT testtype1','Lorem Ipsum is simply dummy text of the printing and typesetting industry. ')");
        }
        
        public override void Down()
        {
        }
    }
}
