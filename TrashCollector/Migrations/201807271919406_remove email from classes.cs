namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeemailfromclasses : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Email");
            DropColumn("dbo.Employees", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Email", c => c.String());
            AddColumn("dbo.Customers", "Email", c => c.String());
        }
    }
}
