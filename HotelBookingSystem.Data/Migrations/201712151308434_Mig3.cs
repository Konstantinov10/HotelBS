namespace HotelBookingSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Login", c => c.String());
            AddColumn("dbo.Customers", "Password", c => c.String());
            DropColumn("dbo.Rooms", "Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "Number", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "Password");
            DropColumn("dbo.Customers", "Login");
        }
    }
}
