namespace E_Mag.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Img", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Img", c => c.String());
        }
    }
}
