namespace HotelBookingSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig1 : DbMigration
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
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Email = c.String(),
                        CreditCard_ID = c.Int(),
                        Room_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CreditCards", t => t.CreditCard_ID)
                .ForeignKey("dbo.Rooms", t => t.Room_ID)
                .Index(t => t.CreditCard_ID)
                .Index(t => t.Room_ID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TotalSum = c.Double(nullable: false),
                        CreditCard_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CreditCards", t => t.CreditCard_ID)
                .Index(t => t.CreditCard_ID);
            
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
                        CheckIn = c.String(),
                        CheckOut = c.String(),
                        HotelName_ID = c.Int(),
                        RoomType_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Hotels", t => t.HotelName_ID)
                .ForeignKey("dbo.Rooms", t => t.RoomType_ID)
                .Index(t => t.HotelName_ID)
                .Index(t => t.RoomType_ID);
            
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
            DropForeignKey("dbo.ReservationInfoes", "RoomType_ID", "dbo.Rooms");
            DropForeignKey("dbo.ReservationInfoes", "HotelName_ID", "dbo.Hotels");
            DropForeignKey("dbo.RoomHotels", "Hotel_ID", "dbo.Hotels");
            DropForeignKey("dbo.RoomHotels", "Room_ID", "dbo.Rooms");
            DropForeignKey("dbo.Customers", "Room_ID", "dbo.Rooms");
            DropForeignKey("dbo.Hotels", "IDPay_ID", "dbo.Payments");
            DropForeignKey("dbo.Payments", "CreditCard_ID", "dbo.CreditCards");
            DropForeignKey("dbo.Customers", "CreditCard_ID", "dbo.CreditCards");
            DropIndex("dbo.RoomHotels", new[] { "Hotel_ID" });
            DropIndex("dbo.RoomHotels", new[] { "Room_ID" });
            DropIndex("dbo.ReservationInfoes", new[] { "RoomType_ID" });
            DropIndex("dbo.ReservationInfoes", new[] { "HotelName_ID" });
            DropIndex("dbo.Hotels", new[] { "IDPay_ID" });
            DropIndex("dbo.Payments", new[] { "CreditCard_ID" });
            DropIndex("dbo.Customers", new[] { "Room_ID" });
            DropIndex("dbo.Customers", new[] { "CreditCard_ID" });
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
