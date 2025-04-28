<<<<<<< HEAD
﻿using Microsoft.EntityFrameworkCore;
=======
﻿//===============================
// bu Faylda file header yaratdim
// negaligini hozircha bilmayaman
//===============================


using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
>>>>>>> main
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shinam.Api.Models.Foundation.Guests;

namespace Shinam.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
 

        public DbSet<Guest> Guests { get; set; }
<<<<<<< HEAD

        public async ValueTask<Guest> InsertGuestAsync(Guest guest)
        {
            using var broker = new StorageBroker(this.configuration);
            EntityEntry<Guest> guestEntityEntity = await broker.Guests.AddAsync(guest);
            await broker.SaveChangesAsync();

            return guestEntityEntity.Entity;
=======
        public async ValueTask<Guest> InserGuestAsync(Guest guest)
        {
            using var broker = new StorageBroker(this.configuration);
           
             EntityEntry<Guest> guestEntityEntry =
                await broker.Guests.AddAsync(guest);

            await broker.SaveChangesAsync();


            return guestEntityEntry.Entity;
>>>>>>> main
        }
    }
    
}

// ushbu faylda this.configuration hatolik berdi.
// lekin videoda hatolik bermagan bu versiya hatoligi bo`lioshi
// mumkin deb AI dan codni hatoligini ketkazdi8m