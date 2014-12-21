namespace ItsGitHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        AssignmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Assignments", t => t.AssignmentId, cascadeDelete: true)
                .Index(t => t.AssignmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "AssignmentId", "dbo.Assignments");
            DropIndex("dbo.Comments", new[] { "AssignmentId" });
            DropTable("dbo.Comments");
        }
    }
}
