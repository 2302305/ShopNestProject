namespace ShopNest.Presistence.Data.Configurations.ProductConfigurations
{
    internal class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(200);
        }
    }
}
