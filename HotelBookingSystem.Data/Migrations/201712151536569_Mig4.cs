namespace HotelBookingSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Room_ID", "dbo.Rooms");
            DropForeignKey("dbo.RoomHotels", "Room_ID", "dbo.Rooms");
            DropForeignKey("dbo.RoomHotels", "Hotel_ID", "dbo.Hotels");
            DropIndex("dbo.Customers", new[] { "Room_ID" });
            DropIndex("dbo.RoomHotels", new[] { "Room_ID" });
            DropIndex("dbo.RoomHotels", new[] { "Hotel_ID" });
            AddColumn("dbo.Rooms", "NumberOfRooms", c => c.Int(nullable: false));
            AddColumn("dbo.Rooms", "Hotel_ID", c => c.Int());
            AlterColumn("dbo.Rooms", "Price", c => c.Int(nullable: false));
            CreateIndex("dbo.Rooms", "Hotel_ID");
            AddForeignKey("dbo.Rooms", "Hotel_ID", "dbo.Hotels", "ID");
            DropColumn("dbo.Customers", "Room_ID");
            DropColumn("dbo.Rooms", "Status");
            DropTable("dbo.RoomHotels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RoomHotels",
                c => new
                    {
                        Room_ID = c.Int(nullable: false),
                        Hotel_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Room_ID, t.Hotel_ID });
            
            AddColumn("dbo.Rooms", "Status", c => c.String());
            AddColumn("dbo.Customers", "Room_ID", c => c.Int());
            DropForeignKey("dbo.Rooms", "Hotel_ID", "dbo.Hotels");
            DropIndex("dbo.Rooms", new[] { "Hotel_ID" });
            AlterColumn("dbo.Rooms", "Price", c => c.Double(nullable: false));
            DropColumn("dbo.Rooms", "Hotel_ID");
            DropColumn("dbo.Rooms", "NumberOfRooms");
            CreateIndex("dbo.RoomHotels", "Hotel_ID");
            CreateIndex("dbo.RoomHotels", "Room_ID");
            CreateIndex("dbo.Customers", "Room_ID");
            AddForeignKey("dbo.RoomHotels", "Hotel_ID", "dbo.Hotels", "ID", cascadeDelete: true);
            AddForeignKey("dbo.RoomHotels", "Room_ID", "dbo.Rooms", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "Room_ID", "dbo.Rooms", "ID");
        }
    }
}
