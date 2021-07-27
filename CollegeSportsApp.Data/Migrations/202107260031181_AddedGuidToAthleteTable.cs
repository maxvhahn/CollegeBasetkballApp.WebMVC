namespace CollegeSportsApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGuidToAthleteTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Athlete", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Athlete", "OwnerId");
        }
    }
}
