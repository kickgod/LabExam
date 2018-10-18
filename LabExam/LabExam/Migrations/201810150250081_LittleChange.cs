namespace LabExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LittleChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UseSuggestions", "Description", c => c.String(nullable: false, maxLength: 3000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UseSuggestions", "Description", c => c.String(maxLength: 3000));
        }
    }
}
