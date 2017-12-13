namespace HotelBookingSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CreditCards", "FirstName_ID", "dbo.Customers");
            DropForeignKey("dbo.CreditCards", "IDCustomer_ID", "dbo.Customers");
            DropForeignKey("dbo.CreditCards", "IDPayment_ID", "dbo.Payments");
            DropForeignKey("dbo.CreditCards", "LastName_ID", "dbo.Customers");
            DropForeignKey("dbo.ReservationInfoes", "IDCustomer_ID", "dbo.Customers");
            DropForeignKey("dbo.ReservationInfoes", "IDHotel_ID", "dbo.Hotels");
            DropIndex("dbo.CreditCards", new[] { "FirstName_ID" });
            DropIndex("dbo.CreditCards", new[] { "IDCustomer_ID" });
            DropIndex("dbo.CreditCards", new[] { "IDPayment_ID" });
            DropIndex("dbo.CreditCards", new[] { "LastName_ID" });
            DropIndex("dbo.ReservationInfoes", new[] { "IDCustomer_ID" });
            DropIndex("dbo.ReservationInfoes", new[] { "IDHotel_ID" });
            AddColumn("dbo.Customers", "CreditCard_ID", c => c.Int());
            AddColumn("dbo.Customers", "ReservationInfo_ID", c => c.Int());
            AddColumn("dbo.Payments", "CreditCard_ID", c => c.Int());
            AddColumn("dbo.Hotels", "ReservationInfo_ID", c => c.Int());
            CreateIndex("dbo.Customers", "CreditCard_ID");
            CreateIndex("dbo.Customers", "ReservationInfo_ID");
            CreateIndex("dbo.Payments", "CreditCard_ID");
            CreateIndex("dbo.Hotels", "ReservationInfo_ID");
            AddForeignKey("dbo.Customers", "CreditCard_ID", "dbo.CreditCards", "ID");
            AddForeignKey("dbo.Payments", "CreditCard_ID", "dbo.CreditCards", "ID");
            AddForeignKey("dbo.Customers", "ReservationInfo_ID", "dbo.ReservationInfoes", "ID");
            AddForeignKey("dbo.Hotels", "ReservationInfo_ID", "dbo.ReservationInfoes", "ID");
            DropColumn("dbo.CreditCards", "FirstName_ID");
            DropColumn("dbo.CreditCards", "IDCustomer_ID");
            DropColumn("dbo.CreditCards", "IDPayment_ID");
            DropColumn("dbo.CreditCards", "LastName_ID");
            DropColumn("dbo.ReservationInfoes", "IDCustomer_ID");
            DropColumn("dbo.ReservationInfoes", "IDHotel_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReservationInfoes", "IDHotel_ID", c => c.Int());
            AddColumn("dbo.ReservationInfoes", "IDCustomer_ID", c => c.Int());
            AddColumn("dbo.CreditCards", "LastName_ID", c => c.Int());
            AddColumn("dbo.CreditCards", "IDPayment_ID", c => c.Int());
            AddColumn("dbo.CreditCards", "IDCustomer_ID", c => c.Int());
            AddColumn("dbo.CreditCards", "FirstName_ID", c => c.Int());
            DropForeignKey("dbo.Hotels", "ReservationInfo_ID", "dbo.ReservationInfoes");
            DropForeignKey("dbo.Customers", "ReservationInfo_ID", "dbo.ReservationInfoes");
            DropForeignKey("dbo.Payments", "CreditCard_ID", "dbo.CreditCards");
            DropForeignKey("dbo.Customers", "CreditCard_ID", "dbo.CreditCards");
            DropIndex("dbo.Hotels", new[] { "ReservationInfo_ID" });
            DropIndex("dbo.Payments", new[] { "CreditCard_ID" });
            DropIndex("dbo.Customers", new[] { "ReservationInfo_ID" });
            DropIndex("dbo.Customers", new[] { "CreditCard_ID" });
            DropColumn("dbo.Hotels", "ReservationInfo_ID");
            DropColumn("dbo.Payments", "CreditCard_ID");
            DropColumn("dbo.Customers", "ReservationInfo_ID");
            DropColumn("dbo.Customers", "CreditCard_ID");
            CreateIndex("dbo.ReservationInfoes", "IDHotel_ID");
            CreateIndex("dbo.ReservationInfoes", "IDCustomer_ID");
            CreateIndex("dbo.CreditCards", "LastName_ID");
            CreateIndex("dbo.CreditCards", "IDPayment_ID");
            CreateIndex("dbo.CreditCards", "IDCustomer_ID");
            CreateIndex("dbo.CreditCards", "FirstName_ID");
            AddForeignKey("dbo.ReservationInfoes", "IDHotel_ID", "dbo.Hotels", "ID");
            AddForeignKey("dbo.ReservationInfoes", "IDCustomer_ID", "dbo.Customers", "ID");
            AddForeignKey("dbo.CreditCards", "LastName_ID", "dbo.Customers", "ID");
            AddForeignKey("dbo.CreditCards", "IDPayment_ID", "dbo.Payments", "ID");
            AddForeignKey("dbo.CreditCards", "IDCustomer_ID", "dbo.Customers", "ID");
            AddForeignKey("dbo.CreditCards", "FirstName_ID", "dbo.Customers", "ID");
        }
    }
}
