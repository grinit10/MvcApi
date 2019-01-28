namespace VidlyAppy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAvailabilityToNumberAvailable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Int());
            DropColumn("dbo.Movies", "Availability");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Availability", c => c.Int());
            DropColumn("dbo.Movies", "NumberAvailable");
        }
    }
}
