namespace Almara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonalIdentificationNumberAddedToRegister : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PersonalIdentificationNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PersonalIdentificationNumber");
        }
    }
}
