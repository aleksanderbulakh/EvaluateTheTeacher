namespace AvaluateTheTeacher1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblVotes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Votings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Interest = c.Single(nullable: false),
                        Quality = c.Single(nullable: false),
                        RelevantToStudents = c.Single(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votings", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Votings", new[] { "TeacherId" });
            DropTable("dbo.Votings");
        }
    }
}
