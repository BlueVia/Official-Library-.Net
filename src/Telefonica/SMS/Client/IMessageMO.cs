// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
namespace Bluevia.SMS.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   
    ///     This interface defines operations to the reception of SMSs(SMS-MO) using polling. 
    ///     See MessageMO class for further information.
    /// </summary>
    /// <remarks>   19/04/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public interface IMessageMO
    {
        Bluevia.SMS.Schemas.ReceivedSMSType GetMessages(string registrationId);
    }
}
