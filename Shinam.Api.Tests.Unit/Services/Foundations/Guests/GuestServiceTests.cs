﻿//===============================
// bu Faylda file header yaratdim
// negaligini hozircha bilmayaman
//===============================


using System.Linq.Expressions;
using Moq;
using Shinam.Api.Brokers.Loggings;
using Shinam.Api.Brokers.Storages;
using Shinam.Api.Models.Foundation.Guests;
using Shinam.Api.Services.Foundations.Guests;
using Tynamix.ObjectFiller;
using Xeptions;

namespace Shinam.Api.Tests.Unit.Services.Foundations.Guests
{
    public partial class GuestServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IGuestService guestService;

        public GuestServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.guestService =
                new GuestService(
                    storageBroker: this.storageBrokerMock.Object,
                    loggingBroker: this.loggingBrokerMock.Object);
        }

        private static Guest CreateRandomGuest() =>
            CreateGuestFiller(date:GetRandomDateTimeOffset()).Create();

        private static DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private Expression<Func<Xeption,bool>> SameExceptionAs(Xeption expectedException)
        {
            return actualException => actualException.Message == expectedException.Message
                && actualException.InnerException.Message == expectedException.InnerException.Message
                && (actualException.InnerException as Xeption).DataEquals(expectedException.Data);
        }


       private static Filler<Guest> CreateGuestFiller(DateTimeOffset date)
        {
            var filler = new Filler<Guest>();
            filler.Setup().
                OnType<DateTimeOffset>().Use(date);

            return filler;
        }


    }
}
