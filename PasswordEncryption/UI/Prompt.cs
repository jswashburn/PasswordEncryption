using PasswordEncryption.Extensions;
using System;
using System.Collections.Generic;

namespace PasswordEncryption.UI
{
    public static class Prompt
    {
        const int _maxUsernameLength = 20;

        public const char PasswordMask = '*';
        public const string ContinuePrompt = "<ENTER>...";
        public const string ExitPrompt = "Are your sure? [y/n] ";
        public const string OptionPrompt = "Enter option: ";
        public const string NewUsernamePrompt = "Enter a username: ";
        public const string NewPasswordPrompt = "Enter a password: ";
        public const string ExistingUsernamePrompt = "Enter your username: ";
        public const string ExistingPasswordPrompt = "Enter your password: ";
        public const string SuccessfulSignIn = "Signed in successfully.";
        public const string UnSuccessfulSignIn = "Sign-in failed.";

        public static MenuOption PromptMenuOption(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int chosenOption))
                throw new ArgumentException($"'{input}' not a valid menu option");

            bool outOfRange = chosenOption > (int)MenuOption.Count || chosenOption <= 0;
            if (outOfRange)
                throw new ArgumentOutOfRangeException(input);

            return (MenuOption)chosenOption;
        }

        public static string PromptUsername(string prompt)
        {
            Console.Write(prompt);
            string username = Console.ReadLine();

            if (username.Length > _maxUsernameLength)
                throw new ArgumentException(
                    $"Username must not exceed {_maxUsernameLength} characters");

            return username;
        }

        // MDMoore313 https://stackoverflow.com/questions/3404421/password-masking-console-application
        public static string PromptPassword(string prompt)
        {
            List<char> keysEntered = new List<char>();
            Console.Write(prompt);
            ConsoleKeyInfo keyPress;

            do
            {
                keyPress = Console.ReadKey(true);

                // Prevent control characters from being written to the password
                if (!char.IsControl(keyPress.KeyChar))
                {
                    keysEntered.Add(keyPress.KeyChar);
                    Console.Write(PasswordMask);
                }
                else if (keyPress.Key == ConsoleKey.Backspace && keysEntered.Count > 0)
                {
                    keysEntered.RemoveAt(keysEntered.Count - 1);
                    Console.Write("\b \b");
                }
            }
            while (keyPress.Key != ConsoleKey.Enter);
            Console.Write("\n");

            return keysEntered.Stringify().ToSHA256Hash();
        }

        public static void PromptContinue()
        {
            Console.Write(ContinuePrompt);
            Console.ReadLine();
        }

        public static bool PromptExit()
        {
            Console.Write(ExitPrompt);
            string wantsToContinue = Console.ReadLine().ToLower();
            
            switch (wantsToContinue)
            {
                case "y":
                    return true;
                case "n":
                    return false;
                default:
                    throw new ArgumentException("Enter either 'y' or 'n'");
            }
        }
    }
}
