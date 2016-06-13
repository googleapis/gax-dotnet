Google REST API Extensions for .NET
===

The [primary library](readme.md) for this repository is
`Google.Api.Gax`, which provides support for gRPC-based APIs.
However, there are many older Google APIs based on
REST/JSON/HTTP1.1. These have their own [support
library](https://github.com/google/google-api-dotnet-client).
However, that support library does not provide functionality
required by some of the [wrapper client
libraries](https://github.com/google-cloud-platform/gcloud-dotnet).
The `Google.Api.Gax.Rest` library fills in these blanks, providing
some similar APIs to those in `Google.Api.Gax`.

Supported platforms
---

We are initially targeting support for .NET 4.5. We hope to support
.NET Core in the future, when all the dependencies do.

Contributing
------------

Contributions to this library are always welcome and highly encouraged.

See the
[CONTRIBUTING](https://github.com/googleapis/gax-dotnet/blob/master/CONTRIBUTING)
documentation for more information on how to get started.


Versioning
----------

This library follows [semantic versioning](http://semver.org).

It is currently in major version zero (`0.y.z`), which means that anything
may change at any time and the public API should not be considered
stable.

License
-------

BSD - See
[LICENSE](https://github.com/googleapis/gax-dotnet/blob/master/LICENSE)
for more information.

