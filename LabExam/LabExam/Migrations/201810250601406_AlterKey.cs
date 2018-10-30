namespace LabExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PrincipalOperationLogs");
            DropColumn("dbo.PrincipalOperationLogs", "PrincipalLogID");
            AddColumn("dbo.PrincipalOperationLogs", "PrincipalOperationLogID", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.PrincipalOperationLogs", "PrincipalID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.PrincipalOperationLogs", "PrincipalOperationLogID");
            
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PrincipalOperationLogs");
            DropColumn("dbo.PrincipalOperationLogs", "PrincipalID");
            DropColumn("dbo.PrincipalOperationLogs", "PrincipalOperationLogID");
            AddColumn("dbo.PrincipalOperationLogs", "PrincipalLogID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.PrincipalOperationLogs", "PrincipalLogID");
        }
    }
}
