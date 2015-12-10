namespace AvaluateTheTeacher1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FullDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GroupSubject", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.GroupSubject", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.TeacherGroup", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.TeacherGroup", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.StudentVotings", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Votings", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.SubjectTeacher", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.SubjectTeacher", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.StudentVotings", new[] { "TeacherId" });
            DropIndex("dbo.Votings", new[] { "TeacherId" });
            DropIndex("dbo.GroupSubject", new[] { "GroupId" });
            DropIndex("dbo.GroupSubject", new[] { "SubjectId" });
            DropIndex("dbo.TeacherGroup", new[] { "TeacherId" });
            DropIndex("dbo.TeacherGroup", new[] { "GroupId" });
            DropIndex("dbo.SubjectTeacher", new[] { "SubjectId" });
            DropIndex("dbo.SubjectTeacher", new[] { "TeacherId" });
            CreateTable(
                "dbo.TeacherSubjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(),
                        SubjectId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.TeacherId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.RaitingTeacherSubjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ForTheEntirePeriod = c.Single(nullable: false),
                        PreviousMonth = c.Single(nullable: false),
                        AvgRating = c.Single(nullable: false),
                        OverallSubject = c.Single(nullable: false),
                        SomethingNew = c.Single(nullable: false),
                        ThePracticalValue = c.Single(nullable: false),
                        DepthPossessionOf = c.Single(nullable: false),
                        ClarityAndAccessibility = c.Single(nullable: false),
                        QualityTeachingMaterials = c.Single(nullable: false),
                        InterestInTheSubject = c.Single(nullable: false),
                        NumberOfAttendance = c.Single(nullable: false),
                        ActivityInClass = c.Single(nullable: false),
                        TheDifficultyOfTheCourse = c.Single(nullable: false),
                        PreparationTime = c.Single(nullable: false),
                        AvailabilityTeacherOutsideLessons = c.Single(nullable: false),
                        CommentsTheWork = c.Single(nullable: false),
                        RelevantToStudents = c.Single(nullable: false),
                        ProcedureGrading = c.Single(nullable: false),
                        HowWellTheProcedurePerformedGrading = c.Single(nullable: false),
                        QualityMasteringTheSubject = c.Single(nullable: false),
                        TeacherSubjectId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TeacherSubjects", t => t.TeacherSubjectId)
                .Index(t => t.TeacherSubjectId);
            
            CreateTable(
                "dbo.GroupTeacherSubject",
                c => new
                    {
                        TeacherSubjectId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeacherSubjectId, t.GroupId })
                .ForeignKey("dbo.TeacherSubjects", t => t.TeacherSubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.TeacherSubjectId)
                .Index(t => t.GroupId);
            
            AddColumn("dbo.StudentVotings", "TeachersSubjectId", c => c.Int());
            AddColumn("dbo.StudentVotings", "TeachersSubjects_Id", c => c.Int());
            AddColumn("dbo.Votings", "TeacherSubjectId", c => c.Int());
            CreateIndex("dbo.StudentVotings", "TeachersSubjects_Id");
            CreateIndex("dbo.Votings", "TeacherSubjectId");
            AddForeignKey("dbo.StudentVotings", "TeachersSubjects_Id", "dbo.TeacherSubjects", "Id");
            AddForeignKey("dbo.Votings", "TeacherSubjectId", "dbo.TeacherSubjects", "Id");
            DropColumn("dbo.StudentVotings", "TeacherId");
            DropColumn("dbo.Votings", "TeacherId");
            DropTable("dbo.GroupSubject");
            DropTable("dbo.TeacherGroup");
            DropTable("dbo.SubjectTeacher");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubjectTeacher",
                c => new
                    {
                        SubjectId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubjectId, t.TeacherId });
            
            CreateTable(
                "dbo.TeacherGroup",
                c => new
                    {
                        TeacherId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeacherId, t.GroupId });
            
            CreateTable(
                "dbo.GroupSubject",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupId, t.SubjectId });
            
            AddColumn("dbo.Votings", "TeacherId", c => c.Int());
            AddColumn("dbo.StudentVotings", "TeacherId", c => c.Int());
            DropForeignKey("dbo.Votings", "TeacherSubjectId", "dbo.TeacherSubjects");
            DropForeignKey("dbo.TeacherSubjects", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.TeacherSubjects", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.RaitingTeacherSubjects", "TeacherSubjectId", "dbo.TeacherSubjects");
            DropForeignKey("dbo.GroupTeacherSubject", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.GroupTeacherSubject", "TeacherSubjectId", "dbo.TeacherSubjects");
            DropForeignKey("dbo.StudentVotings", "TeachersSubjects_Id", "dbo.TeacherSubjects");
            DropIndex("dbo.GroupTeacherSubject", new[] { "GroupId" });
            DropIndex("dbo.GroupTeacherSubject", new[] { "TeacherSubjectId" });
            DropIndex("dbo.Votings", new[] { "TeacherSubjectId" });
            DropIndex("dbo.RaitingTeacherSubjects", new[] { "TeacherSubjectId" });
            DropIndex("dbo.StudentVotings", new[] { "TeachersSubjects_Id" });
            DropIndex("dbo.TeacherSubjects", new[] { "SubjectId" });
            DropIndex("dbo.TeacherSubjects", new[] { "TeacherId" });
            DropColumn("dbo.Votings", "TeacherSubjectId");
            DropColumn("dbo.StudentVotings", "TeachersSubjects_Id");
            DropColumn("dbo.StudentVotings", "TeachersSubjectId");
            DropTable("dbo.GroupTeacherSubject");
            DropTable("dbo.RaitingTeacherSubjects");
            DropTable("dbo.TeacherSubjects");
            CreateIndex("dbo.SubjectTeacher", "TeacherId");
            CreateIndex("dbo.SubjectTeacher", "SubjectId");
            CreateIndex("dbo.TeacherGroup", "GroupId");
            CreateIndex("dbo.TeacherGroup", "TeacherId");
            CreateIndex("dbo.GroupSubject", "SubjectId");
            CreateIndex("dbo.GroupSubject", "GroupId");
            CreateIndex("dbo.Votings", "TeacherId");
            CreateIndex("dbo.StudentVotings", "TeacherId");
            AddForeignKey("dbo.SubjectTeacher", "TeacherId", "dbo.Teachers", "TeacherId", cascadeDelete: true);
            AddForeignKey("dbo.SubjectTeacher", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Votings", "TeacherId", "dbo.Teachers", "TeacherId");
            AddForeignKey("dbo.StudentVotings", "TeacherId", "dbo.Teachers", "TeacherId");
            AddForeignKey("dbo.TeacherGroup", "GroupId", "dbo.Groups", "GroupId", cascadeDelete: true);
            AddForeignKey("dbo.TeacherGroup", "TeacherId", "dbo.Teachers", "TeacherId", cascadeDelete: true);
            AddForeignKey("dbo.GroupSubject", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GroupSubject", "GroupId", "dbo.Groups", "GroupId", cascadeDelete: true);
        }
    }
}
