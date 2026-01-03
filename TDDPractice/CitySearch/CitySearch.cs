using static System.Formats.Asn1.AsnWriter;

namespace TDDPractice.CitySearch
{
    public class CitySearch
    {
        string[] cities = new string[]
        {
            "Paris",
            "Budapest",
            "Skopje",
            "Rotterdam",
            "Valencia",
            "Vancouver",
            "Amsterdam",
            "Vienna",
            "Sydney",
            "New York City",
            "London",
            "Bangkok",
            "Hong Kong",
            "Dubai",
            "Rome",
            "Istanbul"
        };


        public string[] Search(string input)
        {
            if (input == "*")
                return cities;

            if (input.Length >= 2)
            {
                return cities.Where(c => {
                    if (c.Length < input.Length)
                        return false;

                    return c.ToLower().Contains(input.ToLower());
                }).ToArray();
            }
            
            return Array.Empty<string>();
        }
    }
}
