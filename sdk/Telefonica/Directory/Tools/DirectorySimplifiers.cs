// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;

using Bluevia.Directory.Schemas;

namespace Bluevia.Directory.Tools
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="DirectorySimplifiers.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Class for response simplifier functions of Directory API.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public static class DirectorySimplifiers
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Converts a complex UserInfoType object, into a UserInfo object.</summary>
        /// <param name="userInfoType">A complex UserInfoType.</param>
        /// <returns>The simplified user context data, in a UserInfo object.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static UserInfo SimplifyUserInfoType(UserInfoType userInfoType)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.accessInfo = SimplifyUserAccessInfoType(userInfoType.userAccessInfo);
            userInfo.personalInfo = SimplifyUserPersonalInfoType(userInfoType.userPersonalInfo);
            userInfo.profileInfo = SimplifyUserProfileInfoType(userInfoType.userProfile);
            userInfo.terminalInfo = SimplifyUserTerminalInfoType(userInfoType.userTerminalInfo);

            return userInfo;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Converts a complex UserAccessInfoType object, into a AccessInfo object.</summary>
        /// <param name="userAccessInfoType">A complex UserAccessInfoType.</param>
        /// <returns>The simplified access info data, in a AccessInfo object.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static AccessInfo SimplifyUserAccessInfoType(UserAccessInfoType userAccessInfoType)
        {
            AccessInfo accessInfo = null;
            if (userAccessInfoType != null)
            {
                accessInfo = new AccessInfo()
                {
                    accessType = userAccessInfoType.accessType,
                    apn = userAccessInfoType.apn,
                    roaming = Convert.ToString(userAccessInfoType.roaming)
                };

            }
            return accessInfo;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Converts a complex UserPersonalInfoType object, into a PersonalInfo object.</summary>
        /// <param name="userPersonalInfoType">A complex UserPersonalInfoType.</param>
        /// <returns>The simplified personal info data, in a PersonalInfo object.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static PersonalInfo SimplifyUserPersonalInfoType(UserPersonalInfoType userPersonalInfoType)
        {
            PersonalInfo personalInfo = null;
            if (userPersonalInfoType != null)
            {
                personalInfo = new PersonalInfo()
                {
                    gender = Convert.ToString(userPersonalInfoType.gender)
                };
            }
            return personalInfo;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Converts a complex UserProfileType object, into a ProfileInfo object.</summary>
        /// <param name="userProfileInfoType">A complex userProfileInfoType.</param>
        /// <returns>The simplified profile info data, in a ProfileInfo object.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static ProfileInfo SimplifyUserProfileInfoType(UserProfileType userProfileInfoType)
        {
            ProfileInfo profileInfo = null;
            if (userProfileInfoType != null)
            {
                profileInfo = new ProfileInfo()
                {
                    userType = userProfileInfoType.userType,
                    icb = userProfileInfoType.icb,
                    ocb = userProfileInfoType.ocb,
                    language = userProfileInfoType.language,
                    parentalControl = userProfileInfoType.parentalControl,
                    operatorId = userProfileInfoType.operatorId,
                    mmsStatus = Convert.ToString(userProfileInfoType.mmsStatus),
                    segment = userProfileInfoType.segment
                };
            }
            return profileInfo;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Converts a complex UserTerminalInfoType object, into a TerminalInfo object.</summary>
        /// <param name="userTerminalInfoType">A complex UserTerminalInfoType.</param>
        /// <returns>The simplified terminal info data, in a TerminalInfo object.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static TerminalInfo SimplifyUserTerminalInfoType(UserTerminalInfoType userTerminalInfoType)
        {
            TerminalInfo terminalInfo = null;
            if (userTerminalInfoType != null)
            {
                terminalInfo = new TerminalInfo()
                {
                    brand = userTerminalInfoType.brand,
                    model = userTerminalInfoType.model,
                    version = userTerminalInfoType.version,
                    mms = Convert.ToString(userTerminalInfoType.mms),
                    ems = Convert.ToString(userTerminalInfoType.ems),
                    smartMessaging = Convert.ToString(userTerminalInfoType.smartMessaging),
                    wap = Convert.ToString(userTerminalInfoType.wap),
                    ussdPhase = userTerminalInfoType.ussdPhase,
                    emsMaxNumber = userTerminalInfoType.emsMaxNumber,
                    wapPush = Convert.ToString(userTerminalInfoType.wapPush),
                    mmsVideo = Convert.ToString(userTerminalInfoType.mmsVideo),
                    videoStreaming = Convert.ToString(userTerminalInfoType.videoStreaming),
                    screenResolution = userTerminalInfoType.screenResolution
                };
            }
            return terminalInfo;
        }
    }
}
