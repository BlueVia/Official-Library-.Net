// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Payment
{
    public static class Constants
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <copyright file="Constants.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
        /// <summary>File of Bluevia payment constants, including the definition of Bluevia payment enumerators.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static readonly string apiPayment = "/RPC/Payment{0}";

        public static readonly string PaymentPayment = "/payment";
        public static readonly string PaymentCancelAuthorization = "/cancelAuthorization";
        public static readonly string PaymentGetPaymentStatus = "/getPaymentStatus";

        public static readonly string PaymentTrustedPayment = "/payment";
        public static readonly string PaymentTrustedRefund = "/refund";
    }
    /// <summary>The status of the payment.</summary>
    public enum TransactionStatus
    {
        /// <summary>The payment operatioin has been completed and the result is successful. 
        /// The customer has been charged.</summary>
        SUCCESS = 1,
        /// <summary>The payment operation has been completed but the result is unsuccessful.
        /// The customer has not been charged.</summary>
        FAILURE = 2,
        /// <summary>The payment operation has not been completed yet. Ask again later.</summary>
        PENDING = 3
    }
}
