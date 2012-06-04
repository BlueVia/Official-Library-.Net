// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;

using Bluevia.Payment.Schemas;

namespace Bluevia.Payment.Tools
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="PaymentSimplifiers.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Class for response simplifier functions of Payment API.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public static class PaymentSimplifiers
    {

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Converts a complex PaymentResultType object, into a PaymentResult object.</summary>
        /// <param name="result">A complex PaymentResultType.</param>
        /// <returns>The simplified payment data, in a PaymentResult object.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static PaymentResult SimplifyPaymentResultType(PaymentResultType result)
        {
            return new PaymentResult()
            {
                transactionId = result.transactionId,
                transactionStatus = (TransactionStatus)Enum.Parse(typeof(TransactionStatus), result.transactionStatus),
                transactionStatusDescription = result.transactionStatusDescription
            };
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Converts a complex GetPaymentStatusResultType object, into a PaymentStatus object.</summary>
        /// <param name="result">A complex GetPaymentStatusResultType.</param>
        /// <returns>The simplified status data, in a PaymentStatus object.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static PaymentStatus SimplifyPaymentStatusResultType(GetPaymentStatusResultType result)
        {
            return new PaymentStatus()
            {
                transactionStatus = (TransactionStatus)Enum.Parse(typeof(TransactionStatus), result.transactionStatus),
                transactionStatusDescription = result.transactionStatusDescription
            };
        }

        
    }
}
