namespace BookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kljuc : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accommodations", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Accommodations", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.AccommodationTypes", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Places", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Regions", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Countries", "Name", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.AccommodationTypes", "Name", unique: true);
            CreateIndex("dbo.Rooms", "RoomNumber", unique: true);
            CreateIndex("dbo.Places", "Name", unique: true);
            CreateIndex("dbo.Regions", "Name", unique: true);
            CreateIndex("dbo.Countries", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Countries", new[] { "Name" });
            DropIndex("dbo.Regions", new[] { "Name" });
            DropIndex("dbo.Places", new[] { "Name" });
            DropIndex("dbo.Rooms", new[] { "RoomNumber" });
            DropIndex("dbo.AccommodationTypes", new[] { "Name" });
            AlterColumn("dbo.Countries", "Name", c => c.String());
            AlterColumn("dbo.Regions", "Name", c => c.String());
            AlterColumn("dbo.Places", "Name", c => c.String());
            AlterColumn("dbo.AccommodationTypes", "Name", c => c.String());
            AlterColumn("dbo.Accommodations", "Address", c => c.String());
            AlterColumn("dbo.Accommodations", "Name", c => c.String());
        }
    }
}
