// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Directory.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="AccessInfo.cs" company="Telefonica R&amp;D">GNU LPL v3.</copyright>
    /// <summary>Object to contain the Access Info data.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class AccessInfo
    {
        /// <value>It indicates the access network the user is connected to.</value>
        public string accessType;

        /// <value>It indicates the APN (Access Point Name) 
        /// to which the user is connected to access to the Internet.</value>
        public string apn;

        /// <value>It indicates whether the user is in roaming or in his home network.</value>
        public string roaming;
    }
}
