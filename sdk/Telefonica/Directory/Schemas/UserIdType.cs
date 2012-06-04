// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Directory.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="UserIdType.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Class to define what kind of user identifier is going to be used as identity,
    /// in the Directory request.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class UserIdType
    {
        /// <value>The type of user identifier: Alias/PhoneNumber.</value>
        public UserType type;

        /// <value>The Value of the user identifier.</value>
        public string value;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Initializes a new instance of the <see cref="UserIdType"/>.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public UserIdType() { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Initializes a new instance of the <see cref="UserIdType"/>. Overload.</summary>
        /// <param name="type">The type of user identifier: Alias/PhoneNumber.</param>
        /// <param name="value">The Value of the user identifier.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public UserIdType(UserType type, string value)
        {
            this.type = type;
            this.value = value;
        }
    }
}
