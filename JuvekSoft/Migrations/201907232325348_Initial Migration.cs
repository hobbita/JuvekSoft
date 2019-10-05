namespace JuvekSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FacetingTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FacName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.InsertStores",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Photo = c.Binary(storeType: "image"),
                        InsMat = c.Int(nullable: false),
                        FacType = c.Int(nullable: false),
                        Size1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Size2 = c.Decimal(precision: 18, scale: 2),
                        Size3 = c.Decimal(precision: 18, scale: 2),
                        SizeUnits = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        QuantityUnits = c.Int(nullable: false),
                        Cost = c.Decimal(nullable: false, storeType: "money"),
                        CostUnits = c.Int(nullable: false),
                        OtherInfo = c.String(maxLength: 50),
                        InUse = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.InsertMaterials", t => t.InsMat)
                .ForeignKey("dbo.Units", t => t.QuantityUnits)
                .ForeignKey("dbo.Units", t => t.SizeUnits)
                .ForeignKey("dbo.Units", t => t.CostUnits)
                .ForeignKey("dbo.FacetingTypes", t => t.FacType)
                .Index(t => t.InsMat)
                .Index(t => t.FacType)
                .Index(t => t.SizeUnits)
                .Index(t => t.QuantityUnits)
                .Index(t => t.CostUnits);
            
            CreateTable(
                "dbo.InsertMaterials",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        InsMatName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Photo = c.Binary(storeType: "image"),
                        Cost = c.Decimal(storeType: "money"),
                        OtherInfo = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.MetalStores",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Photo = c.Binary(storeType: "image"),
                        MetType = c.Int(nullable: false),
                        MetName = c.Int(nullable: false),
                        Size1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Size2 = c.Decimal(precision: 18, scale: 2),
                        Size3 = c.Decimal(precision: 18, scale: 2),
                        SizeUnits = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantityUnits = c.Int(nullable: false),
                        Cost = c.Decimal(nullable: false, storeType: "money"),
                        CostUnits = c.Int(nullable: false),
                        OtherInfo = c.String(maxLength: 50),
                        InUse = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.MetalNames", t => t.MetName)
                .ForeignKey("dbo.MetalTypes", t => t.MetType)
                .ForeignKey("dbo.Units", t => t.CostUnits)
                .ForeignKey("dbo.Units", t => t.QuantityUnits)
                .ForeignKey("dbo.Units", t => t.SizeUnits)
                .Index(t => t.MetType)
                .Index(t => t.MetName)
                .Index(t => t.SizeUnits)
                .Index(t => t.QuantityUnits)
                .Index(t => t.CostUnits);
            
            CreateTable(
                "dbo.MetalNames",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        MetalName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.MetalTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        MetTypeName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UnitName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Operations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        OperName = c.String(nullable: false, maxLength: 50),
                        Cost = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ProductsMetalStores",
                c => new
                    {
                        MetalStore_id = c.Int(nullable: false),
                        Product_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MetalStore_id, t.Product_id })
                .ForeignKey("dbo.MetalStores", t => t.MetalStore_id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_id, cascadeDelete: true)
                .Index(t => t.MetalStore_id)
                .Index(t => t.Product_id);
            
            CreateTable(
                "dbo.ProductsOperations",
                c => new
                    {
                        Operation_id = c.Int(nullable: false),
                        Product_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Operation_id, t.Product_id })
                .ForeignKey("dbo.Operations", t => t.Operation_id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_id, cascadeDelete: true)
                .Index(t => t.Operation_id)
                .Index(t => t.Product_id);
            
            CreateTable(
                "dbo.InsertStoresProducts",
                c => new
                    {
                        InsertStore_id = c.Int(nullable: false),
                        Product_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.InsertStore_id, t.Product_id })
                .ForeignKey("dbo.InsertStores", t => t.InsertStore_id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_id, cascadeDelete: true)
                .Index(t => t.InsertStore_id)
                .Index(t => t.Product_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InsertStores", "FacType", "dbo.FacetingTypes");
            DropForeignKey("dbo.InsertStoresProducts", "Product_id", "dbo.Products");
            DropForeignKey("dbo.InsertStoresProducts", "InsertStore_id", "dbo.InsertStores");
            DropForeignKey("dbo.ProductsOperations", "Product_id", "dbo.Products");
            DropForeignKey("dbo.ProductsOperations", "Operation_id", "dbo.Operations");
            DropForeignKey("dbo.MetalStores", "SizeUnits", "dbo.Units");
            DropForeignKey("dbo.MetalStores", "QuantityUnits", "dbo.Units");
            DropForeignKey("dbo.MetalStores", "CostUnits", "dbo.Units");
            DropForeignKey("dbo.InsertStores", "CostUnits", "dbo.Units");
            DropForeignKey("dbo.InsertStores", "SizeUnits", "dbo.Units");
            DropForeignKey("dbo.InsertStores", "QuantityUnits", "dbo.Units");
            DropForeignKey("dbo.ProductsMetalStores", "Product_id", "dbo.Products");
            DropForeignKey("dbo.ProductsMetalStores", "MetalStore_id", "dbo.MetalStores");
            DropForeignKey("dbo.MetalStores", "MetType", "dbo.MetalTypes");
            DropForeignKey("dbo.MetalStores", "MetName", "dbo.MetalNames");
            DropForeignKey("dbo.InsertStores", "InsMat", "dbo.InsertMaterials");
            DropIndex("dbo.InsertStoresProducts", new[] { "Product_id" });
            DropIndex("dbo.InsertStoresProducts", new[] { "InsertStore_id" });
            DropIndex("dbo.ProductsOperations", new[] { "Product_id" });
            DropIndex("dbo.ProductsOperations", new[] { "Operation_id" });
            DropIndex("dbo.ProductsMetalStores", new[] { "Product_id" });
            DropIndex("dbo.ProductsMetalStores", new[] { "MetalStore_id" });
            DropIndex("dbo.MetalStores", new[] { "CostUnits" });
            DropIndex("dbo.MetalStores", new[] { "QuantityUnits" });
            DropIndex("dbo.MetalStores", new[] { "SizeUnits" });
            DropIndex("dbo.MetalStores", new[] { "MetName" });
            DropIndex("dbo.MetalStores", new[] { "MetType" });
            DropIndex("dbo.InsertStores", new[] { "CostUnits" });
            DropIndex("dbo.InsertStores", new[] { "QuantityUnits" });
            DropIndex("dbo.InsertStores", new[] { "SizeUnits" });
            DropIndex("dbo.InsertStores", new[] { "FacType" });
            DropIndex("dbo.InsertStores", new[] { "InsMat" });
            DropTable("dbo.InsertStoresProducts");
            DropTable("dbo.ProductsOperations");
            DropTable("dbo.ProductsMetalStores");
            DropTable("dbo.Operations");
            DropTable("dbo.Units");
            DropTable("dbo.MetalTypes");
            DropTable("dbo.MetalNames");
            DropTable("dbo.MetalStores");
            DropTable("dbo.Products");
            DropTable("dbo.InsertMaterials");
            DropTable("dbo.InsertStores");
            DropTable("dbo.FacetingTypes");
        }
    }
}
