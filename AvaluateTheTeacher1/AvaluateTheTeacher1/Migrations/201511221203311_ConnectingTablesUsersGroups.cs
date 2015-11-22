namespace AvaluateTheTeacher1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConnectingTablesUsersGroups : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "GroupId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "GroupId");
            AddForeignKey("dbo.AspNetUsers", "GroupId", "dbo.Groups", "GroupId");
            DropColumn("dbo.AspNetUsers", "Group");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Group", c => c.Int(nullable: false));
            DropForeignKey("dbo.AspNetUsers", "GroupId", "dbo.Groups");
            DropIndex("dbo.AspNetUsers", new[] { "GroupId" });
            DropColumn("dbo.AspNetUsers", "GroupId");
        }
    }
}
