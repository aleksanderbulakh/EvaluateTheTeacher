namespace AvaluateTheTeacher1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblRating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ForTheEntirePeriod = c.Single(nullable: false),
                        PreviousMonth = c.Single(nullable: false),
                        AvgRating = c.Single(nullable: false),
                        AvgInterest = c.Single(nullable: false),
                        AvgQuality = c.Single(nullable: false),
                        AvgRelevantToStudents = c.Single(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Ratings", new[] { "TeacherId" });
            DropTable("dbo.Ratings");
        }
    }
}
