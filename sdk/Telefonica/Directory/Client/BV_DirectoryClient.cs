// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using Bluevia.Core;
using Bluevia.Core.Clients;
using Bluevia.Core.Tools;

using Bluevia.Directory.Schemas;
using Bluevia.Directory.Tools;

namespace Bluevia.Directory.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="BV_DirectoryClient.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>This functional block covers the User Info Request submission following 
    /// <a href=""> BlueVia directory service.</a> </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BV_DirectoryClient : BV_BaseClient
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>This Init function prepares the Directory functional block, to work 
        /// as a trusted client. 
        /// It calls the base Init function, wich creates the SSL client's certificate, the Bluevia Connector and
        /// sets the operational mode. 
        /// Then creates itself the api url, the parsers and serializers that the
        /// service petition's process needs</summary>
        /// <param name="mode"> The Bluevia Mode enumerator, that describes the 
        /// operational behavior of the client: <a href="https://www.bluevia.com/en/page/tech.howto.tut_APPtest"> LIVE, TEST, SANDBOX.</a></param>
        /// <param name="consumer">The application Identifier.</param>
        /// <param name="consumerSecret">The application Secret.</param>
        /// <param name="certPath">The path to the ssl client's pem certificate.</param>
        /// <param name="certPasswd">Optional (only if needed): The password of the ssl client's pem certificate.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected new void InitTrusted(Bluevia.Core.BVMode mode
            , string consumer, string consumerSecret
            , string certPath, string certPasswd = "")
        {
            base.InitTrusted(mode, consumer, consumerSecret, certPath, certPasswd);
            InitApiUrlAndObjects();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>This Init function prepares the Directory functional block, to work 
        /// as an untrusted client. 
        /// It calls the base Init function, wich creates the Bluevia Connector and
        /// sets the operational mode. 
        /// Then creates itself the api url, the parsers and serializers that the
        /// service petition's process needs</summary>
        /// <param name="mode"> The Bluevia Mode enumerator, that describes the 
        /// operational behavior of the client: <a href="https://www.bluevia.com/en/page/tech.howto.tut_APPtest"> LIVE, TEST, SANDBOX.</a></param>
        /// <param name="consumer">The application Identifier.</param>
        /// <param name="consumerSecret">The application Secret.</param>
        /// <param name="token">Optional (Mandatory for 3legged behavior): The final customer Identifier.</param>
        /// <param name="tokenSecret">Optional (Mandatory for 3legged behavior): The final customer Secret.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected new void InitUntrusted(BVMode mode
            , string consumer, string consumerSecret
            , string token = "", string tokenSecret = "")
        {
            base.InitUntrusted(mode, consumer, consumerSecret, token, tokenSecret);
            InitApiUrlAndObjects();           
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Allows an application to get all the user context information.
        /// Information blocks can be filtered using the data set.</summary>
        /// <param name="userIdType">The customer Identifier: Type and Value.
        /// Whom information is going to be retrieved.</param>
        /// <param name="dataSet">Array of DataSet enumerators (the blocks to be retrieved).
        /// If null this function will return all info.</param>
        /// <returns>Object containing the blocks of user context information you've selected.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected UserInfo GetUserInfo(Directory.Schemas.UserIdType userIdType, DirectoryDataSets[] dataSet)
        {
            var parameters = CreateParameters();

            if (dataSet != null)
            {
                parameters.Add("dataSets", HttpTools.CovertEnumToQueryParameter(dataSet));
            }

            //Dont need to select the apropiate parser/serializer for the operation:

            //The Bluevia´s complex response object, as result of the call:
            UserInfoType userInfoResponse = BaseRetrieve<UserInfoType>(
                DirectoryTools.CreateDirectoryServiceURL(userIdType, url, "")
                , parameters);

            return DirectorySimplifiers.SimplifyUserInfoType(userInfoResponse);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Retrieves the whole User Access Information resource block from the directory.</summary>
        /// <param name="userIdType">The customer Identifier: Type and Value.
        /// Whom information is going to be retrieved.</param>
        /// <param name="fields">Array of AccessFields enumerators. 
        /// A filter object to specify which information fields are required.
        /// If null this function will return all info.</param>
        /// <returns>An object containing the requested fields of user Access information.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected AccessInfo GetAccessInfo(Directory.Schemas.UserIdType userIdType, AccessFields[] fields)
        {
            var parameters = CreateParameters();

            if (fields != null)
            {
                string fieldsQueried = string.Format("'{0}'", HttpTools.CovertEnumToQueryParameter(fields));
                parameters.Add("fields", fieldsQueried);
            }

            //Dont need to select the apropiate parser/serializer for the operation:

            //The Bluevia´s complex response object, as result of the call:
            UserAccessInfoType userAccessInfoResponse = BaseRetrieve<UserAccessInfoType>(
                DirectoryTools.CreateDirectoryServiceURL(userIdType, url, Constants.DirectoryAccessInfo_Get)
                , parameters);

            return DirectorySimplifiers.SimplifyUserAccessInfoType(userAccessInfoResponse);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Retrieves a subset of the User Personal Information resource block from the directory.</summary>
        /// <param name="userIdType">The customer Identifier: Type and Value.
        /// Whom information is going to be retrieved.</param>
        /// <param name="fields">Array of PersonalFields enumerators. 
        /// A filter object to specify which information fields are required.
        /// If null this function will return all info.</param>
        /// <returns>An object containing the requested fields of user Personal information.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected PersonalInfo GetPersonalInfo(Directory.Schemas.UserIdType userIdType, PersonalFields[] fields = null)
        {
            var parameters = CreateParameters();

            if (fields != null)
            {
                string fieldsQueried = string.Format("'{0}'", HttpTools.CovertEnumToQueryParameter(fields));
                parameters.Add("fields", fieldsQueried);
            }

            //Dont need to select the apropiate parser/serializer for the operation:

            //The Bluevia´s complex response object, as result of the call:
            UserPersonalInfoType userPersonalInfoResponse = BaseRetrieve<UserPersonalInfoType>(
                DirectoryTools.CreateDirectoryServiceURL(userIdType, url, Constants.DirectoryPersonalInfo_Get)
                , parameters);

            return DirectorySimplifiers.SimplifyUserPersonalInfoType(userPersonalInfoResponse);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Retrieves the whole User Profile Information resource block from the directory.</summary>
        /// <param name="userIdType">The customer Identifier: Type and Value.
        /// Whom information is going to be retrieved.</param>
        /// <param name="fields">Array of ProfileFields enumerators. 
        /// A filter object to specify which information fields are required.
        /// If null this function will return all info.</param>
        /// <returns>An object containing the requested fields of user Profile information.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected ProfileInfo GetProfileInfo(Directory.Schemas.UserIdType userIdType, ProfileFields[] fields = null)
        {
            var parameters = CreateParameters();

            if (fields != null)
            {
                string fieldsQueried = string.Format("'{0}'", HttpTools.CovertEnumToQueryParameter(fields));
                parameters.Add("fields", fieldsQueried);
            }

            //Dont need to select the apropiate parser/serializer for the operation:

            //The Bluevia´s complex response object, as result of the call:
            UserProfileType userProfileInfoType = BaseRetrieve<UserProfileType>(
                DirectoryTools.CreateDirectoryServiceURL(userIdType, url, Constants.DirectoryProfile_Get)
                , parameters);

            return DirectorySimplifiers.SimplifyUserProfileInfoType(userProfileInfoType);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Retrieves the whole User Terminal Information resource block from the directory.</summary>
        /// <param name="userIdType">The customer Identifier: Type and Value.
        /// Whom information is going to be retrieved.</param>
        /// <param name="fields">Array of TerminalFields enumerators. 
        /// A filter object to specify which information fields are required.
        /// If null this function will return all info.</param>
        /// <returns>An object containing the requested fields of user Terminal information.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected TerminalInfo GetTerminalInfo(Directory.Schemas.UserIdType userIdType, TerminalFields[] fields = null)
        {
            var parameters = CreateParameters();

            if (fields != null)
            {
                string fieldsQueried = string.Format("'{0}'",HttpTools.CovertEnumToQueryParameter(fields));
                parameters.Add("fields", fieldsQueried);
            }

            //Dont need to select the apropiate parser/serializer for the operation:

            //The Bluevia´s complex response object, as result of the call:
            UserTerminalInfoType userTerminalInfoType = BaseRetrieve<UserTerminalInfoType>(
                DirectoryTools.CreateDirectoryServiceURL(userIdType, url, Constants.DirectoryTerminalInfo_Get)
                , parameters);

            return DirectorySimplifiers.SimplifyUserTerminalInfoType(userTerminalInfoType);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> This function concatenates the api string into the url, 
        /// and instantiates the parsers and serializers.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void InitApiUrlAndObjects()
        {
            url = string.Format(url, string.Format(Constants.apiDirectory, sandboxString));
            url = string.Format(url, Constants.DirectoryDirectoryInfo);
            //As the whole api uses the same parser, 
            //is instanciated and fixed
            parser = new XMLParser();
        }
    }
}
