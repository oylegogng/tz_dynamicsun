using Microsoft.EntityFrameworkCore;

namespace tz
{
    public class WeatherDbContext : DbContext
    {
        public DbSet<WeatherData> WeatherData { get; set; }

        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Настройка подключения к базе данных
            optionsBuilder.UseSqlServer("Server = LAPTOP-FU2ARVTC\\SQLEXPRESS02;User= oleg; Password = 123; Database = WeatherDatabase; TrustServerCertificate=True; "); 
            
        }
    }

}
