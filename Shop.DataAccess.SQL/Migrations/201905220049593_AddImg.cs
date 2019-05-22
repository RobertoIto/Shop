namespace Shop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Img", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Img");
        }
    }
}
