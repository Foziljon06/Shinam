
//===============================
// bu Faylda file header yaratdim
// negaligini hozircha bilmayaman
//===============================

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shinam.Api.Models.Foundation.Guests;

namespace Shinam.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Guest> Guests { get; set; }
        public async ValueTask<Guest> InserGuestAsync(Guest guest)
        {
            using var broker = new StorageBroker(this.configuration);
           
             EntityEntry<Guest> guestEntityEntry =
                await broker.Guests.AddAsync(guest);

            await broker.SaveChangesAsync();

            return guestEntityEntry.Entity;

        }
    }
    
}

// ushbu faylda this.configuration hatolik berdi.
// lekin videoda hatolik bermagan bu versiya hatoligi bo`lioshi
// mumkin deb AI dan codni hatoligini ketkazdi8m