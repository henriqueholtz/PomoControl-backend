namespace PomoControl.Core.Helpers
{
    public static class HelperRegex
    {
        public const string Email = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public const string Password = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$";
        public const string HasNumber = @"[0-9]+";
        public const string HasLetter = @"[A-Za-z]+";
    }
}
