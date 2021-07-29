namespace CollegeSportsApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedAthlete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Team", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.School", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.School", "OwnerId");
            DropColumn("dbo.Team", "OwnerId");
        }
    }
}
