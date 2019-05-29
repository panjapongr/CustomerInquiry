namespace CustomerIquiry.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCustomerIDToFixSize : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "CustomerID" });
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "CustomerID", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Transactions", "CustomerID", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.Customers", "CustomerID");
            CreateIndex("dbo.Transactions", "CustomerID");
            AddForeignKey("dbo.Transactions", "CustomerID", "dbo.Customers", "CustomerID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "CustomerID" });
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Transactions", "CustomerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "CustomerID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Customers", "CustomerID");
            CreateIndex("dbo.Transactions", "CustomerID");
            AddForeignKey("dbo.Transactions", "CustomerID", "dbo.Customers", "CustomerID", cascadeDelete: true);
        }
    }
}
