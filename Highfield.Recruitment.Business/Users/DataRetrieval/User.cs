using System;

namespace Highfield.Recruitment.Business.Users.DataRetrieval
{
    internal class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? Dob { get; set; }
        public string FavouriteColour { get; set; }
    }
}
