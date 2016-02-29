namespace WonderBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class item : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Items", "Proof");
            DropColumn("dbo.Items", "Proof1");
            DropColumn("dbo.Items", "Proof2");
            DropColumn("dbo.Items", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Items", "Proof2", c => c.String());
            AddColumn("dbo.Items", "Proof1", c => c.String());
            AddColumn("dbo.Items", "Proof", c => c.String());
        }
    }
}
