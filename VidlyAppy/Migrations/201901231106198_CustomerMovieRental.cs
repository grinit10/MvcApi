namespace VidlyAppy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerMovieRental : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CustomerMovies", name: "customerId", newName: "customer_id");
            RenameColumn(table: "dbo.CustomerMovies", name: "movieId", newName: "movie_ID");
            RenameIndex(table: "dbo.CustomerMovies", name: "IX_customerId", newName: "IX_customer_id");
            RenameIndex(table: "dbo.CustomerMovies", name: "IX_movieId", newName: "IX_movie_ID");
            DropPrimaryKey("dbo.CustomerMovies");
            AddColumn("dbo.CustomerMovies", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.CustomerMovies", "DateReturned", c => c.DateTime());
            AddPrimaryKey("dbo.CustomerMovies", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CustomerMovies");
            AlterColumn("dbo.CustomerMovies", "DateReturned", c => c.DateTime(nullable: false));
            DropColumn("dbo.CustomerMovies", "Id");
            AddPrimaryKey("dbo.CustomerMovies", new[] { "customerId", "movieId" });
            RenameIndex(table: "dbo.CustomerMovies", name: "IX_movie_ID", newName: "IX_movieId");
            RenameIndex(table: "dbo.CustomerMovies", name: "IX_customer_id", newName: "IX_customerId");
            RenameColumn(table: "dbo.CustomerMovies", name: "movie_ID", newName: "movieId");
            RenameColumn(table: "dbo.CustomerMovies", name: "customer_id", newName: "customerId");
        }
    }
}
