//===============================
// bu Faylda file header yaratdim
// negaligini hozircha bilmayaman
//===============================
using Shinam.Api.Models.Foundation.Guests;
using Shinam.Api.Models.Foundation.Guests.Exceptions;

namespace Shinam.Api.Services.Foundations.Guests
{
    public partial class GuestService
    {
        private void ValidateGuestNotNull(Guest guest)
        {
            if (guest is null)
            {
                throw new NullGuestException();
            }
        }
    }
}
