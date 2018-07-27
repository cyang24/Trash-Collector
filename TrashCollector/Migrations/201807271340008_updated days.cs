namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateddays : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PickUpDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayOfTheWeek = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PickUpDays");
        }
    }
}
