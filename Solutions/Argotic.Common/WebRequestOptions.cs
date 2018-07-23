namespace Argotic.Common
{
    using System;
    using System.Net;
    using System.Net.Cache;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    using System.Security.Principal;

    /// <summary>
    /// Holds options that should be applied to web requests.
    /// </summary>
    [Serializable]
    public class WebRequestOptions
    {
        private AuthenticationLevel? authenticationLevel;
        [NonSerialized]
        private RequestCachePolicy cachePolicy;
        private string connectionGroupName;
        private ICredentials credentials;
        private WebHeaderCollection headers;
        private TokenImpersonationLevel? impersonationLevel;
        private bool? preAuthenticate;
        private IWebProxy proxy;
        private int? timeout;
        private bool? useDefaultCredentials;

        private long? contentOffset;
        private bool? enableSsl;
        private string renameTo;
        private bool? useBinary;
        private bool? usePassive;

        private string accept;
        private bool? allowAutoRedirect;
        private bool? allowWriteStreamBuffering;
        private DecompressionMethods? automaticDecompression;
        private string connection;
        private HttpContinueDelegate continueDelegate;
        private CookieContainer cookieContainer;
        private string expect;
        private int? maximumAutomaticRedirections;
        private int? maximumResponseHeadersLength;
        private string mediaType;
        private bool? pipelined;
        private Version protocolVersion;
        private string referer;
        private bool? sendChunked;
        private string transferEncoding;
        private bool? unsafeAuthenticatedConnectionSharing;
        private string userAgent;

        private X509CertificateCollection clientCertificates;
        private bool? keepAlive;
        private int? readWriteTimeout;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebRequestOptions"/> class.
        /// </summary>
        public WebRequestOptions()
            : this(null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebRequestOptions"/> class using the specified <see cref="ICredentials">credentials</see>.
        /// </summary>
        /// <param name="credentials">
        ///     A <see cref="ICredentials"/> that provides the proper set of credentials to the source resource when required. This value can be <b>null</b>.
        /// </param>
        public WebRequestOptions(ICredentials credentials)
            : this(credentials, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebRequestOptions"/> class using the specified <see cref="ICredentials">credentials</see> and  <see cref="IWebProxy">proxy</see>.
        /// </summary>
        /// <param name="credentials">
        ///     A <see cref="ICredentials"/> that provides the proper set of credentials to the source resource when required. This value can be <b>null</b>.
        /// </param>
        /// <param name="proxy">
        ///     A <see cref="IWebProxy"/> that provides proxy access to the source resource when required. This value can be <b>null</b>.
        /// </param>
        public WebRequestOptions(ICredentials credentials, IWebProxy proxy)
        {
            this.allowAutoRedirect = true;
            this.keepAlive = true;
            this.credentials = credentials;
            this.proxy = proxy;

            if (credentials == null)
            {
                this.useDefaultCredentials = true;
            }
        }

        /// <summary>Gets or sets values indicating the level of authentication and impersonation used for this request.</summary>
        public AuthenticationLevel? AuthenticationLevel
        {
            get { return this.authenticationLevel; }
            set { this.authenticationLevel = value; }
        }

        /// <summary>Gets or sets the cache policy for this request.</summary>
        public RequestCachePolicy CachePolicy
        {
            get { return this.cachePolicy; }
            set { this.cachePolicy = value; }
        }

        /// <summary>Gets or sets the name of the connection group for the request.</summary>
        public string ConnectionGroupName
        {
            get { return this.connectionGroupName; }
            set { this.connectionGroupName = value; }
        }

        /// <summary>Gets or sets the network credentials used for authenticating the request with the Internet resource.</summary>
        public ICredentials Credentials
        {
            get { return this.credentials; }
            set { this.credentials = value; }
        }

        /// <summary>Gets or sets the collection of header name/value pairs associated with the request.</summary>
        public WebHeaderCollection Headers
        {
            get { return this.headers; }
            set { this.headers = value; }
        }

        /// <summary>Gets or sets the impersonation level for the current request.</summary>
        public TokenImpersonationLevel? ImpersonationLevel
        {
            get { return this.impersonationLevel; }
            set { this.impersonationLevel = value; }
        }

        /// <summary>Gets or sets indicates whether to pre-authenticate the request.</summary>
        public bool? PreAuthenticate
        {
            get { return this.preAuthenticate; }
            set { this.preAuthenticate = value; }
        }

        /// <summary>Gets or sets the network proxy to use to access this Internet resource.</summary>
        public IWebProxy Proxy
        {
            get { return this.proxy; }
            set { this.proxy = value; }
        }

        /// <summary>Gets or sets the length of time before the request times out.</summary>
        public int? Timeout
        {
            get { return this.timeout; }
            set { this.timeout = value; }
        }

        /// <summary>Gets or sets a <see cref="T:System.Boolean"/> value that controls whether <see cref="P:System.Net.CredentialCache.DefaultCredentials"></see> are sent with requests.</summary>
        public bool? UseDefaultCredentials
        {
            get { return this.useDefaultCredentials; }
            set { this.useDefaultCredentials = value; }
        }

        /// <summary>Gets or sets a byte offset into the file being downloaded by this request.</summary>
        public long? ContentOffset
        {
            get { return this.contentOffset; }
            set { this.contentOffset = value; }
        }

        /// <summary>Gets or sets a <see cref="T:System.Boolean"/> that specifies that an SSL connection should be used.</summary>
        public bool? EnableSsl
        {
            get { return this.enableSsl; }
            set { this.enableSsl = value; }
        }

        /// <summary>Gets or sets the new name of a file being renamed.</summary>
        public string RenameTo
        {
            get { return this.renameTo; }
            set { this.renameTo = value; }
        }

        /// <summary>Gets or sets a <see cref="T:System.Boolean"/> value that specifies the data type for file transfers.</summary>
        public bool? UseBinary
        {
            get { return this.useBinary; }
            set { this.useBinary = value; }
        }

        /// <summary>Gets or sets the behavior of a client application's data transfer process.</summary>
        public bool? UsePassive
        {
            get { return this.usePassive; }
            set { this.usePassive = value; }
        }

        /// <summary>Gets or sets the value of the Accept HTTP header.</summary>
        public string Accept
        {
            get { return this.accept; }
            set { this.accept = value; }
        }

        /// <summary>Gets or sets a value that indicates whether the request should follow redirection responses.</summary>
        public bool? AllowAutoRedirect
        {
            get { return this.allowAutoRedirect; }
            set { this.allowAutoRedirect = value; }
        }

        /// <summary>Gets or sets a value that indicates whether to buffer the data sent to the Internet resource.</summary>
        public bool? AllowWriteStreamBuffering
        {
            get { return this.allowWriteStreamBuffering; }
            set { this.allowWriteStreamBuffering = value; }
        }

        /// <summary>Gets or sets the type of decompression that is used.</summary>
        public DecompressionMethods? AutomaticDecompression
        {
            get { return this.automaticDecompression; }
            set { this.automaticDecompression = value; }
        }

        /// <summary>Gets or sets the value of the Connection HTTP header.</summary>
        public string Connection
        {
            get { return this.connection; }
            set { this.connection = value; }
        }

        /// <summary>Gets or sets the delegate method called when an HTTP 100-continue response is received from the Internet resource.</summary>
        public HttpContinueDelegate ContinueDelegate
        {
            get { return this.continueDelegate; }
            set { this.continueDelegate = value; }
        }

        /// <summary>Gets or sets the cookies associated with the request.</summary>
        public CookieContainer CookieContainer
        {
            get { return this.cookieContainer; }
            set { this.cookieContainer = value; }
        }

        /// <summary>Gets or sets the value of the Expect HTTP header.</summary>
        public string Expect
        {
            get { return this.expect; }
            set { this.expect = value; }
        }

        /// <summary>Gets or sets the maximum number of redirects that the request follows.</summary>
        public int? MaximumAutomaticRedirections
        {
            get { return this.maximumAutomaticRedirections; }
            set { this.maximumAutomaticRedirections = value; }
        }

        /// <summary>Gets or sets the maximum allowed length of the response headers.</summary>
        public int? MaximumResponseHeadersLength
        {
            get { return this.maximumResponseHeadersLength; }
            set { this.maximumResponseHeadersLength = value; }
        }

        /// <summary>Gets or sets the media type of the request.</summary>
        public string MediaType
        {
            get { return this.mediaType; }
            set { this.mediaType = value; }
        }

        /// <summary>Gets or sets a value that indicates whether to pipeline the request to the Internet resource.</summary>
        public bool? Pipelined
        {
            get { return this.pipelined; }
            set { this.pipelined = value; }
        }

        /// <summary>Gets or sets the version of HTTP to use for the request.</summary>
        public Version ProtocolVersion
        {
            get { return this.protocolVersion; }
            set { this.protocolVersion = value; }
        }

        /// <summary>Gets or sets the value of the Referer HTTP header.</summary>
        public string Referer
        {
            get { return this.referer; }
            set { this.referer = value; }
        }

        /// <summary>Gets or sets a value that indicates whether to send data in segments to the Internet resource.</summary>
        public bool? SendChunked
        {
            get { return this.sendChunked; }
            set { this.sendChunked = value; }
        }

        /// <summary>Gets or sets the value of the Transfer-encoding HTTP header.</summary>
        public string TransferEncoding
        {
            get { return this.transferEncoding; }
            set { this.transferEncoding = value; }
        }

        /// <summary>Gets or sets a value that indicates whether to allow high-speed NTLM-authenticated connection sharing.</summary>
        public bool? UnsafeAuthenticatedConnectionSharing
        {
            get { return this.unsafeAuthenticatedConnectionSharing; }
            set { this.unsafeAuthenticatedConnectionSharing = value; }
        }

        /// <summary>Gets or sets the value of the User-agent HTTP header.</summary>
        public string UserAgent
        {
            get { return this.userAgent; }
            set { this.userAgent = value; }
        }

        /// <summary>Gets or sets the collection of security certificates that are associated with this request.</summary>
        public X509CertificateCollection ClientCertificates
        {
            get { return this.clientCertificates; }
            set { this.clientCertificates = value; }
        }

        /// <summary>Gets or sets a value that indicates whether to make a persistent connection to the Internet resource.</summary>
        public bool? KeepAlive
        {
            get { return this.keepAlive; }
            set { this.keepAlive = value; }
        }

        /// <summary>Gets or sets a time-out when writing to or reading from a stream.</summary>
        public int? ReadWriteTimeout
        {
            get { return this.readWriteTimeout; }
            set { this.readWriteTimeout = value; }
        }

        /// <summary>
        /// Applies all options on the current instance to the supplied <see cref="WebRequest"/>.
        /// </summary>
        /// <param name="request">A <see cref="WebRequest"/> that should be configured.</param>
        public void ApplyOptions(WebRequest request)
        {
            if (this.AuthenticationLevel != null)
            {
                request.AuthenticationLevel = this.AuthenticationLevel.Value;
            }

            if (this.CachePolicy != null)
            {
                request.CachePolicy = this.CachePolicy;
            }

            if (this.ConnectionGroupName != null)
            {
                request.ConnectionGroupName = this.ConnectionGroupName;
            }

            if (this.Credentials != null)
            {
                request.Credentials = this.Credentials;
            }

            if (this.Headers != null)
            {
                request.Headers = this.Headers;
            }

            if (this.ImpersonationLevel != null)
            {
                request.ImpersonationLevel = this.ImpersonationLevel.Value;
            }

            if (this.PreAuthenticate != null)
            {
                request.PreAuthenticate = this.PreAuthenticate.Value;
            }

            if (this.Proxy != null)
            {
                request.Proxy = this.Proxy;
            }

            if (this.Timeout != null)
            {
                request.Timeout = this.Timeout.Value;
            }

            if (this.UseDefaultCredentials != null)
            {
                request.UseDefaultCredentials = this.UseDefaultCredentials.Value;
            }

            FtpWebRequest ftpRequest = request as FtpWebRequest;
            if (ftpRequest != null)
            {
                this.ApplyFtpOptions(ftpRequest);
            }

            HttpWebRequest httpRequest = request as HttpWebRequest;
            if (httpRequest != null)
            {
                this.ApplyHttpOptions(httpRequest);
            }
        }

        private void ApplyFtpOptions(FtpWebRequest ftpRequest)
        {
            if (this.ContentOffset != null)
            {
                ftpRequest.ContentOffset = this.ContentOffset.Value;
            }

            if (this.EnableSsl != null)
            {
                ftpRequest.EnableSsl = this.EnableSsl.Value;
            }

            if (this.RenameTo != null)
            {
                ftpRequest.RenameTo = this.RenameTo;
            }

            if (this.UseBinary != null)
            {
                ftpRequest.UseBinary = this.UseBinary.Value;
            }

            if (this.UsePassive != null)
            {
                ftpRequest.UsePassive = this.UsePassive.Value;
            }

            if (this.ClientCertificates != null)
            {
                ftpRequest.ClientCertificates = this.ClientCertificates;
            }

            if (this.KeepAlive != null)
            {
                ftpRequest.KeepAlive = this.KeepAlive.Value;
            }

            if (this.ReadWriteTimeout != null)
            {
                ftpRequest.ReadWriteTimeout = this.ReadWriteTimeout.Value;
            }
        }

        private void ApplyHttpOptions(HttpWebRequest httpRequest)
        {
            if (this.Accept != null)
            {
                httpRequest.Accept = this.Accept;
            }

            if (this.AllowAutoRedirect != null)
            {
                httpRequest.AllowAutoRedirect = this.AllowAutoRedirect.Value;
            }

            if (this.AllowWriteStreamBuffering != null)
            {
                httpRequest.AllowWriteStreamBuffering = this.AllowWriteStreamBuffering.Value;
            }

            if (this.AutomaticDecompression != null)
            {
                httpRequest.AutomaticDecompression = this.AutomaticDecompression.Value;
            }

            if (this.Connection != null)
            {
                httpRequest.Connection = this.Connection;
            }

            if (this.ContinueDelegate != null)
            {
                httpRequest.ContinueDelegate = this.ContinueDelegate;
            }

            if (this.CookieContainer != null)
            {
                httpRequest.CookieContainer = this.CookieContainer;
            }

            if (this.Expect != null)
            {
                httpRequest.Expect = this.Expect;
            }

            if (this.MaximumAutomaticRedirections != null)
            {
                httpRequest.MaximumAutomaticRedirections = this.MaximumAutomaticRedirections.Value;
            }

            if (this.MaximumResponseHeadersLength != null)
            {
                httpRequest.MaximumResponseHeadersLength = this.MaximumResponseHeadersLength.Value;
            }

            if (this.MediaType != null)
            {
                httpRequest.MediaType = this.MediaType;
            }

            if (this.Pipelined != null)
            {
                httpRequest.Pipelined = this.Pipelined.Value;
            }

            if (this.ProtocolVersion != null)
            {
                httpRequest.ProtocolVersion = this.ProtocolVersion;
            }

            if (this.Referer != null)
            {
                httpRequest.Referer = this.Referer;
            }

            if (this.SendChunked != null)
            {
                httpRequest.SendChunked = this.SendChunked.Value;
            }

            if (this.TransferEncoding != null)
            {
                httpRequest.TransferEncoding = this.TransferEncoding;
            }

            if (this.UnsafeAuthenticatedConnectionSharing != null)
            {
                httpRequest.UnsafeAuthenticatedConnectionSharing = this.UnsafeAuthenticatedConnectionSharing.Value;
            }

            if (this.UserAgent != null)
            {
                httpRequest.UserAgent = this.UserAgent;
            }

            if (this.ClientCertificates != null)
            {
                httpRequest.ClientCertificates = this.ClientCertificates;
            }

            if (this.KeepAlive != null)
            {
                httpRequest.KeepAlive = this.KeepAlive.Value;
            }

            if (this.ReadWriteTimeout != null)
            {
                httpRequest.ReadWriteTimeout = this.ReadWriteTimeout.Value;
            }
        }
    }
}