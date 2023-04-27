namespace FolderStructure.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Folders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParrentId = c.Int(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Folders", t => t.ParrentId)
                .Index(t => t.ParrentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Folders", "ParrentId", "dbo.Folders");
            DropIndex("dbo.Folders", new[] { "ParrentId" });
            DropTable("dbo.Folders");
        }
    }
}
