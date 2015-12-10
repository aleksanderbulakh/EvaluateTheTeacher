namespace AvaluateTheTeacher1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblGroupSubject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupSubject",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupId, t.SubjectId })
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupSubject", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.GroupSubject", "GroupId", "dbo.Groups");
            DropIndex("dbo.GroupSubject", new[] { "SubjectId" });
            DropIndex("dbo.GroupSubject", new[] { "GroupId" });
            DropTable("dbo.GroupSubject");
        }
    }
}
