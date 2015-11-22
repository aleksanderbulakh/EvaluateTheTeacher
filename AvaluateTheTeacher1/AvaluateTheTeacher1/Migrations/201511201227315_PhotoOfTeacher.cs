namespace AvaluateTheTeacher1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotoOfTeacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "PathToPhoto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "PathToPhoto");
        }
    }
}
