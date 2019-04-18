namespace EmptyASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmodelling : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "supplier_Id", "dbo.Suppliers");
            DropIndex("dbo.Items", new[] { "supplier_Id" });
            CreateTable(
                "dbo.ItemViews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        Stock = c.Int(nullable: false),
                        Supplier_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Items", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Items", "supplier_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Items", "supplier_Id");
            AddForeignKey("dbo.Items", "supplier_Id", "dbo.Suppliers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "supplier_Id", "dbo.Suppliers");
            DropIndex("dbo.Items", new[] { "supplier_Id" });
            AlterColumn("dbo.Items", "supplier_Id", c => c.Int());
            AlterColumn("dbo.Items", "Name", c => c.String());
            DropTable("dbo.ItemViews");
            CreateIndex("dbo.Items", "supplier_Id");
            AddForeignKey("dbo.Items", "supplier_Id", "dbo.Suppliers", "Id");
        }
    }
}
