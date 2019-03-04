namespace E_Mag.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImgInProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Img", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Img");
        }
    }
}
