namespace AvaluateTheTeacher1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RaitingTeacherSubjects", "CountVoting", c => c.Int(nullable: false));
            AddColumn("dbo.Ratings", "CountRaitingVoting", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ratings", "CountRaitingVoting");
            DropColumn("dbo.RaitingTeacherSubjects", "CountVoting");
        }
    }
}
