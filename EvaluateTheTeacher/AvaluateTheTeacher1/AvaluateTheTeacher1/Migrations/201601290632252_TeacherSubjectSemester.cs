namespace AvaluateTheTeacher1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeacherSubjectSemester : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TeacherSubjects", "SemesterId", c => c.Int());
            CreateIndex("dbo.TeacherSubjects", "SemesterId");
            AddForeignKey("dbo.TeacherSubjects", "SemesterId", "dbo.Semesters", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherSubjects", "SemesterId", "dbo.Semesters");
            DropIndex("dbo.TeacherSubjects", new[] { "SemesterId" });
            DropColumn("dbo.TeacherSubjects", "SemesterId");
        }
    }
}
