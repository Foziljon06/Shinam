//===============================
// bu Faylda file header yaratdim
// negaligini hozircha bilmayaman
//===============================

using Shinam.Api.Models.Foundation.Guests;
using Shinam.Api.Models.Foundation.Guests.Exceptions;

namespace Shinam.Api.Tests.Unit.Services.Foundations.Guests
{
    public partial class GuestServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfGuestIsNullAndLogItAsync()
        {
            // given 
            Guest nullGuest = null;
            var nullGuestException = new NullGuestException();

            var expectedGuestValidationException = 
                new GuestValidationException(nullGuestException);

            // when

            ValueTask<Guest> AddGuestTask =
                 this.guestService.AddGuestAsync(nullGuest);
            await Assert.ThrowsAsync<GuestValidationException>(() => AddGuestTask.AsTask());

            //than
        }
    }
}
