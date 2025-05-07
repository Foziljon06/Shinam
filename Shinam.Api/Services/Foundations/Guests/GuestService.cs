//===============================
// bu Faylda file header yaratdim
// negaligini hozircha bilmayaman
//===============================
using System.Threading.Tasks;
using Shinam.Api.Brokers.Loggings;
using Shinam.Api.Brokers.Storages;
using Shinam.Api.Models.Foundation.Guests;
using Shinam.Api.Models.Foundation.Guests.Exceptions;

namespace Shinam.Api.Services.Foundations.Guests
{
    public class GuestService : IGuestService
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

        public async ValueTask<Guest> AddGuestAsync(Guest guest)
        {
            try
            {
                if (guest is null)
                {
                    throw new NullGuestException();
                }

                return await this.storageBroker.InsertGuestAsync(guest);
            }
            catch (NullGuestException nullguestException)
            {
                var guestValidationException = new GuestValidationException(nullguestException);

                this.loggingBroker.LogError(guestValidationException);

                throw guestValidationException;
            }

            //this.loggingBroker.LogError(new Exception("something"));
            //this.storageBroker.InsertGuestAsync(guest);
            //throw new NotImplementedException();

        }




    }
}
