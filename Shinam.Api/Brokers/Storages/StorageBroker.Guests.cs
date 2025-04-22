using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shinam.Api.Models.Foundation.Guests;

namespace Shinam.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Guest> Guests { get; set; }

        public async ValueTask<Guest> InsertGuestAsync(Guest guest)
        {
            using var broker = new StorageBroker(this.configuration);
            EntityEntry<Guest> guestEntityEntity = await broker.Guests.AddAsync(guest);
            await broker.SaveChangesAsync();

            return guestEntityEntity.Entity;
        }
    }
    
}
