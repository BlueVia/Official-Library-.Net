// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
namespace Bluevia.Core
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   OAuth Rest Service Builder Interface. </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public interface IServiceBuilder
    {
        IServiceBuilder AddAcceptableStatus(params int[] value);
        IServiceBuilder AddHeader(string name, params string[] values);
        IServiceBuilder AddQueryString(System.Collections.Generic.KeyValuePair<string, string> value);
        IServiceBuilder AddQueryString(string name, string value);
        IServiceBuilder AddQueryString(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, string>> values);
        IServiceBuilder AddFile(string filePath, string mimeType);
        IServiceBuilder AddFile(Bluevia.Core.Schemas.StreamAttachment streamAttachment);
        IServiceBuilder AuthenticateClient();
        IServiceBuilder SetCallback(Action<DotNetOpenAuth.Messaging.IncomingWebResponse> afterCall);
        IServiceBuilder SetBaseUri(string baseUri);
        IServiceBuilder SetBaseUri(Uri baseUri);
        IServiceBuilder SetRequestContentAsType<T>(T value);
        IServiceBuilder SetMethod(Bluevia.Core.Schemas.WebMethod method);
        IServiceBuilder EnableTwoLeggedAuth();
        IServiceBuilder EnableIsFormUrlEncoded();
        IServiceBuilder EnableIsForPaymentRequest();
        IServiceBuilder SetCallBackUrl(string callBack);
        IServiceBuilder ForceDate(bool date);
        IServiceBuilder EnableIsForSMSHandshake();

        string GetActiveAccessToken();
        void Call();

    }
}
