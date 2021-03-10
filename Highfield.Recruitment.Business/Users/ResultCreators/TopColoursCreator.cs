using System.Collections.Generic;
using System.Linq;
using Highfield.Recruitment.Business.Users.DataRetrieval;

namespace Highfield.Recruitment.Business.Users.ResultCreators
{
    internal class TopColoursCreator
    {
        public IReadOnlyList<ColourCount> Create(IReadOnlyList<User> users)
        {
           return users
                .GroupBy(u => u.FavouriteColour ?? "No Favourite")
                .Select(CreateColourCount)
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.Colour)
                .ToList();
        }

        private ColourCount CreateColourCount(IGrouping<string, User> colourGroup)
        {
            return new ColourCount
            {
                Colour = colourGroup.Key,
                Count = colourGroup.Count(),
            };
        }
    }
}
