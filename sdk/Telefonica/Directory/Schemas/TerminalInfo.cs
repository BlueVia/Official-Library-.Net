// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Directory.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="TerminalInfo.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Object to contain the Terminal Info data.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class TerminalInfo
    {
        /// <value>It indicates the user's handset brand.</value>
        public string brand;

        /// <value>It indicates the user's handset model.</value>
        public string model;

        /// <value>It indicates the user's handset software version.</value>
        public string version;

        /// <value>It indicates whether the user's handset supports MMS.</value>
        public string mms;

        /// <value>It indicates whether the user's handset supports EMS.</value>
        public string ems;

        /// <value>It indicates whether the user's handset supports smart messages.</value>
        public string smartMessaging;

        /// <value>It indicates whether the user's handset supports the WAP service.</value>
        public string wap;

        /// <value>It indicates if the user's handset support USSD, and in that case, which USSD phase.</value>
        public string ussdPhase;

        /// <value>It indicates the maximum number of concatenated SMS allowed by the user's handset.</value>
        public string emsMaxNumber;

        /// <value>It indicates whether the user's handset supports the WAP Push service.</value>
        public string wapPush;

        /// <value>It indicates whether the user's handset is able to play video received over MMS.</value>
        public string mmsVideo;

        /// <value>It indicates whether the user's handset supports video streaming.</value>
        public string videoStreaming;

        /// <value>It indicates the user's handset screen size.</value>
        public string screenResolution;
    }
}
