//===============================
// bu Faylda file header yaratdim
// negaligini hozircha bilmayaman
//===============================

namespace Shinam.Api.Brokers.Loggings
{
    public interface ILoggingBroker
    {
        void LogError(Exception exeption);
        void LogCritical(Exception exception);
    }
}
