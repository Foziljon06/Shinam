//===============================
// bu Faylda file header yaratdim
// negaligini hozircha bilmayaman
//===============================

using Shinam.Api.Brokers.Loggings;
using Shinam.Api.Brokers.Storages;
using Shinam.Api.Models.Foundation.Guests;
using Shinam.Api.Models.Foundation.Guests.Exceptions;

namespace Shinam.Api.Services.Foundations.Guests
{
    public partial class GuestService : IGuestService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public GuestService(
            IStorageBroker storageBroker, 
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        // Exception Noise Cancellation // Xatoliklarni shovqinini bartaraf etish
        public ValueTask<Guest> AddGuestAsync(Guest guest) =>
            TryCatch(async () =>
        {
            ValidateGuestNotNull(guest);

            return await this.storageBroker.InsertGuestAsync(guest);
        });
    }
}



//this.loggingBroker.LogError(new Exception("something"));
//this.storageBroker.InsertGuestAsync(guest);
//throw new NotImplementedException();