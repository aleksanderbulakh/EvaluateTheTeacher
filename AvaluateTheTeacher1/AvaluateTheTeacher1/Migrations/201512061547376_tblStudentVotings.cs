namespace AvaluateTheTeacher1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblStudentVotings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentVotings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Student_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Student_Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.Student_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentVotings", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.StudentVotings", "Student_Id", "dbo.AspNetUsers");
            DropIndex("dbo.StudentVotings", new[] { "Student_Id" });
            DropIndex("dbo.StudentVotings", new[] { "TeacherId" });
            DropTable("dbo.StudentVotings");
        }
    }
}
