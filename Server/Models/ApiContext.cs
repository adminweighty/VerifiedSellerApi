using Microsoft.EntityFrameworkCore;
using VerifiedSeller.Shared.Entities.Database;

namespace VerifiedSeller.Server.Models
{
    public partial class ApiContext : DbContext
    {
        public ApiContext()
        {
        }
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Buyers>? Buyers { get; set; }
        public virtual DbSet<Currencies>? Currencies { get; set; }
        public virtual DbSet<Categories>? Categories { get; set; }
        public virtual DbSet<MobileRegisteredUsers>? MobileRegisteredUsers { get; set; }
        public virtual DbSet<SellerUsers>? SellersUsers { get; set; }
        public virtual DbSet<Products>? Products { get; set; }
        public virtual DbSet<SystemUsers>? SystemUsers { get; set; }
        public virtual DbSet<UserRoles>? UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyers>(entity =>
            {
                entity.HasKey("Id");
                entity.Property(e => e.BuyerType)
                     .HasMaxLength(255)
                     .IsUnicode(false);
                entity.Property(e => e.status);
             });
            modelBuilder.Entity<Currencies>(entity =>
            {
                entity.HasKey("Id");
                entity.Property(e => e.Name)
                         .HasMaxLength(255)
                         .IsUnicode(false);
                entity.Property(e => e.Code)
                     .HasMaxLength(255)
                     .IsUnicode(false);
                entity.Property(e => e.Symbol)
                     .HasMaxLength(255)
                     .IsUnicode(false);
                entity.Property(e => e.status);
            });
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey("Id");
                entity.Property(e => e.CategoryName)
                     .HasMaxLength(255)
                     .IsUnicode(false);
                entity.Property(e => e.status);
            });
            modelBuilder.Entity<SellerUsers>(entity =>
            {
                entity.HasKey("Id");
                 entity.Property(e => e.PasswordHash)
                         .HasMaxLength(255)
                         .IsUnicode(false);
                entity.Property(e => e.PasswordSalt)
                         .HasMaxLength(255)
                         .IsUnicode(false);
                entity.Property(e => e.ActiveCode)
                         .HasMaxLength(255)
                         .IsUnicode(false);
                entity.Property(e => e.RoleId);
                entity.Property(e => e.DateCreated);
                entity.Property(e => e.DateModified);
                entity.Property(e => e.IsLocked);
                entity.Property(e => e.PhoneNumber)
                         .HasMaxLength(255)
                         .IsUnicode(false);
                entity.Property(e => e.Email)
                         .HasMaxLength(255)
                         .IsUnicode(false);
                entity.Property(e => e.LockCount);
                entity.Property(e => e.FirstName)
                         .HasMaxLength(255)
                         .IsUnicode(false);
                entity.Property(e => e.LastName)
                         .HasMaxLength(255)
                         .IsUnicode(false);
                entity.Property(e => e.CompanyName)
                         .HasMaxLength(255)
                         .IsUnicode(false);
                entity.Property(e => e.Street)
                         .HasMaxLength(255)
                         .IsUnicode(false);
                entity.Property(e => e.City)
                     .HasMaxLength(255)
                     .IsUnicode(false);
                entity.Property(e => e.Country)
                     .HasMaxLength(255)
                     .IsUnicode(false);
                entity.Property(e => e.ZipCode)
                     .HasMaxLength(255)
                     .IsUnicode(false);
                entity.Property(e => e.SpecialityArea)
                     .HasMaxLength(255)
                     .IsUnicode(false);
                entity.Property(e => e.status);
            });
            modelBuilder.Entity<MobileRegisteredUsers>(entity =>
            {
                entity.HasKey("Id");
                entity.Property(e => e.BuyerId);
                entity.Property(e => e.PasswordHash)
                         .HasMaxLength(255)
                         .IsUnicode(false);
                entity.Property(e => e.PasswordSalt)
                         .HasMaxLength(255)
                         .IsUnicode(false);
                entity.Property(e => e.ActiveCode)
                         .HasMaxLength(255)
                         .IsUnicode(false);
                entity.Property(e => e.RoleId);
                entity.Property(e => e.DateCreated);
                entity.Property(e => e.DateModified);
                entity.Property(e => e.IsLocked);
                entity.Property(e => e.PhoneNumber)
                         .HasMaxLength(255)
                         .IsUnicode(false);
                entity.Property(e => e.Email)
                         .HasMaxLength(255)
                         .IsUnicode(false);
                entity.Property(e => e.LockCount);
                entity.Property(e => e.Platform)
                         .HasMaxLength(255)
                         .IsUnicode(false);
                entity.Property(e => e.status);
            });
            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey("productId");
                entity.Property(e => e.productName);
                entity.Property(e => e.productCode);
                entity.Property(e => e.productCurrency);
                entity.Property(e => e.productPrice);
                entity.Property(e => e.productRetailPrice);
                entity.Property(e => e.productPriceDescription);
                entity.Property(e => e.productDiscount);
                entity.Property(e => e.productBrand);
                entity.Property(e => e.productLastUpdated);
                entity.Property(e => e.productManufacturerDate);
                entity.Property(e => e.productExpiryDate);
                entity.Property(e => e.productBarCode)
                         .HasMaxLength(255)
                         .IsUnicode(false);
                entity.Property(e => e.productUnit)
                     .HasMaxLength(255)
                     .IsUnicode(false);
                entity.Property(e => e.productWeight);
                entity.Property(e => e.productHeight);
                entity.Property(e => e.productHeightUnit);
                entity.Property(e => e.productQuantity);
                entity.Property(e => e.productColor)
                         .HasMaxLength(255)
                         .IsUnicode(false);
                entity.Property(e => e.sellerId);
                entity.Property(e => e.categoryId);
                entity.Property(e => e.featureImageUrl)
                             .HasMaxLength(255)
                             .IsUnicode(false);
                entity.Property(e => e.featureImageUrl_1)
                             .HasMaxLength(255)
                             .IsUnicode(false);
                entity.Property(e => e.featureImageUrl_2)
                             .HasMaxLength(255)
                             .IsUnicode(false);
                entity.Property(e => e.featureImageUrl_3)
                             .HasMaxLength(255)
                             .IsUnicode(false);
                entity.Property(e => e.featureImageUrl_4)
                                 .HasMaxLength(255)
                                 .IsUnicode(false);
                entity.Property(e => e.featureImageUrl_5)
                             .HasMaxLength(255)
                             .IsUnicode(false);
                entity.Property(e => e.status);
            });
            modelBuilder.Entity<SystemUsers>(entity =>
            {
                entity.HasKey("Id");
                entity.Property(e => e.UserId)
                         .HasMaxLength(255)
                         .IsUnicode(false);
                entity.Property(e => e.PasswordHash)
                         .HasMaxLength(255)
                         .IsUnicode(false);
                entity.Property(e => e.PasswordSalt)
                       .HasMaxLength(255)
                       .IsUnicode(false);
                entity.Property(e => e.ActiveCode)
                       .HasMaxLength(255)
                       .IsUnicode(false);
                entity.Property(e => e.RoleId);
                entity.Property(e => e.DateCreated);
                entity.Property(e => e.DateModified);
                entity.Property(e => e.IsLocked);
                entity.Property(e => e.Username)
                           .HasMaxLength(255)
                           .IsUnicode(false);
                entity.Property(e => e.Email)
                       .HasMaxLength(255)
                       .IsUnicode(false);
                entity.Property(e => e.LockCount);
                entity.Property(e => e.status);
            });
            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.HasKey("Id");
                entity.Property(e => e.RoleName)
                     .HasMaxLength(255)
                     .IsUnicode(false);
                entity.Property(e => e.CreatedBy)
             .HasMaxLength(255)
             .IsUnicode(false);
                entity.Property(e => e.ModifiedBy)
             .HasMaxLength(255)
             .IsUnicode(false);
                entity.Property(e => e.DateCreated);
                entity.Property(e => e.DateModified);
                entity.Property(e => e.status);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
