namespace LabExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManyTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddTime = c.DateTime(nullable: false),
                        IsCompulsory = c.Boolean(nullable: false),
                        Introduction = c.String(maxLength: 1000),
                        Credit = c.Single(nullable: false),
                        ReviewProcess = c.Int(nullable: false),
                        PrincipalID = c.String(maxLength: 100),
                        ModuleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Modules", t => t.ModuleID, cascadeDelete: true)
                .ForeignKey("dbo.Principals", t => t.PrincipalID)
                .Index(t => t.PrincipalID)
                .Index(t => t.ModuleID);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        ResourceID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Description = c.String(maxLength: 700),
                        ReviewProcess = c.Int(nullable: false),
                        AddTime = c.DateTime(nullable: false),
                        ResourceType = c.Int(nullable: false),
                        StorePath = c.String(maxLength: 600),
                        LengthOfStudy = c.Int(),
                        PrincipalID = c.String(maxLength: 100),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResourceID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Principals", t => t.PrincipalID)
                .Index(t => t.PrincipalID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Principals",
                c => new
                    {
                        PrincipalID = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 600),
                        JobNumber = c.String(maxLength: 100),
                        Name = c.String(),
                        UserType = c.Int(nullable: false),
                        UserStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PrincipalID);
            
            CreateTable(
                "dbo.ExamQuestions",
                c => new
                    {
                        ExamQuestionChoiceID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 3000),
                        Answer = c.String(maxLength: 20),
                        A = c.String(maxLength: 300),
                        B = c.String(maxLength: 300),
                        C = c.String(maxLength: 300),
                        D = c.String(maxLength: 300),
                        E = c.String(maxLength: 300),
                        F = c.String(maxLength: 300),
                        G = c.String(maxLength: 300),
                        h = c.String(maxLength: 300),
                        AddTime = c.DateTime(nullable: false),
                        DegreeOfDifficulty = c.Single(),
                        ExamQuestionType = c.Int(nullable: false),
                        PrincipalID = c.String(maxLength: 100),
                        ModuleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExamQuestionChoiceID)
                .ForeignKey("dbo.Modules", t => t.ModuleID, cascadeDelete: true)
                .ForeignKey("dbo.Principals", t => t.PrincipalID)
                .Index(t => t.PrincipalID)
                .Index(t => t.ModuleID);
            
            CreateTable(
                "dbo.ExamQuestionJudgmentals",
                c => new
                    {
                        ExamQuestionJudgmentalID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 3000),
                        Answer = c.Boolean(nullable: false),
                        AddTime = c.DateTime(nullable: false),
                        DegreeOfDifficulty = c.Single(),
                        ExamQuestionType = c.Int(nullable: false),
                        PrincipalID = c.String(maxLength: 100),
                        ModuleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExamQuestionJudgmentalID)
                .ForeignKey("dbo.Modules", t => t.ModuleID, cascadeDelete: true)
                .ForeignKey("dbo.Principals", t => t.PrincipalID)
                .Index(t => t.PrincipalID)
                .Index(t => t.ModuleID);
            
            CreateTable(
                "dbo.ExamQuestionSubjectives",
                c => new
                    {
                        ExamQuestionSubjectiveID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 3000),
                        Answer = c.String(maxLength: 2000),
                        AddTime = c.DateTime(nullable: false),
                        DegreeOfDifficulty = c.Single(),
                        ExamQuestionType = c.Int(nullable: false),
                        PrincipalID = c.String(maxLength: 100),
                        ModuleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExamQuestionSubjectiveID)
                .ForeignKey("dbo.Modules", t => t.ModuleID, cascadeDelete: true)
                .ForeignKey("dbo.Principals", t => t.PrincipalID)
                .Index(t => t.PrincipalID)
                .Index(t => t.ModuleID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.String(nullable: false, maxLength: 128),
                        Passwrod = c.String(nullable: false, maxLength: 1000),
                        Email = c.String(maxLength: 200),
                        IDNumber = c.String(maxLength: 200),
                        Sex = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 100),
                        Grade = c.Int(nullable: false),
                        StudentIdentity = c.Int(nullable: false),
                        IsExam = c.Boolean(),
                        JoinExamYear = c.Int(),
                        ExamScore = c.Single(),
                        ProfessionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Professions", t => t.ProfessionID, cascadeDelete: true)
                .Index(t => t.ProfessionID);
            
            DropTable("dbo.TopicTypes");
        }
        
        public override void Down()
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
            
            DropForeignKey("dbo.Students", "ProfessionID", "dbo.Professions");
            DropForeignKey("dbo.Courses", "PrincipalID", "dbo.Principals");
            DropForeignKey("dbo.Courses", "ModuleID", "dbo.Modules");
            DropForeignKey("dbo.Resources", "PrincipalID", "dbo.Principals");
            DropForeignKey("dbo.ExamQuestionSubjectives", "PrincipalID", "dbo.Principals");
            DropForeignKey("dbo.ExamQuestionSubjectives", "ModuleID", "dbo.Modules");
            DropForeignKey("dbo.ExamQuestionJudgmentals", "PrincipalID", "dbo.Principals");
            DropForeignKey("dbo.ExamQuestionJudgmentals", "ModuleID", "dbo.Modules");
            DropForeignKey("dbo.ExamQuestions", "PrincipalID", "dbo.Principals");
            DropForeignKey("dbo.ExamQuestions", "ModuleID", "dbo.Modules");
            DropForeignKey("dbo.Resources", "CourseID", "dbo.Courses");
            DropIndex("dbo.Students", new[] { "ProfessionID" });
            DropIndex("dbo.ExamQuestionSubjectives", new[] { "ModuleID" });
            DropIndex("dbo.ExamQuestionSubjectives", new[] { "PrincipalID" });
            DropIndex("dbo.ExamQuestionJudgmentals", new[] { "ModuleID" });
            DropIndex("dbo.ExamQuestionJudgmentals", new[] { "PrincipalID" });
            DropIndex("dbo.ExamQuestions", new[] { "ModuleID" });
            DropIndex("dbo.ExamQuestions", new[] { "PrincipalID" });
            DropIndex("dbo.Resources", new[] { "CourseID" });
            DropIndex("dbo.Resources", new[] { "PrincipalID" });
            DropIndex("dbo.Courses", new[] { "ModuleID" });
            DropIndex("dbo.Courses", new[] { "PrincipalID" });
            DropTable("dbo.Students");
            DropTable("dbo.ExamQuestionSubjectives");
            DropTable("dbo.ExamQuestionJudgmentals");
            DropTable("dbo.ExamQuestions");
            DropTable("dbo.Principals");
            DropTable("dbo.Resources");
            DropTable("dbo.Courses");
        }
    }
}
