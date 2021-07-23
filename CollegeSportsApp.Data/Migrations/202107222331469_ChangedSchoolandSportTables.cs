namespace CollegeSportsApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedSchoolandSportTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sport", "SchoolId", "dbo.School");
            DropIndex("dbo.Sport", new[] { "SchoolId" });
            AddColumn("dbo.School", "SportId", c => c.Int());
            CreateIndex("dbo.School", "SportId");
            AddForeignKey("dbo.School", "SportId", "dbo.Sport", "SportId");
            DropColumn("dbo.Sport", "SchoolId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sport", "SchoolId", c => c.Int());
            DropForeignKey("dbo.School", "SportId", "dbo.Sport");
            DropIndex("dbo.School", new[] { "SportId" });
            DropColumn("dbo.School", "SportId");
            CreateIndex("dbo.Sport", "SchoolId");
            AddForeignKey("dbo.Sport", "SchoolId", "dbo.School", "SchoolId");
        }
    }
}
