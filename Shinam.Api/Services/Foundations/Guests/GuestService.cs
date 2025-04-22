//===============================
// bu Faylda file header yaratdim
// negaligini hozircha bilmayaman
//===============================
using System.Threading.Tasks;
using Shinam.Api.Brokers.Storages;
using Shinam.Api.Models.Foundation.Guests;

namespace Shinam.Api.Services.Foundations.Guests
{
    public class GuestService : IGuestService
    {
        private readonly IStorageBroker storageBroker;

        public GuestService(IStorageBroker storageBroker) => 
            this.storageBroker = storageBroker;

        public ValueTask<Guest> AddGuestAsync(Guest guest) =>

            this.storageBroker.InsertGuestAsync(guest);
            //throw new NotImplementedException();
            
        
    }
}
