namespace LabExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UseSuggestions", newName: "UserSuggestions");
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
            
            CreateTable(
                "dbo.StudentOperationLogs",
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
            
            CreateTable(
                "dbo.UserLoginRecords",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        LoginTime = c.DateTime(nullable: false),
                        LoginYear = c.Int(nullable: false),
                        LoginMonth = c.Int(nullable: false),
                        LoginDay = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserLoginRecords");
            DropTable("dbo.StudentOperationLogs");
            DropTable("dbo.AdministratorOperationLogs");
            RenameTable(name: "dbo.UserSuggestions", newName: "UseSuggestions");
        }
    }
}
