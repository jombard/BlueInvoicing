namespace BlueInvoicer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFurtherColumnsToInvoiceEntry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvoiceEntries", "Rate", c => c.String());
            AddColumn("dbo.InvoiceEntries", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InvoiceEntries", "Quantity");
            DropColumn("dbo.InvoiceEntries", "Rate");
        }
    }
}
