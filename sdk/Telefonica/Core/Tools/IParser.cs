// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Core.Tools
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="IParser.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Parser Interface.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public interface IParser
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Method to transform an object serialized into a single byte array, 
        /// to a full builded object.</summary>
        /// <remarks>   2012/03/02. </remarks>
        /// <typeparam name="T">The result object type.</typeparam>
        /// <param name="stream">The object in a flat string (in byte array format)</param>
        /// <returns> The parsed received object.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        T Parse<T>(byte[] stream);
    }
}
