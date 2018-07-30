namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pickupdayadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "PickUpDayID", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "PickUpDayID");
            AddForeignKey("dbo.Customers", "PickUpDayID", "dbo.PickUpDays", "Id", cascadeDelete: true);
            DropColumn("dbo.Employees", "Address");
            DropColumn("dbo.Employees", "ZipCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "ZipCode", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "Address", c => c.String());
            DropForeignKey("dbo.Customers", "PickUpDayID", "dbo.PickUpDays");
            DropIndex("dbo.Customers", new[] { "PickUpDayID" });
            DropColumn("dbo.Customers", "PickUpDayID");
        }
    }
}
