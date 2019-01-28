namespace VidlyAppy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvailabilityInMovieClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Availability", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Availability");
        }
    }
}
