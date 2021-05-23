namespace Almara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingRandomMovieAddingMovieID7 : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Movies ON INSERT INTO Movies(Id,Name,ReleaseDate,DateAdded,NumberInStock,GenreId) VALUES(7,'Spiderman',01/01/2003,05/18/2019,3,2)");
        }
        
        public override void Down()
        {
        }
    }
}
