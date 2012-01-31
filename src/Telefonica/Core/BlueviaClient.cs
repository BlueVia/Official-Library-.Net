// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bluevia.Core
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Bluevia Client. Extends from BaseClient to manage the unique ServiceBuilder,
    /// and contains the reference to the BlueviaClient of the APIs.
    /// </summary>
    /// <remarks>   22/04/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BlueviaClient : BaseClient, Bluevia.Core.IBlueviaClient
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor (injection). </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <param name="builder">  The builder. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public BlueviaClient(IServiceBuilder builder) : base (builder) { }
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        /// <remarks>   22/04/2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public BlueviaClient()
        {
            CreateRequest();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Authenticate using the accessToken. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <returns>   I Bluevia Client. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IBlueviaClient AuthenticateClient()
        {
            callBuilder.AuthenticateClient();
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates the request. This method also allows to reset the builder.</summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <returns>  I Bluevia Client. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IBlueviaClient CreateRequest()
        {
            callBuilder = new ServiceBuilder();
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets OAuth client services. </summary>
        /// <value> OAuth. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bluevia.OAuth.Client.IBlueviaClient OAuth { get { return new Bluevia.OAuth.Client.BlueviaClient(callBuilder); } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the Directory client services. </summary>
        /// <value> Directory. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bluevia.Directory.Client.IBlueviaClient Directory { get { return new Bluevia.Directory.Client.BlueviaClient(callBuilder); } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the MMS client services. </summary>
        /// <value> MMS. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bluevia.MMS.Client.IBlueviaClient MMS { get { return new Bluevia.MMS.Client.BlueviaClient(callBuilder); } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the SMS client services. </summary>
        /// <value> SMS. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bluevia.SMS.Client.IBlueviaClient SMS { get { return new Bluevia.SMS.Client.BlueviaClient(callBuilder); } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the SGAP (Advertising) client services. </summary>
        /// <value> GAP. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bluevia.SGAP.Client.IBlueviaClient SGAP { get { return new Bluevia.SGAP.Client.BlueviaClient(callBuilder); } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the Location client services. </summary>
        /// <value> Location. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bluevia.Location.Client.IBlueviaClient Location { get { return new Bluevia.Location.Client.BlueviaClient(callBuilder); } }
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the Payment client services. </summary>
        /// <value> Payment. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bluevia.Payment.Client.IBlueviaClient Payment { get { return new Bluevia.Payment.Client.BlueviaClient(callBuilder); } }

    }
}
