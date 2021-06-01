namespace Almara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingPhoneToRegisterUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Phone", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Phone");
        }
    }
}
