namespace AvaluateTheTeacher1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblSemester : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Semesters",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    From = c.DateTime(nullable: false),
                    To = c.DateTime(nullable: false),
                    IsVote = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.GroupTeacherSubjects", "SemesterId", c => c.Int());
            CreateIndex("dbo.GroupTeacherSubjects", "SemesterId");
            AddForeignKey("dbo.GroupTeacherSubjects", "SemesterId", "dbo.Semesters", "Id");
            DropColumn("dbo.GroupTeacherSubjects", "SemesterFrom");
            DropColumn("dbo.GroupTeacherSubjects", "SemesterTo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GroupTeacherSubjects", "SemesterTo", c => c.DateTime(nullable: false));
            AddColumn("dbo.GroupTeacherSubjects", "SemesterFrom", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.GroupTeacherSubjects", "SemesterId", "dbo.Semesters");
            DropIndex("dbo.GroupTeacherSubjects", new[] { "SemesterId" });
            DropColumn("dbo.GroupTeacherSubjects", "SemesterId");
            DropTable("dbo.Semesters");
        }
    }
}
