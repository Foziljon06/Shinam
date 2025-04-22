//===============================
// bu Faylda file header yaratdim
// negaligini hozircha bilmayaman
//===============================


using Moq;
using Shinam.Api.Brokers.Storages;
using Shinam.Api.Models.Foundation.Guests;
using Shinam.Api.Services.Foundations.Guests;
using Tynamix.ObjectFiller;

namespace Shinam.Api.Tests.Unit.Services.Foundations.Guests
{
    public partial class GuestServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly IGuestService guestService;

        public GuestServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();

            this.guestService = 
                new GuestService(storageBroker: this.storageBrokerMock.Object);
        }

        private static Guest CreateRandomGuest() =>
            CreateGuestFiller(date:GetRandomDateTimeOffset()).Create();

        private static DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

       private static Filler<Guest> CreateGuestFiller(DateTimeOffset date)
        {
            var filler = new Filler<Guest>();
            filler.Setup().
                OnType<DateTimeOffset>().Use(date);

            return filler;
        }


    }
}
