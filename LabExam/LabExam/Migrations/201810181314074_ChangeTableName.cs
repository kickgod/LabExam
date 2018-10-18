namespace LabExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTableName : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.StudentOperationLogs");
            CreateTable(
                "dbo.PrincipalOperationLogs",
                c => new
                    {
                        PrincipalLogID = c.Int(nullable: false, identity: true),
                        OperationCode = c.String(maxLength: 15),
                        OperationName = c.String(maxLength: 50),
                        Description = c.String(maxLength: 300),
                        OperationStyle = c.Int(nullable: false),
                        OprationDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PrincipalLogID);
            DropColumn("dbo.StudentOperationLogs", "KeyID");
            DropTable("dbo.AdministratorOperationLogs");
            AddColumn("dbo.StudentOperationLogs", "StudentLogID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.StudentOperationLogs", "StudentLogID");

        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AdministratorOperationLogs",
                c => new
                    {
                        KeyID = c.Int(nullable: false, identity: true),
                        OperationCode = c.String(maxLength: 15),
                        OperationName = c.String(maxLength: 50),
                        Description = c.String(maxLength: 300),
                        OperationStyle = c.Int(nullable: false),
                        OprationDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KeyID);
            
            AddColumn("dbo.StudentOperationLogs", "KeyID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.StudentOperationLogs");
            DropColumn("dbo.StudentOperationLogs", "StudentLogID");
            DropTable("dbo.PrincipalOperationLogs");
            AddPrimaryKey("dbo.StudentOperationLogs", "KeyID");
        }
    }
}
