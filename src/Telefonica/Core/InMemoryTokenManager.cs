// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

//-----------------------------------------------------------------------
// <copyright file="InMemoryTokenManager.cs" company="Andrew Arnott">
//     Copyright (c) Andrew Arnott. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Bluevia.Core {
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using DotNetOpenAuth.OAuth.ChannelElements;
	using DotNetOpenAuth.OAuth.Messages;

	public class InMemoryTokenManager : IConsumerTokenManager {
		private Dictionary<string, string> tokensAndSecrets = new Dictionary<string, string>();

		internal InMemoryTokenManager() {
		}
        public string ConsumerKey { get { return Bluevia.Core.Configuration.Client.Consumer; } internal set { } }
        public string ConsumerSecret { get { return Bluevia.Core.Configuration.Client.ConsumerSecret; } internal set { } }

		#region ITokenManager Members

		public string GetConsumerSecret(string consumerKey) {
			if (consumerKey == this.ConsumerKey) {
				return this.ConsumerSecret;
			} else {
				throw new ArgumentException("Unrecognized consumer key.", "consumerKey");
			}
		}

		public string GetTokenSecret(string token) {
           return this.tokensAndSecrets[token];
		}

		public void StoreNewRequestToken(UnauthorizedTokenRequest request, ITokenSecretContainingMessage response) {
			this.tokensAndSecrets[response.Token] = response.TokenSecret;
		}

        public void StoreNewRequestToken(string token, string secret)
        {
            this.tokensAndSecrets[token] = secret;
        }

		public void ExpireRequestTokenAndStoreNewAccessToken(string consumerToken, string requestToken, string accessToken, string accessTokenSecret) {
            if (!string.IsNullOrEmpty(requestToken))
			    this.tokensAndSecrets.Remove(requestToken);
            if (!string.IsNullOrEmpty(accessToken) && !string.IsNullOrEmpty(accessTokenSecret))
			    this.tokensAndSecrets[accessToken] = accessTokenSecret;
		}

		/// <summary>
		/// Classifies a token as a request token or an access token.
		/// </summary>
		/// <param name="token">The token to classify.</param>
		/// <returns>Request or Access token, or invalid if the token is not recognized.</returns>
		public TokenType GetTokenType(string token) {
			throw new NotImplementedException();
		}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Boolean HaveStoredTokens()
        {
            return this.tokensAndSecrets.Count > 0;
        }

        /// <summary>
        /// return the active token
        /// </summary>
        /// <returns></returns>
        public string getActiveToken()
        {
            List<string> list = new List<string>(tokensAndSecrets.Keys);
            if (list.Count > 0) return list[0];
            else return String.Empty;
        }

		#endregion
	}
}
