using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.IntegrationTests
{
    /// <summary>
    /// Verifies Post-Quantum Cryptography (PQC) TLS negotiation (MLKEM) across gRPC and REST transports against the GAPIC Showcase server.
    /// Note: These tests will fail unless the GAPIC Showcase server is actively running.
    /// </summary>
    public class PqcIntegrationTest
    {
        private static readonly string s_showcaseEndpoint = Environment.GetEnvironmentVariable("SHOWCASE_ENDPOINT") ?? "https://localhost:7469";

        /// <summary>
        /// Ensures raw gRPC metadata negotiated a post-quantum MLKEM curve.
        /// </summary>
        [Fact]
        public async Task TestPqcGrpcNegotiation()
        {
            // Bypass certificate validation since we only care about verifying the negotiated key exchange algorithm.
            // .NET 8 requires HttpClientHandler callbacks, while .NET Framework 4.6.2 requires the legacy global ServicePointManager.
#if NETFRAMEWORK
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var handler = new HttpClientHandler();
#else
            var handler = new HttpClientHandler { ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator };
#endif
            using var channel = GrpcChannel.ForAddress(s_showcaseEndpoint, new global::Grpc.Net.Client.GrpcChannelOptions { HttpHandler = handler });
            var method = new Method<byte[], byte[]>(MethodType.Unary, "google.showcase.v1beta1.Echo", "Echo", Marshallers.Create(b => b, b => b), Marshallers.Create(b => b, b => b));
            
            // The Showcase server intercepts the TLS connection and attaches 
            // the supported and negotiated cipher groups directly to the gRPC response trailing metadata.
            var invoker = channel.CreateCallInvoker();
            using var call = invoker.AsyncUnaryCall(method, null, new CallOptions(), Array.Empty<byte>());
            await call.ResponseAsync;
            var allHeaders = (await call.ResponseHeadersAsync).Concat(call.GetTrailers());

            // Retrieve the client's advertised cipher list (supported) and the server's chosen cipher (negotiated).
            // We expect exactly one entry for each header, throwing otherwise.
            var clientSupportedGroupsEntry = Assert.Single(allHeaders, e => e.Key.Equals("x-showcase-tls-client-supported-groups", StringComparison.OrdinalIgnoreCase));
            var negotiatedGroupEntry = Assert.Single(allHeaders, e => e.Key.Equals("x-showcase-tls-group", StringComparison.OrdinalIgnoreCase));
            
            // 'MLKEM' substring confirms post-quantum encryption despite naming variations.
            // Note: If new post-quantum algorithms are standardized in the future, these assertions may require updating.
            // See https://en.wikipedia.org/wiki/Post-Quantum_Cryptography_Standardization
            Assert.Contains("MLKEM", clientSupportedGroupsEntry.Value, StringComparison.OrdinalIgnoreCase);
            Assert.Contains("MLKEM", negotiatedGroupEntry.Value, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Ensures native HTTP headers negotiated a post-quantum MLKEM curve.
        /// </summary>
        [Fact]
        public async Task TestPqcRestNegotiation()
        {
            // Bypass certificate validation since we only care about verifying the negotiated key exchange algorithm.
            // .NET 8 requires HttpClientHandler callbacks, while .NET Framework 4.6.2 requires the legacy global ServicePointManager.
#if NETFRAMEWORK
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var handler = new HttpClientHandler();
#else
            var handler = new HttpClientHandler { ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator };
#endif
            using var client = new HttpClient(handler);
            var request = new HttpRequestMessage(HttpMethod.Post, $"{s_showcaseEndpoint}/v1beta1/echo:echo") { Content = new StringContent("{}") };
            
            // The Showcase server intercepts the TLS connection and attaches 
            // the supported and negotiated cipher groups directly to the HTTP response headers.
            var response = await client.SendAsync(request);
            
            // Retrieve the client's advertised cipher list (supported) and the server's chosen cipher (negotiated).
            // We expect exactly one header and one entry for each header, throwing otherwise.
            var clientSupportedGroupsEntry = Assert.Single(response.Headers, h => h.Key.Equals("x-showcase-tls-client-supported-groups", StringComparison.OrdinalIgnoreCase));
            var negotiatedGroupEntry = Assert.Single(response.Headers, h => h.Key.Equals("x-showcase-tls-group", StringComparison.OrdinalIgnoreCase));
            var clientSupportedGroupsSingle = Assert.Single(clientSupportedGroupsEntry.Value);
            var negotiatedGroupsSingle = Assert.Single(negotiatedGroupEntry.Value);

            // 'MLKEM' substring confirms post-quantum encryption despite naming variations.
            // Note: If new post-quantum algorithms are standardized in the future, these assertions may require updating.
            // See https://en.wikipedia.org/wiki/Post-Quantum_Cryptography_Standardization
            Assert.Contains("MLKEM", clientSupportedGroupsSingle, StringComparison.OrdinalIgnoreCase);
            Assert.Contains("MLKEM", negotiatedGroupsSingle, StringComparison.OrdinalIgnoreCase);
        }
    }
}
