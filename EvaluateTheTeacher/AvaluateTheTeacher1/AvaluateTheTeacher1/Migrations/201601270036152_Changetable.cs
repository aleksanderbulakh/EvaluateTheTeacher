namespace AvaluateTheTeacher1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GroupTeacherSubjects", "VotesCount", c => c.Int(nullable: false));
            AddColumn("dbo.GroupTeacherSubjects", "SemesterFrom", c => c.DateTime(nullable: false));
            AddColumn("dbo.GroupTeacherSubjects", "SemesterTo", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GroupTeacherSubjects", "SemesterTo");
            DropColumn("dbo.GroupTeacherSubjects", "SemesterFrom");
            DropColumn("dbo.GroupTeacherSubjects", "VotesCount");
        }
    }
}
