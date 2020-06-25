### Per call credentials depreaction.
As of Google.Api.Gax 3.1.0, `Google.Api.Gax.Grpc.CallSettings.CallCredetianls` has been marked obsolete,
as well as the `Google.Api.Gax.Grpc.CallSettings` constructors that receive `Grpc.Core.CallCredentials`
as a parameter. The behaviour due to using any of these members is the same as before and it's described below.

### Specifying call credentials for a gRPC call.
There are two ways in which you can specify call credentials for gRPC calls.

  * You can set any of the credential sources in client builders inheriting from
  `Google.Api.Gax.Grcp.ClientBuilderBase` (or none, and defaults will be used).
  All calls made with clients built from these builders will include the specified credential.
  * You can set credentials on `Google.Api.Gax.Grpc.CallSettings`. All calls made with these
  settings will include the specified credential in addition to the credential specified
  for the client.

This means that both call credentials specified for the client and for the specific call
will be sent to the service. The credential specified at the call site (via `CallSettings`)
does not override the credential specified at the client.

Given that Google APIs only accept one credential (ignoring all others), we have decided to
deprecate `Google.Api.Gax.Grpc.CallSettings.CallCredetianls` to avoid sending two credentials
per call, which could lead to unexpected behaviour now or in the future.

It's not recommended that you use the obsolete members when communicating with Google APIs.
If you need to make calls with different credentials, the recommendation is to create a client
per credential.

If for some reason you still need to make calls to Google APIs with different credentials and
cannot create different clients then use the following approach to guarantee that just one credential
is being sent.

  * Set an `Grpc.Core.SslCredentials` on `Google.Api.Gax.Grcp.ClientBuilderBase.ChannelCredentials`.
  `SslCredentials` do not contain a credential that can be used to authenticate and authorize calls, it's
  only used to establish the TSL channel used for communication with the service.
  * And use `Google.Api.Gax.Grpc.CallSettings` for each call by setting `CallCredentials` to the specific
  credential. Take into account that you'd still be using an obsolete member that will eventually dissapear from
  `Google.Api.Gax.Grpc`.

### Making calls with multiple credentials.
Gax libraries can be used to communicate with services other than Google APIs, and some of those
may accept or even require multiple credentials to be sent per call. This is still achievable.

  * By setting a composed gRPC credential on `Google.Api.Gax.Grcp.ClientBuilderBase.ChannelCredentials`.
  See [gRPC's .NET library documentation](https://grpc.io/docs/languages/csharp/) for more details on how
  to compose credentials.
  * Or by setting both a credential on `Google.Api.Gax.Grcp.ClientBuilderBase.ChannelCredentials`
  and on `Google.Api.Gax.Grpc.CallSettings.CallCredetianls`.
  Take into account that you'd still be using an obsolete member that will eventually dissapear from
  `Google.Api.Gax.Grpc`.