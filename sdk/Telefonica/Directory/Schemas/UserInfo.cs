// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Directory.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="UserInfo.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Object to contain the User Info data.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class UserInfo
    {
        /// <value>Information about the network the user is using.</value>
        public AccessInfo accessInfo;

        /// <value>Information about the user's profile.</value>
        public ProfileInfo profileInfo;

        /// <value>Information about the user.</value>
        public PersonalInfo personalInfo;

        /// <value>Information about the user's handset.</value>
        public TerminalInfo terminalInfo;
    }
}
