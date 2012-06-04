// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- //  

using System.Collections.Generic;
using Bluevia.Core.Schemas;

namespace Bluevia.Core.Connectors
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="IBV_Connector.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>   The IConnector: Interface wich describes functionallity to access 
    /// the BlueVia services trough CRUD operations.</summary>
    /// <remarks>   2012/02/09. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public interface IBV_Connector
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> The CRUD's "Create" operation. Will prepare and call this operation over the belower
        /// Layer.</summary>
        /// <remarks>   2012/02/09. </remarks>
        /// <param name="address">The string wich represents the Bluevia's service that is going to be called.</param>
        /// <param name="parameters">Key-Value url query pairs.</param>
        /// <param name="content">The UPDATE Body Content.</param>
        /// <param name="headers">The UPDATE Content-Type, and extra Bluevia's special headers.</param>
        /// <returns>The response related to the request.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        BV_Response Create(string address, Dictionary<string, string> parameters, byte[] content, Dictionary<string, string> headers);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> The CRUD's "Retrieve" operation. Will prepare and call this operation over the belower
        /// Layer</summary>
        /// <remarks>   2012/02/09. </remarks>
        /// <param name="address">The string wich represents the Bluevia's service that is going to be called.</param>
        /// <param name="parameters">Key-Value url query pairs.</param>
        /// <returns>The response related to the request.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        BV_Response Retrieve(string address, Dictionary<string, string> parameters);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> The CRUD's "Update" operation. Will prepare and call this operation over the belower
        /// Layer</summary>
        /// <remarks>   2012/02/09. </remarks>
        /// <param name="address">The string wich represents the Bluevia's service that is going to be called.</param>
        /// <param name="parameters">Key-Value url query pairs.</param>
        /// <param name="content">The UPDATE Body Content.</param>
        /// <param name="headers">The UPDATE Content-Type, and extra Bluevia's special headers.</param>
        /// <returns>The response related to the request.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        BV_Response Update(string address, Dictionary<string, string> parameters, byte[] content, Dictionary<string, string> headers);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> The CRUD's "Delete" operation. Will prepare and call this operation over the belower
        /// Layer</summary>
        /// <remarks>   2012/02/09. </remarks>
        /// <param name="address">The string wich represents the Bluevia's service that is going to be called.</param>
        /// <param name="parameters">Key-Value url query pairs.</param>
        /// <returns>The response related to the request.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        BV_Response Delete(string address, Dictionary<string, string> parameters);
    }
}
