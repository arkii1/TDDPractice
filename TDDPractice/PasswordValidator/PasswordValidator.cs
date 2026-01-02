using System.Text.RegularExpressions;

namespace TDDPractice.PasswordValidator
{
    public class PasswordValidator
    {
        public PasswordValidationResult Validate(string input)
        {
            var errors = new List<string>();

            if(input.Length <= 8)
            {
                errors.Add("Password must be at least 8 characters");
            }

            var checkCharacterRequirement = (string errorMessage, string regexPattern, int minimumCount) =>
            {
                var regex = new Regex(regexPattern);
                var matches = regex.Matches(input);
                if (matches.Count < minimumCount)
                {
                    errors.Add(errorMessage);
                }
            };

            checkCharacterRequirement("The password must contain at least 2 numbers", "[0-9]", 2);
            checkCharacterRequirement("password must contain at least one capital letter", "[A-Z]", 1);
            checkCharacterRequirement("password must contain at least one special character", "[^A-Za-z0-9]", 1);

            var isValid = errors.Count == 0;
            return new PasswordValidationResult(isValid, String.Join("\n", errors));
        }
    }
}
