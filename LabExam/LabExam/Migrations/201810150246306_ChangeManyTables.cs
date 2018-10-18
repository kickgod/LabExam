namespace LabExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeManyTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UseSuggestions", "ContactType", c => c.String(maxLength: 50));
            AddColumn("dbo.UseSuggestions", "Title", c => c.String(maxLength: 300));
            AlterColumn("dbo.UseSuggestions", "AddTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.UseSuggestions", "QQNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UseSuggestions", "QQNumber", c => c.String(maxLength: 50));
            AlterColumn("dbo.UseSuggestions", "AddTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.UseSuggestions", "Title");
            DropColumn("dbo.UseSuggestions", "ContactType");
        }
    }
}
