namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updattabl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Confirmation", c => c.String());
            AddColumn("dbo.Customers", "DateStart", c => c.String());
            AddColumn("dbo.Customers", "DateEnd", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "DateEnd");
            DropColumn("dbo.Customers", "DateStart");
            DropColumn("dbo.Customers", "Confirmation");
        }
    }
}
