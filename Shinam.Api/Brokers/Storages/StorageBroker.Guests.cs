using Microsoft.EntityFrameworkCore;
using Shinam.Api.Models.Foundation.Guests;

namespace Shinam.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Guest> Guests { get; set; }
    }
}
