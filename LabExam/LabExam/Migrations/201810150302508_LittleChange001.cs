namespace LabExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LittleChange001 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UseSuggestions", "Contact", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UseSuggestions", "Contact");
        }
    }
}
