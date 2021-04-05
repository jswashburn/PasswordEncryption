using System.Collections.Generic;

namespace PasswordEncryption.Extensions
{
    public static class IListExtensions
    {
        public static string Stringify<T>(this IList<T> original)
        {
            string s = "";
            foreach (T item in original)
                s += item.ToString();

            return s;
        }
    }
}
