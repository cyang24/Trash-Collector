namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class confirmation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "PickUpStatus", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customers", "PickUpStatus");
            AddForeignKey("dbo.Customers", "PickUpStatus", "dbo.PickUpConfirmations", "PickUpStatus");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "PickUpStatus", "dbo.PickUpConfirmations");
            DropIndex("dbo.Customers", new[] { "PickUpStatus" });
            DropColumn("dbo.Customers", "PickUpStatus");
        }
    }
}
