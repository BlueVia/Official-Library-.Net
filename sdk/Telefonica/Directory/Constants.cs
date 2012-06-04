// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Directory
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="Constants.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>File of Directory Constants, including the definition of Directory enumerators.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public static class Constants
    {
        public static readonly string apiDirectory = "/REST/Directory{0}";

        public static readonly string DirectoryDirectoryInfo = "/{0}/UserInfo{1}";
        public static readonly string DirectoryPersonalInfo_Get = "/UserPersonalInfo";
        public static readonly string DirectoryAccessInfo_Get = "/UserAccessInfo";
        public static readonly string DirectoryProfile_Get = "/UserProfile";
        public static readonly string DirectoryTerminalInfo_Get = "/UserTerminalInfo";
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>Data sets that can be retrieved using the UserInfo service.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public enum DirectoryDataSets
    {
        /// <summary>Information about the user.</summary>
        PersonalInfo = 1,
        /// <summary>Information about the user's profile.</summary>
        Profile = 2,
        /// <summary>Information about the network the user is using.</summary>
        AccessInfo = 3,
        /// <summary>Information about the user's handset.</summary>
        TerminalInfo = 4
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>Data sets that can be retrieved using the AccessInfo service.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public enum AccessFields
    {
        /// <summary>It indicates the access network the user is connected to.</summary>
        accessType = 1,
        /// <summary>It indicates the APN (Access Point Name) 
        /// to which the user is connected to access to the Internet.</summary>
        apn = 2,
        /// <summary>It indicates whether the user is in roaming or in his home network.</summary>
        roaming = 3
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>Data sets that can be retrieved using the PersonalInfo service.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public enum PersonalFields
    {
        /// <summary>Indicates the user's gender.</summary>
        gender = 1
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>Data sets that can be retrieved using the ProfileInfo service.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public enum ProfileFields
    {
        /// <summary>It indicates if the user is prepay or postpay.</summary>
        userType = 1,
        /// <summary>It indicates whether the user has the icb (incomming call barring) service activated.</summary>
        icb = 2,
        /// <summary>It indicates whether the user has the ocb (outgoing call barring) service activated.</summary>
        ocb = 3,
        /// <summary>It indicates the user's language.</summary>
        language = 4,
        /// <summary>It indicates whether the user has some parental control restriction activated.</summary>
        parentalControl = 5,
        /// <summary>It indicates the user's operator.</summary>
        operatorId = 6,
        /// <summary>It indicates whether the MMS service is activated for the user.</summary>
        mmsStatus = 7,
        /// <summary>It indicates the segment the user belongs to.</summary>
        segment = 8,
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>Data sets that can be retrieved using the PTerminalInfo service.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public enum TerminalFields
    {
        /// <summary>It indicates the user's handset brand.</summary>
        brand = 1,
        /// <summary>It indicates the user's handset model.</summary>
        model = 2,
        /// <summary>It indicates the user's handset software version.</summary>
        version = 3,
        /// <summary>It indicates the user's handset screen size.</summary>
        screenResolution = 4,
        /// <summary>It indicates whether the user's handset supports MMS.</summary>
        mms = 5,
        /// <summary>It indicates whether the user's handset supports EMS. </summary>
        ems = 6,
        /// <summary>It indicates whether the user's handset supports smart messages. </summary>
        smartMessaging = 7,
        /// <summary>It indicates whether the user's handset supports the WAP service.</summary>
        wap = 8,
        /// <summary>It indicates if the user's handset support USSD, and in that case, which USSD phase.</summary>
        ussdPhase = 9,
        /// <summary>It indicates the maximum number of concatenated SMS allowed by the user's handset.</summary>
        emsMaxNumber = 10,
        /// <summary>It indicates whether the user's handset supports the WAP Push service. </summary>
        wapPush = 11,
        /// <summary>	It indicates whether the user's handset supports video streaming. </summary>
        videoStreaming = 12,
        /// <summary>It indicates whether the user's handset is able to play video received over MMS. </summary>
        mmsVideo = 13
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>Enumerator to define what kind of user identifier is going to be used as identity,
    /// in the Directory request.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public enum UserType
    {
        /// <summary>Identity through an Alias.</summary>
        alias,
        /// <summary>Identity through PhoneNumber.</summary>
        phoneNumber,
    }

}
