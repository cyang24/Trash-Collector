namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtraDay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "XtraDayPickUp", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "PickUpDayXtra_Id", c => c.Int());
            CreateIndex("dbo.Customers", "PickUpDayXtra_Id");
            AddForeignKey("dbo.Customers", "PickUpDayXtra_Id", "dbo.PickUpDays", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "PickUpDayXtra_Id", "dbo.PickUpDays");
            DropIndex("dbo.Customers", new[] { "PickUpDayXtra_Id" });
            DropColumn("dbo.Customers", "PickUpDayXtra_Id");
            DropColumn("dbo.Customers", "XtraDayPickUp");
        }
    }
}
