
namespace TDDPractice.PasswordValidator
{
    public class PasswordValidationResult
    {
        public PasswordValidationResult(bool isValid, string errors)
        {
            IsValid = isValid;
            Errors = errors;
        }

        public bool IsValid { get; private set; } = false;
        public string Errors { get; private set; } = string.Empty;
    }
}
