using System.Text.RegularExpressions;

namespace PomoControl.Core.Helpers
{
    public static class HelperRegex
    {
        public const string EmailRegex = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public const string PasswordRegex = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";
        public const string HasNumberRegex = @"[0-9]+";
        public const string HasLetterRegex = @"[A-Za-z]+";
        public const string HasSymbolRegex = @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]";


        public static bool EmailIsValid(string email)
        {
            var regex = new Regex(EmailRegex);
            return regex.IsMatch(email);
        }
        public static bool PasswordIsValid(string password)
        {
            var regex = new Regex(PasswordRegex);
            return regex.IsMatch(password);
        }
        public static bool HasNumber(string str)
        {
            var regex = new Regex(HasNumberRegex);
            return regex.IsMatch(str);
        }
        public static bool HasLetter(string str)
        {
            var regex = new Regex(HasLetterRegex);
            return regex.IsMatch(str);
        }
        public static bool HasSymbol(string str)
        {
            var regex = new Regex(HasSymbolRegex);
            return regex.IsMatch(str);
        }
    }
}
