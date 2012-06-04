// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Payment.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="PaymentStatus.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Class representing the status of a previous payment.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class PaymentStatus
    {
        /// <value>Element indicating the status of the payment. Possible values: SUCCESS/FAILURE/PENDING.</value>
        public TransactionStatus transactionStatus;

        /// <value>Element containing further information related to the transactionStatus.</value>
        public string transactionStatusDescription;
    }
}
