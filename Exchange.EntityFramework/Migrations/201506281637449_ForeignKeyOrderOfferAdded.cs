namespace Exchange.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyOrderOfferAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Offers", "OrderId", c => c.Long(nullable: false));
            CreateIndex("dbo.Offers", "OrderId");
            AddForeignKey("dbo.Offers", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offers", "OrderId", "dbo.Orders");
            DropIndex("dbo.Offers", new[] { "OrderId" });
            AlterColumn("dbo.Offers", "OrderId", c => c.Int(nullable: false));
        }
    }
}
