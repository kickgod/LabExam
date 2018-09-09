namespace LabExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExaminationPapers",
                c => new
                    {
                        ExaminationPaperID = c.Int(nullable: false, identity: true),
                        PrincipalID = c.String(maxLength: 100),
                        AddTime = c.DateTime(nullable: false),
                        AdaptedGrade = c.Int(nullable: false),
                        ExaminationPaperStatus = c.Int(nullable: false),
                        QuestionChoiceCount = c.Int(nullable: false),
                        QuestionJudgemtnCount = c.Int(nullable: false),
                        QuestionSubjectCount = c.Int(nullable: false),
                        TotalScore = c.Int(nullable: false),
                        PassScore = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ExaminationPaperID)
                .ForeignKey("dbo.Principals", t => t.PrincipalID)
                .Index(t => t.PrincipalID);
            
            CreateTable(
                "dbo.PaperChoiceSets",
                c => new
                    {
                        PaperChoiceSetID = c.Int(nullable: false, identity: true),
                        ExamQuestionChoiceID = c.Int(nullable: false),
                        ExaminationPaperID = c.Int(nullable: false),
                        ExamQuestionType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaperChoiceSetID)
                .ForeignKey("dbo.ExaminationPapers", t => t.ExaminationPaperID, cascadeDelete: true)
                .ForeignKey("dbo.ExamQuestions", t => t.ExamQuestionChoiceID, cascadeDelete: true)
                .Index(t => t.ExamQuestionChoiceID)
                .Index(t => t.ExaminationPaperID);
            
            CreateTable(
                "dbo.PaperJudgmentSets",
                c => new
                    {
                        PaperJudgmentSetID = c.Int(nullable: false, identity: true),
                        ExamQuestionJudgmentalID = c.Int(nullable: false),
                        ExaminationPaperID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaperJudgmentSetID)
                .ForeignKey("dbo.ExaminationPapers", t => t.ExaminationPaperID, cascadeDelete: true)
                .ForeignKey("dbo.ExamQuestionJudgmentals", t => t.ExamQuestionJudgmentalID, cascadeDelete: true)
                .Index(t => t.ExamQuestionJudgmentalID)
                .Index(t => t.ExaminationPaperID);
            
            CreateTable(
                "dbo.PaperSubjectiveSets",
                c => new
                    {
                        PaperSubjectiveSetID = c.Int(nullable: false, identity: true),
                        ExamQuestionSubjectiveID = c.Int(nullable: false),
                        ExaminationPaperID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaperSubjectiveSetID)
                .ForeignKey("dbo.ExaminationPapers", t => t.ExaminationPaperID, cascadeDelete: true)
                .ForeignKey("dbo.ExamQuestionSubjectives", t => t.ExamQuestionSubjectiveID, cascadeDelete: true)
                .Index(t => t.ExamQuestionSubjectiveID)
                .Index(t => t.ExaminationPaperID);
            
            CreateTable(
                "dbo.StudentApplyForReExaminations",
                c => new
                    {
                        StudentApplyForReExaminationID = c.Int(nullable: false, identity: true),
                        ApplyDescription = c.String(maxLength: 2500),
                        StudentReExamApplication = c.Int(nullable: false),
                        ApplyTime = c.DateTime(nullable: false),
                        ExamTime = c.Int(),
                        StudentID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.StudentApplyForReExaminationID)
                .ForeignKey("dbo.Students", t => t.StudentID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.UseSuggestions",
                c => new
                    {
                        UseSuggestionID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 3000),
                        AddTime = c.DateTime(nullable: false),
                        QQNumber = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.UseSuggestionID);
            
            AddColumn("dbo.Students", "IsMalicious", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentApplyForReExaminations", "StudentID", "dbo.Students");
            DropForeignKey("dbo.PaperSubjectiveSets", "ExamQuestionSubjectiveID", "dbo.ExamQuestionSubjectives");
            DropForeignKey("dbo.PaperSubjectiveSets", "ExaminationPaperID", "dbo.ExaminationPapers");
            DropForeignKey("dbo.PaperJudgmentSets", "ExamQuestionJudgmentalID", "dbo.ExamQuestionJudgmentals");
            DropForeignKey("dbo.PaperJudgmentSets", "ExaminationPaperID", "dbo.ExaminationPapers");
            DropForeignKey("dbo.PaperChoiceSets", "ExamQuestionChoiceID", "dbo.ExamQuestions");
            DropForeignKey("dbo.PaperChoiceSets", "ExaminationPaperID", "dbo.ExaminationPapers");
            DropForeignKey("dbo.ExaminationPapers", "PrincipalID", "dbo.Principals");
            DropIndex("dbo.StudentApplyForReExaminations", new[] { "StudentID" });
            DropIndex("dbo.PaperSubjectiveSets", new[] { "ExaminationPaperID" });
            DropIndex("dbo.PaperSubjectiveSets", new[] { "ExamQuestionSubjectiveID" });
            DropIndex("dbo.PaperJudgmentSets", new[] { "ExaminationPaperID" });
            DropIndex("dbo.PaperJudgmentSets", new[] { "ExamQuestionJudgmentalID" });
            DropIndex("dbo.PaperChoiceSets", new[] { "ExaminationPaperID" });
            DropIndex("dbo.PaperChoiceSets", new[] { "ExamQuestionChoiceID" });
            DropIndex("dbo.ExaminationPapers", new[] { "PrincipalID" });
            DropColumn("dbo.Students", "IsMalicious");
            DropTable("dbo.UseSuggestions");
            DropTable("dbo.StudentApplyForReExaminations");
            DropTable("dbo.PaperSubjectiveSets");
            DropTable("dbo.PaperJudgmentSets");
            DropTable("dbo.PaperChoiceSets");
            DropTable("dbo.ExaminationPapers");
        }
    }
}
