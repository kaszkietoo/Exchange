namespace Exchange.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsClosedPropertyAddedToOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "IsClosed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "IsClosed");
        }
    }
}
