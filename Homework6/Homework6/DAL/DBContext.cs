using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Homework6.Models;

namespace Homework6.DAL
{
    /// <summary>
    /// Context for ProductCategories
    /// </summary>
    public class DBContext : DbContext
    {
        /// <summary>
        /// Constructor for Category Context
        /// </summary>
        public DBContext() : base("name=MyDBContext") { }

        /// <summary>
        /// DBSet for Categories
        /// </summary>
        public virtual DbSet<ProductCategory> Category { get; set; }
        public virtual DbSet<ProductCostHistory> CostHistory { get; set; }
        public virtual DbSet<ProductDescription> Description { get; set; }
        public virtual DbSet<ProductInventory> Inventory { get; set; }
        public virtual DbSet<ProductListPriceHistory> PriceListHistory { get; set; }
        public virtual DbSet<ProductModel> Model { get; set; }
        public virtual DbSet<ProductModelIllustration> Illustration { get; set;}
        public virtual DbSet<ProductModelProductDescriptionCulture> ProductDescriptionCulture { get; set; }
        public virtual DbSet<ProductPhoto> Photo { get; set; }
        public virtual DbSet<ProductProductPhoto> ProductProductPhoto { get; set; }
        public virtual DbSet<ProductReview> Review { get; set; }
        public virtual DbSet<ProductSubcategory> Subcategory { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ScrapReason> ScrapReason { get; set; }
        public virtual DbSet<UnitMeasure> UnitMeasuer { get; set; }
        public virtual DbSet<TransactionHistory> TransactionHistory { get; set; }
        public virtual DbSet<TransactionHistoryArchive> TransactionHistoryArchive { get; set; }
        public virtual DbSet<WorkOrder> WorkOrder { get; set; }
        public virtual DbSet<WorkOrderRouting> WorkOrderRouting { get; set; }
        public virtual DbSet<BillOfMaterial> BillOfMaterials { get; set; }
        public virtual DbSet<Culture> Culture { get; set; }
        public virtual DbSet<ProductDocument> ProductDocument { get; set; }
    }
}