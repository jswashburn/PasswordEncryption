namespace PasswordEncryption.UI
{
    public enum MenuOption
    {
        Establish,
        Authenticate,
        Exit,
        Count
    }

    public static class Menu
    {
        const int _horizontalRuleLength = 50;
        const char _horizontalRuleChar = '-';

        const string _titleMain = "PASSWORD AUTHENTICATION SYSTEM";
        const string _titleCreateAccount = "CREATE NEW ACCOUNT";
        const string _titleSignIn = "SIGN IN";

        static string[] _mainMenuOptions =
        {
            "Create new account",
            "Sign In",
            "Exit"
        };

        // Horizontal rule
        static string hr => _horizontalRuleChar.ToString()
            .PadLeft(_horizontalRuleLength, _horizontalRuleChar)
            .PadRight(_horizontalRuleLength, _horizontalRuleChar);

        public static string CreateAccount => $"{hr}\n{_titleCreateAccount}\n{hr}\n\n";

        public static string SignIn => $"{hr}\n{_titleSignIn}\n{hr}\n\n";

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
