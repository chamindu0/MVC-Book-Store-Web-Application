namespace BookStoreMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameQuantityToAvailableStock1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "UserID", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "UserID" });
            AddColumn("dbo.Orders", "PaymentStatus", c => c.String());
            AddColumn("dbo.Orders", "User_UserID", c => c.Int());
            AddColumn("dbo.OrderItems", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "UserID", c => c.String());
            AlterColumn("dbo.OrderItems", "Quantity", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "User_UserID");
            AddForeignKey("dbo.Orders", "User_UserID", "dbo.Users", "UserID");
            DropColumn("dbo.Orders", "OrderStatus");
            DropColumn("dbo.OrderItems", "SubTotal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderItems", "SubTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "OrderStatus", c => c.String());
            DropForeignKey("dbo.Orders", "User_UserID", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "User_UserID" });
            AlterColumn("dbo.OrderItems", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "UserID", c => c.Int(nullable: false));
            DropColumn("dbo.OrderItems", "Price");
            DropColumn("dbo.Orders", "User_UserID");
            DropColumn("dbo.Orders", "PaymentStatus");
            CreateIndex("dbo.Orders", "UserID");
            AddForeignKey("dbo.Orders", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
        }
    }
}
