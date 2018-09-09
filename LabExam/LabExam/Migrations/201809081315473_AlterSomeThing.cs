namespace LabExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterSomeThing : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ExamQuestions", newName: "ExamQuestionChoice");
            CreateTable(
                "dbo.StudentApplyForNotTakeExaminations",
                c => new
                    {
                        StudentApplyForNotTakeExaminationID = c.Int(nullable: false, identity: true),
                        ApplyDescription = c.String(maxLength: 2500),
                        StudentReExamApplication = c.Int(nullable: false),
                        ApplyTime = c.DateTime(nullable: false),
                        StudentID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.StudentApplyForNotTakeExaminationID)
                .ForeignKey("dbo.Students", t => t.StudentID)
                .Index(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentApplyForNotTakeExaminations", "StudentID", "dbo.Students");
            DropIndex("dbo.StudentApplyForNotTakeExaminations", new[] { "StudentID" });
            DropTable("dbo.StudentApplyForNotTakeExaminations");
            RenameTable(name: "dbo.ExamQuestionChoice", newName: "ExamQuestions");
        }
    }
}
