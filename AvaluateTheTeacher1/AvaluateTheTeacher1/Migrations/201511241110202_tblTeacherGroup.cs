namespace AvaluateTheTeacher1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblTeacherGroup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeacherGroup",
                c => new
                    {
                        TeacherId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeacherId, t.GroupId })
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherGroup", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.TeacherGroup", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.TeacherGroup", new[] { "GroupId" });
            DropIndex("dbo.TeacherGroup", new[] { "TeacherId" });
            DropTable("dbo.TeacherGroup");
        }
    }
}
