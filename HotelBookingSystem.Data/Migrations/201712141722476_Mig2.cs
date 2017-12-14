namespace HotelBookingSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "CreditCard_ID", "dbo.CreditCards");
            DropIndex("dbo.Customers", new[] { "CreditCard_ID" });
            AddColumn("dbo.CreditCards", "CardHolder", c => c.String());
            AlterColumn("dbo.CreditCards", "CardNumber", c => c.String());
            AlterColumn("dbo.CreditCards", "CVV", c => c.String());
            AlterColumn("dbo.CreditCards", "Date", c => c.String());
            DropColumn("dbo.Customers", "CreditCard_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CreditCard_ID", c => c.Int());
            AlterColumn("dbo.CreditCards", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CreditCards", "CVV", c => c.Int(nullable: false));
            AlterColumn("dbo.CreditCards", "CardNumber", c => c.Int(nullable: false));
            DropColumn("dbo.CreditCards", "CardHolder");
            CreateIndex("dbo.Customers", "CreditCard_ID");
            AddForeignKey("dbo.Customers", "CreditCard_ID", "dbo.CreditCards", "ID");
        }
    }
}
