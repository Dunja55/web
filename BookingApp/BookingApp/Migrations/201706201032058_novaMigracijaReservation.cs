namespace BookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class novaMigracijaReservation : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.RoomReservations", name: "AppUserId", newName: "UserId");
            RenameIndex(table: "dbo.RoomReservations", name: "IX_AppUserId", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.RoomReservations", name: "IX_UserId", newName: "IX_AppUserId");
            RenameColumn(table: "dbo.RoomReservations", name: "UserId", newName: "AppUserId");
        }
    }
}
