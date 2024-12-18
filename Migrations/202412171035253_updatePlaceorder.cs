namespace BookStoreMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePlaceorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ShippingAddress", c => c.String());
            AddColumn("dbo.Orders", "CardNumber", c => c.String());
            AddColumn("dbo.Orders", "CardHolderName", c => c.String());
            AddColumn("dbo.Orders", "ExpiryDate", c => c.String());
            AddColumn("dbo.Orders", "CVV", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "CVV");
            DropColumn("dbo.Orders", "ExpiryDate");
            DropColumn("dbo.Orders", "CardHolderName");
            DropColumn("dbo.Orders", "CardNumber");
            DropColumn("dbo.Orders", "ShippingAddress");
        }
    }
}
