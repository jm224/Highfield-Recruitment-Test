using System;

namespace Highfield.Recruitment.Business.Users.ResultCreators
{
    public class UserAge
    {
        public Int32? OriginalAge { get; set; }
        public Int32? AgePlusTwenty { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Dob { get; set; }
    }
}
