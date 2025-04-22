//===============================
// bu Faylda file header yaratdim
// negaligini hozircha bilmayaman
//===============================

using Shinam.Api.Models.Foundation.Guests;

namespace Shinam.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Guest> InsertGuestAsync(Guest guest);
    }
}
