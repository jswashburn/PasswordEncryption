using PasswordEncryption.Extensions;
using PasswordEncryption.UI;
using System;
using System.Collections.Generic;

namespace PasswordEncryption
{
    public static class AccountManager
    {
        static Dictionary<string, string> _passwords = new Dictionary<string, string>();

        public static void CreateAccount()
        {
            string username = GetNewUsernameFromConsole();

            string hash = Prompt.PromptPassword(Prompt.NewPasswordPrompt);
            _passwords[username] = hash;

            Console.WriteLine($"\nResulting SHA256 hash -> {hash}");
            Prompt.PromptContinue();
        }

        public static void AuthenticateAccount()
        {
            string username = GetExistingUsernameFromConsole();

            bool correct = AuthenticatePasswordFromConsole(username);
            if (correct)
            {
                Prompt.SuccessfulSignIn.WriteLineColored(ConsoleColor.Green);
                Prompt.PromptContinue();
            }
            else
            {
                Prompt.UnSuccessfulSignIn.WriteLineColored(ConsoleColor.DarkRed);
                Prompt.PromptContinue();
            }
        }

        static bool AuthenticatePasswordFromConsole(string username)
        {
            string enteredHash = Prompt.PromptPassword(Prompt.ExistingPasswordPrompt);
            string actualHash = _passwords[username];
            bool correct = string.Equals(enteredHash, actualHash,
                StringComparison.OrdinalIgnoreCase);
            return correct;
        }

        static string GetExistingUsernameFromConsole()
        {
            Console.WriteLine(Menu.SignIn);
            string username = Prompt.PromptUsername(Prompt.ExistingUsernamePrompt);

            bool usernameAlreadyExists = _passwords.ContainsKey(username);

            if (!usernameAlreadyExists)
                throw new ArgumentException($"{username} does not exist");

            return username;
        }

        static string GetNewUsernameFromConsole()
        {
            Console.WriteLine(Menu.CreateAccount);
            string username = Prompt.PromptUsername(Prompt.ExistingUsernamePrompt);

            bool usernameAlreadyExists = _passwords.ContainsKey(username);

            if (usernameAlreadyExists)
                throw new ArgumentException($"{username} does not exist");

            return username;
        }
    }
}
