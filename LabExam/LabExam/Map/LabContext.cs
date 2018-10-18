using LabExam.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LabExam.Map
{
    /// <summary>
    ///  <remarks> 数据上下文类,是EF 和数据库的链接通道 </remarks>
    ///  <Create> 2018/9/6 10:09 </Create>
    ///  <Author> 2016110418 蒋星 </Author>
    ///  <LastAlterTimeAndAuthor>  </LastAlterTimeAndAuthor>
    /// </summary>
    public class LabContext:DbContext
    {
        public LabContext() : base("name=ConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer<LabContext>(new DropCreateDatabaseIfModelChanges<LabContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            try
            {
                base.OnModelCreating(modelBuilder);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DbSet<UserLoginRecord> UserLoginRecords { get; set; }               // 记录用户登录信息

        public DbSet<PrincipalOperationLog> PrincipalOperationLoggs { get; set; } //管理员操作信息

        public DbSet<StudentOperationLog> StudentOperationLogs { get; set; }       // 学生操作信息表

        public DbSet<ExamQuestionChoice> ExamQuestionChoices { get; set; }          //选择题
        public DbSet<ExamQuestionJudgmental> ExamQuestionJudgmentals { get; set; }  //判断题
        public DbSet<ExamQuestionSubjective> ExamQuestionSubjectives { get; set; } // 主观题

        public DbSet<ExaminationPaper> ExaminationPapers { get; set; }       //考试试卷表格

        public DbSet<PaperChoiceSet> PaperChoiceSets { get; set; }           // 试卷 选择题
        public DbSet<PaperJudgmentSet> PaperJudgmentSets { get; set; }       // 试卷 判断题
        public DbSet<PaperSubjectiveSet> PaperSubjectiveSets { get; set; }   // 试卷 主观题

        public DbSet<UserSuggestion> UserSuggestions { get; set; }             // 用户建议投诉表
        public DbSet<StudentApplyForReExamination> StudentsApplyForReExaminations { get; set; }            // 学生申请重考表

        public DbSet<StudentApplyForNotTakeExamination> StudentApplyForNotTakeExaminations { get; set; }   // 学生申请不考试

        public DbSet<Student> Students { get; set; }         //学生表
        public DbSet<Module> Modules { get; set; }           //模块表
        public DbSet<Profession> Professions { get; set; }   //专业表
        public DbSet<Institute> Institutes { get; set; }     //学院表
        public DbSet<Course> Courses { get; set; }           //课程表
        public DbSet<Principal> Principals { get; set; }     //负责人表
        public DbSet<Resource> Resources { get; set; }       //课程资料表
    }
}