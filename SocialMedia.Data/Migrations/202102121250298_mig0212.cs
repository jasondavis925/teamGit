namespace SocialMedia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig0212 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "Post_PostId", "dbo.Post");
            DropIndex("dbo.Comment", new[] { "Post_PostId" });
            RenameColumn(table: "dbo.Comment", name: "Post_PostId", newName: "PostId");
            AlterColumn("dbo.Comment", "PostId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comment", "PostId");
            AddForeignKey("dbo.Comment", "PostId", "dbo.Post", "PostId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropIndex("dbo.Comment", new[] { "PostId" });
            AlterColumn("dbo.Comment", "PostId", c => c.Int());
            RenameColumn(table: "dbo.Comment", name: "PostId", newName: "Post_PostId");
            CreateIndex("dbo.Comment", "Post_PostId");
            AddForeignKey("dbo.Comment", "Post_PostId", "dbo.Post", "PostId");
        }
    }
}
