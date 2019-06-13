/* 
 * CyberSource Merged Spec
 *
 * All CyberSource API specs merged together. These are available at https://developer.cybersource.com/api/reference/api-reference.html
 *
 * OpenAPI spec version: 0.0.1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using CyberSource.Client;
using CyberSource.Model;

namespace CyberSource.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface INotificationOfChangesApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get Notification Of Changes
        /// </summary>
        /// <remarks>
        /// Download the Notification of Change report. This report shows eCheck-related fields updated as a result of a response to an eCheck settlement transaction. 
        /// </remarks>
        /// <exception cref="CyberSource.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="startTime">Valid report Start Time in **ISO 8601 format** Please refer the following link to know more about ISO 8601 format. - https://xml2rfc.tools.ietf.org/public/rfc/html/rfc3339.html#anchor14   **Example date format:**   - yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ (e.g. 2018-01-01T00:00:00.000Z) </param>
        /// <param name="endTime">Valid report End Time in **ISO 8601 format** Please refer the following link to know more about ISO 8601 format. - https://xml2rfc.tools.ietf.org/public/rfc/html/rfc3339.html#anchor14   **Example date format:**   - yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ (e.g. 2018-01-01T00:00:00.000Z) </param>
        /// <returns>ReportingV3NotificationofChangesGet200Response</returns>
        ReportingV3NotificationofChangesGet200Response GetNotificationOfChangeReport (DateTime? startTime, DateTime? endTime);

        /// <summary>
        /// Get Notification Of Changes
        /// </summary>
        /// <remarks>
        /// Download the Notification of Change report. This report shows eCheck-related fields updated as a result of a response to an eCheck settlement transaction. 
        /// </remarks>
        /// <exception cref="CyberSource.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="startTime">Valid report Start Time in **ISO 8601 format** Please refer the following link to know more about ISO 8601 format. - https://xml2rfc.tools.ietf.org/public/rfc/html/rfc3339.html#anchor14   **Example date format:**   - yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ (e.g. 2018-01-01T00:00:00.000Z) </param>
        /// <param name="endTime">Valid report End Time in **ISO 8601 format** Please refer the following link to know more about ISO 8601 format. - https://xml2rfc.tools.ietf.org/public/rfc/html/rfc3339.html#anchor14   **Example date format:**   - yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ (e.g. 2018-01-01T00:00:00.000Z) </param>
        /// <returns>ApiResponse of ReportingV3NotificationofChangesGet200Response</returns>
        ApiResponse<ReportingV3NotificationofChangesGet200Response> GetNotificationOfChangeReportWithHttpInfo (DateTime? startTime, DateTime? endTime);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Get Notification Of Changes
        /// </summary>
        /// <remarks>
        /// Download the Notification of Change report. This report shows eCheck-related fields updated as a result of a response to an eCheck settlement transaction. 
        /// </remarks>
        /// <exception cref="CyberSource.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="startTime">Valid report Start Time in **ISO 8601 format** Please refer the following link to know more about ISO 8601 format. - https://xml2rfc.tools.ietf.org/public/rfc/html/rfc3339.html#anchor14   **Example date format:**   - yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ (e.g. 2018-01-01T00:00:00.000Z) </param>
        /// <param name="endTime">Valid report End Time in **ISO 8601 format** Please refer the following link to know more about ISO 8601 format. - https://xml2rfc.tools.ietf.org/public/rfc/html/rfc3339.html#anchor14   **Example date format:**   - yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ (e.g. 2018-01-01T00:00:00.000Z) </param>
        /// <returns>Task of ReportingV3NotificationofChangesGet200Response</returns>
        System.Threading.Tasks.Task<ReportingV3NotificationofChangesGet200Response> GetNotificationOfChangeReportAsync (DateTime? startTime, DateTime? endTime);

        /// <summary>
        /// Get Notification Of Changes
        /// </summary>
        /// <remarks>
        /// Download the Notification of Change report. This report shows eCheck-related fields updated as a result of a response to an eCheck settlement transaction. 
        /// </remarks>
        /// <exception cref="CyberSource.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="startTime">Valid report Start Time in **ISO 8601 format** Please refer the following link to know more about ISO 8601 format. - https://xml2rfc.tools.ietf.org/public/rfc/html/rfc3339.html#anchor14   **Example date format:**   - yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ (e.g. 2018-01-01T00:00:00.000Z) </param>
        /// <param name="endTime">Valid report End Time in **ISO 8601 format** Please refer the following link to know more about ISO 8601 format. - https://xml2rfc.tools.ietf.org/public/rfc/html/rfc3339.html#anchor14   **Example date format:**   - yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ (e.g. 2018-01-01T00:00:00.000Z) </param>
        /// <returns>Task of ApiResponse (ReportingV3NotificationofChangesGet200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<ReportingV3NotificationofChangesGet200Response>> GetNotificationOfChangeReportAsyncWithHttpInfo (DateTime? startTime, DateTime? endTime);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class NotificationOfChangesApi : INotificationOfChangesApi
    {
        private CyberSource.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationOfChangesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public NotificationOfChangesApi(String basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));

            ExceptionFactory = CyberSource.Client.Configuration.DefaultExceptionFactory;

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationOfChangesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public NotificationOfChangesApi(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = CyberSource.Client.Configuration.DefaultExceptionFactory;

            this.Configuration.ApiClient.Configuration = this.Configuration;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public CyberSource.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public Dictionary<String, String> DefaultHeader()
        {
            return this.Configuration.DefaultHeader;
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// Get Notification Of Changes Download the Notification of Change report. This report shows eCheck-related fields updated as a result of a response to an eCheck settlement transaction. 
        /// </summary>
        /// <exception cref="CyberSource.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="startTime">Valid report Start Time in **ISO 8601 format** Please refer the following link to know more about ISO 8601 format. - https://xml2rfc.tools.ietf.org/public/rfc/html/rfc3339.html#anchor14   **Example date format:**   - yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ (e.g. 2018-01-01T00:00:00.000Z) </param>
        /// <param name="endTime">Valid report End Time in **ISO 8601 format** Please refer the following link to know more about ISO 8601 format. - https://xml2rfc.tools.ietf.org/public/rfc/html/rfc3339.html#anchor14   **Example date format:**   - yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ (e.g. 2018-01-01T00:00:00.000Z) </param>
        /// <returns>ReportingV3NotificationofChangesGet200Response</returns>
        public ReportingV3NotificationofChangesGet200Response GetNotificationOfChangeReport (DateTime? startTime, DateTime? endTime)
        {
             ApiResponse<ReportingV3NotificationofChangesGet200Response> localVarResponse = GetNotificationOfChangeReportWithHttpInfo(startTime, endTime);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get Notification Of Changes Download the Notification of Change report. This report shows eCheck-related fields updated as a result of a response to an eCheck settlement transaction. 
        /// </summary>
        /// <exception cref="CyberSource.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="startTime">Valid report Start Time in **ISO 8601 format** Please refer the following link to know more about ISO 8601 format. - https://xml2rfc.tools.ietf.org/public/rfc/html/rfc3339.html#anchor14   **Example date format:**   - yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ (e.g. 2018-01-01T00:00:00.000Z) </param>
        /// <param name="endTime">Valid report End Time in **ISO 8601 format** Please refer the following link to know more about ISO 8601 format. - https://xml2rfc.tools.ietf.org/public/rfc/html/rfc3339.html#anchor14   **Example date format:**   - yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ (e.g. 2018-01-01T00:00:00.000Z) </param>
        /// <returns>ApiResponse of ReportingV3NotificationofChangesGet200Response</returns>
        public ApiResponse< ReportingV3NotificationofChangesGet200Response > GetNotificationOfChangeReportWithHttpInfo (DateTime? startTime, DateTime? endTime)
        {
            // verify the required parameter 'startTime' is set
            if (startTime == null)
                throw new ApiException(400, "Missing required parameter 'startTime' when calling NotificationOfChangesApi->GetNotificationOfChangeReport");
            // verify the required parameter 'endTime' is set
            if (endTime == null)
                throw new ApiException(400, "Missing required parameter 'endTime' when calling NotificationOfChangesApi->GetNotificationOfChangeReport");

            var localVarPath = $"/reporting/v3/notification-of-changes?startTime={startTime.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")}&endTime={endTime.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json;charset=utf-8"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/hal+json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            //if (startTime != null) localVarQueryParams.Add("startTime", Configuration.ApiClient.ParameterToString(startTime)); // query parameter
            //if (endTime != null) localVarQueryParams.Add("endTime", Configuration.ApiClient.ParameterToString(endTime)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetNotificationOfChangeReport", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ReportingV3NotificationofChangesGet200Response>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ReportingV3NotificationofChangesGet200Response) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ReportingV3NotificationofChangesGet200Response)));
        }

        /// <summary>
        /// Get Notification Of Changes Download the Notification of Change report. This report shows eCheck-related fields updated as a result of a response to an eCheck settlement transaction. 
        /// </summary>
        /// <exception cref="CyberSource.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="startTime">Valid report Start Time in **ISO 8601 format** Please refer the following link to know more about ISO 8601 format. - https://xml2rfc.tools.ietf.org/public/rfc/html/rfc3339.html#anchor14   **Example date format:**   - yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ (e.g. 2018-01-01T00:00:00.000Z) </param>
        /// <param name="endTime">Valid report End Time in **ISO 8601 format** Please refer the following link to know more about ISO 8601 format. - https://xml2rfc.tools.ietf.org/public/rfc/html/rfc3339.html#anchor14   **Example date format:**   - yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ (e.g. 2018-01-01T00:00:00.000Z) </param>
        /// <returns>Task of ReportingV3NotificationofChangesGet200Response</returns>
        public async System.Threading.Tasks.Task<ReportingV3NotificationofChangesGet200Response> GetNotificationOfChangeReportAsync (DateTime? startTime, DateTime? endTime)
        {
             ApiResponse<ReportingV3NotificationofChangesGet200Response> localVarResponse = await GetNotificationOfChangeReportAsyncWithHttpInfo(startTime, endTime);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get Notification Of Changes Download the Notification of Change report. This report shows eCheck-related fields updated as a result of a response to an eCheck settlement transaction. 
        /// </summary>
        /// <exception cref="CyberSource.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="startTime">Valid report Start Time in **ISO 8601 format** Please refer the following link to know more about ISO 8601 format. - https://xml2rfc.tools.ietf.org/public/rfc/html/rfc3339.html#anchor14   **Example date format:**   - yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ (e.g. 2018-01-01T00:00:00.000Z) </param>
        /// <param name="endTime">Valid report End Time in **ISO 8601 format** Please refer the following link to know more about ISO 8601 format. - https://xml2rfc.tools.ietf.org/public/rfc/html/rfc3339.html#anchor14   **Example date format:**   - yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ (e.g. 2018-01-01T00:00:00.000Z) </param>
        /// <returns>Task of ApiResponse (ReportingV3NotificationofChangesGet200Response)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ReportingV3NotificationofChangesGet200Response>> GetNotificationOfChangeReportAsyncWithHttpInfo (DateTime? startTime, DateTime? endTime)
        {
            // verify the required parameter 'startTime' is set
            if (startTime == null)
                throw new ApiException(400, "Missing required parameter 'startTime' when calling NotificationOfChangesApi->GetNotificationOfChangeReport");
            // verify the required parameter 'endTime' is set
            if (endTime == null)
                throw new ApiException(400, "Missing required parameter 'endTime' when calling NotificationOfChangesApi->GetNotificationOfChangeReport");

            var localVarPath = $"/reporting/v3/notification-of-changes?startTime={startTime.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")}&endTime={endTime.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json;charset=utf-8"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/hal+json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            //if (startTime != null) localVarQueryParams.Add("startTime", Configuration.ApiClient.ParameterToString(startTime)); // query parameter
            //if (endTime != null) localVarQueryParams.Add("endTime", Configuration.ApiClient.ParameterToString(endTime)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetNotificationOfChangeReport", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ReportingV3NotificationofChangesGet200Response>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ReportingV3NotificationofChangesGet200Response) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ReportingV3NotificationofChangesGet200Response)));
        }

    }
}
