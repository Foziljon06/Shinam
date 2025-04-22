//===============================
// bu Faylda file header yaratdim
// negaligini hozircha bilmayaman
//===============================
using LanguageExt;
using Xeptions;
namespace Shinam.Api.Models.Foundation.Guests.Exceptions
{
    public class GuestValidationException:Xeption
    {
        public GuestValidationException(Xeption innerExceptions) 
        :base(message:"Guest validation error occured, fix errors and try again",
             innerExceptions)
        { }
    }
}
