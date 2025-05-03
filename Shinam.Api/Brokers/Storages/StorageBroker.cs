//===============================
// bu Faylda file header yaratdim
// negaligini hozircha bilmayaman
//===============================

using EFxceptions;
using Microsoft.EntityFrameworkCore;
using Shinam.Api.Models.Foundation.Guests;


namespace Shinam.Api.Brokers.Storages
{
    public partial class StorageBroker : EFxceptionsContext,IStorageBroker
    {
        private readonly IConfiguration configuration;
        public StorageBroker(IConfiguration configuration) 

        {
            this.configuration = configuration;
            this.Database.Migrate();
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string connectionString =
                this.configuration.GetConnectionString(name: "DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

        }

        public override void Dispose()
        {
            base.Dispose(); // Asosiy Dispose metodini chaqirish
        }

        public ValueTask<Guest> InsertGuestAsync(Guest guest)
        {
            throw new NotImplementedException();
        }

        //internal void InsertGuestAsync(Guest guest)
        //{
        //    throw new NotImplementedException();
        //}
    }

    // Design-time uchun DbContext yaratish

    //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<StorageBroker>
    //{
    //    public StorageBroker CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<StorageBroker>();
    //        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ShinamCoreDb;Trusted_Connection=True;MultipleActiveResultSets=True");

    //        return new StorageBroker();
    //    }
    //}
}