using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordEncryption.Extensions
{
    public static class StringExtensions
    {
        public static string ToSHA256Hash(this string original)
        {
            string formatted = "";
            byte[] hashed;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] input = Encoding.UTF8.GetBytes(original);
                hashed = sha256.ComputeHash(input);
            }

            foreach (byte hashedByte in hashed)
                formatted += hashedByte.ToString("x2");

            return formatted;
        }
        public static void WriteLineColored(this string original, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(original);
            Console.ResetColor();
        }

        public static void WriteColored(this string original, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(original);
            Console.ResetColor();
        }
    }
}
