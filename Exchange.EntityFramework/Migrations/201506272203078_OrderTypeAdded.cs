namespace Exchange.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderTypeAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Type", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Type");
        }
    }
}
