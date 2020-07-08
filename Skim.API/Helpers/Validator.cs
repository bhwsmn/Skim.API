using System;

namespace Skim.API.Helpers
{
    /// <summary>
    /// Collection of validation related helper methods
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Validates if a given string is a proper absolute URL
        /// </summary>
        /// <param name="urlString">URL to validate in string format</param>
        /// <returns>Validation result</returns>
        public static bool IsValidUrl(string urlString)
        {
            var result = Uri.TryCreate(urlString, UriKind.Absolute, out var tempUri)
                && (tempUri.Scheme == Uri.UriSchemeHttp || tempUri.Scheme == Uri.UriSchemeHttps);

            return result;
        }
    }
}