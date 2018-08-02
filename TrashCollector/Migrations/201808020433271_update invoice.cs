namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateinvoice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Invoice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Invoice");
        }
    }
}
