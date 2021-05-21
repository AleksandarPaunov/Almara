namespace Almara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MembershipTypeNameIsRequired : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE from MembershipTypes WHERE Id=5");
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String());
        }
    }
}
