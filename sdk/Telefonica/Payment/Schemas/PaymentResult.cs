// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Payment.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="PaymentResult.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Class representing the response of a payment.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class PaymentResult : PaymentStatus
    {
        /// <value>The Payment identifier to further retrieve the status.</value>
        public string transactionId;
        
    }
}
