namespace LabExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterColumnTypeOfPrincalLog : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PrincipalOperationLogs", "PrincipalID", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PrincipalOperationLogs", "PrincipalID", c => c.Int(nullable: false));
        }
    }
}
