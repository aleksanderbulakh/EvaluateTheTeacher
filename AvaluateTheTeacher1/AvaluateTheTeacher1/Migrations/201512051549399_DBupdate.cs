namespace AvaluateTheTeacher1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBupdate : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Suggestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SuggestionsForImprovement = c.String(),
                        TeacherId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.TeacherId);
            
            AddColumn("dbo.Ratings", "OverallSubject", c => c.Single(nullable: false));
            AddColumn("dbo.Ratings", "SomethingNew", c => c.Single(nullable: false));
            AddColumn("dbo.Ratings", "ThePracticalValue", c => c.Single(nullable: false));
            AddColumn("dbo.Ratings", "DepthPossessionOf", c => c.Single(nullable: false));
            AddColumn("dbo.Ratings", "ClarityAndAccessibility", c => c.Single(nullable: false));
            AddColumn("dbo.Ratings", "QualityTeachingMaterials", c => c.Single(nullable: false));
            AddColumn("dbo.Ratings", "InterestInTheSubject", c => c.Single(nullable: false));
            AddColumn("dbo.Ratings", "NumberOfAttendance", c => c.Single(nullable: false));
            AddColumn("dbo.Ratings", "ActivityInClass", c => c.Single(nullable: false));
            AddColumn("dbo.Ratings", "TheDifficultyOfTheCourse", c => c.Single(nullable: false));
            AddColumn("dbo.Ratings", "PreparationTime", c => c.Single(nullable: false));
            AddColumn("dbo.Ratings", "AvailabilityTeacherOutsideLessons", c => c.Single(nullable: false));
            AddColumn("dbo.Ratings", "CommentsTheWork", c => c.Single(nullable: false));
            AddColumn("dbo.Ratings", "RelevantToStudents", c => c.Single(nullable: false));
            AddColumn("dbo.Ratings", "ProcedureGrading", c => c.Single(nullable: false));
            AddColumn("dbo.Ratings", "HowWellTheProcedurePerformedGrading", c => c.Single(nullable: false));
            AddColumn("dbo.Ratings", "QualityMasteringTheSubject", c => c.Single(nullable: false));
            AddColumn("dbo.Votings", "OverallSubject", c => c.Int(nullable: false));
            AddColumn("dbo.Votings", "SomethingNew", c => c.Int(nullable: false));
            AddColumn("dbo.Votings", "ThePracticalValue", c => c.Int(nullable: false));
            AddColumn("dbo.Votings", "DepthPossessionOf", c => c.Int(nullable: false));
            AddColumn("dbo.Votings", "ClarityAndAccessibility", c => c.Int(nullable: false));
            AddColumn("dbo.Votings", "QualityTeachingMaterials", c => c.Int(nullable: false));
            AddColumn("dbo.Votings", "InterestInTheSubject", c => c.Int(nullable: false));
            AddColumn("dbo.Votings", "NumberOfAttendance", c => c.Int(nullable: false));
            AddColumn("dbo.Votings", "ActivityInClass", c => c.Int(nullable: false));
            AddColumn("dbo.Votings", "TheDifficultyOfTheCourse", c => c.Int(nullable: false));
            AddColumn("dbo.Votings", "PreparationTime", c => c.Int(nullable: false));
            AddColumn("dbo.Votings", "AvailabilityTeacherOutsideLessons", c => c.Int(nullable: false));
            AddColumn("dbo.Votings", "CommentsTheWork", c => c.Int(nullable: false));
            AddColumn("dbo.Votings", "ProcedureGrading", c => c.Int(nullable: false));
            AddColumn("dbo.Votings", "HowWellTheProcedurePerformedGrading", c => c.Int(nullable: false));
            AddColumn("dbo.Votings", "QualityMasteringTheSubject", c => c.Int(nullable: false));
            AlterColumn("dbo.Votings", "RelevantToStudents", c => c.Int(nullable: false));
            DropColumn("dbo.Ratings", "AvgInterest");
            DropColumn("dbo.Ratings", "AvgQuality");
            DropColumn("dbo.Ratings", "AvgRelevantToStudents");
            DropColumn("dbo.Votings", "Interest");
            DropColumn("dbo.Votings", "Quality");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Votings", "Quality", c => c.Single(nullable: false));
            AddColumn("dbo.Votings", "Interest", c => c.Single(nullable: false));
            AddColumn("dbo.Ratings", "AvgRelevantToStudents", c => c.Single(nullable: false));
            AddColumn("dbo.Ratings", "AvgQuality", c => c.Single(nullable: false));
            AddColumn("dbo.Ratings", "AvgInterest", c => c.Single(nullable: false));
            DropForeignKey("dbo.Suggestions", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.MessageForModerators", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Suggestions", new[] { "TeacherId" });
            DropIndex("dbo.MessageForModerators", new[] { "TeacherId" });
            AlterColumn("dbo.Votings", "RelevantToStudents", c => c.Single(nullable: false));
            DropColumn("dbo.Votings", "QualityMasteringTheSubject");
            DropColumn("dbo.Votings", "HowWellTheProcedurePerformedGrading");
            DropColumn("dbo.Votings", "ProcedureGrading");
            DropColumn("dbo.Votings", "CommentsTheWork");
            DropColumn("dbo.Votings", "AvailabilityTeacherOutsideLessons");
            DropColumn("dbo.Votings", "PreparationTime");
            DropColumn("dbo.Votings", "TheDifficultyOfTheCourse");
            DropColumn("dbo.Votings", "ActivityInClass");
            DropColumn("dbo.Votings", "NumberOfAttendance");
            DropColumn("dbo.Votings", "InterestInTheSubject");
            DropColumn("dbo.Votings", "QualityTeachingMaterials");
            DropColumn("dbo.Votings", "ClarityAndAccessibility");
            DropColumn("dbo.Votings", "DepthPossessionOf");
            DropColumn("dbo.Votings", "ThePracticalValue");
            DropColumn("dbo.Votings", "SomethingNew");
            DropColumn("dbo.Votings", "OverallSubject");
            DropColumn("dbo.Ratings", "QualityMasteringTheSubject");
            DropColumn("dbo.Ratings", "HowWellTheProcedurePerformedGrading");
            DropColumn("dbo.Ratings", "ProcedureGrading");
            DropColumn("dbo.Ratings", "RelevantToStudents");
            DropColumn("dbo.Ratings", "CommentsTheWork");
            DropColumn("dbo.Ratings", "AvailabilityTeacherOutsideLessons");
            DropColumn("dbo.Ratings", "PreparationTime");
            DropColumn("dbo.Ratings", "TheDifficultyOfTheCourse");
            DropColumn("dbo.Ratings", "ActivityInClass");
            DropColumn("dbo.Ratings", "NumberOfAttendance");
            DropColumn("dbo.Ratings", "InterestInTheSubject");
            DropColumn("dbo.Ratings", "QualityTeachingMaterials");
            DropColumn("dbo.Ratings", "ClarityAndAccessibility");
            DropColumn("dbo.Ratings", "DepthPossessionOf");
            DropColumn("dbo.Ratings", "ThePracticalValue");
            DropColumn("dbo.Ratings", "SomethingNew");
            DropColumn("dbo.Ratings", "OverallSubject");
            DropTable("dbo.Suggestions");
            DropTable("dbo.MessageForModerators");
        }
    }
}
