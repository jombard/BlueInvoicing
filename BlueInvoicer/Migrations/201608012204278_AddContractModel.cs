namespace BlueInvoicer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContractModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OvertimeRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Client_ClientId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_ClientId)
                .Index(t => t.Client_ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contracts", "Client_ClientId", "dbo.Clients");
            DropIndex("dbo.Contracts", new[] { "Client_ClientId" });
            DropTable("dbo.Contracts");
        }
    }
}
