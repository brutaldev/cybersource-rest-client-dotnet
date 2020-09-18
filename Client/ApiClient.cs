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
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using AuthenticationSdk.core;

namespace CyberSource.Client
{
    /// <summary>
    /// API client is mainly responsible for making the HTTP call to the API backend.
    /// </summary>
    public partial class ApiClient
    {
        private JsonSerializerSettings serializerSettings = new JsonSerializerSettings
        {
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
        };

        /// <summary>
        /// Allows for extending request processing for <see cref="ApiClient"/> generated code.
        /// </summary>
        /// <param name="request">The RestSharp request object</param>
        partial void InterceptRequest(IRestRequest request);

        /// <summary>
        /// Allows for extending response processing for <see cref="ApiClient"/> generated code.
        /// </summary>
        /// <param name="request">The RestSharp request object</param>
        /// <param name="response">The RestSharp response object</param>
        partial void InterceptResponse(IRestRequest request, IRestResponse response);

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient" /> class
        /// with default configuration and base path (https://apitest.cybersource.com).
        /// </summary>
        public ApiClient()
        {
            Configuration = Configuration.Default;
            RestClient = new RestClient("https://apitest.cybersource.com");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient" /> class
        /// with default base path (https://apitest.cybersource.com).
        /// </summary>
        /// <param name="config">An instance of Configuration.</param>
        public ApiClient(Configuration config = null)
        {
            if (config == null)
                Configuration = Configuration.Default;
            else
                Configuration = config;

            RestClient = new RestClient("https://apitest.cybersource.com");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient" /> class
        /// with default configuration.
        /// </summary>
        /// <param name="basePath">The base path.</param>
        public ApiClient(String basePath = "https://apitest.cybersource.com")
        {
           if (String.IsNullOrEmpty(basePath))
                throw new ArgumentException("basePath cannot be empty");

            RestClient = new RestClient(basePath);
            Configuration = Configuration.Default;
        }

        /// <summary>
        /// Gets or sets the default API client for making HTTP calls.
        /// </summary>
        /// <value>The default API client.</value>
        [Obsolete("ApiClient.Default is deprecated, please use 'Configuration.Default.ApiClient' instead.")]
        public static ApiClient Default;

        /// <summary>
        /// Gets or sets the Configuration.
        /// </summary>
        /// <value>An instance of the Configuration.</value>
        public Configuration Configuration { get; set; }

        /// <summary>
        /// Sets the Accept Header Type.
        /// </summary>
        /// <value>User-defined Accept Header Type.</value>
        public string AcceptHeader { get; set; }

        /// <summary>
        /// Gets or sets the RestClient.
        /// </summary>
        /// <value>An instance of the RestClient</value>
        public RestClient RestClient { get; set; }

        /// <summary>
        /// Gets or sets the file name, in which the response to be downloaded.
        /// </summary>
        /// <value>An instance of the Configuration.</value>
        public string DownloadReponseFileName { get; set; }

        // Creates and sets up a RestRequest prior to a call.
        private RestRequest PrepareRequest(
            String path, RestSharp.Method method, Dictionary<String, String> queryParams, Object postBody,
            Dictionary<String, String> headerParams, Dictionary<String, String> formParams,
            Dictionary<String, FileParameter> fileParams, Dictionary<String, String> pathParams,
            String contentType)
        {
            //1.set in the defaultHeaders of configuration

            // Change to path(Request Target) to be sent to Authentication SDK
            // Include Query Params in the Request target
            var firstQueryParam = true;
            foreach (var param in queryParams)
            {
                var key = param.Key;
                var val = param.Value;

                if (!firstQueryParam)
                {
                    path = path + "&" + key + "=" + val;
                }
                else
                {
                    path = path + "?" + key + "=" + val;
                    firstQueryParam = false;
                }
            }
            
            var request = new RestRequest(path, method);

            // add path parameter, if any
            foreach(var param in pathParams)
                request.AddParameter(param.Key, param.Value, ParameterType.UrlSegment);

            // add header parameter, if any
            // 2. passed to this function
            foreach (var param in headerParams)
            {
                if (param.Key == "Authorization")
                {
                    request.AddParameter("Authorization", string.Format("Bearer " + param.Value),
                        ParameterType.HttpHeader);
                }
                else
                    request.AddHeader(param.Key, param.Value);
            }            

            if (postBody == null)
            {
                CallAuthenticationHeaders(method.ToString(), path);
            }
            else
            {
                CallAuthenticationHeaders(method.ToString(), path, postBody.ToString());
            }

            foreach (var param in Configuration.DefaultHeader)
            {
                if (param.Key == "Authorization")
                {
                    request.AddParameter("Authorization", string.Format("Bearer " + param.Value),
                        ParameterType.HttpHeader);
                }
                else
                    request.AddHeader(param.Key, param.Value);
            }

            // add query parameter, if any
            // foreach(var param in queryParams)
            //     request.AddQueryParameter(param.Key, param.Value);

            // add form parameter, if any
            foreach(var param in formParams)
                request.AddParameter(param.Key, param.Value);

            // add file parameter, if any
            foreach(var param in fileParams)
            {
                request.AddFile(param.Value.Name, param.Value.Writer, param.Value.FileName, param.Value.ContentLength, param.Value.ContentType);
            }

            if (postBody != null) // http body (model or byte[]) parameter
            {
                if (postBody.GetType() == typeof(String))
                {
                    request.AddParameter("application/json", postBody, ParameterType.RequestBody);
                }
                else if (postBody.GetType() == typeof(byte[]))
                {
                    request.AddParameter(contentType, postBody, ParameterType.RequestBody);
                }
            }

            return request;
        }

        // Creates and sets up a HttpWebRequest for calls which needs response in a file format.
        private HttpWebRequest PrepareHttpWebRequest(
            String path, RestSharp.Method method, Dictionary<String, String> queryParams, Object postBody,
            Dictionary<String, String> headerParams, Dictionary<String, String> formParams,
            Dictionary<String, FileParameter> fileParams, Dictionary<String, String> pathParams,
            String contentType)
        {
            // Change to path(Request Target) to be sent to Authentication SDK
            // Include Query Params in the Request target
            var firstQueryParam = true;
            foreach (var param in queryParams)
            {
                var key = param.Key;
                var val = param.Value;

                if (!firstQueryParam)
                {
                    path = path + "&" + key + "=" + val;
                }
                else
                {
                    path = path + "?" + key + "=" + val;
                    firstQueryParam = false;
                }
            }

            //initiate a HttpWebRequest object
            HttpWebRequest requestT = (HttpWebRequest)WebRequest.Create(Uri.EscapeUriString("https://" + RestClient.BaseUrl.Host + path));
            requestT.UserAgent = Configuration.UserAgent;

            if (Configuration.Proxy != null)
            {
                requestT.Proxy = Configuration.Proxy;
            }
            requestT.ContentType = contentType;

            // add header parameter, if any
            // passed to this function
            foreach (var param in headerParams)
            {
                if (param.Key == "Accept")
                {
                    requestT.Accept = param.Value;
                }
                else
                    requestT.Headers.Add(param.Key, param.Value);
            }

            //initiate the default authentication headers
            if (postBody == null)
            {
                CallAuthenticationHeaders(method.ToString(), path);
            }
            else
            {
                CallAuthenticationHeaders(method.ToString(), path, postBody.ToString());
            }

            foreach (var param in Configuration.DefaultHeader)
            {
                if (param.Key == "Authorization")
                {
                    requestT.Headers.Add("Authorization", string.Format("Bearer " + param.Value));
                }
                else if (param.Key == "Date")
                {
                    requestT.Date = DateTime.Parse(param.Value);
                }
                else if (param.Key == "Host")
                { }
                else
                    requestT.Headers.Add(param.Key, param.Value);
            }

            return requestT;
        }

        /// <summary>
        /// Makes the HTTP request (Sync).
        /// </summary>
        /// <param name="path">URL path.</param>
        /// <param name="method">HTTP method.</param>
        /// <param name="queryParams">Query parameters.</param>
        /// <param name="postBody">HTTP body (POST request).</param>
        /// <param name="headerParams">Header parameters.</param>
        /// <param name="formParams">Form parameters.</param>
        /// <param name="fileParams">File parameters.</param>
        /// <param name="pathParams">Path parameters.</param>
        /// <param name="contentType">Content Type of the request</param>
        /// <returns>Object</returns>
        public Object CallApi(
            String path, RestSharp.Method method, Dictionary<String, String> queryParams, Object postBody,
            Dictionary<String, String> headerParams, Dictionary<String, String> formParams,
            Dictionary<String, FileParameter> fileParams, Dictionary<String, String> pathParams,
            String contentType)
        {
            //declared separately to handle both regular call and download file calls
            int httpResponseStatusCode;
            IList<Parameter> httpResponseHeaders = null;
            string httpResponseData = string.Empty;

            var response = new RestResponse();

            if (!string.IsNullOrEmpty(AcceptHeader))
            {
                var defaultAcceptHeader = "," + headerParams["Accept"];
                defaultAcceptHeader = AcceptHeader + defaultAcceptHeader.Replace("," + AcceptHeader, "");
                headerParams.Remove("Accept");
                headerParams.Add("Accept", defaultAcceptHeader);
            }

            //check if the Response is to be downloaded as a file, this value to be set by the calling API class
            if (string.IsNullOrEmpty(DownloadReponseFileName))
            {
                var request = PrepareRequest(
                    path, method, queryParams, postBody, headerParams, formParams, fileParams,
                    pathParams, contentType);

                // set timeout
                RestClient.Timeout = Configuration.Timeout;
                // set user agent
                RestClient.UserAgent = Configuration.UserAgent;
            
                RestClient.ClearHandlers();

                if (Configuration.Proxy != null)
                {
                    RestClient.Proxy = Configuration.Proxy;
                }            

                InterceptRequest(request);
                response = (RestResponse) RestClient.Execute(request);
                InterceptResponse(request, response);
            }
            else
            {
                //prepare a HttpWebRequest request object
                var requestT = PrepareHttpWebRequest(path, method, queryParams, postBody, headerParams, formParams, fileParams, pathParams, contentType);

                //getting the response stream using httpwebrequest
                HttpWebResponse responseT = (HttpWebResponse)requestT.GetResponse();
                using (Stream responseStream = responseT.GetResponseStream())
                {
                    try
                    {
                        //setting high timeout to accomodate large files till 2GB, need to revisit for a dynamic approach
                        responseStream.ReadTimeout = 8000000;
                        responseStream.WriteTimeout = 9000000;
                        using (Stream fileStream = File.OpenWrite(@DownloadReponseFileName))
                        {
                            byte[] buffer = new byte[4096];
                            int bytesRead = responseStream.Read(buffer, 0, 4096);
                            while (bytesRead > 0)
                            {
                                fileStream.Write(buffer, 0, bytesRead);
                                bytesRead = responseStream.Read(buffer, 0, 4096);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw new ApiException(-1, $"Error writing to path : {DownloadReponseFileName}");
                    }
                }

                //setting the generic response with response headers
                foreach (var header in responseT.Headers)
                {
                    response.Headers.Add(new Parameter(header.ToString(), String.Join(",", responseT.Headers.GetValues(header.ToString()).ToArray()), ParameterType.HttpHeader));
                }

                //setting the generic RestResponse which is returned to the calling class
                response.StatusCode = responseT.StatusCode;
                if (responseT.StatusCode == HttpStatusCode.OK)
                {
                    response.Content = "Custom Message: Response downloaded to file " + DownloadReponseFileName;
                }
                else if (responseT.StatusCode == HttpStatusCode.NotFound)
                {
                    response.Content = "Custom Message: The requested resource is not found. Please try again later.";
                }
                else
                {
                    response.Content = responseT.StatusDescription;
                }
            }

            Configuration.DefaultHeader.Clear();

            httpResponseStatusCode = (int)response.StatusCode;
            httpResponseHeaders = response.Headers;
            httpResponseData = response.Content;

            Console.WriteLine($"\n");
            Console.WriteLine($"RESPONSE STATUS CODE: {httpResponseStatusCode}");

            Console.WriteLine($"\n");
            Console.WriteLine("RESPONSE HEADERS:-");

            foreach (var header in httpResponseHeaders)
            {
                Console.WriteLine(header);
            }
            Console.WriteLine($"\n");

            if (!string.IsNullOrEmpty(httpResponseData))
            {
                Console.WriteLine("RESPONSE BODY:-");
                Console.WriteLine(httpResponseData);
                Console.WriteLine($"\n");
            }

            return (Object) response;
        }

        /// <summary>
        /// Makes the asynchronous HTTP request.
        /// </summary>
        /// <param name="path">URL path.</param>
        /// <param name="method">HTTP method.</param>
        /// <param name="queryParams">Query parameters.</param>
        /// <param name="postBody">HTTP body (POST request).</param>
        /// <param name="headerParams">Header parameters.</param>
        /// <param name="formParams">Form parameters.</param>
        /// <param name="fileParams">File parameters.</param>
        /// <param name="pathParams">Path parameters.</param>
        /// <param name="contentType">Content type.</param>
        /// <returns>The Task instance.</returns>
        public async System.Threading.Tasks.Task<Object> CallApiAsync(
            String path, RestSharp.Method method, Dictionary<String, String> queryParams, Object postBody,
            Dictionary<String, String> headerParams, Dictionary<String, String> formParams,
            Dictionary<String, FileParameter> fileParams, Dictionary<String, String> pathParams,
            String contentType)
        {
            var request = PrepareRequest(
                path, method, queryParams, postBody, headerParams, formParams, fileParams,
                pathParams, contentType);
            InterceptRequest(request);
            var response = await RestClient.ExecuteAsync(request);
            InterceptResponse(request, response);
            return (Object)response;
        }

        /// <summary>
        /// Escape string (url-encoded).
        /// </summary>
        /// <param name="str">String to be escaped.</param>
        /// <returns>Escaped string.</returns>
        public string EscapeString(string str)
        {
            return UrlEncode(str);
        }

        /// <summary>
        /// Create FileParameter based on Stream.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="stream">Input stream.</param>
        /// <returns>FileParameter.</returns>
        public FileParameter ParameterToFile(string name, Stream stream)
        {
            if (stream is FileStream)
                return FileParameter.Create(name, ReadAsBytes(stream), Path.GetFileName(((FileStream)stream).Name));
            else
                return FileParameter.Create(name, ReadAsBytes(stream), "no_file_name_provided");
        }

        /// <summary>
        /// If parameter is DateTime, output in a formatted string (default ISO 8601), customizable with Configuration.DateTime.
        /// If parameter is a list, join the list with ",".
        /// Otherwise just return the string.
        /// </summary>
        /// <param name="obj">The parameter (header, path, query, form).</param>
        /// <returns>Formatted string.</returns>
        public string ParameterToString(object obj)
        {
            if (obj is DateTime) {
                string outDateTime = null;

                if (((DateTime)obj).TimeOfDay.CompareTo(new TimeSpan(0, 0, 0)) == 0) {
                    outDateTime = ((DateTime?)obj).Value.ToString("yyyy-MM-dd");
                }
                else
                {
                    outDateTime = ((DateTime?)obj).Value.ToString("yyyy-MM-ddTHH:mm:ssZ");
                }
                
                return outDateTime;
            }
            else if (obj is DateTimeOffset) {
                return ((DateTimeOffset)obj).ToString (Configuration.DateTimeFormat);
            }
            else if (obj is IList)
            {
                var flattenedString = new StringBuilder();
                foreach (var param in (IList)obj)
                {
                    if (flattenedString.Length > 0)
                        flattenedString.Append(",");
                    flattenedString.Append(param);
                }
                return flattenedString.ToString();
            }
            else
                return Convert.ToString (obj);
        }

        /// <summary>
        /// Deserialize the JSON string into a proper object.
        /// </summary>
        /// <param name="response">The HTTP response.</param>
        /// <param name="type">Object type.</param>
        /// <returns>Object representation of the JSON string.</returns>
        public object Deserialize(IRestResponse response, Type type)
        {
            IList<Parameter> headers = response.Headers;
            if (type == typeof(byte[])) // return byte array
            {
                return response.RawBytes;
            }

            if (type == typeof(Stream))
            {
                if (headers != null)
                {
                    var filePath = String.IsNullOrEmpty(Configuration.TempFolderPath)
                        ? Path.GetTempPath()
                        : Configuration.TempFolderPath;
                    var regex = new Regex(@"Content-Disposition=.*filename=['""]?([^'""\s]+)['""]?$");
                    foreach (var header in headers)
                    {
                        var match = regex.Match(header.ToString());
                        if (match.Success)
                        {
                            string fileName = filePath + SanitizeFilename(match.Groups[1].Value.Replace("\"", "").Replace("'", ""));
                            File.WriteAllBytes(fileName, response.RawBytes);
                            return new FileStream(fileName, FileMode.Open);
                        }
                    }
                }
                var stream = new MemoryStream(response.RawBytes);
                return stream;
            }

            if ( type == typeof(DateTime?)) // return a datetime object
            {
                return DateTime.Parse(response.Content,  null, System.Globalization.DateTimeStyles.RoundtripKind);
            }

            if (type == typeof(String) || type.Name.StartsWith("System.Nullable")) // return primitive type
            {
                return ConvertType(response.Content, type);
            }

            // at this point, it must be a model (json)
            try
            {
                return JsonConvert.DeserializeObject(response.Content, type, serializerSettings);
            }
            catch (Exception e)
            {
                throw new ApiException(500, e.Message);
            }
        }

        /// <summary>
        /// Serialize an input (model) into JSON string
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>JSON string.</returns>
        public String Serialize(object obj)
        {
            try
            {
                return obj != null ? JsonConvert.SerializeObject(obj) : null;
            }
            catch (Exception e)
            {
                throw new ApiException(500, e.Message);
            }
        }

        /// <summary>
        /// Select the Content-Type header's value from the given content-type array:
        /// if JSON exists in the given array, use it;
        /// otherwise use the first one defined in 'consumes'
        /// </summary>
        /// <param name="contentTypes">The Content-Type array to select from.</param>
        /// <returns>The Content-Type header to use.</returns>
        public String SelectHeaderContentType(String[] contentTypes)
        {
            if (contentTypes.Length == 0)
                return null;

            if (contentTypes.Contains("application/json", StringComparer.OrdinalIgnoreCase))
                return "application/json";

            return contentTypes[0]; // use the first content type specified in 'consumes'
        }

        /// <summary>
        /// Select the Accept header's value from the given accepts array:
        /// if JSON exists in the given array, use it;
        /// otherwise use all of them (joining into a string)
        /// </summary>
        /// <param name="accepts">The accepts array to select from.</param>
        /// <returns>The Accept header to use.</returns>
        public String SelectHeaderAccept(String[] accepts)
        {
            if (accepts.Length == 0)
                return null;

            if (accepts.Contains("application/json", StringComparer.OrdinalIgnoreCase))
                return "application/json";

            return String.Join(",", accepts);
        }

        /// <summary>
        /// Encode string in base64 format.
        /// </summary>
        /// <param name="text">String to be encoded.</param>
        /// <returns>Encoded string.</returns>
        public static string Base64Encode(string text)
        {
            return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(text));
        }

        /// <summary>
        /// Dynamically cast the object into target type.
        /// Ref: http://stackoverflow.com/questions/4925718/c-dynamic-runtime-cast
        /// </summary>
        /// <param name="source">Object to be casted</param>
        /// <param name="dest">Target type</param>
        /// <returns>Casted object</returns>
        public static dynamic ConvertType(dynamic source, Type dest)
        {
            return Convert.ChangeType(source, dest);
        }

        /// <summary>
        /// Convert stream to byte array
        /// Credit/Ref: http://stackoverflow.com/a/221941/677735
        /// </summary>
        /// <param name="input">Input stream to be converted</param>
        /// <returns>Byte array</returns>
        public static byte[] ReadAsBytes(Stream input)
        {
            byte[] buffer = new byte[16*1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        /// <summary>
        /// URL encode a string
        /// Credit/Ref: https://github.com/restsharp/RestSharp/blob/master/RestSharp/Extensions/StringExtensions.cs#L50
        /// </summary>
        /// <param name="input">String to be URL encoded</param>
        /// <returns>Byte array</returns>
        public static string UrlEncode(string input)
        {
            const int maxLength = 32766;

            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            if (input.Length <= maxLength)
            {
                return Uri.EscapeDataString(input);
            }

            StringBuilder sb = new StringBuilder(input.Length * 2);
            int index = 0;

            while (index < input.Length)
            {
                int length = Math.Min(input.Length - index, maxLength);
                string subString = input.Substring(index, length);

                sb.Append(Uri.EscapeDataString(subString));
                index += subString.Length;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Sanitize filename by removing the path
        /// </summary>
        /// <param name="filename">Filename</param>
        /// <returns>Filename</returns>
        public static string SanitizeFilename(string filename)
        {
            Match match = Regex.Match(filename, @".*[/\\](.*)$");

            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            else
            {
                return filename;
            }
        }
        
        /// Calling the Authentication SDK to Generate Request Headers necessary for Authentication        
        public void CallAuthenticationHeaders(string requestType, string requestTarget, string requestJsonData = null)
        {
            requestTarget = Uri.EscapeUriString(requestTarget);

            var merchantConfig = Configuration.MerchantConfigDictionaryObj != null
                ? new MerchantConfig(Configuration.MerchantConfigDictionaryObj)
                : new MerchantConfig();

            merchantConfig.RequestType = requestType;
            merchantConfig.RequestTarget = requestTarget;
            merchantConfig.RequestJsonData = requestJsonData;

            var authorize = new Authorize(merchantConfig);

            //these are the Request Headers to be sent along with the HTTP Request
            var authenticationHeaders = new Dictionary<string, string>();

            if (merchantConfig.IsJwtTokenAuthType)
            {
                //generate token and set JWT token headers
                var jwtToken = authorize.GetToken();
                authenticationHeaders.Add("Authorization", jwtToken.BearerToken);
            }
            else if (merchantConfig.IsHttpSignAuthType)
            {
                //generate signature and set HTTP Signature headers
                var httpSign = authorize.GetSignature();
                authenticationHeaders.Add("v-c-merchant-id", httpSign.MerchantId);
                authenticationHeaders.Add("Date", httpSign.GmtDateTime);
                authenticationHeaders.Add("Host", httpSign.HostName);
                authenticationHeaders.Add("Signature", httpSign.SignatureParam);

                if (merchantConfig.IsPostRequest || merchantConfig.IsPutRequest || merchantConfig.IsPatchRequest)
                    authenticationHeaders.Add("Digest", httpSign.Digest);
            }

            if (!string.IsNullOrEmpty(Configuration.ClientId))
            {
                authenticationHeaders.Add("v-c-client-id", Configuration.ClientId);
            }

            // if (!string.IsNullOrEmpty(Configuration.SolutionId))
            // {
            //     authenticationHeaders.Add("v-c-solution-id", Configuration.SolutionId);
            // }
            
            if (Configuration.Proxy == null && merchantConfig.UseProxy != null)
            {
                if (bool.Parse(merchantConfig.UseProxy))
                {
                    int proxyPortTest;

                    if (!string.IsNullOrWhiteSpace(merchantConfig.ProxyAddress) && int.TryParse(merchantConfig.ProxyPort, out proxyPortTest)) 
                    {
                        WebProxy proxy = new WebProxy(merchantConfig.ProxyAddress, proxyPortTest);
                        
                        if (!string.IsNullOrWhiteSpace(merchantConfig.ProxyUsername) && !string.IsNullOrWhiteSpace(merchantConfig.ProxyPassword)) 
                        {
                            proxy.Credentials = new NetworkCredential(merchantConfig.ProxyUsername, merchantConfig.ProxyPassword);
                        }
                        
                        Configuration.AddWebProxy(proxy);
                    }
                }
            }

            //Set the Configuration
            Configuration.DefaultHeader = authenticationHeaders;
            RestClient = new RestClient("https://" + merchantConfig.HostName);
            
            if (Configuration.Proxy != null)
            {
                RestClient.Proxy = Configuration.Proxy;
            }
        }
    }
}
