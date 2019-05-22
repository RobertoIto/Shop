namespace Shop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageOrderItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItems", "Img", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderItems", "Img");
        }
    }
}
