using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Rental.API.Model;

namespace Rental.API.Infrastructures
{
    public partial class RentalDbContext : DbContext
    {
        public RentalDbContext(DbContextOptions<RentalDbContext> options)
            : base(options)
        {
        }
        public DbSet<FieldMaster> FieldMasters { get; set; }
        public DbSet<ProductReview> ProductReview { get; set; }
        public virtual DbSet<AddressLocation> AddressLocation { get; set; }
        public virtual DbSet<CartItem> CartItem { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategoryProduct> CategoryProduct { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Currencies> Currencies { get; set; }
        public virtual DbSet<FieldDetails> FieldDetails { get; set; }
        public virtual DbSet<OrderCrossAction> OrderCrossAction { get; set; }
        public virtual DbSet<OrderPaymentHistory> OrderPaymentHistory { get; set; }
        public virtual DbSet<OrderProduct> OrderProduct { get; set; }
        public virtual DbSet<ProductAddressLocation> ProductAddressLocation { get; set; }
        public virtual DbSet<ProductFieldDetail> ProductFieldDetail { get; set; }
        public virtual DbSet<ProductPhotos> ProductPhotos { get; set; }
        public virtual DbSet<ProductRentDetail> ProductRentDetail { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<RentDetail> RentDetail { get; set; }
        public virtual DbSet<StatusMaster> StatusMaster { get; set; }
        public virtual DbSet<SubCategory> SubCategory { get; set; }
        public virtual DbSet<SubcategoryFieldDetails> SubcategoryFieldDetails { get; set; }
        public virtual DbSet<UserAddress> UserAddress { get; set; }
        public virtual DbSet<UserPaymentDetails> UserPaymentDetails { get; set; }
        public virtual DbSet<UserTransactionHistory> UserTransactionHistory { get; set; }
        public virtual DbSet<Users> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FieldMaster>(entity =>
            {
                entity.Property(e => e.IsUsed)
                .HasDefaultValue("False");
                entity.HasIndex(e => e.Name).IsUnique();
            });
            modelBuilder.Entity<AddressLocation>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PK__AddressL__E7FEA4979E439B0C");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ChangeTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Latitude).HasColumnType("decimal(10, 6)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(10, 6)");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.ToTable("Cart_Item");

                entity.Property(e => e.CartItemId).HasColumnName("Cart_Item_Id");

                entity.Property(e => e.ChangeTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartItem)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart_Item__Produ__6E01572D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CartItem)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart_Item__User___6EF57B66");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ChangeTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Picture).IsUnicode(false);
            });

            modelBuilder.Entity<CategoryProduct>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Category_Product");

                entity.Property(e => e.ChangeTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Category)
                    .WithMany()
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Category___Categ__45F365D3");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Category___Produ__46E78A0C");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("PK__Countrie__10D1609F4533608C");

                entity.HasIndex(e => e.CountryName)
                    .HasName("UQ__Countrie__E056F201C72AF32D")
                    .IsUnique();

                entity.Property(e => e.ChangeTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Currencies>(entity =>
            {
                entity.HasKey(e => e.CurrencyId)
                    .HasName("PK__Currenci__14470AF0E1665FDA");

                entity.Property(e => e.ChangeTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CurrencyName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<FieldDetails>(entity =>
            {
                entity.HasKey(e => e.FieldId)
                    .HasName("PK__MainFiel__C8B6FF07DEC1B886");

                entity.HasIndex(e => new { e.FieldId, e.FieldName })
                    .HasName("UC_MFM")
                    .IsUnique();

                entity.Property(e => e.ChangeTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FieldName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<OrderCrossAction>(entity =>
            {
                entity.HasKey(e => e.CrossActionId)
                    .HasName("PK__OrderCro__B4AA2F30FA655F98");

                entity.Property(e => e.ChangeTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.OrderRequestId).HasColumnName("OrderRequest_Id");

                entity.Property(e => e.Remarks).HasColumnType("text");

                entity.HasOne(d => d.OrderRequest)
                    .WithMany(p => p.OrderCrossAction)
                    .HasForeignKey(d => d.OrderRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderCros__Order__71D1E811");
            });

            modelBuilder.Entity<OrderPaymentHistory>(entity =>
            {
                entity.HasKey(e => e.PaymentHistoryId)
                    .HasName("PK__Order_Pa__121FFA4C81A32A95");

                entity.ToTable("Order_Payment_History");

                entity.Property(e => e.PaymentHistoryId).HasColumnName("Payment_History_Id");

                entity.Property(e => e.AddedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddedOn).HasColumnType("datetime");

                entity.Property(e => e.ChangeTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.ModeOfPayment).HasColumnName("Mode_Of_Payment");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.Property(e => e.PaidAmount)
                    .HasColumnName("Paid_Amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PaymentDate)
                    .HasColumnName("Payment_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaymentStatus).HasColumnName("Payment_Status");

                entity.Property(e => e.ReceiverId)
                    .IsRequired()
                    .HasColumnName("Receiver_Id")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SenderId)
                    .IsRequired()
                    .HasColumnName("Sender_Id")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderPaymentHistory)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order_Pay__Order__74AE54BC");
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.HasKey(e => e.OrderRequestId)
                    .HasName("PK__Order_Pr__C58BD035D476B6B6");

                entity.ToTable("Order_Product");

                entity.HasIndex(e => e.OrderCode)
                    .HasName("UQ__Order_Pr__999B5229D56B1291")
                    .IsUnique();

                entity.Property(e => e.ChangeTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.LateFees).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.OrderCode)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RentPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SecurityDepositAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderProduct)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order_Pro__Produ__6B24EA82");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderProduct)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order_Pro__UserI__6A30C649");
            });

            modelBuilder.Entity<ProductAddressLocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Product_AddressLocation");

                entity.Property(e => e.ChangeTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Location)
                    .WithMany()
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_A__Locat__5FB337D6");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_A__Produ__60A75C0F");
            });

            modelBuilder.Entity<ProductFieldDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Product_FieldDetail");

                entity.Property(e => e.ChangeTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FieldValue)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Field)
                    .WithMany()
                    .HasForeignKey(d => d.FieldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_F__Field__6383C8BA");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_F__Produ__628FA481");
            });

            modelBuilder.Entity<ProductPhotos>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Product_Photos");

                entity.Property(e => e.Alt)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Bit)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ChangeTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ThumbnailPath)
                    .HasColumnName("Thumbnail_Path")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_P__Produ__48CFD27E");
            });

            modelBuilder.Entity<ProductRentDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Product_RentDetail");

                entity.Property(e => e.ChangeTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_R__Produ__5AEE82B9");

                entity.HasOne(d => d.RentDetail)
                    .WithMany()
                    .HasForeignKey(d => d.RentDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_R__RentD__5BE2A6F2");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Products__B40CC6CD99238634");

                entity.Property(e => e.ChangeTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.FieldAuthor)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SoldBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RentDetail>(entity =>
            {
                entity.Property(e => e.ChangeTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LateFee).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.PurchasePrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.RentalPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SecurityDeposit).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.RentDetail)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RentDetai__Curre__59063A47");
            });

            modelBuilder.Entity<StatusMaster>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK__StatusMa__C8EE20630B64B23F");

                entity.HasIndex(e => e.StatusName)
                    .HasName("UQ__StatusMa__05E7698A8DF9FFF3")
                    .IsUnique();

                entity.Property(e => e.ChangeTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.Property(e => e.ChangeTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Discription).IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Picture).IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SubCategoryName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SubCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__SubCatego__Categ__3B75D760");
            });

            modelBuilder.Entity<SubcategoryFieldDetails>(entity =>
            {
                entity.HasKey(e => e.MainFieldSubcategoryId)
                    .HasName("PK__MainFiel__E9D68B459E1251A2");

                entity.ToTable("Subcategory_FieldDetails");

                entity.Property(e => e.ChangeTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.SubcategoryFieldDetails)
                    .HasForeignKey(d => d.FieldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MainField__Field__412EB0B6");

                entity.HasOne(d => d.Subcategory)
                    .WithMany(p => p.SubcategoryFieldDetails)
                    .HasForeignKey(d => d.SubcategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MainField__Subca__4222D4EF");
            });

            modelBuilder.Entity<UserAddress>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("PK__Address__091C2AFBC6900524");

                entity.ToTable("User_Address");

                entity.Property(e => e.ChangeTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CountryId).HasColumnName("Country_Id");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.HouseNumber)
                    .HasColumnName("House_Number")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Street)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.UserAddress)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Address__Country__5441852A");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAddress)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Address__User_Id__534D60F1");
            });

            modelBuilder.Entity<UserPaymentDetails>(entity =>
            {
                entity.HasKey(e => e.UserPaymentId)
                    .HasName("PK__User_Pay__635471198C5BB599");

                entity.ToTable("User_Payment_Details");

                entity.Property(e => e.UserPaymentId).HasColumnName("User_Payment_Id");

                entity.Property(e => e.AddedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddedOn).HasColumnType("datetime");

                entity.Property(e => e.Cc)
                    .IsRequired()
                    .HasColumnName("CC")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CcNum)
                    .IsRequired()
                    .HasColumnName("CC_Num")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ChangeTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.ExpireDate)
                    .IsRequired()
                    .HasColumnName("Expire_Date")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HolderName)
                    .IsRequired()
                    .HasColumnName("Holder_Name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPaymentDetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User_Paym__User___778AC167");
            });

            modelBuilder.Entity<UserTransactionHistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("User_Transaction_History");

                entity.Property(e => e.AddedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddedOn).HasColumnType("datetime");

                entity.Property(e => e.ChangeTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CC4C4DD4D745");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Users__A9D105340908DC10")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber)
                    .HasName("UQ__Users__85FB4E3839B069C1")
                    .IsUnique();

                entity.HasIndex(e => e.SsouserId)
                    .HasName("UQ__Users__1D872838C0DA67FC")
                    .IsUnique();

                entity.Property(e => e.ChangeTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SsouserId)
                    .IsRequired()
                    .HasColumnName("SSOUser_Id")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
