namespace Flixster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNumberInStockToCopiesAvailable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET NumberInStock = CopiesAvailable");
        }
        
        public override void Down()
        {
        }
    }
}
