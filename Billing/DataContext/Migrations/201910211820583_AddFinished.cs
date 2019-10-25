namespace DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFinished : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoice", "Finished", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoice", "Finished");
        }
    }
}
