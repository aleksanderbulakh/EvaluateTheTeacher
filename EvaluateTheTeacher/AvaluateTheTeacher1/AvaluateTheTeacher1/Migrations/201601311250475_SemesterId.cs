namespace AvaluateTheTeacher1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SemesterId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Semesters", "SemesterId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Semesters", "SemesterId");
        }
    }
}
