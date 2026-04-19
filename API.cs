using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static gymTracker.BodyPart;

namespace gymTracker
{
    internal class API
    {
        private static readonly HttpClient client = new HttpClient(); // create a single instance of HttpClient to be reused for all requests

        public static async Task<List<BodyPart.Result>> SearchExercises(string query)
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://gym-fit.p.rapidapi.com/v1/exercises/search?query={query}"),
                    Headers =
                {
            { "x-rapidapi-key", "3c35ee4e5bmshcb9b17740b05531p191de3jsnb18afbb43c64" },
            { "x-rapidapi-host", "gym-fit.p.rapidapi.com" },
                },
             };

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();

                    BodyPart.APIResponse apiResponse =
                    JsonConvert.DeserializeObject<BodyPart.APIResponse>(body); // this will deserialize the JSON response from the API into an instance of the APIResponse class, which contains a list of Result objects representing the exercises that match the search query - deserialize meaning to convert the JSON string into a C# object that can be easily manipulated and accessed in the code

                    return apiResponse?.results ?? new List<BodyPart.Result>(); // return the list of exercises from the API response, or an empty list if the response is null, the ? operator is used to check if the apiResponse object is null before trying to access its results property, and if it is null, it will return an empty list instead of throwing a NullReferenceException
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("API ERROR: " + ex.Message);
                return new List<BodyPart.Result>();
            }



        }
    }
}