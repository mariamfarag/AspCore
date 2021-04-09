using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GradProject3.Models
{
    public partial class ProductsContext : DbContext
    {
        public ProductsContext()
        {
        }

        public ProductsContext(DbContextOptions<ProductsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Good> Goods { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Register> Registers { get; set; }
        public virtual DbSet<TypeGood> TypeGoods { get; set; }
        public virtual DbSet<TypeRegister> TypeRegisters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=.;Database=Products;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DatePayment).HasColumnType("date");

                entity.Property(e => e.Idgoods).HasColumnName("IDGoods");

                entity.Property(e => e.Idtrade).HasColumnName("IDTrade");

                entity.Property(e => e.PriceForPic).HasColumnType("money");

                entity.HasOne(d => d.IdgoodsNavigation)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.Idgoods)
                    .HasConstraintName("FK_Goods");

                entity.HasOne(d => d.IdtradeNavigation)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.Idtrade)
                    .HasConstraintName("FK_IDTRADE");
            });

            modelBuilder.Entity<Good>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ExpireDate)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Expire_Date");

                entity.Property(e => e.Idoffers).HasColumnName("IDOffers");

                entity.Property(e => e.Idtg).HasColumnName("IDTG");

                entity.Property(e => e.Images)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("images");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.HasOne(d => d.IdoffersNavigation)
                    .WithMany(p => p.Goods)
                    .HasForeignKey(d => d.Idoffers)
                    .HasConstraintName("FK_IDOffers");

                entity.HasOne(d => d.IdtgNavigation)
                    .WithMany(p => p.Goods)
                    .HasForeignKey(d => d.Idtg)
                    .HasConstraintName("FK_IDTYPE");
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdtyG).HasColumnName("IDTyG");

                entity.Property(e => e.Offer1).HasColumnName("Offer");

                entity.Property(e => e.Size)
                    .HasMaxLength(100)
                    .HasColumnName("size");

                entity.HasOne(d => d.IdtyGNavigation)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.IdtyG)
                    .HasConstraintName("FK_IDTYG");
            });

            modelBuilder.Entity<Register>(entity =>
            {
                entity.ToTable("Register");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(80);

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("FName");

                entity.Property(e => e.IdtyReg).HasColumnName("IDTyReg");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("LName");

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(100);

                entity.Property(e => e.ShopeName).HasMaxLength(80);

                entity.HasOne(d => d.IdtyRegNavigation)
                    .WithMany(p => p.Registers)
                    .HasForeignKey(d => d.IdtyReg)
                    .HasConstraintName("FK_IDTPEREG");
            });

            modelBuilder.Entity<TypeGood>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(90);
            });

            modelBuilder.Entity<TypeRegister>(entity =>
            {
                entity.ToTable("TypeRegister");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
