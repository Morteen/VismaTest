namespace VismaUtvikler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populate_ContactPersons : DbMigration
    {
        public override void Up()
        {
           /* Sql("INSERT INTO CustomerContactPersons(FirstName,lastName,Adress,PostalCode,PhoneNumber,MailAdress,CustomerId)VALUES('Morten','Olsen','AAfoss',3731,'40042106','morten@mortenolsen.com',1)");
            Sql("INSERT INTO CustomerContactPersons(FirstName,lastName,Adress,PostalCode,PhoneNumber,MailAdress,CustomerId)VALUES('Per','Olavsen','Skien',37300,'40044103','per@oavlsen.com',2)");
            Sql("INSERT INTO CustomerContactPersons(FirstName,lastName,Adress,PostalCode,PhoneNumber,MailAdress,CustomerId)VALUES('olav','Nordmann','Porsgrunn',3900,'40041301','olav@nordman.com',1)");*/
        }
        
        public override void Down()
        {
        }
    }
}
