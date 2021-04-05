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
            Console.WriteLine(Menu.CreateAccount);
            string username = Prompt.PromptUsername(Prompt.NewUsernamePrompt);

            if (_passwords.ContainsKey(username))
                throw new ArgumentException($"{username} already exists");

            string hash = Prompt.PromptPassword(Prompt.NewPasswordPrompt);
            _passwords[username] = hash;

            Console.WriteLine($"\nResulting SHA256 hash -> {hash}");
            Prompt.PromptContinue();
        }

        public static void AuthenticateAccount()
        {
            Console.WriteLine(Menu.SignIn);
            string username = Prompt.PromptUsername(Prompt.ExistingUsernamePrompt);
            string enteredHash = Prompt.PromptPassword(Prompt.ExistingPasswordPrompt);

            string actualHash = _passwords[username];
            bool correct = string.Equals(enteredHash, actualHash,
                StringComparison.OrdinalIgnoreCase);

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
    }
}
