namespace Almara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingMovieWithId2 : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Movies ON INSERT INTO Movies(Id,Name,ReleaseDate,DateAdded,NumberInStock,GenreId) VALUES(2,'Shrek',01/01/1999,05/18/2021,7,2)");
        }
        
        public override void Down()
        {
        }
    }
}
