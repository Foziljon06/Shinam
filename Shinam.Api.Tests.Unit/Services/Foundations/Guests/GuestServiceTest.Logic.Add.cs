
using FluentAssertions;
using Moq;
using Shinam.Api.Models.Foundation.Guests;

namespace Shinam.Api.Tests.Unit.Services.Foundations.Guests
{
    public partial class GuestServiceTests
    {  
    
        [Fact]
        public async Task ShouldAddGuestAsync()
        {
            // given 
            Guest randomGuest = CreateRandomGuest();
            Guest inputGuest = randomGuest;
            Guest returningGuest = inputGuest;
            Guest expectedGuest = returningGuest;

            this.storageBrokerMock.Setup(broker =>
            broker.InsertGuestAsync(inputGuest)).ReturnsAsync(returningGuest);

            // when
            Guest actualgGuest =
                await this.guestService.AddGuestAsync(inputGuest);

            // then
            actualgGuest.Should().BeEquivalentTo(expectedGuest);

            this.storageBrokerMock.Verify(broker =>
            broker.InsertGuestAsync(inputGuest),
            Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}



