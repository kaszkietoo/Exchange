namespace Exchange.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class OrderEntityAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CarBody = c.String(nullable: false),
                        Capacity = c.Single(nullable: false),
                        Length = c.Single(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.String(nullable: false),
                        Visibility = c.String(nullable: false),
                        Partial = c.Boolean(nullable: false),
                        CountryFrom = c.String(nullable: false),
                        CityFrom = c.String(nullable: false),
                        LoadingDate = c.DateTime(nullable: false),
                        CountryTo = c.String(nullable: false),
                        CityTo = c.String(nullable: false),
                        UnloadingDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Order_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Order_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
