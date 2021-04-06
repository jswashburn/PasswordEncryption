using System.Collections.Generic;
using System.Text;

namespace PasswordEncryption.Extensions
{
    public static class IListExtensions
    {
        public static string Stringify<T>(this IList<T> original)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (T item in original)
                stringBuilder.Append(item);

            return stringBuilder.ToString();
        }
    }
}
