namespace LabExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterRecord : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserLoginRecords");
            AddColumn("dbo.UserLoginRecords", "UserLoginRecordID", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.UserLoginRecords", "UserID", c => c.String());
            AddPrimaryKey("dbo.UserLoginRecords", "UserLoginRecordID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserLoginRecords");
            AlterColumn("dbo.UserLoginRecords", "UserID", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.UserLoginRecords", "UserLoginRecordID");
            AddPrimaryKey("dbo.UserLoginRecords", "UserID");
        }
    }
}
