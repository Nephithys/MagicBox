namespace WonderBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class survey1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Question1 = c.String(),
                        Question2 = c.String(),
                        Question3 = c.String(),
                        Question4 = c.String(),
                        Question5 = c.String(),
                        Question6 = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Surveys");
        }
    }
}
