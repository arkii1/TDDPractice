namespace TDDPractice.PasswordValidator
{
    // From https://tddmanifesto.com/exercises/

    [TestClass]
    public class PasswordValidator_Tests
    {
        PasswordValidator validator;

        [TestInitialize]
        public void PasswordValidator_Initialize()
        {
            validator = new PasswordValidator();
        }

        [TestMethod]
        public void PasswordValidator_Is_Not_Null()
        {
            Assert.IsNotNull(validator);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("Pa")]
        [DataRow("Pass")]
        [DataRow("Passwor")]
        public void PasswordValidator_Fails_If_Less_Than_Eight_Characters(string input)
        {
            var result = validator.Validate(input);
            Assert.IsFalse(result.IsValid);

            var expectedErrorMessage = "Password must be at least 8 characters";
            bool includesExpectedError = result.Errors.Contains(expectedErrorMessage);
            Assert.IsTrue(includesExpectedError);
        }

        [TestMethod]
        [DataRow("Password")]
        [DataRow("Password1")]
        [DataRow("Passwor2")]
        public void PasswordValidator_Fails_If_Less_Than_Two_Numbers(string input)
        {
            var result = validator.Validate(input);
            Assert.IsFalse(result.IsValid);

            var expectedErrorMessage = "The password must contain at least 2 numbers";
            bool includesExpectedError = result.Errors.Contains(expectedErrorMessage);
            Assert.IsTrue(includesExpectedError);
        }

        [TestMethod]
        [DataRow("some")]
        [DataRow("test")]
        public void PasswordValidator_Includes_Multiple_Errors(string input)
        {
            var result = validator.Validate(input);
            Assert.IsFalse(result.IsValid);

            var expectedErrorMessage = "Password must be at least 8 characters\nThe password must contain at least 2 numbers\npassword must contain at least one capital letter\npassword must contain at least one special character";
            Assert.AreEqual(expectedErrorMessage, result.Errors);
        }

        [TestMethod]
        [DataRow("sometest")]
        [DataRow("test1234")]
        public void PasswordValidator_Must_Contain_Capital_Letter(string input)
        {
            var result = validator.Validate(input);
            Assert.IsFalse(result.IsValid);

            var expectedErrorMessage = "password must contain at least one capital letter";
            bool includesExpectedError = result.Errors.Contains(expectedErrorMessage);
            Assert.IsTrue(includesExpectedError);
        }

        [TestMethod]
        [DataRow("sometest")]
        [DataRow("test1234")]
        public void PasswordValidator_Must_Contain_Special_Character(string input)
        {
            var result = validator.Validate(input);
            Assert.IsFalse(result.IsValid);

            var expectedErrorMessage = "password must contain at least one special character";
            bool includesExpectedError = result.Errors.Contains(expectedErrorMessage);
            Assert.IsTrue(includesExpectedError);
        }
    }
}
