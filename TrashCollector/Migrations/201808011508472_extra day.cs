namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class extraday : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ExtraDayPickUp", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "XtraDayPickUp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "XtraDayPickUp", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "ExtraDayPickUp");
        }
    }
}
