using System;
using System.Linq;

namespace Skim.API.Helpers
{
    /// <summary>
    /// A static helper class to generate a slug of given length using random characters
    /// </summary>
    public static class SlugGenerator
    {
        /// <summary>
        /// Generate a slug based on a constant list of chars of given length
        /// </summary>
        /// <param name="length">Length of the generated slug</param>
        /// <returns>Generated slug containing random characters from the constant list of chars</returns>
        public static string Generate(int length)
        {
            // Avoid using 1, l, I, o, O, 0 and similar ambiguous characters
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz23456789";

            var random = new Random();

            var slug = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());

            return slug;
        }
    }
}