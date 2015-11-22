namespace AvaluateTheTeacher1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblCathedra : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cathedras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameCathedra = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Teachers", "CathedraId", c => c.Int());
            CreateIndex("dbo.Teachers", "CathedraId");
            AddForeignKey("dbo.Teachers", "CathedraId", "dbo.Cathedras", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "CathedraId", "dbo.Cathedras");
            DropIndex("dbo.Teachers", new[] { "CathedraId" });
            DropColumn("dbo.Teachers", "CathedraId");
            DropTable("dbo.Cathedras");
        }
    }
}
