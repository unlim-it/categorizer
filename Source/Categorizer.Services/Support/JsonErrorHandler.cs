namespace Categorizer.Services.Support
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization.Json;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Dispatcher;

    using Categorizer.Services.Contracts;

    public class JsonErrorHandler : IErrorHandler
    {
        #region Public Method(s)
        #region IErrorHandler Members
        ///
        /// Is the error always handled in this class?
        ///
        public bool HandleError(Exception error)
        {
            return true;
        }

        ///
        /// Provide the Json fault message
        ///
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            fault = this.GetJsonFaultMessage(version, error);

            this.ApplyJsonSettings(ref fault);
            this.ApplyHttpResponseSettings(ref fault, System.Net.HttpStatusCode.BadRequest, "Bad Request");
        }
        #endregion
        #endregion

        #region Protected Method(s)
        ///
        /// Apply Json settings to the message
        ///
        protected virtual void ApplyJsonSettings(ref Message fault)
        {
            // Use JSON encoding
            var jsonFormatting =
              new WebBodyFormatMessageProperty(WebContentFormat.Json);
            fault.Properties.Add(WebBodyFormatMessageProperty.Name, jsonFormatting);
        }

        ///
        /// Get the HttpResponseMessageProperty
        ///
        protected virtual void ApplyHttpResponseSettings(
          ref Message fault, System.Net.HttpStatusCode statusCode,
          string statusDescription)
        {
            var httpResponse = new HttpResponseMessageProperty()
            {
                StatusCode = statusCode,
                StatusDescription = statusDescription
            };
            fault.Properties.Add(HttpResponseMessageProperty.Name, httpResponse);
        }

        ///
        /// Get the json fault message from the provided error
        ///
        protected virtual Message GetJsonFaultMessage(MessageVersion version, Exception error)
        {
            CategorizerFaultBase detail = null;
            var knownTypes = new List<Type>();
            if ((error is FaultException) && (error.GetType().GetProperty("Detail") != null))
            {
                detail = (error.GetType().GetProperty("Detail").GetGetMethod()
                    .Invoke(error, null) as CategorizerFaultBase);

                knownTypes.Add(detail.GetType());
            }

            var faultMessage = Message.CreateMessage(version, "", detail,
              new DataContractJsonSerializer(detail.GetType(), knownTypes));

            return faultMessage;
        }

        #endregion
    }
}