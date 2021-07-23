namespace CollegeSportsApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGuidToSportTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sport", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sport", "OwnerId");
        }
    }
}
