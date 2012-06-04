// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System.Text;
using System.Collections.Generic;

namespace Bluevia.Core.Tools
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="FormUrlParser.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Class to parse a FormUrlEncoded string(in byte arrayformat), into a key-value dictionary.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    class FormUrlParser : IParser
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Method to parse a FormUrlEncoded byte array, to a full object from the Bluevia Schemas.</summary>
        /// <remarks>   2012/03/07. </remarks>
        /// <typeparam name="T">Dictionary&lt;string,string&gt;.</typeparam>
        /// <param name="stream">A FormUrlEncoded string(in byte arrayformat).</param>
        /// <returns> The parsed dictionary.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public T Parse<T>(byte[] stream)
        {
            if (stream == null)
            {
                return (T)(object)stream;
            }

            string str = Encoding.Default.GetString(stream);
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            var chunks = str.Split(new char[] { '&' });
            int separator;
            foreach (string pair in chunks)
            {
                separator = pair.IndexOf('=');
                pairs.Add(pair.Substring(0, separator), pair.Substring(separator+1));
            }

            object sol = pairs;
            return (T)sol;
        }
    }
}
