namespace Almara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingBugWithPINRange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "PersonalIdentificationNumber", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "PersonalIdentificationNumber", c => c.Single(nullable: false));
        }
    }
}
