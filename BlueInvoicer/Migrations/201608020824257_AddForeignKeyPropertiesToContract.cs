namespace BlueInvoicer.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddForeignKeyPropertiesToContract : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contracts", "Client_ClientId", "dbo.Clients");
            DropForeignKey("dbo.Contracts", "OvertimeRateType_Id", "dbo.RateTypes");
            DropForeignKey("dbo.Contracts", "RateType_Id", "dbo.RateTypes");
            DropIndex("dbo.Contracts", new[] { "Client_ClientId" });
            DropIndex("dbo.Contracts", new[] { "OvertimeRateType_Id" });
            DropIndex("dbo.Contracts", new[] { "RateType_Id" });
            RenameColumn(table: "dbo.Contracts", name: "Client_ClientId", newName: "ClientId");
            RenameColumn(table: "dbo.Contracts", name: "OvertimeRateType_Id", newName: "OvertimeRateTypeId");
            RenameColumn(table: "dbo.Contracts", name: "RateType_Id", newName: "RateTypeId");
            AlterColumn("dbo.Contracts", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Contracts", "ClientId", c => c.Int(nullable: false));
            AlterColumn("dbo.Contracts", "OvertimeRateTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Contracts", "RateTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contracts", "ClientId");
            CreateIndex("dbo.Contracts", "RateTypeId");
            CreateIndex("dbo.Contracts", "OvertimeRateTypeId");
            AddForeignKey("dbo.Contracts", "ClientId", "dbo.Clients", "ClientId");
            AddForeignKey("dbo.Contracts", "OvertimeRateTypeId", "dbo.RateTypes", "Id");
            AddForeignKey("dbo.Contracts", "RateTypeId", "dbo.RateTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contracts", "RateTypeId", "dbo.RateTypes");
            DropForeignKey("dbo.Contracts", "OvertimeRateTypeId", "dbo.RateTypes");
            DropForeignKey("dbo.Contracts", "ClientId", "dbo.Clients");
            DropIndex("dbo.Contracts", new[] { "OvertimeRateTypeId" });
            DropIndex("dbo.Contracts", new[] { "RateTypeId" });
            DropIndex("dbo.Contracts", new[] { "ClientId" });
            AlterColumn("dbo.Contracts", "RateTypeId", c => c.Int());
            AlterColumn("dbo.Contracts", "OvertimeRateTypeId", c => c.Int());
            AlterColumn("dbo.Contracts", "ClientId", c => c.Int());
            AlterColumn("dbo.Contracts", "Name", c => c.String());
            RenameColumn(table: "dbo.Contracts", name: "RateTypeId", newName: "RateType_Id");
            RenameColumn(table: "dbo.Contracts", name: "OvertimeRateTypeId", newName: "OvertimeRateType_Id");
            RenameColumn(table: "dbo.Contracts", name: "ClientId", newName: "Client_ClientId");
            CreateIndex("dbo.Contracts", "RateType_Id");
            CreateIndex("dbo.Contracts", "OvertimeRateType_Id");
            CreateIndex("dbo.Contracts", "Client_ClientId");
            AddForeignKey("dbo.Contracts", "RateType_Id", "dbo.RateTypes", "Id");
            AddForeignKey("dbo.Contracts", "OvertimeRateType_Id", "dbo.RateTypes", "Id");
            AddForeignKey("dbo.Contracts", "Client_ClientId", "dbo.Clients", "ClientId");
        }
    }
}
