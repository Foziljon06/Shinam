//===============================
// bu Faylda file header yaratdim
// negaligini hozircha bilmayaman
//===============================



using Shinam.Api.Models.Foundation.Guests;

namespace Shinam.Api.Brokers
{
    public partial interface IstorageBroker
    {
        ValueTask<Guest> InserGuestAsync(Guest guest);

    }
}
