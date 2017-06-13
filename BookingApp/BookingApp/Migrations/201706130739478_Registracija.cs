namespace BookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Registracija : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppUsers", "Username", c => c.String());
            DropColumn("dbo.AppUsers", "FullName");
            DropColumn("dbo.AppUsers", "Email");
            DropColumn("dbo.AppUsers", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppUsers", "Password", c => c.String());
            AddColumn("dbo.AppUsers", "Email", c => c.String());
            AddColumn("dbo.AppUsers", "FullName", c => c.Int(nullable: false));
            DropColumn("dbo.AppUsers", "Username");
        }
    }
}
