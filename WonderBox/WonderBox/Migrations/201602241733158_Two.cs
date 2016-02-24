namespace WonderBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Two : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "BoxesOrdered", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "BoxesOrdered");
        }
    }
}
