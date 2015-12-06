namespace AvaluateTheTeacher1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblStudentVotingsMod : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.StudentVotings", name: "Student_Id", newName: "StudentId");
            RenameIndex(table: "dbo.StudentVotings", name: "IX_Student_Id", newName: "IX_StudentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.StudentVotings", name: "IX_StudentId", newName: "IX_Student_Id");
            RenameColumn(table: "dbo.StudentVotings", name: "StudentId", newName: "Student_Id");
        }
    }
}
