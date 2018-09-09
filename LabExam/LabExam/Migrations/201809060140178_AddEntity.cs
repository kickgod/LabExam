namespace LabExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TopicTypes",
                c => new
                    {
                        TopicTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Status = c.Boolean(nullable: false),
                        AutomaticCalculationOfScores = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TopicTypeID);
            
            AddColumn("dbo.Institutes", "ModuleID", c => c.Int(nullable: false));
            DropColumn("dbo.Modules", "ModuleName");
            AddColumn("dbo.Modules", "Name", c => c.String(maxLength: 200));
            AlterColumn("dbo.Institutes", "Name", c => c.String(maxLength: 200));
            CreateIndex("dbo.Institutes", "ModuleID");
            AddForeignKey("dbo.Institutes", "ModuleID", "dbo.Modules", "ModuleID", cascadeDelete: true);
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Modules", "ModuleName", c => c.String(maxLength: 200));
            DropForeignKey("dbo.Institutes", "ModuleID", "dbo.Modules");
            DropIndex("dbo.Institutes", new[] { "ModuleID" });
            AlterColumn("dbo.Institutes", "Name", c => c.String());
            DropColumn("dbo.Modules", "Name");
            DropColumn("dbo.Institutes", "ModuleID");
            DropTable("dbo.TopicTypes");
        }
    }
}
