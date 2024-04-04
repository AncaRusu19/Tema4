using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DataLayer
{
    // dotnet ef migrations add Initial
    // dotnet ef database update

    public class MyDbContext : DbContext
    {
        private readonly string _windowsConnectionString = @"Server=.\SQLExpress;Database=Lab5Database1;Trusted_Connection=True;TrustServerCertificate=true";
        //private readonly string _windowsConnectionString = @"Server=localhost\SQLEXPRESS;Database=Lab5Database1;Trusted_Connection=True;TrustServerCertificate=True;";

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Vinyl> Vinyl { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Producer> Producer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_windowsConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasOne(f => f.Type)
                .WithMany(c => c.Users)
                .HasForeignKey(f => f.TypeId);
            // Relația one-to-one între Vinyl și Author
            builder.Entity<Vinyl>()
                .HasOne(v => v.Author)
                .WithOne(a => a.Vinyl)
                .HasForeignKey<Vinyl>(v => v.AuthorId);

            // Relația one-to-many între Vinyl și Track
            builder.Entity<Vinyl>()
                .HasMany(v => v.Tracks) 
                .WithOne(t => t.Vinyl)
                .HasForeignKey(t => t.VinylId);
            //Relatia many to many intre Author si Producer
            builder.Entity<Author>()
                .HasMany(a => a.Producers)
                .WithMany(p => p.Authors)
                .UsingEntity<Dictionary<string, object>>(
                    "AuthorProducer",
                    j => j.HasOne<Producer>().WithMany().HasForeignKey("ProducerId"),
                    j => j.HasOne<Author>().WithMany().HasForeignKey("AuthorId"),
                    j =>
                    {
                        j.HasKey("AuthorId", "ProducerId");
                        j.ToTable("AuthorProducer");
                    }
                );

            builder.Entity<Vinyl>().HasData(new Vinyl[0]);
            builder.Entity<Author>().HasData(new Author[0]);
            builder.Entity<Track>().HasData(new Track[0]);
            builder.Entity<Producer>().HasData(new Producer[0]);

            Vinyl[] vinyl =
            {
                new Vinyl("Blood on the dance floor", 30, "Blood on the dance floor"),
                new Vinyl("Freak of nature", 25, "I'm outta love"),
                new Vinyl("Believe", 40, "Strong enough")
                
            };
            builder.Entity<Vinyl>().HasData(vinyl);

            Author[] author =
           {
                new Author("Michael Jackson"),
                new Author("Anastacia"),
                new Author("Cher")

            };
            builder.Entity<Author>().HasData(author);

            Producer[] producer =
           {
                new Producer("Quincy Jones"),
                new Producer("Glen Ballard"),
                new Producer("Alexander Edwards")

            };
            builder.Entity<Producer>().HasData(producer);

            Track[] track =
          {
                new Track("Morphine"),
                new Track("Paid my dues"),
                new Track("Believe")

            };
            builder.Entity<Track>().HasData(track);


        }
    }
}
