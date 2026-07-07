namespace ShopNest.Presistence.Data.Configurations
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
