namespace Almara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingMovieReleaseYear : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseYear", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "ReleaseDate");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime());
            DropColumn("dbo.Movies", "ReleaseYear");
        }
    }
}
