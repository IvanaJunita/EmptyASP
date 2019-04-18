namespace EmptyASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmodelitem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        Stock = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        supplier_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.supplier_Id)
                .Index(t => t.supplier_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "supplier_Id", "dbo.Suppliers");
            DropIndex("dbo.Items", new[] { "supplier_Id" });
            DropTable("dbo.Items");
        }
    }
}
