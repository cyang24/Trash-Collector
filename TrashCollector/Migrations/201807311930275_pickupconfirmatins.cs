namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pickupconfirmatins : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PickUpConfirmations",
                c => new
                    {
                        PickUpStatus = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PickUpStatus);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PickUpConfirmations");
        }
    }
}
