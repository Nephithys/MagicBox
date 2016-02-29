namespace WonderBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MsteryOne : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TheMysteryBoxes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TheMysteryBoxes");
        }
    }
}
