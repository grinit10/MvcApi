namespace VidlyAppy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerMovieRentalClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerMovies",
                c => new
                    {
                        customerId = c.Int(nullable: false),
                        movieId = c.Int(nullable: false),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.customerId, t.movieId })
                .ForeignKey("dbo.Customers", t => t.customerId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.movieId, cascadeDelete: true)
                .Index(t => t.customerId)
                .Index(t => t.movieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerMovies", "movieId", "dbo.Movies");
            DropForeignKey("dbo.CustomerMovies", "customerId", "dbo.Customers");
            DropIndex("dbo.CustomerMovies", new[] { "movieId" });
            DropIndex("dbo.CustomerMovies", new[] { "customerId" });
            DropTable("dbo.CustomerMovies");
        }
    }
}
