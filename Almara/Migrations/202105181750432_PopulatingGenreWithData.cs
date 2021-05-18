namespace Almara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingGenreWithData : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Genres ON INSERT INTO Genres (Id,Name) VALUES (1,'Comedy')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (2,'Family')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (3,'Romance')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (4,'Action')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (5,'Horror')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (6,'Thriller')");

        }
        
        public override void Down()
        {
        }
    }
}
