// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Core.Connectors
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="IBV_Auth.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>   The IAuth: Interface wich describes functionallity to authenticate the requests.</summary>
    /// <remarks>   2012/03/02. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    interface IBV_Auth
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Method to prepare or provide authentication info for the CRUD operations.</summary>
        /// <remarks>   2012/02/09. From IConnector</remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        void Authenticate();
    }
}
