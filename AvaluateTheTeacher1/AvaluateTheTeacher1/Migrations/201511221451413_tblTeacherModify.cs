namespace AvaluateTheTeacher1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblTeacherModify : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "ForTheEntirePeriod", c => c.Single(nullable: false));
            AddColumn("dbo.Teachers", "PreviousMonth", c => c.Single(nullable: false));
            AddColumn("dbo.Teachers", "AvgRating", c => c.Single(nullable: false));
            AddColumn("dbo.Teachers", "AvgInterest", c => c.Single(nullable: false));
            AddColumn("dbo.Teachers", "AvgQuality", c => c.Single(nullable: false));
            AddColumn("dbo.Teachers", "AvgRelevantToStudents", c => c.Single(nullable: false));
            AddColumn("dbo.Teachers", "Description", c => c.String());
            DropColumn("dbo.Teachers", "Skill");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "Skill", c => c.String());
            DropColumn("dbo.Teachers", "Description");
            DropColumn("dbo.Teachers", "AvgRelevantToStudents");
            DropColumn("dbo.Teachers", "AvgQuality");
            DropColumn("dbo.Teachers", "AvgInterest");
            DropColumn("dbo.Teachers", "AvgRating");
            DropColumn("dbo.Teachers", "PreviousMonth");
            DropColumn("dbo.Teachers", "ForTheEntirePeriod");
        }
    }
}
