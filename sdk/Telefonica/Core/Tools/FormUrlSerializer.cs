// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Bluevia.Core.Tools
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="FormUrlSerializer.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Class to serialize a key value dictionary, into a FormUrlEncoded string(in byte arrayformat).</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class FormUrlSerializer : ISerializer
    {

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Method to transform a KeyValuePair collection (Dictionary),
        /// to FormUrlEncoded in a single string.</summary>
        /// <remarks>   2012/03/07. </remarks>
        /// <typeparam name="T">Dictionary&lt;string,string&gt;.</typeparam>
        /// <param name="entity">A Dictionary.</param>
        /// <returns> The serialized data.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public byte[] Serialize<T>(T entity)
        {
            if (entity == null)
            {
                return null;
            }
            Dictionary<string, string> pairs = entity as Dictionary<string, string>;
            var body = string.Join("&", pairs.Select(q => q.Key + "=" + Uri.EscapeDataString(q.Value)).ToArray());
            return Encoding.UTF8.GetBytes(body);
        }
    }
}
