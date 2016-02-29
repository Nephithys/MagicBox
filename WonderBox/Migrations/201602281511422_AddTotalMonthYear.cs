namespace WonderBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTotalMonthYear : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "TotalMonthlySubcription", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "TotalYearlySubscription", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "TotalYearlySubscription");
            DropColumn("dbo.Users", "TotalMonthlySubcription");
        }
    }
}
