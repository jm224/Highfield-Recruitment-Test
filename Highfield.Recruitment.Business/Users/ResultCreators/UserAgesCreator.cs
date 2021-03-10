using System;
using System.Collections.Generic;
using System.Linq;
using Highfield.Recruitment.Business.Users.DataRetrieval;

namespace Highfield.Recruitment.Business.Users.ResultCreators
{
    internal class UserAgesCreator
    {
        public IReadOnlyList<UserAge> Create(IReadOnlyList<User> users)
        {
            DateTime today = DateTime.Today;

            return users
                .Select(u => CreateUserAgeData(u, today))
                .OrderBy(u => u.Name)
                .ToList();
        }

        private UserAge CreateUserAgeData(User user, DateTime today)
        {
            Int32? age = CalculateAge(user.Dob, today);
            Int32? agePlusTwenty = age == null ? null : age + 20;
            string dob = user.Dob?.ToString("dd/MM/yyyy") ?? "";

            return new UserAge {
                OriginalAge = age,
                AgePlusTwenty = agePlusTwenty,
                Name = FormatName(user.FirstName, user.LastName),
                Email = user.Email,
                Dob = dob,
            };
        }

        private string FormatName(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
                return "N/A";
            else if (string.IsNullOrEmpty(lastName))
                return firstName;

            string formattedName = lastName.ToUpperInvariant();

            if (firstName.Length != 0)
                formattedName += $", {firstName}";

            return formattedName;
        }

        private Int32? CalculateAge(DateTime? dob, DateTime today)
        {
            if (dob == null)
                return null;

            int age = today.Year - dob.Value.Year;

            if (dob > today.AddYears(-age))
                age--;

            return age;
        }
    }
}
