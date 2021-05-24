namespace Almara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingReleaseYearValues : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET ReleaseYear = 2006 WHERE Id=1");
            Sql("UPDATE Movies SET ReleaseYear = 2000 WHERE Id=2");
            Sql("UPDATE Movies SET ReleaseYear = 1995 WHERE Id=3");
            Sql("UPDATE Movies SET ReleaseYear = 1999 WHERE Id=4");
            Sql("UPDATE Movies SET ReleaseYear = 1993 WHERE Id=5");
            Sql("UPDATE Movies SET ReleaseYear = 1989 WHERE Id=6");
            Sql("UPDATE Movies SET ReleaseYear = 2001 WHERE Id=7");
            Sql("UPDATE Movies SET ReleaseYear = 2005 WHERE Id=8");
            Sql("UPDATE Movies SET ReleaseYear = 1990 WHERE Id=9");
            Sql("UPDATE Movies SET ReleaseYear = 1988 WHERE Id=10");
        }
        
        public override void Down()
        {
        }
    }
}
