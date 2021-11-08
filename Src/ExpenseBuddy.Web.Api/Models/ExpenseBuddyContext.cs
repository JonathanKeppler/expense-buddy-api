using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ExpenseBuddy.Models
{
    public partial class ExpenseBuddyContext : DbContext
    {
        public ExpenseBuddyContext()
        {
        }

        public ExpenseBuddyContext(DbContextOptions<ExpenseBuddyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<ExpenseType> ExpenseTypes { get; set; }
        public virtual DbSet<ExpenseTypesTemp> ExpenseTypesTemps { get; set; }
        public virtual DbSet<ExpensesTemp> ExpensesTemps { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<PaymentTypesTemp> PaymentTypesTemps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=ExpenseBuddy;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ExDate).HasColumnType("date");

                entity.Property(e => e.ExItem)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExTypeId).HasColumnName("ExTypeID");

                entity.Property(e => e.ExpenseId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ExpenseID");

                entity.Property(e => e.IsGift).HasColumnName("isGift");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PayMethod)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExpenseType>(entity =>
            {
                entity.HasKey(e => new { e.ExType, e.SubType })
                    .HasName("PK_Type");

                entity.Property(e => e.ExType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExTypeId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ExTypeID");
            });

            modelBuilder.Entity<ExpenseTypesTemp>(entity =>
            {
                entity.ToTable("ExpenseTypesTemp");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.ExpenseSubTypeName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.ExpenseTypeName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExpensesTemp>(entity =>
            {
                entity.ToTable("ExpensesTemp");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.IsGift).HasColumnName("isGift");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasDefaultValueSql("(sysdatetimeoffset())");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.PayType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PayTypeId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PayTypeID");
            });

            modelBuilder.Entity<PaymentTypesTemp>(entity =>
            {
                entity.ToTable("PaymentTypesTemp");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.PaymentTypeName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
