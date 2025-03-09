//===============================
// bu Faylda file header yaratdim
// negaligini hozircha bilmayaman
//===============================


using EFxceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Shinam.Api.Brokers.Storages
{
    public partial class StorageBroker : EFxceptionsContext
    {
        // IConfiguration ga bog'liq bo'lmaslik uchun konstruktorni olib tashlaymiz
        public StorageBroker() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // To'g'ridan-to'g'ri connection string ni o'rnatamiz
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ShinamCoreDb;Trusted_Connection=True;MultipleActiveResultSets=True");
            }
        }

        public override void Dispose()
        {
            base.Dispose(); // Asosiy Dispose metodini chaqirish
        }
    }

    // Design-time uchun DbContext yaratish
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<StorageBroker>
    {
        public StorageBroker CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StorageBroker>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ShinamCoreDb;Trusted_Connection=True;MultipleActiveResultSets=True");

            return new StorageBroker();
        }
    }
}