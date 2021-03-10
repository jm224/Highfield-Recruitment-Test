using System.Collections.Generic;
using System.Threading.Tasks;
using Highfield.Recruitment.Business.Users.DataRetrieval;
using Highfield.Recruitment.Business.Users.ResultCreators;

namespace Highfield.Recruitment.Business.Users
{
    public class UserProvider
    {
        private readonly UserApi userApi;

        public UserProvider()
        {
            this.userApi = new UserApi();
        }
            
        public UsersViewModel GetUserData()
        {
            Task<IReadOnlyList<User>> users = this.userApi.GetUsers();

            users.Wait();

            IReadOnlyList<ColourCount> topColours = GetTopColours(users.Result);
            IReadOnlyList<UserAge> userAges = GetUserAges(users.Result);

            return new UsersViewModel
            {
                TopColours = topColours,
                UserAges = userAges,
            };
        }

        private IReadOnlyList<ColourCount> GetTopColours(IReadOnlyList<User> users)
        {
            var topColoursCreator = new TopColoursCreator();
            return topColoursCreator.Create(users);
        }

        private IReadOnlyList<UserAge> GetUserAges(IReadOnlyList<User> users)
        {
            var userAgesCreator = new UserAgesCreator();
            return userAgesCreator.Create(users);
        }
    }
}
