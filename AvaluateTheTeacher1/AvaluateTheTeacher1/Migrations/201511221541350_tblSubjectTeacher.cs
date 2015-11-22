namespace AvaluateTheTeacher1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblSubjectTeacher : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CathedraId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cathedras", t => t.CathedraId, cascadeDelete: true)
                .Index(t => t.CathedraId);
            
            CreateTable(
                "dbo.SubjectTeacher",
                c => new
                    {
                        SubjectId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubjectId, t.TeacherId })
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubjectTeacher", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.SubjectTeacher", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "CathedraId", "dbo.Cathedras");
            DropIndex("dbo.SubjectTeacher", new[] { "TeacherId" });
            DropIndex("dbo.SubjectTeacher", new[] { "SubjectId" });
            DropIndex("dbo.Subjects", new[] { "CathedraId" });
            DropTable("dbo.SubjectTeacher");
            DropTable("dbo.Subjects");
        }
    }
}
