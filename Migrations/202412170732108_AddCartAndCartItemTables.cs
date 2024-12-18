namespace BookStoreMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCartAndCartItemTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        CartItemID = c.Int(nullable: false, identity: true),
                        CartID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CartItemID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Carts", t => t.CartID, cascadeDelete: true)
                .Index(t => t.CartID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                    })
                .PrimaryKey(t => t.CartID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItems", "CartID", "dbo.Carts");
            DropForeignKey("dbo.CartItems", "BookID", "dbo.Books");
            DropIndex("dbo.CartItems", new[] { "BookID" });
            DropIndex("dbo.CartItems", new[] { "CartID" });
            DropTable("dbo.Carts");
            DropTable("dbo.CartItems");
        }
    }
}
