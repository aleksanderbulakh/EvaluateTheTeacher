namespace AvaluateTheTeacher1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeaherModify : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Votings", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Votings", new[] { "TeacherId" });
            AlterColumn("dbo.Votings", "TeacherId", c => c.Int());
            CreateIndex("dbo.Votings", "TeacherId");
            AddForeignKey("dbo.Votings", "TeacherId", "dbo.Teachers", "TeacherId");
            DropColumn("dbo.Teachers", "ForTheEntirePeriod");
            DropColumn("dbo.Teachers", "PreviousMonth");
            DropColumn("dbo.Teachers", "AvgRating");
            DropColumn("dbo.Teachers", "AvgInterest");
            DropColumn("dbo.Teachers", "AvgQuality");
            DropColumn("dbo.Teachers", "AvgRelevantToStudents");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "AvgRelevantToStudents", c => c.Single(nullable: false));
            AddColumn("dbo.Teachers", "AvgQuality", c => c.Single(nullable: false));
            AddColumn("dbo.Teachers", "AvgInterest", c => c.Single(nullable: false));
            AddColumn("dbo.Teachers", "AvgRating", c => c.Single(nullable: false));
            AddColumn("dbo.Teachers", "PreviousMonth", c => c.Single(nullable: false));
            AddColumn("dbo.Teachers", "ForTheEntirePeriod", c => c.Single(nullable: false));
            DropForeignKey("dbo.Votings", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Votings", new[] { "TeacherId" });
            AlterColumn("dbo.Votings", "TeacherId", c => c.Int(nullable: false));
            CreateIndex("dbo.Votings", "TeacherId");
            AddForeignKey("dbo.Votings", "TeacherId", "dbo.Teachers", "TeacherId", cascadeDelete: true);
        }
    }
}
