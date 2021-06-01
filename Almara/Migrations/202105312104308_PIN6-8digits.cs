namespace Almara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PIN68digits : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "PersonalIdentificationNumber", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "PersonalIdentificationNumber", c => c.Int(nullable: false));
        }
    }
}
