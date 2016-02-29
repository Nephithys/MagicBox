namespace WonderBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTotalGenderMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "TotalMale", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "TotalFemale", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "TotalFemale");
            DropColumn("dbo.Users", "TotalMale");
        }
    }
}
