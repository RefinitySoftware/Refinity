using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Refinity.Http
{
    /// <summary>
    /// Provides utility methods for working with HTTP requests and responses.
    /// </summary>
    public static class HttpUtility
    {
        private static object ToQueryString(this object data)
        {
            var properties = from p in data.GetType().GetProperties()
                             where p.GetValue(data, null) != null
                             select p.Name + "=" + WebUtility.UrlEncode(p.GetValue(data, null)?.ToString());

            return string.Join("&", properties.ToArray());
        }

        /// <summary>
        /// Encodes a URL string.
        /// </summary>
        /// <param name="str">The string to be encoded.</param>
        /// <returns>The encoded URL string.</returns>
        public static string UrlEncode(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException(nameof(str));
            }

            return WebUtility.UrlEncode(str);
        }

        /// <summary>
        /// Decodes a URL-encoded string.
        /// </summary>
        /// <param name="str">The URL-encoded string to decode.</param>
        /// <returns>The decoded string.</returns>
        public static string UrlDecode(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException(nameof(str));
            }

            return WebUtility.UrlDecode(str);
        }

        /// <summary>
        /// Encodes a string to be displayed in HTML format.
        /// </summary>
        /// <param name="str">The string to be encoded.</param>
        /// <returns>The encoded string.</returns>
        public static string HtmlEncode(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException(nameof(str));
            }

            return WebUtility.HtmlEncode(str);
        }

        /// <summary>
        /// Decodes a string that has been HTML-encoded into a decoded string.
        /// </summary>
        /// <param name="str">The string to decode.</param>
        /// <returns>The decoded string.</returns>
        public static string HtmlDecode(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException(nameof(str));
            }

            return WebUtility.HtmlDecode(str);
        }

        /// <summary>
        /// Sends a POST request to the specified URL with the provided data and content type.
        /// </summary>
        /// <param name="url">The URL to send the request to.</param>
        /// <param name="data">The data to send in the request body.</param>
        /// <param name="contentType">The content type of the request body. Default is "application/x-www-form-urlencoded".</param>
        /// <returns>The response string from the server.</returns>
        public static dynamic Post(string url, string data, string contentType = "application/x-www-form-urlencoded")
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            using (var client = new HttpClient())
            {
                var content = new StringContent(data, System.Text.Encoding.UTF8, contentType);
                var response = client.PostAsync(url, content).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                return responseString;
            }
        }

        /// <summary>
        /// Sends a GET request to the specified URL and returns the response as a dynamic object.
        /// </summary>
        /// <param name="url">The URL to send the GET request to.</param>
        /// <returns>The response from the GET request as a dynamic object.</returns>
        public static dynamic Get(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                return responseString;
            }
        }

        /// <summary>
        /// Sends a GET request to the specified URL asynchronously and returns the response as a dynamic object.
        /// </summary>
        /// <param name="url">The URL to send the GET request to.</param>
        /// <returns>The response from the GET request as a dynamic object.</returns>
        public static async Task<dynamic> GetAsync(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url));
            }
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }
        }

        /// <summary>
        /// Sends a GET request to the specified URL with the provided data and returns the response as a dynamic object.
        /// </summary>
        /// <param name="url">The URL to send the GET request to.</param>
        /// <param name="data">The data to include in the GET request.</param>
        /// <returns>The response from the GET request as a dynamic object.</returns>
        public static dynamic Get(string url, object data)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url));
            }
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url + "?" + data.ToQueryString()).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                return responseString;
            }
        }

        /// <summary>
        /// Sends an HTTP GET request to the specified URL with the provided data and returns the response as a dynamic object.
        /// </summary>
        /// <param name="url">The URL to send the request to.</param>
        /// <param name="data">The data to include in the request.</param>
        /// <returns>The response from the server as a dynamic object.</returns>
        public static async Task<dynamic> GetAsync(string url, object data)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url));
            }
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url + "?" + data.ToQueryString());
                var responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }
        }
    }
}