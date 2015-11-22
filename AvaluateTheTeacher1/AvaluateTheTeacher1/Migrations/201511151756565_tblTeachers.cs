namespace AvaluateTheTeacher1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblTeachers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SurName = c.String(),
                        LastName = c.String(),
                        Skill = c.String(),
                    })
                .PrimaryKey(t => t.TeacherId);
            
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.AspNetUsers", "Surname");
            DropColumn("dbo.AspNetUsers", "Lastname");
            DropColumn("dbo.AspNetUsers", "Skill");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Skill", c => c.String());
            AddColumn("dbo.AspNetUsers", "Lastname", c => c.String());
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String());
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            DropTable("dbo.Teachers");
        }
    }
}
