namespace CollegeSportsApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDidntChangeAnything : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Athlete", "TeamId", "dbo.Team");
            DropIndex("dbo.Athlete", new[] { "TeamId" });
            AlterColumn("dbo.Athlete", "TeamId", c => c.Int(nullable: false));
            CreateIndex("dbo.Athlete", "TeamId");
            AddForeignKey("dbo.Athlete", "TeamId", "dbo.Team", "TeamId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Athlete", "TeamId", "dbo.Team");
            DropIndex("dbo.Athlete", new[] { "TeamId" });
            AlterColumn("dbo.Athlete", "TeamId", c => c.Int());
            CreateIndex("dbo.Athlete", "TeamId");
            AddForeignKey("dbo.Athlete", "TeamId", "dbo.Team", "TeamId");
        }
    }
}
