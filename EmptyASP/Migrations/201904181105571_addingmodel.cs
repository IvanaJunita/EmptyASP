namespace EmptyASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemViews", "IsDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ItemViews", "IsDelete");
        }
    }
}
