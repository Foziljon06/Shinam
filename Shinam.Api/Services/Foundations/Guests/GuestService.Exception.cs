//===============================
// bu Faylda file header yaratdim
// negaligini hozircha bilmayaman
//===============================

using Shinam.Api.Models.Foundation.Guests;
using Shinam.Api.Models.Foundation.Guests.Exceptions;
using Xeptions;

namespace Shinam.Api.Services.Foundations.Guests
{
    public partial class GuestService
    {
        // Guest qaytaradigan funksiyaning Delegatini yaratamiz

        private delegate ValueTask<Guest> ReturningGuestFunction();
        private async ValueTask<Guest> TryCatch(ReturningGuestFunction returningGuestFunction)
        {
            try
            {
                return await returningGuestFunction();
            }
            catch (NullGuestException nullguestException)
            {


                throw CreateAndLogValidationException(nullguestException);
            }
        }

        private GuestValidationException CreateAndLogValidationException( Xeption exception)
        {
            var guestValidationException =
                new GuestValidationException(exception);

            this.loggingBroker.LogError(guestValidationException);
            return guestValidationException;
        }

    }
}
