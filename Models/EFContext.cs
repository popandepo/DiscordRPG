using Microsoft.EntityFrameworkCore;

namespace DiscordRPG.Models
{
    public class EFContext : DbContext
    {

        private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=EFCore;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<PlayerModel> Players { get; set; }
        //public DbSet<ItemModel> Items { get; set; }
        //public DbSet<SkillModel> Skills { get; set; }
        //public DbSet<EquipmentModel> Equipment { get; set; }
        //public DbSet<MaterialModel> Materials { get; set; }

    }
}
