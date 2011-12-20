// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bluevia.Core;
using Common = Bluevia.Core.Schemas;

namespace Bluevia.Payment.Client
{
    public class AmountCharging : BaseClient, Bluevia.Payment.Client.IAmountCharging
    {
        public AmountCharging(IServiceBuilder builder) : base(builder) { }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        ///     This operation allows to request a charge in the account indicated by the end user identifier,
        ///     with information about the purchase, such as economic units, the currency employed, 
        ///     optional information about additional taxes that could apply, 
        ///     generic code and a suggested reference code which uniquely identifies the current payment event.
        /// </summary>
        /// <param name="paymentParams">  PaymentParamsType Object contains:
        ///     a timeStamp.
        ///     a paymentInfo Object.
        ///     a receiptRequest. which specify the endpoint for notifications.
        /// </param>
        /// <returns>   
        ///    A PaymentResultType Object.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Schemas.PaymentResultType Payment(Schemas.PaymentParamsType paymentParams)
        {
            if (paymentParams.paymentInfo == null)
            {
                throw new Exception("Missing mandatory paymentParams.paymentInfo parameter");
            }
            if (string.IsNullOrEmpty(paymentParams.paymentInfo.currency))
            {
                throw new Exception("Missing mandatory paymentParams.paymentInfo.currency parameter");
            }

            Schemas.MethodResponseType1 response = null;

            Schemas.MethodCallType1 mct1 = new Schemas.MethodCallType1();
            mct1.id = generateId();
            mct1.version = Common.QueryString.currentVersion.Value;
            mct1.method = Schemas.MethodType.PAYMENT;
            mct1.@params = new Schemas.MethodCallTypeParams();
            mct1.@params.Item = paymentParams;

            callBuilder
                .SetBaseUri(Bluevia.Core.Configuration.UriManager.Payment_Payment)
                .SetMethod(Common.WebMethod.Post)
                .SetRequestContentAsType<Schemas.MethodCallType1>(mct1)
                .AddAcceptableStatus(200)
                .SetCallback(resp => { response = resp.ParseXml<Schemas.MethodResponseType1>(); })
                .ForceDate(true)
                .Call();

            return (Schemas.PaymentResultType) response.result.Item;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        ///     Cancels the previous AccesToken requested, before making the payment.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void CancelAuthorization()
        {
            Schemas.MethodCallType1 mct1 = new Schemas.MethodCallType1();
            mct1.id = generateId();
            mct1.version = Common.QueryString.currentVersion.Value;
            mct1.method = Schemas.MethodType.CANCEL_AUTHORIZATION;


            Schemas.MethodResponseType1 response = null;

            callBuilder
                .SetBaseUri(Bluevia.Core.Configuration.UriManager.Payment_CancelAuthorization)
                .SetMethod(Common.WebMethod.Post)
                .SetRequestContentAsType<Schemas.MethodCallType1>(mct1)
                .AddAcceptableStatus(200)
                .SetCallback(resp => { response = resp.ParseXml<Schemas.MethodResponseType1>(); })
                .Call();

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        ///     This operation allows to query for the current status of an already initiated purchase 
        ///     (i.e. payment transaction).
        /// </summary>
        /// <param name="paymentStatusParams">   A GetPaymentStatusParamsType Object contains:
        ///     a transactionId. </param>
        /// <returns>   
        ///    A GetPaymentStatusResultType Object.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Schemas.GetPaymentStatusResultType GetPaymentStatus(Schemas.GetPaymentStatusParamsType paymentStatusParams)
        {
            if (string.IsNullOrEmpty(paymentStatusParams.transactionId))
            {
                throw new Exception("Missing mandatory paymentStatusParams.transactionId parameter");
            }
            Schemas.MethodResponseType1 response = null;

            Schemas.MethodCallType1 mct1 = new Schemas.MethodCallType1();
            mct1.id = generateId();
            mct1.version = Common.QueryString.currentVersion.Value;
            mct1.method = Schemas.MethodType.GET_PAYMENT_STATUS;
            mct1.@params = new Schemas.MethodCallTypeParams();
            mct1.@params.Item = paymentStatusParams;

            callBuilder
                .SetBaseUri(Bluevia.Core.Configuration.UriManager.Payment_GetPaymentStatus)
                .SetMethod(Common.WebMethod.Post)
                .SetRequestContentAsType<Schemas.MethodCallType1>(mct1)
                .AddAcceptableStatus(200)
                .SetCallback(resp => { response = resp.ParseXml<Schemas.MethodResponseType1>(); })
                .Call();

            return (Schemas.GetPaymentStatusResultType)response.result.Item;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Generates an identifier for RPC operations </summary>
        /// <returns>   
        ///    The id string
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private string generateId()
        {
            return Guid.NewGuid().ToString().GetHashCode().ToString("x");
        }

    }
}
