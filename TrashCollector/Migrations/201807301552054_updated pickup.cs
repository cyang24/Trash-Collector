namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedpickup : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Customers", new[] { "PickUpDayID" });
            CreateIndex("dbo.Customers", "PickUpDayId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customers", new[] { "PickUpDayId" });
            CreateIndex("dbo.Customers", "PickUpDayID");
        }
    }
}
