namespace HotelBookingSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstM : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CardNumber = c.Int(nullable: false),
                        CVV = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        FirstName_ID = c.Int(),
                        IDCustomer_ID = c.Int(),
                        IDPayment_ID = c.Int(),
                        LastName_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.FirstName_ID)
                .ForeignKey("dbo.Customers", t => t.IDCustomer_ID)
                .ForeignKey("dbo.Payments", t => t.IDPayment_ID)
                .ForeignKey("dbo.Customers", t => t.LastName_ID)
                .Index(t => t.FirstName_ID)
                .Index(t => t.IDCustomer_ID)
                .Index(t => t.IDPayment_ID)
                .Index(t => t.LastName_ID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Email = c.String(),
                        Room_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Rooms", t => t.Room_ID)
                .Index(t => t.Room_ID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TotalSum = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                        Stars = c.Int(nullable: false),
                        IDPay_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Payments", t => t.IDPay_ID)
                .Index(t => t.IDPay_ID);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Number = c.Int(nullable: false),
                        Status = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ReservationInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CheckIn = c.DateTime(nullable: false),
                        CheckOut = c.DateTime(nullable: false),
                        IDCustomer_ID = c.Int(),
                        IDHotel_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.IDCustomer_ID)
                .ForeignKey("dbo.Hotels", t => t.IDHotel_ID)
                .Index(t => t.IDCustomer_ID)
                .Index(t => t.IDHotel_ID);
            
            CreateTable(
                "dbo.RoomHotels",
                c => new
                    {
                        Room_ID = c.Int(nullable: false),
                        Hotel_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Room_ID, t.Hotel_ID })
                .ForeignKey("dbo.Rooms", t => t.Room_ID, cascadeDelete: true)
                .ForeignKey("dbo.Hotels", t => t.Hotel_ID, cascadeDelete: true)
                .Index(t => t.Room_ID)
                .Index(t => t.Hotel_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReservationInfoes", "IDHotel_ID", "dbo.Hotels");
            DropForeignKey("dbo.ReservationInfoes", "IDCustomer_ID", "dbo.Customers");
            DropForeignKey("dbo.RoomHotels", "Hotel_ID", "dbo.Hotels");
            DropForeignKey("dbo.RoomHotels", "Room_ID", "dbo.Rooms");
            DropForeignKey("dbo.Customers", "Room_ID", "dbo.Rooms");
            DropForeignKey("dbo.Hotels", "IDPay_ID", "dbo.Payments");
            DropForeignKey("dbo.CreditCards", "LastName_ID", "dbo.Customers");
            DropForeignKey("dbo.CreditCards", "IDPayment_ID", "dbo.Payments");
            DropForeignKey("dbo.CreditCards", "IDCustomer_ID", "dbo.Customers");
            DropForeignKey("dbo.CreditCards", "FirstName_ID", "dbo.Customers");
            DropIndex("dbo.RoomHotels", new[] { "Hotel_ID" });
            DropIndex("dbo.RoomHotels", new[] { "Room_ID" });
            DropIndex("dbo.ReservationInfoes", new[] { "IDHotel_ID" });
            DropIndex("dbo.ReservationInfoes", new[] { "IDCustomer_ID" });
            DropIndex("dbo.Hotels", new[] { "IDPay_ID" });
            DropIndex("dbo.Customers", new[] { "Room_ID" });
            DropIndex("dbo.CreditCards", new[] { "LastName_ID" });
            DropIndex("dbo.CreditCards", new[] { "IDPayment_ID" });
            DropIndex("dbo.CreditCards", new[] { "IDCustomer_ID" });
            DropIndex("dbo.CreditCards", new[] { "FirstName_ID" });
            DropTable("dbo.RoomHotels");
            DropTable("dbo.ReservationInfoes");
            DropTable("dbo.Rooms");
            DropTable("dbo.Hotels");
            DropTable("dbo.Payments");
            DropTable("dbo.Customers");
            DropTable("dbo.CreditCards");
        }
    }
}
