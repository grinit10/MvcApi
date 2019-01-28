namespace VidlyAppy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, DurationInMonth, SignUpFee, DiscountRate) VALUES (1, 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (Id, DurationInMonth, SignUpFee, DiscountRate) VALUES (2, 1, 30, 10)");
            Sql("INSERT INTO MembershipTypes (Id, DurationInMonth, SignUpFee, DiscountRate) VALUES (3, 3, 90, 15)");
            Sql("INSERT INTO MembershipTypes (Id, DurationInMonth, SignUpFee, DiscountRate) VALUES (4, 12, 300, 20)");

        }

        public override void Down()
        {
        }
    }
}
