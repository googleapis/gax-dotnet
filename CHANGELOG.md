# Changelog

## [4.3.0-beta01](https://github.com/googleapis/gax-dotnet/compare/Google.Api.Gax-4.3.0...Google.Api.Gax-4.3.0-beta01) (2022-12-08)


### Features

* Add scoped self-signed JWT support for REST ([8f62655](https://github.com/googleapis/gax-dotnet/commit/8f6265559d516cf09b7265e6d3c0a56621ad0419))
* Improve handling of bad/missing/unsupported methods in REGAPIC ([703f386](https://github.com/googleapis/gax-dotnet/commit/703f386c67b39b9bf128e6aa3e901b422effb908)), closes [#623](https://github.com/googleapis/gax-dotnet/issues/623)
* Improve server streaming exception behavior ([28f759a](https://github.com/googleapis/gax-dotnet/commit/28f759afd8fb247a95a1cce157162d64fcc16de2))
* Regenerate common protos ([4e6ec67](https://github.com/googleapis/gax-dotnet/commit/4e6ec674c091fbda6c11bb3d73db2c2d5f3cc7a8))
* rest server streaming support ([a7f122a](https://github.com/googleapis/gax-dotnet/commit/a7f122a4108ad940ef460dbb15c0ab7b2edfb46d))


### Bug Fixes

* Change default for UseSelfSignedJwtsWithScopes in REST to false ([20663c1](https://github.com/googleapis/gax-dotnet/commit/20663c158c8675c008237196c8b3faa53c1f2437))
* Close TextReader when we've found the end of responses ([302e8b6](https://github.com/googleapis/gax-dotnet/commit/302e8b6493340214f5f78d174385cd15d0ff7bd9))
* Dispose of CancellationTokenSources when a method is "done" ([c6e3502](https://github.com/googleapis/gax-dotnet/commit/c6e35020ff72b74ac2c6eb4321137cfac6229d64)), closes [#592](https://github.com/googleapis/gax-dotnet/issues/592)
* Drop trailing hex characters from version header values ([b3e2cf9](https://github.com/googleapis/gax-dotnet/commit/b3e2cf9e91dd3ce3b626a4f002a68a5f666caf9f)), closes [#636](https://github.com/googleapis/gax-dotnet/issues/636)
* Fix cancellation (including deadlines) for REGAPIC streaming ([3df4f82](https://github.com/googleapis/gax-dotnet/commit/3df4f82712f3ed308432cc28d11636703495e946)), closes [#648](https://github.com/googleapis/gax-dotnet/issues/648)
* Fix error handling for server-streaming REGAPIC ([9b0336f](https://github.com/googleapis/gax-dotnet/commit/9b0336f7745539766134d95bb7ec4021ae04ec09)), closes [#655](https://github.com/googleapis/gax-dotnet/issues/655)
* Keep the gRPC full method name in RestServiceCollection ([fcb1173](https://github.com/googleapis/gax-dotnet/commit/fcb1173bbc867a223e6d6a32e5a9f3bdd2b8a29f)), closes [#650](https://github.com/googleapis/gax-dotnet/issues/650)
* Throw RpcException if transcoding fails ([49c7349](https://github.com/googleapis/gax-dotnet/commit/49c7349049384670d50748a7c806e273542c22a7)), closes [#659](https://github.com/googleapis/gax-dotnet/issues/659)

## [4.2.0](https://github.com/googleapis/gax-dotnet/compare/Google.Api.Gax-4.1.1...Google.Api.Gax-4.2.0) (2022-11-03)

### Features

* Support HTTP rule overrides, primarily for mix-ins ([cbfdfe0](https://github.com/googleapis/gax-dotnet/commit/cbfdfe0fce202b990f9e9aed94cdb56d94541ea9))
* Add formatting method for routing header values ([f4064f9](https://github.com/googleapis/gax-dotnet/commit/f4064f9e5d2cb94d157445751b20acef5b5f7472))

### Bug Fixes

* Add correct formatting for well-known types ([75bcdd8](https://github.com/googleapis/gax-dotnet/commit/75bcdd86a539ffa9cace9f08f7b483acb4451818))
* Revert to "slash isn't allowed in single-star wildcard in path templates" ([2a8ec9f](https://github.com/googleapis/gax-dotnet/commit/2a8ec9f18288cb622196645d03c43f3cdf816dcc))
* Transcode well-known types (Timestamp etc) for query parameters ([33b3a95](https://github.com/googleapis/gax-dotnet/commit/33b3a9520ab01c8200677f534b87dd13c27bd66f))
* Parse error details more robustly ([67b3438](https://github.com/googleapis/gax-dotnet/commit/67b34387f4e06fd9dc11b46cde95aaa9b636d330))

## [4.1.1](https://github.com/googleapis/gax-dotnet/compare/Google.Api.Gax-4.1.0...Google.Api.Gax-4.1.1) (2022-09-06)


### Features

* Allow endpoints with schemes in RestGrpcAdapter ([8b40dcd](https://github.com/googleapis/gax-dotnet/commit/8b40dcdfe4028b2a7db2e6ef8c968da6aa64207e))
* Allow non-string/integer fields in path templates ([112f890](https://github.com/googleapis/gax-dotnet/commit/112f89053e22dff2b9a44622b472ca29ffa8eb87))


### Bug Fixes

* Avoid an NRE in RestMethod when a method doesn't have an options ([8a1acd0](https://github.com/googleapis/gax-dotnet/commit/8a1acd0a8288ddd43e9c11c43d851827e3cf3e15))
* Convert enum values appropriately for query parameters ([b1945d7](https://github.com/googleapis/gax-dotnet/commit/b1945d7c7ec51947fe26a5f805ea0b4c2f816233))
* Correction to query parameter population in gRPC transcoding ([b97297d](https://github.com/googleapis/gax-dotnet/commit/b97297dabd26fbfe2167d6cdf4fada50895d0743))
* Fix transcoding of path templates including doubly-nested fields ([dc0ef55](https://github.com/googleapis/gax-dotnet/commit/dc0ef55797a4672e4b500a18d4c875cc1f9804a7))
* Format Boolean query parameters as true/false ([120d416](https://github.com/googleapis/gax-dotnet/commit/120d416675869dce99b04c3784c72a98c79ade64))
* Handle empty credentials in RestChannel ([533703d](https://github.com/googleapis/gax-dotnet/commit/533703d969722c9262b72f95851677e48451c01d))
* Skip streaming methods during REST method discovery ([ad85def](https://github.com/googleapis/gax-dotnet/commit/ad85deff827a79ec480e3469ec3df24a94ce3413))


### Miscellaneous Chores

* release 4.1.1 ([#596](https://github.com/googleapis/gax-dotnet/issues/596)) ([7d13a21](https://github.com/googleapis/gax-dotnet/commit/7d13a21c60a124a3345acf4c91d3671c8b498718))

## [4.1.0](https://github.com/googleapis/gax-dotnet/compare/Google.Api.Gax-4.0.0...Google.Api.Gax-4.1.0) (2022-09-05)


### Features

* Add WithRequestNumericEnumJsonEncoding to ApiMetadata ([8369921](https://github.com/googleapis/gax-dotnet/commit/8369921fe07d9dad1371905afb446f30524a3bda))
* Apply $alt query parameter when numeric enum encoding is required ([ba6c969](https://github.com/googleapis/gax-dotnet/commit/ba6c969097576c926c98c47e55901b8023abbe40))
* Finish (in terms of feature completeness) gRPC transcoding ([ab88585](https://github.com/googleapis/gax-dotnet/commit/ab88585d417c2102f6959b17795648a0a5fe2906))
* gRPC transcoding improvements ([0d20c00](https://github.com/googleapis/gax-dotnet/commit/0d20c005da086c3c1cadd835f43aea58fc4a6668))
* Preserve query parameters in TranscodingOutput ([13e9816](https://github.com/googleapis/gax-dotnet/commit/13e981697877098b3cc5f4ea8fd7950927a396a0))


### Bug Fixes

* Allow slashes in single-star wildcard fields (gRPC transcoding) ([612b49f](https://github.com/googleapis/gax-dotnet/commit/612b49f16c24bfce244f734ceb2e1326cf1e297d))
* Improve query parameter transcoding ([b747591](https://github.com/googleapis/gax-dotnet/commit/b74759126dd91cdf6f28626489dfee69fd9c200d))
* More transcoding tests, and a couple of bug fixes for transcoding that they exposed ([d87d1ef](https://github.com/googleapis/gax-dotnet/commit/d87d1efa314c07057781adf8326a203f77aad1f0))
