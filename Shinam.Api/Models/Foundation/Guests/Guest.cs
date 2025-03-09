﻿//===============================
// bu Faylda file header yaratdim
// negaligini hozircha bilmayaman
//===============================



namespace Shinam.Api.Models.Foundation.Guests
{
    public class Guest
    {
        public Guid id { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public GenderType Gender {  get; set; }

    }
}
