using Microsoft.EntityFrameworkCore;
using MyClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyData
{
    public class MyDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder dbContext)
        {
            dbContext.UseSqlServer("Server=DESKTOP-V9IBQCE\\SQLEXPRESS;Database=Secere33;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false");
        }
        public DbSet<Tur> Turler { get; set; }
        public DbSet<Cins> Cinsler { get; set; }

        public DbSet<Hayvan> Hayvanlar { get; set; }
        public DbSet<Iliski> Iliskiler { get; set; }
        public DbSet<Asi> Asilar { get; set; }
        public DbSet<Bakim> Bakimlar { get; set; }
        public DbSet<User> User { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tablo adlarını ve şemalarını belirleyin
            modelBuilder.Entity<Tur>().ToTable("Turler", schema: "security");
            modelBuilder.Entity<Cins>().ToTable("Cinsler", schema: "security");
            modelBuilder.Entity<Hayvan>().ToTable("Hayvanlar", schema: "security");
            modelBuilder.Entity<Iliski>().ToTable("Iliskiler", schema: "security");
            modelBuilder.Entity<Asi>().ToTable("Asilar", schema: "security");
            modelBuilder.Entity<Bakim>().ToTable("Bakimlar", schema: "security");
            modelBuilder.Entity<User>().ToTable("User", schema: "security");

            // İlişkileri tanımlayın
            modelBuilder.Entity<Iliski>()
                .HasOne(i => i.Hayvan1)
                .WithMany()
                .HasForeignKey(i => i.Hayvan1Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Iliski>()
                .HasOne(i => i.Hayvan2)
                .WithMany()
                .HasForeignKey(i => i.Hayvan2Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tur>()
                .HasMany(t => t.Hayvanlar)
                .WithOne(h => h.Tur)
                .HasForeignKey(h => h.TurId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tur>()
                .HasMany(t => t.Cinsler)
                .WithOne(c => c.Tur)
                .HasForeignKey(c => c.TurId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cins>()
                .HasMany(c => c.Hayvanlar)
                .WithOne(h => h.Cins)
                .HasForeignKey(h => h.CinsId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Asi>()
                .HasOne(a => a.Hayvan)
                .WithMany(h => h.Asilar)
                .HasForeignKey(a => a.HayvanID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bakim>()
                .HasOne(b => b.Hayvan)
                .WithMany(h => h.Bakimlar)
                .HasForeignKey(b => b.HayvanID)
                .OnDelete(DeleteBehavior.Restrict);
        }




    }
}
