// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Core.Tools
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="ISerializer.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Parser Interface.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public interface ISerializer
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Method to transform a full builded object from the Bluevia Schemas, 
        /// to XML in a single string .</summary>
        /// <remarks>   2012/03/02. </remarks>
        /// <typeparam name="T">The type of the object to be serialized.</typeparam>
        /// <param name="entity">The object from the Bluevia Schemas, to be serialized.</param>
        /// <returns>The serialized object.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        byte[] Serialize<T>(T entity);
    }
}
