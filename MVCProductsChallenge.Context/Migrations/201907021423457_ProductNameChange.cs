namespace MVCProductsChallenge.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductNameChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductTypes", "Name", c => c.String(nullable: false));
            DropColumn("dbo.ProductTypes", "ProductTypeName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductTypes", "ProductTypeName", c => c.String(nullable: false));
            DropColumn("dbo.ProductTypes", "Name");
        }
    }
}
