namespace TDDPractice.FizzBuzz
{
    [TestClass]
    public class FizzBuzz_Tests
    {
        private FizzBuzz fizzBuzz = null;

        [TestInitialize]
        public void FizzBuzz_Initialize()
        {
            fizzBuzz = new FizzBuzz();
        }

        [TestMethod]
        public void FizzBuss_Is_Not_Empty()
        {
            Assert.IsNotNull(fizzBuzz);
        }

        [TestMethod]
        [DataRow(1, "1")]
        [DataRow(2, "2")]
        [DataRow(3, "Fizz")]
        [DataRow(6, "Fizz")]
        [DataRow(5, "Buzz")]
        [DataRow(10, "Buzz")]
        [DataRow(15, "FizzBuzz")]
        [DataRow(30, "FizzBuzz")]
        public void FizzBuzz_Returns_Expected_Result(int input, string expected)
        {
            var actual = fizzBuzz.Check(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
