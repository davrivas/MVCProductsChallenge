namespace MVCProductsChallenge.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.ProductTypes", "ProductTypeName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductTypes", "ProductTypeName", c => c.String());
            AlterColumn("dbo.Products", "Description", c => c.String());
        }
    }
}
