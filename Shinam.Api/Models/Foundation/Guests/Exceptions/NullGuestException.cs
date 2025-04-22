//===============================
// bu Faylda file header yaratdim
// negaligini hozircha bilmayaman
//===============================




using Xeptions;
namespace Shinam.Api.Models.Foundation.Guests.Exceptions
{
    public class NullGuestException : Xeption
    {
        public NullGuestException()
            : base(message: "Guest is Null")
        { }
    }
}