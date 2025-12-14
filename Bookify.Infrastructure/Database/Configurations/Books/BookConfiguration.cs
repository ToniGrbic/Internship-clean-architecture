using Bookify.Domain.Entities.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookify.Infrastructure.Database.Configurations.Books
{
    internal sealed class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("books");

            builder.HasKey(b => b.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Title)
                .HasColumnName("title")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Author)
                .HasColumnName("author")
                .HasMaxLength(100);

            builder.Property(x => x.ISBN)
                .HasColumnName("isbn")
                .HasMaxLength(20);

            builder.Property(x => x.PublishedDate)
                .HasColumnName("published_date");

            builder.Property(x => x.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            // Configure the relationship
            builder.HasOne(b => b.User)
                .WithMany(u => u.Books)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
