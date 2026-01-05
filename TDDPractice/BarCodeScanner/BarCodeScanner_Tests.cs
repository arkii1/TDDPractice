namespace TDDPractice.BarCodeScanner
{
    [TestClass]
    public class BarCodeScanner_Tests
    {
        BarCodeScanner scanner;

        [TestInitialize]
        public void BarCodeScanner_Initialize()
        {
            scanner = new BarCodeScanner();
        }

        [TestMethod]
        public void BarCodeScanner_Is_Not_Null()
        {
            Assert.IsNotNull(scanner);
        }

        [TestMethod]
        [DataRow("12345", "$7.25")]
        [DataRow("23456", "$12.50")]
        public void BarCodeScanner_Returns_Expected(string input, string expected)
        {
            var actual = scanner.Scan(input);
        }

        [TestMethod]
        public void BarCodeScanner_Returns_Error_On_Not_Found()
        {
            var expected = "Error: barcode not found";
            var actual = scanner.Scan("999");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BarCodeScanner_Returns_Empty_Barcode_On_Empty_Input()
        {
            var expected = "Error: empty barcode";
            var actual = scanner.Scan("");
            Assert.AreEqual(expected, actual);
        }
    }
}
