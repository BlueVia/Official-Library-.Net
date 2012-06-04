// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;

namespace Bluevia.Core.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="Token.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>A data class representing an access token returned during an OAuth session.</summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class Token 
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string key { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets the token secret.
        /// </summary>
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string secret { get; set; }
    }
}
