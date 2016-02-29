namespace WonderBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MasterBoxes",
                c => new
                    {
                        BoxId = c.Int(nullable: false, identity: true),
                        BoxName = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.BoxId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.String(),
                        TotalBoxesOrdered = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.People");
            DropTable("dbo.MasterBoxes");
        }
    }
}
