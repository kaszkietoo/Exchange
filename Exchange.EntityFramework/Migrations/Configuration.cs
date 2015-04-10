namespace Exchange.Migrations
{
    using Exchange.Core.Users;
    using Exchange.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Exchange.EntityFramework.ExchangeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Exchange";
        }

        protected override void Seed(ExchangeDbContext context)
        {
            
        }
    }
}
