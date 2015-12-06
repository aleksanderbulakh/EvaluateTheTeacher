namespace AvaluateTheTeacher1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Conflicts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentVotings", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.StudentVotings", new[] { "TeacherId" });
            AlterColumn("dbo.StudentVotings", "TeacherId", c => c.Int());
            CreateIndex("dbo.StudentVotings", "TeacherId");
            AddForeignKey("dbo.StudentVotings", "TeacherId", "dbo.Teachers", "TeacherId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentVotings", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.StudentVotings", new[] { "TeacherId" });
            AlterColumn("dbo.StudentVotings", "TeacherId", c => c.Int(nullable: false));
            CreateIndex("dbo.StudentVotings", "TeacherId");
            AddForeignKey("dbo.StudentVotings", "TeacherId", "dbo.Teachers", "TeacherId", cascadeDelete: true);
        }
    }
}
