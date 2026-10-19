# Changelog

## [4.0.0](https://github.com/atc-net/atc/compare/Atc@v3.0.186...Atc@v4.0.0) (2026-10-19)


### ⚠ BREAKING CHANGES

* **tfm:** remove net9.0 target framework support

### New features

* **tfm:** remove net9.0 target framework support ([95ac125](https://github.com/atc-net/atc/commit/95ac125da98b05130b673e1b4929a400c696201f))


### Bug fixes

* add short, byte, Half, DateOnly, TimeOnly and TimeSpan to CSharpTypeHelper value types ([60e36b7](https://github.com/atc-net/atc/commit/60e36b7c678b1c92f9a39580493e8c52dab7b786))
* reject non-strict notations in IsIPv4Address, IsIPv6Address and IPAddressAttribute ([ff191db](https://github.com/atc-net/atc/commit/ff191db323bbe2103a143b007db3f9d77898bc07))
* resolve analyzer warnings from updated analyzers ([398ef11](https://github.com/atc-net/atc/commit/398ef1132976b8560e687b54d8606ce9721f2eb4))
* use the default timeout of 30 seconds in ProcessHelper.ExecutePrompt instead of 1 second ([f43913e](https://github.com/atc-net/atc/commit/f43913e4537f0e9b6f68c3c6f6de72023f559587))
