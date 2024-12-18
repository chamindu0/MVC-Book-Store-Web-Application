namespace BookStoreMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameQuantityToAvailableStock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "AvailableStock", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "AvailableStock");
        }
    }
}
