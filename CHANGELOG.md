# Changelog

## [4.2.0-alpha05](https://github.com/googleapis/gax-dotnet/compare/Google.Api.Gax-4.2.0-alpha04...Google.Api.Gax-4.2.0-alpha05) (2022-10-14)


### Features

* Support HTTP rule overrides, primarily for mix-ins ([cbfdfe0](https://github.com/googleapis/gax-dotnet/commit/cbfdfe0fce202b990f9e9aed94cdb56d94541ea9))


### Bug Fixes

* Add correct formatting for well-known types ([75bcdd8](https://github.com/googleapis/gax-dotnet/commit/75bcdd86a539ffa9cace9f08f7b483acb4451818))
* Revert to "slash isn't allowed in single-star wildcard in path templates" ([2a8ec9f](https://github.com/googleapis/gax-dotnet/commit/2a8ec9f18288cb622196645d03c43f3cdf816dcc))
* Transcode well-known types (Timestamp etc) for query parameters ([33b3a95](https://github.com/googleapis/gax-dotnet/commit/33b3a9520ab01c8200677f534b87dd13c27bd66f))


### Miscellaneous Chores

* Specify release version ([#622](https://github.com/googleapis/gax-dotnet/issues/622)) ([e3e9346](https://github.com/googleapis/gax-dotnet/commit/e3e9346757493cf152aa62189f88ac7d0c09511b))

## [4.2.0-alpha04](https://github.com/googleapis/gax-dotnet/compare/Google.Api.Gax-4.2.0-alpha03...Google.Api.Gax-4.2.0-alpha04) (2022-09-14)


### Miscellaneous Chores

* Fix pip packages again ([96f565a](https://github.com/googleapis/gax-dotnet/commit/96f565aa708d526ca720392305a2b0777e6931ad))

## [4.2.0-alpha03](https://github.com/googleapis/gax-dotnet/compare/Google.Api.Gax-4.2.0-alpha02...Google.Api.Gax-4.2.0-alpha03) (2022-09-14)


### Miscellaneous Chores

* Fix requirements file for Linux ([d717ad4](https://github.com/googleapis/gax-dotnet/commit/d717ad4fddbc15c2cb592b3a045d216667912f68))

## [4.2.0-alpha02](https://github.com/googleapis/gax-dotnet/compare/Google.Api.Gax-4.2.0-alpha01...Google.Api.Gax-4.2.0-alpha02) (2022-09-14)


### Bug Fixes

* Parse error details more robustly ([67b3438](https://github.com/googleapis/gax-dotnet/commit/67b34387f4e06fd9dc11b46cde95aaa9b636d330))


### Miscellaneous Chores

* Use hashes with pip install ([04c3e3d](https://github.com/googleapis/gax-dotnet/commit/04c3e3d46c5b9c7a337794934593e1fbf2a425a1))

## [4.2.0-alpha01](https://github.com/googleapis/gax-dotnet/compare/Google.Api.Gax-4.1.1...Google.Api.Gax-4.2.0-alpha01) (2022-09-06)


### Features

* Add formatting method for routing header values ([f4064f9](https://github.com/googleapis/gax-dotnet/commit/f4064f9e5d2cb94d157445751b20acef5b5f7472))

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
