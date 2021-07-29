namespace CollegeSportsApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NonNullableConferenceId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.School", "ConferenceId", "dbo.Conference");
            DropIndex("dbo.School", new[] { "ConferenceId" });
            AlterColumn("dbo.School", "ConferenceId", c => c.Int(nullable: false));
            CreateIndex("dbo.School", "ConferenceId");
            AddForeignKey("dbo.School", "ConferenceId", "dbo.Conference", "ConferenceId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.School", "ConferenceId", "dbo.Conference");
            DropIndex("dbo.School", new[] { "ConferenceId" });
            AlterColumn("dbo.School", "ConferenceId", c => c.Int());
            CreateIndex("dbo.School", "ConferenceId");
            AddForeignKey("dbo.School", "ConferenceId", "dbo.Conference", "ConferenceId");
        }
    }
}
