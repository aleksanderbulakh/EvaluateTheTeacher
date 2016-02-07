namespace AvaluateTheTeacher1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refactoring : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GroupTeacherSubjects", "SemesterId", "dbo.Semesters");
            DropIndex("dbo.GroupTeacherSubjects", new[] { "SemesterId" });
            CreateTable(
                "dbo.SubjectSemester",
                c => new
                {
                    SubjectId = c.Int(nullable: false),
                    SemesterId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.SubjectId, t.SemesterId })
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Semesters", t => t.SemesterId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.SemesterId);

            DropTable("dbo.GroupTeacherSubjects");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GroupTeacherSubjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherSubjectId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        VotesCount = c.Int(nullable: false),
                        SemesterId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.SubjectSemester", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.SubjectSemester", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.SubjectSemester", new[] { "SemesterId" });
            DropIndex("dbo.SubjectSemester", new[] { "SubjectId" });
            DropTable("dbo.SubjectSemester");
            CreateIndex("dbo.GroupTeacherSubjects", "SemesterId");
            AddForeignKey("dbo.GroupTeacherSubjects", "SemesterId", "dbo.Semesters", "Id");
        }
    }
}
