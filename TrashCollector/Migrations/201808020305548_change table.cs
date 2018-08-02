namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "PickUpConfirmID", "dbo.PickUpConfirmations");
            DropIndex("dbo.Customers", new[] { "PickUpConfirmID" });
            DropColumn("dbo.Customers", "PickUpConfirmID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "PickUpConfirmID", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "PickUpConfirmID");
            AddForeignKey("dbo.Customers", "PickUpConfirmID", "dbo.PickUpConfirmations", "Id", cascadeDelete: true);
        }
    }
}
