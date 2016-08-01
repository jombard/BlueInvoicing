namespace BlueInvoicer.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateRateTypes : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into RateTypes Values ('Hourly')");
            Sql("Insert into RateTypes Values ('Daily')");
            Sql("Insert into RateTypes Values ('Weekly')");
            Sql("Insert into RateTypes Values ('Monthly')");
        }
        
        public override void Down()
        {
            Sql("Truncate table RateTypes");
        }
    }
}
