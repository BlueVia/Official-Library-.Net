﻿// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bluevia.Payment.Client
{
    public interface IAmountCharging
    {
        Schemas.PaymentResultType Payment(Schemas.PaymentParamsType paymentParams);
        void CancelAuthorization();
        Schemas.GetPaymentStatusResultType GetPaymentStatus(Schemas.GetPaymentStatusParamsType paymentStatusParams);
    }
}
