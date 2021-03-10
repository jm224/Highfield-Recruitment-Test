using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Highfield.Recruitment.Business.Users.DataRetrieval
{
    internal class UserApi
    {
        public async Task<IReadOnlyList<User>> GetUsers()
        {
            IReadOnlyList<User> users = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://recruitment.highfieldqualifications.com/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await client.GetAsync("api/test");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                        };
                        return JsonSerializer.Deserialize<IReadOnlyList<User>>(responseBody, options);
                    }

                    return users;
                }
            }
            catch (Exception)
            {
                return users;
            }
        }
    }
}
