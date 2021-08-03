namespace CollegeSportsApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedTablesWithIds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Team", "SchoolId", "dbo.School");
            DropForeignKey("dbo.Team", "Sport_SportId", "dbo.Sport");
            DropIndex("dbo.Team", new[] { "SchoolId" });
            DropIndex("dbo.Team", new[] { "Sport_SportId" });
            RenameColumn(table: "dbo.Team", name: "Sport_SportId", newName: "SportId");
            AlterColumn("dbo.Team", "SportId", c => c.Int(nullable: false));
            CreateIndex("dbo.Team", "SportId");
            AddForeignKey("dbo.Team", "SportId", "dbo.Sport", "SportId", cascadeDelete: true);
            DropColumn("dbo.Team", "SchoolId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Team", "SchoolId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Team", "SportId", "dbo.Sport");
            DropIndex("dbo.Team", new[] { "SportId" });
            AlterColumn("dbo.Team", "SportId", c => c.Int());
            RenameColumn(table: "dbo.Team", name: "SportId", newName: "Sport_SportId");
            CreateIndex("dbo.Team", "Sport_SportId");
            CreateIndex("dbo.Team", "SchoolId");
            AddForeignKey("dbo.Team", "Sport_SportId", "dbo.Sport", "SportId");
            AddForeignKey("dbo.Team", "SchoolId", "dbo.School", "SchoolId", cascadeDelete: true);
        }
    }
}
