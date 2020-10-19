namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventDetails",
                c => new
                    {
                        EventDetailId = c.Int(nullable: false, identity: true),
                        EventDetailname = c.String(nullable: false, maxLength: 20),
                        EventDetailNumber = c.Int(nullable: false),
                        EventDetailOdd = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Finishingposition = c.Int(nullable: false),
                        FirstTimer = c.Boolean(nullable: false),
                        EventId = c.Int(nullable: false),
                        EventDetailStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventDetailId)
                .ForeignKey("dbo.EventDetailStatus", t => t.EventDetailStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.EventDetailStatusId);
            
            CreateTable(
                "dbo.EventDetailStatus",
                c => new
                    {
                        EventDetailStatusId = c.Int(nullable: false, identity: true),
                        EventDetailStatusName = c.String(),
                    })
                .PrimaryKey(t => t.EventDetailStatusId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventName = c.String(nullable: false, maxLength: 20),
                        EventNumber = c.Int(nullable: false),
                        EventDateTime = c.DateTime(nullable: false),
                        EventEndDateTime = c.DateTime(nullable: false),
                        AutoClose = c.Boolean(nullable: false),
                        TournamentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Tournaments", t => t.TournamentId, cascadeDelete: true)
                .Index(t => t.TournamentId);
            
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        TournamentId = c.Int(nullable: false, identity: true),
                        TournamentName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.TournamentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventDetails", "EventId", "dbo.Events");
            DropForeignKey("dbo.Events", "TournamentId", "dbo.Tournaments");
            DropForeignKey("dbo.EventDetails", "EventDetailStatusId", "dbo.EventDetailStatus");
            DropIndex("dbo.Events", new[] { "TournamentId" });
            DropIndex("dbo.EventDetails", new[] { "EventDetailStatusId" });
            DropIndex("dbo.EventDetails", new[] { "EventId" });
            DropTable("dbo.Tournaments");
            DropTable("dbo.Events");
            DropTable("dbo.EventDetailStatus");
            DropTable("dbo.EventDetails");
        }
    }
}
