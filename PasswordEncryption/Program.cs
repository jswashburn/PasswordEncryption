using PasswordEncryption.Extensions;
using PasswordEncryption.UI;
using System;
using System.Collections.Generic;

namespace PasswordEncryption
{
    class Program
    {
        static Dictionary<MenuOption, Action> _menus = new Dictionary<MenuOption, Action>
        {
            [MenuOption.Establish] = AccountManager.CreateAccount,
            [MenuOption.Authenticate] = AccountManager.AuthenticateAccount,
            [MenuOption.Exit] = () => Environment.Exit(0)
        };

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(Menu.Main);
                try
                {
                    MenuOption chosenOption = Prompt.PromptMenuOption(Prompt.OptionPrompt);
                    _menus[chosenOption - 1]();
                }
                catch (Exception ex)
                {
                    ex.Message.WriteLineColored(ConsoleColor.Red);
                    Prompt.PromptContinue();
                    continue;
                }
            }
        }
    }
}
