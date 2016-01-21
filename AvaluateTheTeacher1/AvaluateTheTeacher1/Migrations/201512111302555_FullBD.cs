namespace AvaluateTheTeacher1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FullBD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cathedras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameCathedra = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CathedraId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cathedras", t => t.CathedraId, cascadeDelete: true)
                .Index(t => t.CathedraId);
            
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
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        GroupId = c.Int(),
                        PasswordTxt = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .Index(t => t.GroupId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.StudentVotings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.String(maxLength: 128),
                        TeachersSubjectId = c.Int(),
                        Date = c.DateTime(nullable: false),
                        TeachersSubjects_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.StudentId)
                .ForeignKey("dbo.TeacherSubjects", t => t.TeachersSubjects_Id)
                .Index(t => t.StudentId)
                .Index(t => t.TeachersSubjects_Id);
            
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
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SurName = c.String(),
                        LastName = c.String(),
                        PathToPhoto = c.String(),
                        Description = c.String(),
                        CathedraId = c.Int(),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.Cathedras", t => t.CathedraId)
                .Index(t => t.CathedraId);
            
            CreateTable(
                "dbo.MessageForModerators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        TeacherId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Ratings",
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
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Suggestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SuggestionsForImprovement = c.String(),
                        TeacherSubjectId = c.Int(),
                        Teacher_TeacherId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TeacherSubjects", t => t.TeacherSubjectId)
                .ForeignKey("dbo.Teachers", t => t.Teacher_TeacherId)
                .Index(t => t.TeacherSubjectId)
                .Index(t => t.Teacher_TeacherId);
            
            CreateTable(
                "dbo.Votings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OverallSubject = c.Int(nullable: false),
                        SomethingNew = c.Int(nullable: false),
                        ThePracticalValue = c.Int(nullable: false),
                        DepthPossessionOf = c.Int(nullable: false),
                        ClarityAndAccessibility = c.Int(nullable: false),
                        QualityTeachingMaterials = c.Int(nullable: false),
                        InterestInTheSubject = c.Int(nullable: false),
                        NumberOfAttendance = c.Int(nullable: false),
                        ActivityInClass = c.Int(nullable: false),
                        TheDifficultyOfTheCourse = c.Int(nullable: false),
                        PreparationTime = c.Int(nullable: false),
                        AvailabilityTeacherOutsideLessons = c.Int(nullable: false),
                        CommentsTheWork = c.Int(nullable: false),
                        RelevantToStudents = c.Int(nullable: false),
                        ProcedureGrading = c.Int(nullable: false),
                        HowWellTheProcedurePerformedGrading = c.Int(nullable: false),
                        QualityMasteringTheSubject = c.Int(nullable: false),
                        TeacherSubjectId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TeacherSubjects", t => t.TeacherSubjectId)
                .Index(t => t.TeacherSubjectId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Votings", "TeacherSubjectId", "dbo.TeacherSubjects");
            DropForeignKey("dbo.TeacherSubjects", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Suggestions", "Teacher_TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Suggestions", "TeacherSubjectId", "dbo.TeacherSubjects");
            DropForeignKey("dbo.Ratings", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.MessageForModerators", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "CathedraId", "dbo.Cathedras");
            DropForeignKey("dbo.TeacherSubjects", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.RaitingTeacherSubjects", "TeacherSubjectId", "dbo.TeacherSubjects");
            DropForeignKey("dbo.GroupTeacherSubject", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.GroupTeacherSubject", "TeacherSubjectId", "dbo.TeacherSubjects");
            DropForeignKey("dbo.StudentVotings", "TeachersSubjects_Id", "dbo.TeacherSubjects");
            DropForeignKey("dbo.StudentVotings", "StudentId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Subjects", "CathedraId", "dbo.Cathedras");
            DropIndex("dbo.GroupTeacherSubject", new[] { "GroupId" });
            DropIndex("dbo.GroupTeacherSubject", new[] { "TeacherSubjectId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Votings", new[] { "TeacherSubjectId" });
            DropIndex("dbo.Suggestions", new[] { "Teacher_TeacherId" });
            DropIndex("dbo.Suggestions", new[] { "TeacherSubjectId" });
            DropIndex("dbo.Ratings", new[] { "TeacherId" });
            DropIndex("dbo.MessageForModerators", new[] { "TeacherId" });
            DropIndex("dbo.Teachers", new[] { "CathedraId" });
            DropIndex("dbo.RaitingTeacherSubjects", new[] { "TeacherSubjectId" });
            DropIndex("dbo.StudentVotings", new[] { "TeachersSubjects_Id" });
            DropIndex("dbo.StudentVotings", new[] { "StudentId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "GroupId" });
            DropIndex("dbo.TeacherSubjects", new[] { "SubjectId" });
            DropIndex("dbo.TeacherSubjects", new[] { "TeacherId" });
            DropIndex("dbo.Subjects", new[] { "CathedraId" });
            DropTable("dbo.GroupTeacherSubject");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Votings");
            DropTable("dbo.Suggestions");
            DropTable("dbo.Ratings");
            DropTable("dbo.MessageForModerators");
            DropTable("dbo.Teachers");
            DropTable("dbo.RaitingTeacherSubjects");
            DropTable("dbo.StudentVotings");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Groups");
            DropTable("dbo.TeacherSubjects");
            DropTable("dbo.Subjects");
            DropTable("dbo.Cathedras");
        }
    }
}
