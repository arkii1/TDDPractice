namespace TDDPractice.StringCalculator
{
    // From https://tddmanifesto.com/exercises/

    [TestClass]
    public class StringCalculator_Tests
    {
        private StringCalculator stringCalculator = null;

        [TestInitialize]
        public void StingCalculator_Initialize()
        {
            stringCalculator = new StringCalculator();
        }

        [TestMethod]
        public void StringCalculator_Is_Not_Empty()
        {
            Assert.IsNotNull(stringCalculator);
        }

        [TestMethod]
        [DataRow(",")]
        [DataRow("test")]
        [DataRow("test, 1")]
        [DataRow("1, test")]
        [DataRow("test, test")]
        [DataRow("1.2, test")]
        [DataRow("test, 1.2")]
        [DataRow("1.2, 1.2")]
        public void StringCalculator_Throw_Argument_Exception_On_Non_Numbers(string input)
        {
            Assert.Throws<ArgumentException>(() => stringCalculator.Add(input));
        }

        [TestMethod]
        [DataRow("1.2, test")]
        [DataRow("test, 1.2")]
        [DataRow("1.2, 1.2")]
        public void StringCalculator_Throw_Argument_Exception_On_Non_Integers(string input)
        {
            Assert.Throws<ArgumentException>(() => stringCalculator.Add(input));
        }

        [TestMethod]
        [DataRow("0,1", 1)]
        [DataRow("1,2", 3)]
        [DataRow("-1,2,4", 5)]
        [DataRow("-1,-2,5,8", 10)]
        [DataRow("4,7, 9,10", 30)]
        [DataRow("3,10,1,2", 16)]
        [DataRow("6,8,3,4,5", 26)]
        [DataRow("16,28,12", 56)]
        [DataRow("61,82,13", 156)]
        [DataRow("116,812,13", 941)]
        public void StringCalculator_Adds_Numbers_Correctly(string input, int expected)
        {
            int actual = stringCalculator.Add(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("1\n2", 3)]
        [DataRow("1\n2,4", 7)]
        public void StringCalculator_Adds_Correctly_With_New_Line(string input, int expected)
        {
            int actual = stringCalculator.Add(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StringCalculator_Arguement_Throws_Exception_On_Double_New_Line() 
        {
            string input = "1\n\n3";
            Assert.Throws<ArgumentException>(() => stringCalculator.Add(input));
        }

        [TestMethod]
        [DataRow("1,")]
        [DataRow("1\n")]
        public void StringCalculator_Throws_Exception_When_Seperate_On_End(string input)
        {
            Assert.Throws<ArgumentException>(() => stringCalculator.Add(input));
        }

        [TestMethod]
        [DataRow("//|\n1|2,3", '|', ',', 3)]
        [DataRow("//|\n1|2|3;5", '|', ';', 4)]
        [DataRow("//>\n1`2|3;5", '>', '`', 2)]
        public void StringCalculator_Throws_Exception_With_Correct_Message_When_Delimiter_Is_Not_Consistent(string input, char delimiter, char errorDelimiter, int errorColumn)
        {
            var exception = Assert.Throws<ArgumentException>(() => stringCalculator.Add(input));
            string expectedMessage = $"'{delimiter}' expected but '{errorDelimiter}' found at position {errorColumn}.";
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestMethod]
        [DataRow("//;\n1;3", 4)]
        [DataRow("//|\n1|2|3", 6)]
        [DataRow("//sep\n2sep5”", 7)]
        public void StringCalculator_Adds_With_Custom_Delimiter(string input, int expected)
        {
            Assert.Throws<ArgumentException>(() => stringCalculator.Add(input));
        }
    }
}
