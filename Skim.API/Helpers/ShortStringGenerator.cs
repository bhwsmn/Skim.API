using System;
using System.Linq;

namespace Skim.API.Helpers
{
    /// <summary>
    /// A static helper class to generate a shortString of random length within the boundary defined by
    /// the parameters, minLength & maxLength.
    /// </summary>
    public static class ShortStringGenerator
    {
        /// <summary>
        /// Generate a string based on a constant list of chars of random length defined by parameters.
        /// </summary>
        /// <param name="minLength">Minimum length of the generated string</param>
        /// <param name="maxLength">Maximum length of the generated string</param>
        /// <returns>Generated string containing random characters from the constant list of chars</returns>
        public static string Generate(int minLength = 3, int maxLength = 6)
        {
            // Avoid using 1, l, I, o, O, 0 and similar ambiguous characters
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz23456789";

            var random = new Random();
            var length = random.Next(minLength, maxLength);

            var shortString = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());

            return shortString;
        }
    }
}