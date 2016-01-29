namespace AvaluateTheTeacher1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GroupTeacherSubject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupTeacherSubjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherSubjectId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GroupTeacherSubjects");
        }
    }
}
