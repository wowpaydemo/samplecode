using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Utility.Helpers
{
    public static class HttpHelper
    {

        static readonly HttpClient httpClientObj = new HttpClient();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiurl"></param>
        /// <param name="data"></param>
        /// <param name="method"></param>
        /// <param name="contentType"></param>        
        /// <returns></returns>
        private static async Task<string?> SendRequestAsync(string apiurl, string data, HttpMethod method, string contentType = ContentTypes.Json)
        {
            try
            {

                if (Uri.IsWellFormedUriString(apiurl,UriKind.RelativeOrAbsolute))
                {
                    HttpContent? content = null;

                    if (method != HttpMethod.Get && !string.IsNullOrWhiteSpace(data))
                    {
                        content = new StringContent(data, Encoding.UTF8, contentType);
                    }

                    return await SendRequestAsync(apiurl, httpClientObj, method, content);
                }

                return string.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// IDictionary<string, string> data
        /// </summary>
        /// <param name="data"></param>
        /// <param name="apiurl"></param>
        /// <param name="method"></param>                
        /// <returns></returns>
        private static async Task<string?> SendRequestAsync(IDictionary<string, string> data, string apiurl, HttpMethod method)
        {
            try
            {
                if (Uri.IsWellFormedUriString(apiurl,UriKind.RelativeOrAbsolute))
                {
                    HttpContent? content = method != HttpMethod.Get ? new FormUrlEncodedContent(data) : null;                                        

                    return await SendRequestAsync(apiurl, httpClientObj, method, content);
                }

                return string.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiurl"></param>
        /// <param name="data"></param>
        /// <param name="method"></param>
        /// <param name="credential"></param>
        /// <param name="contentType"></param>        
        /// <returns></returns>
        private static async Task<string?> SendRequestAsync(string apiurl, string data,HttpMethod method, NetworkCredential credential,string contentType = ContentTypes.Json)
        {
            try
            {
                if (Uri.IsWellFormedUriString(apiurl,UriKind.RelativeOrAbsolute))
                {
                    HttpClient oclient;

                    if (credential != null)
                    {
                        var httpClientHandler = new HttpClientHandler
                        {
                            Credentials = credential
                        };

                        oclient = new HttpClient(httpClientHandler);
                    }
                    else
                    {
                        oclient = httpClientObj;
                    }

                    HttpContent? content = null;

                    if (method != HttpMethod.Get && !string.IsNullOrWhiteSpace(data))
                    {
                        content = new StringContent(data, Encoding.UTF8, contentType);
                    }

                    return await SendRequestAsync(apiurl, oclient, method, content);
                }

                return string.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiurl"></param>
        /// <param name="data"></param>
        /// <param name="method"></param>
        /// <param name="authheaderkey"></param>
        /// <param name="authheadervalue"></param>
        /// <param name="contentType"></param>        
        /// <returns></returns>
        private static async Task<string?> SendRequestAsync(string apiurl,string data,HttpMethod method, string authheaderkey, string authheadervalue, string contentType = ContentTypes.Json)
        {
            try
            {
                if (Uri.IsWellFormedUriString(apiurl,UriKind.RelativeOrAbsolute))
                {
                    HttpClient oclient;

                    HttpContent? content = null;

                    if (method != HttpMethod.Get && !string.IsNullOrWhiteSpace(data))
                    {
                        content = new StringContent(data, Encoding.UTF8, contentType);
                    }

                    if (!string.IsNullOrEmpty(authheaderkey) || !string.IsNullOrWhiteSpace(authheadervalue))
                    {
                        oclient = new HttpClient();
                        oclient.DefaultRequestHeaders.Add(authheaderkey, authheadervalue);

                    }
                    else
                    {
                        oclient = httpClientObj;
                    }

                    return await SendRequestAsync(apiurl, oclient, method, content);
                }

                return string.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="apiurl"></param>
        /// <param name="method"></param>
        /// <param name="authheaderkey"></param>
        /// <param name="authheadervalue"></param>        
        /// <returns></returns>
        private static async Task<string?> SendRequestAsync(IDictionary<string, string> data,string apiurl, HttpMethod method, string authheaderkey,string authheadervalue)
        {                     

            try
            {
                if (Uri.IsWellFormedUriString(apiurl,UriKind.RelativeOrAbsolute))
                {
                    HttpClient oclient;

                    HttpContent? content = method != HttpMethod.Get ? new FormUrlEncodedContent(data) : null;

                    if (!string.IsNullOrEmpty(authheaderkey) || !string.IsNullOrWhiteSpace(authheadervalue))
                    {
                        var authValue = new AuthenticationHeaderValue(authheaderkey, authheadervalue);

                        oclient = new HttpClient()
                        {
                            DefaultRequestHeaders = { Authorization = authValue }
                        };
                    }
                    else
                    {
                        oclient = httpClientObj;
                    }

                    return await SendRequestAsync(apiurl, oclient, method, content);
                }

                return string.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }         


        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiurl"></param>
        /// <param name="httpClient"></param>
        /// <param name="method"></param>
        /// <param name="content"></param>        
        /// <returns></returns>

        private static async Task<string?> SendRequestAsync(string apiurl, HttpClient httpClient, HttpMethod method, HttpContent? content = null)
        {
            string? result = "";

            CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(60));

            try
            {
                HttpResponseMessage httpResponse = method.ToString().ToUpper() switch
                {
                    "GET" => await httpClient.GetAsync(apiurl, tokenSource.Token),
                    "POST" => await httpClient.PostAsync(apiurl, content),
                    "PUT" => await httpClient.PutAsync(apiurl, content),
                    "DELETE" => await httpClient.DeleteAsync(apiurl, tokenSource.Token),
                    _ => throw new NotImplementedException(),
                };

                // httpResponse.EnsureSuccessStatusCode();

                using (HttpContent ct = httpResponse.Content)
                {
                    result = await ct.ReadAsStringAsync();
                }

            }
            //catch (OperationCanceledException ex) when (ex.CancellationToken == tokenSource.Token)
            //{
            //    
            //}
            catch (WebException we)
            {
                result = we.ToString();

                if (we.Status != WebExceptionStatus.Timeout)
                {
                    HttpWebResponse? ErrorResponse = (HttpWebResponse)we.Response!;
                    
                    result = ErrorResponse == null ? "" :  new StreamReader(ErrorResponse.GetResponseStream()).ReadToEnd();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }


        /// <summary>
        /// Default contentType:application/json
        /// </summary>
        /// <param name="apiurl"></param>
        /// <param name="data"></param>
        /// <param name="method"></param>
        /// 
        /// <returns></returns>
        public static async Task<string?> RequestAsync(string apiurl, string data, HttpMethod method)
        {
            return await SendRequestAsync(apiurl, data, method, contentType: ContentTypes.Json);
        }



        /// <summary>
        /// Default contentType is ContentTypes.UrlEncode
        /// </summary>
        /// <param name="apiurl"></param>
        /// <param name="method"></param>
        
        /// <returns></returns>
        public static async Task<string?> RequestAsync(string apiurl, HttpMethod method)
        {
            return await SendRequestAsync(apiurl, "", method, contentType: ContentTypes.UrlEncode);
        }

        public static async Task<string?> RequestAsync(string apiurl, HttpMethod method, string authheaderkey, string authheadervalue)
        {
            return await SendRequestAsync(apiurl, "", method, authheaderkey: authheaderkey, authheadervalue: authheadervalue, contentType: ContentTypes.UrlEncode);
        }

        public static async Task<string?> RequestAsync(string apiurl, HttpMethod method, string contentType, string authheaderkey, string authheadervalue)
        {
            return await SendRequestAsync(apiurl, "", method, authheaderkey: authheaderkey, authheadervalue: authheadervalue, contentType: contentType);
        }

        public static async Task<string?> RequestAsync(string apiurl, string data, HttpMethod method, string contentType, string authheaderkey, string authheadervalue)
        {
            return await SendRequestAsync(apiurl, data, method, authheaderkey, authheadervalue, contentType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiurl"></param>
        /// <param name="data"></param>
        /// <param name="method"></param>
        /// <param name="authheaderkey"></param>
        /// <param name="authheadervalue"></param>
        /// <returns></returns>
        public static async Task<string?> RequestAsync(IDictionary<string, string> data, string apiurl, HttpMethod method, string authheaderkey, string authheadervalue)
        {
            return await SendRequestAsync(data, apiurl, method, authheaderkey, authheadervalue);
        }        


        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiurl"></param>
        /// <param name="data"></param>
        /// <param name="method"></param>
        /// <param name="contentType"></param>
        
        /// <returns></returns>
        public static async Task<string?> RequestAsync(string apiurl, string data, HttpMethod method, string contentType)
        {
            return await SendRequestAsync(apiurl, data, method, contentType);
        }



        /// <summary>
        /// /
        /// </summary>
        /// <param name="apiurl"></param>
        /// <param name="data"></param>
        /// <param name="method"></param>
        /// <param name="contentType"></param>
        /// <param name="credential"></param>
        /// <returns></returns>
        public static async Task<string?> RequestAsync(string apiurl, string data, HttpMethod method, string contentType, NetworkCredential networkcredential)
        {
            return await SendRequestAsync(apiurl, data, method, networkcredential, contentType);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiurl"></param>
        /// <param name="data"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public static async Task<string?> RequestAsync(IDictionary<string, string> data, string apiurl, HttpMethod method)
        {
            return await SendRequestAsync(data, apiurl, method);
        }
    }
}
