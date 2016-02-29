namespace WonderBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateAddTotalReg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "TotalRegistered", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "TotalRegistered");
        }
    }
}
