namespace TDDPractice.CitySearch
{
    // From https://tddmanifesto.com/exercises/

    [TestClass]
    public class CitySearch_Tests
    {
        CitySearch citySearch;

        [TestInitialize]
        public void CitySearch_Initialize()
        {
            citySearch = new CitySearch();
        }

        [TestMethod]
        public void CitySearch_Is_Not_Null()
        {
            Assert.IsNotNull(citySearch);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("a")]
        public void CitySearch_Returns_Empty_On_Less_Than_Two_Characters(string input)
        {
            var expected = Array.Empty<string>();
            CollectionAssert.AreEqual(expected, citySearch.Search(input));
        }

        [TestMethod]
        [DataRow("Paris", new string[] {"Paris"} )]
        [DataRow("Va", new string[] { "Valencia", "Vancouver" })]
        [DataRow("ko", new string[] { "Skopje", "Bangkok", "Hong Kong" })]
        [DataRow("*", new string[] 
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
            }
        )]
        public void CitySearch_Returns_Correct_Cities(string input, string[] expected)
        {
            CollectionAssert.AreEqual(expected, citySearch.Search(input));
        }

        [TestMethod]
        [DataRow("paris", new string[] { "Paris" })]
        [DataRow("va", new string[] { "Valencia", "Vancouver" })]
        [DataRow("PARIS", new string[] { "Paris" })]
        [DataRow("VA", new string[] { "Valencia", "Vancouver" })]
        public void CitySearch_Is_Case_Insensitive(string input, string[] expected)
        {
            CollectionAssert.AreEqual(expected, citySearch.Search(input));
        }
    }
}
