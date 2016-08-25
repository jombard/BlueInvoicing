namespace BlueInvoicer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInvoiceEntryColumnTypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InvoiceEntries", "Rate", c => c.Int(nullable: false));
            DropColumn("dbo.InvoiceEntries", "Amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InvoiceEntries", "Amount", c => c.Int(nullable: false));
            AlterColumn("dbo.InvoiceEntries", "Rate", c => c.String());
        }
    }
}
