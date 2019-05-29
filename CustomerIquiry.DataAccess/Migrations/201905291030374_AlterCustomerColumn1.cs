namespace CustomerIquiry.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCustomerColumn1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "MobileNumber", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "MobileNumber", c => c.String());
        }
    }
}
