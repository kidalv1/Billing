namespace DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeuser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Invoice", "User", c => c.String());
            DropColumn("dbo.Invoice", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoice", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Invoice", "User", c => c.String(nullable: false, maxLength: 8000, unicode: false));
        }
    }
}
