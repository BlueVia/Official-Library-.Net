// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;
using System.Text;

namespace Bluevia.Core.Tools
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="HttpTools.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>   The Http constants, and tools.</summary>
    /// <remarks>   2012/02/14. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public static class HttpTools
    {
        public static readonly string ContetTypeKey = "Content-Type";

        public static string unreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
        public static readonly string ContetTypeVoid = "";
        public static readonly string ContetTypeFormUrl = "application/x-www-form-urlencoded; charset=utf-8";
        public static readonly string ContetTypeXML = "application/xml; charset=utf-8";
        public static readonly string ContetTypeMultipart = "multipart/form-data; boundary={0}; charset=utf-8";


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Method to build the url, composing it with the service uri,
        /// and the aditional parameters .</summary>
        /// <remarks>   2012/02/09. </remarks>
        /// <param name="endpoint">The service endpoint.</param>
        /// <param name="queryParameters">Request parameters.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static Uri BuildUri(string endpoint, Dictionary<string, string> queryParameters)
        {
            //1.Instancing an Uri object with the baseUri
            var baseUri = new Uri(endpoint);

            //2.Generating the queryString with the query parameters:
            HttpQueryString queryString = new HttpQueryString();

            foreach (var pair in queryParameters)
            {
                queryString.Add(pair.Key, pair.Value);
            }
            //3.Generating and returning the whole Uri:
            return HttpQueryString.MakeQueryString(baseUri, queryString);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Generate a nonce
        /// </summary>
        /// <returns>The nonce.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string GenerateNonce()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Generates an identifier for RPC operations.</summary>
        /// <returns>The id string.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string generateRPCId()
        {
            return Guid.NewGuid().ToString().GetHashCode().ToString("x");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Generates the timestamp for the signature.</summary>
        /// <returns>The timestamp.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string GenerateTimeStamp()
        {
            // Default implementation of UNIX time of the current UTC time
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// This is a different Url Encode implementation since the default .NET one outputs the percent encoding in lower case.
        /// While this is not mandatory but recommended in the 
        /// <a href="http://tools.ietf.org/html/rfc3986#section-2.1percent"> encoding spec</a>, 
        /// it is used in upper case throughout OAuth.</summary>
        /// <param name="value">The value to Url encode</param>
        /// <returns>Returns a Url encoded string with uppercase hexadecimal digits.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string UrlEncode(string value)
        {
            //The default .NET output would be:
            //return Uri.UnescapeDataString(value);

            StringBuilder result = new StringBuilder();

            foreach (char symbol in value)
            {
                if (unreservedChars.IndexOf(symbol) != -1)
                {
                    result.Append(symbol);
                }
                else
                {
                    result.Append('%' + String.Format("{0:X2}", (int)symbol));
                }
            }

            return result.ToString();

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Normalizes the request parameters according to the spec.</summary>
        /// <param name="parameters">The list of parameters already sorted.</param>
        /// <returns>A string representing the normalized parameters.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string NormalizeRequestParameters(IList<KeyValuePair<string, string>> parameters)
        {
            StringBuilder sb = new StringBuilder();
            KeyValuePair<string, string> p;
            for (int i = 0; i < parameters.Count; i++)
            {
                p = parameters[i];
                sb.AppendFormat("{0}={1}", UrlEncode(p.Key), UrlEncode(p.Value));

                if (i < parameters.Count - 1)
                {
                    sb.Append("&");
                }
            }

            return sb.ToString();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Creates a queryParams string, from an enumeration array.</summary>
        /// <typeparam name="T">The type of enumerator received.</typeparam>
        /// <param name="array">The enumerator array.</param>
        /// <returns>The query parameters string.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string CovertEnumToQueryParameter<T>(T[] array)
        {
            if (array == null) return null;
            if (array.Length<=0) return null;

            StringBuilder builder = new StringBuilder();
	        foreach (var value in array)
	        {
	            builder.Append(value);
	            builder.Append(',');
	        }
            return builder.Remove(builder.Length-1,1).ToString();
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts a flag enumeration to an quoted string concatenation of the values. </summary>
        /// <remarks>   26/11/2010. </remarks>
        /// <typeparam name="T"> Enum type. </typeparam>
        /// <param name="flags"> The (enum) flags. </param>
        /// <returns>   This object as a string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string ToFlagStringQuoted<T>(this T flags)
        {
            return "'" + ToFlagString<T>(flags) + "'";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts a flag enumeration to an string concatenation of the values. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <typeparam name="T"> Enum type. </typeparam>
        /// <param name="flags"> The (enum) flags. </param>
        /// <returns>   This object as a string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string ToFlagString<T>(this T flags)
        {
            // Check null argument
            if (flags == null)
                throw new ArgumentNullException();

            // Check argument type
            Type typeofFlag = typeof(T);
            if (!typeofFlag.IsEnum)
                throw new ArgumentException();

            // Extract enum values
            var values = Enum.GetValues(typeofFlag);

            List<string> flagValues = new List<string>();
            foreach (dynamic item in values)
            {
                if ((flags & item) == item)
                    flagValues.Add(Enum.Format(typeofFlag, item, "g"));
            }
            return String.Join(",", flagValues.ToArray());
        }
    }
}
