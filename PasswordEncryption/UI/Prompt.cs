using PasswordEncryption.Extensions;
using System;
using System.Collections.Generic;

namespace PasswordEncryption.UI
{
    public static class Prompt
    {
        const int _maxUsernameLength = 20;

        public const char PasswordMaskChar = '*';
        public const string ContinuePrompt = "<ENTER>...";
        public const string OptionPrompt = "Enter option: ";
        public const string NewUsernamePrompt = "Enter a username: ";
        public const string NewPasswordPrompt = "Enter a password: ";
        public const string ExistingUsernamePrompt = "Enter your username: ";
        public const string ExistingPasswordPrompt = "Enter your password: ";
        public const string SuccessfulSignIn = "Signed in successfully.";
        public const string UnSuccessfulSignIn = "Sign-in failed.";

        public static MenuOption PromptMenuOption(string prompt)
        {
            string input;

            Console.Write(prompt);
            input = Console.ReadLine();

            if (!int.TryParse(input, out int chosenOption))
                throw new ArgumentException($"'{input}' not a valid menu option");

            bool outOfRange = chosenOption > (int)MenuOption.Count || chosenOption <= 0;
            if (outOfRange)
                throw new ArgumentOutOfRangeException(input);

            return (MenuOption)chosenOption;
        }

        public static string PromptUsername(string prompt)
        {
            string username;

            Console.Write(prompt);
            username = Console.ReadLine();

            if (username.Length > _maxUsernameLength)
                throw new ArgumentException(
                    $"Username must not exceed {_maxUsernameLength} characters");

            return username;
        }

        // MDMoore313 https://stackoverflow.com/questions/3404421/password-masking-console-application
        public static string PromptPassword(string prompt)
        {
            List<char> passwordChars = new List<char>();
            Console.Write(prompt);
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                // Backspace should not work
                if (!char.IsControl(key.KeyChar))
                {
                    passwordChars.Add(key.KeyChar);
                    Console.Write(PasswordMaskChar);
                }
                else if (key.Key == ConsoleKey.Backspace && passwordChars.Count > 0)
                {
                    passwordChars.RemoveAt(passwordChars.Count - 1);
                    Console.Write("\b \b");
                }
            }
            while (key.Key != ConsoleKey.Enter);
            Console.Write("\n");

            return passwordChars.Stringify().ToSHA256Hash();
        }

        public static void PromptContinue()
        {
            Console.Write(ContinuePrompt);
            Console.ReadLine();
        }

    }
}
