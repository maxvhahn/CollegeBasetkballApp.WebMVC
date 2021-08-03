namespace CollegeSportsApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedSchool : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Athlete", "TeamId", "dbo.Team");
            DropForeignKey("dbo.Team", "SportId", "dbo.Sport");
            DropForeignKey("dbo.Sport", "SchoolId", "dbo.School");
            DropIndex("dbo.Athlete", new[] { "TeamId" });
            DropIndex("dbo.Team", new[] { "SportId" });
            DropIndex("dbo.Sport", new[] { "SchoolId" });
            AlterColumn("dbo.Athlete", "TeamId", c => c.Int());
            AlterColumn("dbo.Team", "SportId", c => c.Int());
            AlterColumn("dbo.Sport", "SchoolId", c => c.Int());
            CreateIndex("dbo.Athlete", "TeamId");
            CreateIndex("dbo.Team", "SportId");
            CreateIndex("dbo.Sport", "SchoolId");
            AddForeignKey("dbo.Athlete", "TeamId", "dbo.Team", "TeamId");
            AddForeignKey("dbo.Team", "SportId", "dbo.Sport", "SportId");
            AddForeignKey("dbo.Sport", "SchoolId", "dbo.School", "SchoolId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sport", "SchoolId", "dbo.School");
            DropForeignKey("dbo.Team", "SportId", "dbo.Sport");
            DropForeignKey("dbo.Athlete", "TeamId", "dbo.Team");
            DropIndex("dbo.Sport", new[] { "SchoolId" });
            DropIndex("dbo.Team", new[] { "SportId" });
            DropIndex("dbo.Athlete", new[] { "TeamId" });
            AlterColumn("dbo.Sport", "SchoolId", c => c.Int(nullable: false));
            AlterColumn("dbo.Team", "SportId", c => c.Int(nullable: false));
            AlterColumn("dbo.Athlete", "TeamId", c => c.Int(nullable: false));
            CreateIndex("dbo.Sport", "SchoolId");
            CreateIndex("dbo.Team", "SportId");
            CreateIndex("dbo.Athlete", "TeamId");
            AddForeignKey("dbo.Sport", "SchoolId", "dbo.School", "SchoolId", cascadeDelete: true);
            AddForeignKey("dbo.Team", "SportId", "dbo.Sport", "SportId", cascadeDelete: true);
            AddForeignKey("dbo.Athlete", "TeamId", "dbo.Team", "TeamId", cascadeDelete: true);
        }
    }
}
