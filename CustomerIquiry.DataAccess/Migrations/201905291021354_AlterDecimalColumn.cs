namespace CustomerIquiry.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterDecimalColumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transactions", "Amount", c => c.Decimal(nullable: false, precision: 12, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
