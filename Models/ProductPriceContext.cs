using Microsoft.EntityFrameworkCore;

namespace Product_Prices.Models;

public partial class ProductPriceContext : DbContext
{
    public ProductPriceContext()
    {
    }

    public ProductPriceContext(DbContextOptions<ProductPriceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ProductPrice> ProductPrices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-01LQ3IF\\MSSQLSERVER01;Database=Product-Price;User Id=sa;Password=arbisoft;Trusted_Connection=false;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductPrice>(entity =>
        {
            entity.ToTable("ProductPrice");

            entity.Property(e => e.Prices).HasColumnType("decimal(18, 3)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
