// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Core.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="RequestToken.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>A data class representing request  token returned during an OAuth session.</summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class RequestToken : Token
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating the url where authorise the application.
        /// </summary>
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string authUrl { get; set; }

    }
}
