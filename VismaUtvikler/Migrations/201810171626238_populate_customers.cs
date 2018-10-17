namespace VismaUtvikler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populate_customers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO customers(FirmName,Adress,PostalCode,PhoneNumber,FaxNumber,MailAdress)VALUES('SAS','Oslo',0100,'10032450','1003999','sas@sas.com')");
            Sql("INSERT INTO customers(FirmName,Adress,PostalCode,PhoneNumber,FaxNumber,MailAdress)VALUES('ABB','Skien',3700,'10032450','10032999','abb@abb.com')");
            Sql("INSERT INTO customers(FirmName,Adress,PostalCode,PhoneNumber,FaxNumber,MailAdress)VALUES('Bring','Oslo',0100,'10032450','99966555','bring@bring.com')");
            Sql("INSERT INTO customers(FirmName,Adress,PostalCode,PhoneNumber,FaxNumber,MailAdress)VALUES('Coop','Tonsbergo',3100,'15932450','57468759','coop@coop.com')");
        }
        
        public override void Down()
        {
        }
    }
}
