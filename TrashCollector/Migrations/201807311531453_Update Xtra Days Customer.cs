namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateXtraDaysCustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "PickUpDayXtra_Id", "dbo.PickUpDays");
            DropIndex("dbo.Customers", new[] { "PickUpDayXtra_Id" });
            DropColumn("dbo.Customers", "PickUpDayXtra_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "PickUpDayXtra_Id", c => c.Int());
            CreateIndex("dbo.Customers", "PickUpDayXtra_Id");
            AddForeignKey("dbo.Customers", "PickUpDayXtra_Id", "dbo.PickUpDays", "Id");
        }
    }
}
