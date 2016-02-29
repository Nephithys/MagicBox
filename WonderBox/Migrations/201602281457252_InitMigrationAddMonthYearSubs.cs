namespace WonderBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigrationAddMonthYearSubs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "MonthlySubscription", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "YearlySubscription", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "YearlySubscription");
            DropColumn("dbo.Users", "MonthlySubscription");
        }
    }
}
