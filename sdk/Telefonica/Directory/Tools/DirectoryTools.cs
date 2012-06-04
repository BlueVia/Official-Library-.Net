// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Directory.Tools
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="DirectoryTools.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Additional static methods to serve to the API main classes.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public static class DirectoryTools
    {
        /// <summary>This method formats the apropiate url to "attack" the service.</summary>
        /// <param name="userIdType">Alias or PhoneNumber.</param>
        /// <param name="url">The Directory API formated url.</param>
        /// <param name="service">The service to be called.</param>
        /// <returns>The complete url of the service for the request.</returns>
        public static string CreateDirectoryServiceURL(Directory.Schemas.UserIdType userIdType, string url, string service = "")
        {
            string alias = string.Format("{0}:{1}", userIdType.type, userIdType.value);
            return string.Format(url, alias, service);
        }
    }
}
