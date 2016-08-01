namespace BlueInvoicer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRateTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RateTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rate = c.String(maxLength: 12),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Contracts", "OvertimeRateType_Id", c => c.Int());
            AddColumn("dbo.Contracts", "RateType_Id", c => c.Int());
            CreateIndex("dbo.Contracts", "OvertimeRateType_Id");
            CreateIndex("dbo.Contracts", "RateType_Id");
            AddForeignKey("dbo.Contracts", "OvertimeRateType_Id", "dbo.RateTypes", "Id");
            AddForeignKey("dbo.Contracts", "RateType_Id", "dbo.RateTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contracts", "RateType_Id", "dbo.RateTypes");
            DropForeignKey("dbo.Contracts", "OvertimeRateType_Id", "dbo.RateTypes");
            DropIndex("dbo.Contracts", new[] { "RateType_Id" });
            DropIndex("dbo.Contracts", new[] { "OvertimeRateType_Id" });
            DropColumn("dbo.Contracts", "RateType_Id");
            DropColumn("dbo.Contracts", "OvertimeRateType_Id");
            DropTable("dbo.RateTypes");
        }
    }
}
