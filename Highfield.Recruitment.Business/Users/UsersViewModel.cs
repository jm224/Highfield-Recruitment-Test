using System.Collections.Generic;
using Highfield.Recruitment.Business.Users.ResultCreators;

namespace Highfield.Recruitment.Business.Users
{
    public class UsersViewModel
    {
        public IReadOnlyList<ColourCount> TopColours { get; set; }
        public IReadOnlyList<UserAge> UserAges { get; set; }
    }
}
