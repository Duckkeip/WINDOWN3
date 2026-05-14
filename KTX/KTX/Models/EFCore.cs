using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

namespace KTX.Models
{
    public class EFCore : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        public void ConfigureServices(IServiceCollection services)
            => services.AddDbContext<EFCore>();
        protected override void OnConfiguring(DbContextOptionsBuilder
        optionsBuilder)
        => optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Thiết lập quan hệ 1-n giữa Room và Contract
            modelBuilder.Entity<Room>()
                .HasMany(r => r.Contracts)
                .WithOne(c => c.Room)
                .HasForeignKey(c => c.RoomID);

            // Thiết lập quan hệ 1-n giữa Student và Contract
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Contracts)
                .WithOne(c => c.Student)
                .HasForeignKey(c => c.StudentID);

            modelBuilder.Entity<Student>()
            .Property(s => s.StudentID)
            .UseIdentityColumn(2154810000, 1);

            modelBuilder.Entity<Contract>()
            .Property(s => s.ContractID)
            .UseIdentityColumn(1000, 1);

            modelBuilder.Entity<Contract>()
           .Property(c => c.Price)
           .HasColumnType("decimal(18,2)");  // Đặt precision và scale tùy thuộc vào yêu cầu của bạn

            modelBuilder.Entity<Room>()
                .Property(r => r.Price)
                .HasColumnType("decimal(18,2)");  // Đặt precision và scale tùy thuộc vào yêu cầu của bạn

        }

        
    }
}
