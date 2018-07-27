namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removepasswordupdatecustomer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Password");
            DropColumn("dbo.Employees", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Password", c => c.String());
            AddColumn("dbo.Customers", "Password", c => c.String());
        }
    }
}
