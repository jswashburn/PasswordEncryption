namespace PasswordEncryption.UI
{
    public static class Menu
    {
        const int _horizontalRuleLength = 50;
        const char _horizontalRuleChar = '-';

        const string _titleMain = "PASSWORD AUTHENTICATION SYSTEM";
        const string _titleCreateAccount = "CREATE NEW ACCOUNT";
        const string _titleSignIn = "SIGN IN";

        static string[] _mainMenuOptions = new[]
        {
            "Establish an account",
            "Authenticate a user",
            "Exit the system"
        };

        // Horizontal rule
        static string hr => _horizontalRuleChar.ToString()
            .PadLeft(_horizontalRuleLength, _horizontalRuleChar)
            .PadRight(_horizontalRuleLength, _horizontalRuleChar);

        // Create Account menu
        public static string CreateAccount =>
            $"{hr}\n{_titleCreateAccount}\n{hr}\n\n";

        // Sign in menu
        public static string SignIn => $"{hr}\n{_titleSignIn}\n{hr}\n\n";

        // Main menu
        public static string Main
        {
            get
            {
                string options = "";
                for (int i = 0; i < _mainMenuOptions.Length; i++)
                {
                    string menuOption = _mainMenuOptions[i];
                    options += $"\n {i + 1}. {menuOption}";
                }
                return $"{hr}\n{_titleMain}\n{options}\n{hr}\n\n";
            }
        }
    }
}
