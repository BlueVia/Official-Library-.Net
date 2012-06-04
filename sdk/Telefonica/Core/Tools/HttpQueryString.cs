// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Globalization;

namespace Bluevia.Core.Tools
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="HttpQueryString.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Class to manage query params.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public sealed class HttpQueryString : Collection<KeyValuePair<string, string>>
    {
        /// <value>Characters that shouldn't be formUrl escaped.</value>
        private const string unreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._~";

        /// <summary>Method to add a new param to the query.</summary>
        /// <param name="item">A hash.</param>
        public new void Add(KeyValuePair<string, string> item)
        {
            if (!this.Any((kvp) => kvp.Key == item.Key))
                base.Add(item);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Method to add a new param to the query.</summary>
        /// <param name="name">The param label.</param>
        /// <param name="value">The param value.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Add(string name, string value)
        {
            if (!string.IsNullOrEmpty(name))
                this.Add(new KeyValuePair<string, string>(name, value));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Method to add a new param to the query.</summary>
        /// <param name="values">A shorted list of parameter hashes.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Add(IEnumerable<KeyValuePair<string, string>> values)
        {
            foreach (var item in values)
                Add(item);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Function to update the uri, with the maintainted parameters.</summary>
        /// <param name="uri">The actual uri.</param>
        /// <returns>The modified uri.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Uri MakeQueryString(Uri uri)
        {
            return MakeQueryString(uri, this);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Function to update the uri, with new parameters.</summary>
        /// <param name="uri">The actual uri.</param>
        /// <param name="queryString"></param>
        /// <returns>The modified uri.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static Uri MakeQueryString(Uri uri, HttpQueryString queryString)
        {
            return MakeQueryString(uri, (IEnumerable<KeyValuePair<string, string>>)queryString);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Function to update the uri, with new parameters.</summary>
        /// <param name="uri">The actual uri.</param>
        /// <param name="values">A shorted list of parameter hashes.</param>
        /// <returns>The modified uri.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static Uri MakeQueryString(Uri uri, IEnumerable<KeyValuePair<string, string>> values)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var pair in values)
            {
                if (sb.Length != 0)
                {
                    sb.Append('&');
                }
                sb.Append(UrlEncodeWithUppercasePercent20(pair.Key));
                sb.Append('=');
                sb.Append(UrlEncodeWithUppercasePercent20(pair.Value));
            }

            if (!uri.IsAbsoluteUri)
            {
                var s = uri.ToString();
                if (s.Contains("?"))
                {
                    if (!s.EndsWith("&") && !s.EndsWith("?"))
                    {
                        return new Uri(s + "&" + sb, UriKind.Relative);
                    }
                    return new Uri(s + sb, UriKind.Relative);
                }

                return new Uri(s + "?" + sb, UriKind.Relative);
            }
            UriBuilder b = new UriBuilder(uri);
            string existing = b.Query;
            if (existing.StartsWith("?"))
            {
                existing = existing.Substring(1);
            }
            if (!string.IsNullOrEmpty(existing))
            {
                existing = existing + "&";
            }
            b.Query = existing + sb.ToString();
            return b.Uri;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Function to properly encode a value.</summary>
        /// <param name="value">The string to be encoded.</param>
        /// <returns>The encoded string.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private static string UrlEncodeWithUppercasePercent20(string value)
        {
            StringBuilder result = new StringBuilder(value.Length);

            foreach (char symbol in value)
            {
                if (unreservedChars.IndexOf(symbol) != -1)
                {
                    result.Append(symbol);
                }
                else
                {
                    result.Append('%');
                    result.Append(((int)symbol).ToString("X2", CultureInfo.InvariantCulture));
                }
            }
            return result.ToString();
        }

        
    }
}