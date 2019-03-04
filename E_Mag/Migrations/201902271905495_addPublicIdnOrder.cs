namespace E_Mag.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPublicIdnOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PublicOrderId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "PublicOrderId");
        }
    }
}
