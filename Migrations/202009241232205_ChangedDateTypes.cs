namespace Flixster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDateTypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Birthdate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "Birthdate", c => c.DateTime());
        }
    }
}
