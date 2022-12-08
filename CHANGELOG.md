# Changelog

## [2.3.0-beta01](https://github.com/googleapis/gax-dotnet/compare/Google.Api.Gax-v4.3.0-beta01...Google.Api.Gax-2.3.0-beta01) (2022-12-08)


### ⚠ BREAKING CHANGES

* Improve compatibility of error messages between gRPC and REGAPIC
* previous error messages containing large amounts of JSON will be replaced with simpler ones, with the detail available via the RpcException extension methods. This could break anyone using REGAPIC (currently just Compute) and trying to find the error details in the message. (This change will only be in a new major version anyway, but we should include this in the change log.)
* Remove single-parameter ChannelPool constructor
* Remove obsolete CallCredentials code from CallSettings

### Features

* add client streaming to the gax ([#514](https://github.com/googleapis/gax-dotnet/issues/514)) ([7db4af7](https://github.com/googleapis/gax-dotnet/commit/7db4af728714c42017a002eb06beb3ae55e9cba7))
* Add ClientBuilderBase.Build/BuildAsync overloads accepting IServiceProvider ([7320b7e](https://github.com/googleapis/gax-dotnet/commit/7320b7ef4cb69622fa2209e28e20240a23f0180c))
* Add dependency injection support to client builders ([1e6358a](https://github.com/googleapis/gax-dotnet/commit/1e6358a43420248b7205a9179f6e585135eb0922))
* Add extension methods to access extra error information ([6a6dd81](https://github.com/googleapis/gax-dotnet/commit/6a6dd811c11d9fdfeb6a9aaa5fdba24ec32b2b4b))
* Add formatting method for routing header values ([f4064f9](https://github.com/googleapis/gax-dotnet/commit/f4064f9e5d2cb94d157445751b20acef5b5f7472))
* Add logger support to ClientBuilderBase ([f61d976](https://github.com/googleapis/gax-dotnet/commit/f61d976e1b398a4c954a098e90260daf54316233))
* Add logging to ClientHelper, ApiCall and related classes ([c98440f](https://github.com/googleapis/gax-dotnet/commit/c98440f9ede01c882ae9683c284348d7c7a7e9aa))
* Add method name to ApiCall and related classes ([d0cfbd4](https://github.com/googleapis/gax-dotnet/commit/d0cfbd46f24fa0e6f3b2741eee8b3429451b3c84))
* add query parameters to transcoding ([f5f2d23](https://github.com/googleapis/gax-dotnet/commit/f5f2d230877feef93f16b2f729de6f3c639fe0a4))
* Add scoped self-signed JWT support for REST ([8f62655](https://github.com/googleapis/gax-dotnet/commit/8f6265559d516cf09b7265e6d3c0a56621ad0419))
* Add Shutdown extension method for ChannelBase ([5adf741](https://github.com/googleapis/gax-dotnet/commit/5adf741bcffe79d83b6aa6072ebc866b31cbdf8d))
* Add WithRequestNumericEnumJsonEncoding to ApiMetadata ([8369921](https://github.com/googleapis/gax-dotnet/commit/8369921fe07d9dad1371905afb446f30524a3bda))
* Allow endpoints with schemes in RestGrpcAdapter ([8b40dcd](https://github.com/googleapis/gax-dotnet/commit/8b40dcdfe4028b2a7db2e6ef8c968da6aa64207e))
* Allow gRPC adapter detection to be overridden ([7e99bb8](https://github.com/googleapis/gax-dotnet/commit/7e99bb8946dcdc184c0a307e49822ab0ea3e1018))
* Allow non-string/integer fields in path templates ([112f890](https://github.com/googleapis/gax-dotnet/commit/112f89053e22dff2b9a44622b472ca29ffa8eb87))
* Allow scoped Self-Signed JWTs ([8e93dbf](https://github.com/googleapis/gax-dotnet/commit/8e93dbfb83c6aa88249345bf9dad5df3ccd78b75))
* Apply $alt query parameter when numeric enum encoding is required ([ba6c969](https://github.com/googleapis/gax-dotnet/commit/ba6c969097576c926c98c47e55901b8023abbe40))
* escape variable expansion in URI path ([#515](https://github.com/googleapis/gax-dotnet/issues/515)) ([a90a7ca](https://github.com/googleapis/gax-dotnet/commit/a90a7ca8b4c159d81644c3f2c79f9d5e31ac04f0))
* Expose CreateChannel in ClientBuilderBase ([385b63f](https://github.com/googleapis/gax-dotnet/commit/385b63f6ac9dc991de94bce022dbfaf7353698c0))
* Expose error details as synthesized gRPC trailers in REGAPIC ([31600fc](https://github.com/googleapis/gax-dotnet/commit/31600fcd81d90ba47ed3887f7795383497e51d24))
* Expose Google.Apis.Http.IHttpClientFactory on Rest.ClientBuilderBase ([58515ad](https://github.com/googleapis/gax-dotnet/commit/58515adcb29d34616b3e403cc16e2a0a8acf771e))
* Expose HTTP to gRPC status code conversions in REGAPIC ([4b3442a](https://github.com/googleapis/gax-dotnet/commit/4b3442a2d57b58b6f373a47ad59319f4d40b11c9))
* Expose the ClientHelper logger publicly ([3137425](https://github.com/googleapis/gax-dotnet/commit/3137425ea6685af90c611c68732d922be2361671))
* Expose the last-created channel publicly ([c987d86](https://github.com/googleapis/gax-dotnet/commit/c987d86cb4ac4123efcbc32f0f76b3bc735e95f3))
* Finish (in terms of feature completeness) gRPC transcoding ([ab88585](https://github.com/googleapis/gax-dotnet/commit/ab88585d417c2102f6959b17795648a0a5fe2906))
* ForwardingCallInvoker, currently REGAPIC-specific ([499f636](https://github.com/googleapis/gax-dotnet/commit/499f6362bd9ec4986f68b5710358bb83ecacc3cc))
* Get Grpc.Gcp code working within Google.Api.Gax.Grpc ([a45e792](https://github.com/googleapis/gax-dotnet/commit/a45e792864905e0bcf90b18ea5b3f46bf132d077))
* gRPC transcoding improvements ([0d20c00](https://github.com/googleapis/gax-dotnet/commit/0d20c005da086c3c1cadd835f43aea58fc4a6668))
* Improve compatibility of error messages between gRPC and REGAPIC ([d615254](https://github.com/googleapis/gax-dotnet/commit/d615254c7323bbe38e643971415ec191dd54aece))
* Improve consistency of AddGrpcNetClientAdapter methods ([bd9ebc8](https://github.com/googleapis/gax-dotnet/commit/bd9ebc87d9c1d03c6a358f8ba0aca547ce463dc5))
* Improve handling of bad/missing/unsupported methods in REGAPIC ([703f386](https://github.com/googleapis/gax-dotnet/commit/703f386c67b39b9bf128e6aa3e901b422effb908)), closes [#623](https://github.com/googleapis/gax-dotnet/issues/623)
* Improve server streaming exception behavior ([28f759a](https://github.com/googleapis/gax-dotnet/commit/28f759afd8fb247a95a1cce157162d64fcc16de2))
* Make UseJwtAccessWithScopes public ([80f91bc](https://github.com/googleapis/gax-dotnet/commit/80f91bc390b9204818e77a464ec02c2b8e0f3176))
* Move all GCP code into a common location + namespace ([1544893](https://github.com/googleapis/gax-dotnet/commit/15448938e862064924aa36f11446d6d7a8b938fc))
* Preserve query parameters in TranscodingOutput ([13e9816](https://github.com/googleapis/gax-dotnet/commit/13e981697877098b3cc5f4ea8fd7950927a396a0))
* Regenerate common protos ([4e6ec67](https://github.com/googleapis/gax-dotnet/commit/4e6ec674c091fbda6c11bb3d73db2c2d5f3cc7a8))
* Regenerate common protos, including adding routing ([33d545d](https://github.com/googleapis/gax-dotnet/commit/33d545d639107f853dbc9e2b0edacc2631081bd6))
* rest server streaming support ([a7f122a](https://github.com/googleapis/gax-dotnet/commit/a7f122a4108ad940ef460dbb15c0ab7b2edfb46d))
* runtime support for explicit routing headers ([#517](https://github.com/googleapis/gax-dotnet/issues/517)) ([29ac7ee](https://github.com/googleapis/gax-dotnet/commit/29ac7ee663990e88f5ef9f4ff721ad547bc7397a))
* Select the first GrpcAdapter that supports the API ([cf2001e](https://github.com/googleapis/gax-dotnet/commit/cf2001ee9f01a10bb7a448edf8a914532dd35a11))
* send correct x-goog-api-client headers for the diregapic ([#470](https://github.com/googleapis/gax-dotnet/issues/470)) ([56c0ca9](https://github.com/googleapis/gax-dotnet/commit/56c0ca998ec863faa7003c35b744ee770e436bd3))
* Support HTTP rule overrides, primarily for mix-ins ([cbfdfe0](https://github.com/googleapis/gax-dotnet/commit/cbfdfe0fce202b990f9e9aed94cdb56d94541ea9))
* Surface better error information for REGAPIC ([d6504a3](https://github.com/googleapis/gax-dotnet/commit/d6504a35123cc063c9e5cb0935fa301a5d9de1ee))
* timeout http calls and add async headers calls ([#516](https://github.com/googleapis/gax-dotnet/issues/516)) ([afb1dbf](https://github.com/googleapis/gax-dotnet/commit/afb1dbfeaf4d42c87bb89b71927125a51c53cf1d))
* Use self-signed JWTs in Google.Api.Gax.Rest ([b52107e](https://github.com/googleapis/gax-dotnet/commit/b52107e81c850b30373172720eb5670f6048a2f7))


### Bug Fixes

* Add correct formatting for well-known types ([75bcdd8](https://github.com/googleapis/gax-dotnet/commit/75bcdd86a539ffa9cace9f08f7b483acb4451818))
* Allow logger to be null for a retrying ApiCall ([f7e7fdf](https://github.com/googleapis/gax-dotnet/commit/f7e7fdf7735b57c41c6d1ea1b794da52af188055))
* Allow slashes in single-star wildcard fields (gRPC transcoding) ([612b49f](https://github.com/googleapis/gax-dotnet/commit/612b49f16c24bfce244f734ceb2e1326cf1e297d))
* Avoid an NRE in RestMethod when a method doesn't have an options ([8a1acd0](https://github.com/googleapis/gax-dotnet/commit/8a1acd0a8288ddd43e9c11c43d851827e3cf3e15))
* Change default for UseSelfSignedJwtsWithScopes in REST to false ([20663c1](https://github.com/googleapis/gax-dotnet/commit/20663c158c8675c008237196c8b3faa53c1f2437))
* Close TextReader when we've found the end of responses ([302e8b6](https://github.com/googleapis/gax-dotnet/commit/302e8b6493340214f5f78d174385cd15d0ff7bd9))
* Convert enum values appropriately for query parameters ([b1945d7](https://github.com/googleapis/gax-dotnet/commit/b1945d7c7ec51947fe26a5f805ea0b4c2f816233))
* Copy GrpcChannelOptions in ClientBuilderBase.CopyCommonSettings ([324268d](https://github.com/googleapis/gax-dotnet/commit/324268d3bccf14af4794d0adc028ea20ef9286ca)), closes [#551](https://github.com/googleapis/gax-dotnet/issues/551)
* Correction to query parameter population in gRPC transcoding ([b97297d](https://github.com/googleapis/gax-dotnet/commit/b97297dabd26fbfe2167d6cdf4fada50895d0743))
* Dispose of CancellationTokenSources when a method is "done" ([c6e3502](https://github.com/googleapis/gax-dotnet/commit/c6e35020ff72b74ac2c6eb4321137cfac6229d64)), closes [#592](https://github.com/googleapis/gax-dotnet/issues/592)
* Drop trailing hex characters from version header values ([b3e2cf9](https://github.com/googleapis/gax-dotnet/commit/b3e2cf9e91dd3ce3b626a4f002a68a5f666caf9f)), closes [#636](https://github.com/googleapis/gax-dotnet/issues/636)
* Fix cancellation (including deadlines) for REGAPIC streaming ([3df4f82](https://github.com/googleapis/gax-dotnet/commit/3df4f82712f3ed308432cc28d11636703495e946)), closes [#648](https://github.com/googleapis/gax-dotnet/issues/648)
* Fix error handling for server-streaming REGAPIC ([9b0336f](https://github.com/googleapis/gax-dotnet/commit/9b0336f7745539766134d95bb7ec4021ae04ec09)), closes [#655](https://github.com/googleapis/gax-dotnet/issues/655)
* Fix the .NET 4.6.2 build ([eb797c4](https://github.com/googleapis/gax-dotnet/commit/eb797c49f2532d67420d714e430a7c366ebef8a4))
* Fix transcoding of path templates including doubly-nested fields ([dc0ef55](https://github.com/googleapis/gax-dotnet/commit/dc0ef55797a4672e4b500a18d4c875cc1f9804a7))
* Format Boolean query parameters as true/false ([120d416](https://github.com/googleapis/gax-dotnet/commit/120d416675869dce99b04c3784c72a98c79ade64))
* Handle empty credentials in RestChannel ([533703d](https://github.com/googleapis/gax-dotnet/commit/533703d969722c9262b72f95851677e48451c01d))
* Handle unexpected REST responses ([bfbcaa6](https://github.com/googleapis/gax-dotnet/commit/bfbcaa687aef3d2e2137af76ef2ae44b6b1889ce))
* Improve query parameter transcoding ([b747591](https://github.com/googleapis/gax-dotnet/commit/b74759126dd91cdf6f28626489dfee69fd9c200d))
* In GrpcNetClientAdapter, be smart when guessing the scheme to use for schemeless URLs ([0ac68c7](https://github.com/googleapis/gax-dotnet/commit/0ac68c7965da4b2df11409c0bcb3bcaccf89447b))
* Keep the gRPC full method name in RestServiceCollection ([fcb1173](https://github.com/googleapis/gax-dotnet/commit/fcb1173bbc867a223e6d6a32e5a9f3bdd2b8a29f)), closes [#650](https://github.com/googleapis/gax-dotnet/issues/650)
* More transcoding tests, and a couple of bug fixes for transcoding that they exposed ([d87d1ef](https://github.com/googleapis/gax-dotnet/commit/d87d1efa314c07057781adf8326a203f77aad1f0))
* Parse error details more robustly ([67b3438](https://github.com/googleapis/gax-dotnet/commit/67b34387f4e06fd9dc11b46cde95aaa9b636d330))
* Revert to "slash isn't allowed in single-star wildcard in path templates" ([2a8ec9f](https://github.com/googleapis/gax-dotnet/commit/2a8ec9f18288cb622196645d03c43f3cdf816dcc))
* Skip streaming methods during REST method discovery ([ad85def](https://github.com/googleapis/gax-dotnet/commit/ad85deff827a79ec480e3469ec3df24a94ce3413))
* Throw RpcException if transcoding fails ([49c7349](https://github.com/googleapis/gax-dotnet/commit/49c7349049384670d50748a7c806e273542c22a7)), closes [#659](https://github.com/googleapis/gax-dotnet/issues/659)
* Transcode well-known types (Timestamp etc) for query parameters ([33b3a95](https://github.com/googleapis/gax-dotnet/commit/33b3a9520ab01c8200677f534b87dd13c27bd66f))


### deprecation

* Remove obsolete CallCredentials code from CallSettings ([9170338](https://github.com/googleapis/gax-dotnet/commit/9170338b14c5c8bae5aae7e14fb8fd2753c9b2fb))
* Remove single-parameter ChannelPool constructor ([70951e6](https://github.com/googleapis/gax-dotnet/commit/70951e6c420ce0310f7df720b7999283ca2f7861)), closes [#534](https://github.com/googleapis/gax-dotnet/issues/534)


### Miscellaneous Chores

* Fix pip packages again ([96f565a](https://github.com/googleapis/gax-dotnet/commit/96f565aa708d526ca720392305a2b0777e6931ad))
* Fix requirements file for Linux ([d717ad4](https://github.com/googleapis/gax-dotnet/commit/d717ad4fddbc15c2cb592b3a045d216667912f68))
* release 4.1.1 ([#596](https://github.com/googleapis/gax-dotnet/issues/596)) ([7d13a21](https://github.com/googleapis/gax-dotnet/commit/7d13a21c60a124a3345acf4c91d3671c8b498718))
* Set release version ([#625](https://github.com/googleapis/gax-dotnet/issues/625)) ([a594981](https://github.com/googleapis/gax-dotnet/commit/a594981262fa9ad75759409bd003015cdae7be61))
* Specify release version ([#622](https://github.com/googleapis/gax-dotnet/issues/622)) ([e3e9346](https://github.com/googleapis/gax-dotnet/commit/e3e9346757493cf152aa62189f88ac7d0c09511b))
* Use hashes with pip install ([04c3e3d](https://github.com/googleapis/gax-dotnet/commit/04c3e3d46c5b9c7a337794934593e1fbf2a425a1))

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
