namespace SocialMedia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropIndex("dbo.Comment", new[] { "PostId" });
            RenameColumn(table: "dbo.Comment", name: "PostId", newName: "Post_PostId");
            AlterColumn("dbo.Comment", "Post_PostId", c => c.Int());
            CreateIndex("dbo.Comment", "Post_PostId");
            AddForeignKey("dbo.Comment", "Post_PostId", "dbo.Post", "PostId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "Post_PostId", "dbo.Post");
            DropIndex("dbo.Comment", new[] { "Post_PostId" });
            AlterColumn("dbo.Comment", "Post_PostId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Comment", name: "Post_PostId", newName: "PostId");
            CreateIndex("dbo.Comment", "PostId");
            AddForeignKey("dbo.Comment", "PostId", "dbo.Post", "PostId", cascadeDelete: true);
        }
    }
}
