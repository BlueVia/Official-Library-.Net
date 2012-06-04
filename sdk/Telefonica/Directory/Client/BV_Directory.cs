// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 


using Bluevia.Core;

namespace Bluevia.Directory.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="BV_Directory.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Bluevia Client for Directory (user content), to request user directory info from the
    /// <a href=""> BlueVia directory service.</a> </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BV_Directory : BV_DirectoryClient
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Initializes a new instance of the <see cref="BV_Directory"/>. 3 Legged Constructor</summary>
        /// <param name="mode">The Bluevia operation mode: <a href="https://www.bluevia.com/en/page/tech.howto.tut_APPtest">LIVE, TEST, SANDBOX.</a></param>
        /// <param name="consumer">The appplication Identifier</param>
        /// <param name="consumerSecret">The application Secret</param>
        /// <param name="token">The final customer Identifier</param>
        /// <param name="tokenSecret">The final customer Secret</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public BV_Directory(BVMode mode, string consumer, string consumerSecret, string token, string tokenSecret)
        {
            if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(tokenSecret))
            {
                throw new Bluevia.Core.Schemas.BlueviaException(
                    "Null or Empty tokens when creating Directory Client. Two legged mode is not available in Directory."
                    , Bluevia.Core.Schemas.ExceptionCode.InvalidArgumentException);
            }
            InitUntrusted(mode, consumer, consumerSecret, token, tokenSecret);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Allows an application to get all the user context information. Applications 
        /// will only be able to retrieve directory information on themselves.</summary>
        /// <param name="dataSet">Optional:An array of the Directory Info blocks to be retrieved.
        /// If not included this function will return all info.</param>
        /// <returns>An object containing the requested blocks of user context information.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Schemas.UserInfo GetUserInfo(DirectoryDataSets[] dataSet = null)
        {
            return base.GetUserInfo(new Directory.Schemas.UserIdType(UserType.alias, connector.GetToken()), dataSet);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Retrieves the whole User Access Information resource block from the directory. 
        /// Applications will only be able to retrieve directory information on themselves.</summary>
        /// <param name="fields">Optional: An array of the Access Info fields to be retrieved.
        /// If not included this function will return all info.</param>
        /// <returns>An object containing the requested fields of user Access information.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Schemas.AccessInfo GetAccessInfo(AccessFields[] fields = null)
        {
            return GetAccessInfo(new Directory.Schemas.UserIdType(UserType.alias, connector.GetToken()), fields);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Retrieves the whole User Personal Information resource block from the directory. 
        /// Applications will only be able to retrieve directory information on themselves.</summary>
        /// <param name="fields">Optional: An array of the Access Info fields to be retrieved.
        /// If not included this function will return all info.</param>
        /// <returns>An object containing the requested fields of user Personal information.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Schemas.PersonalInfo GetPersonalInfo(PersonalFields[] fields = null)
        {
            return GetPersonalInfo(new Directory.Schemas.UserIdType(UserType.alias, connector.GetToken()), fields);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Retrieves the whole User Profile Information resource block from the directory. 
        /// Applications will only be able to retrieve directory information on themselves.</summary>
        /// <param name="fields">Optional: An array of the Access Info fields to be retrieved.</param>
        /// <returns>An object containing the requested fields of user Profile information.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Schemas.ProfileInfo GetProfileInfo(ProfileFields[] fields = null)
        {
            return GetProfileInfo(new Directory.Schemas.UserIdType(UserType.alias, connector.GetToken()), fields);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Retrieves the whole User Terminal Information resource block from the directory. 
        /// Applications will only be able to retrieve directory information on themselves.</summary>
        /// <param name="fields">Optional: An array of the Access Info fields to be retrieved.
        /// If not included this function will return all info.</param>
        /// <returns>An object containing the requested fields of user Terminal information.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Schemas.TerminalInfo GetTerminalInfo(TerminalFields[] fields = null)
        {
            return GetTerminalInfo(new Directory.Schemas.UserIdType(UserType.alias, connector.GetToken()), fields);
        }
    }
}
