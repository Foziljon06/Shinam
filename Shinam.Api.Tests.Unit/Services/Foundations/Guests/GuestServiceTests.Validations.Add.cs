//===============================
// bu Faylda file header yaratdim
// negaligini hozircha bilmayaman
//===============================

using System.Linq.Expressions;
using Moq;
using Shinam.Api.Models.Foundation.Guests;
using Shinam.Api.Models.Foundation.Guests.Exceptions;
using Xunit.Sdk;

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
            //than
            await Assert.ThrowsAsync<GuestValidationException>(() => 
            AddGuestTask.AsTask());

            this.loggingBrokerMock.Verify(broker => 
            broker.LogError(It.Is(SameExceptionAs(expectedGuestValidationException))),
            Times.Once);

            this.storageBrokerMock.Verify(broker => broker.InsertGuestAsync(It.IsAny<Guest>()),
                Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
           
        }

     
    }
}
