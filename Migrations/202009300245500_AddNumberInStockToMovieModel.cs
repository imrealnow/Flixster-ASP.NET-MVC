namespace Flixster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberInStockToMovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberInStock");
        }
    }
}
