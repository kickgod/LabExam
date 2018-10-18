namespace LabExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserChangeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Principals", "UserConfige", c => c.String(nullable: false, maxLength: 400));
            DropColumn("dbo.Principals", "UserType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Principals", "UserType", c => c.Int(nullable: false));
            DropColumn("dbo.Principals", "UserConfige");
        }
    }
}
