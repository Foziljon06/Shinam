//===============================
// bu Faylda file header yaratdim
// negaligini hozircha bilmayaman
//===============================

using System.Threading.Tasks;
using Shinam.Api.Models.Foundation.Guests;

namespace Shinam.Api.Services.Foundations.Guests
{
    public interface IGuestService
    {
        ValueTask<Guest> AddGuestAsync(Guest guest);
    }
}
