namespace E_Mag.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addWebId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "WebID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "WebID");
        }
    }
}
