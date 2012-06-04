// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Directory.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="ProfileInfo.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Object to contain the Profile Info data.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class ProfileInfo
    {
        /// <value>It indicates if the user is prepay or postpay.</value>
        public string userType;

        /// <value>It indicates whether the user has the icb (incomming call barring) service activated.</value>
        public string icb;

        /// <value>It indicates whether the user has the ocb (outgoing call barring) service activated.</value>
        public string ocb;

        /// <value>It indicates the user's language.</value>
        public string language;

        /// <value>It indicates whether the user has some parental control restriction activated.</value>
        public string parentalControl;

        /// <value>It indicates the user's operator.</value>
        public string operatorId;

        /// <value>It indicates whether the MMS service is activated for the user.</value>
        public string mmsStatus;

        /// <value>It indicates the segment the user belongs to.</value>
        public string segment;

    }
}
