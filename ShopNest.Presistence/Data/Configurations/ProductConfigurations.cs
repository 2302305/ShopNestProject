
namespace ShopNest.Presistence.Data.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(200);
            builder.Property(p => p.Description)
                .HasMaxLength(500);
            builder.Property(p => p.PictureUrl)
             .HasMaxLength(200);
            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
            builder.HasOne(h => h.ProductBrand)
                .WithMany()
                .HasForeignKey(f => f.ProductBrandId);
            builder.HasOne(h => h.ProductType)
                .WithMany()
                .HasForeignKey(f => f.ProductTypeId);
        }
    }
}
