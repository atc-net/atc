# Changelog

## [4.1.0](https://github.com/atc-net/atc/compare/Atc@v4.0.0...Atc@v4.1.0) (2026-11-09)


### New features

* **atc:** add AsyncEnumerableFactory.FromException ([dc56c33](https://github.com/atc-net/atc/commit/dc56c3324b5b51c89196ff47d9838f3fb8634d8f))
* **atc:** add CSharpKeywordHelper and UniqueNameHelper ([be9f19f](https://github.com/atc-net/atc/commit/be9f19ff102cb5407c1ed120dd328596e27f2556))
* **atc:** add display name, username, email and app id claims helpers ([2805f14](https://github.com/atc-net/atc/commit/2805f14f9ce4957e26e97bbf396791212fbe4c22))
* **atc:** add FileHelper.WriteAllTextIfChanged ([800ee5e](https://github.com/atc-net/atc/commit/800ee5e3c4c06fbb14b12ffcd52dafc606efde40))
* **atc:** add FileSystemTransaction ([e128274](https://github.com/atc-net/atc/commit/e128274106201d9db7a944a4fd93bd94d2d4f97a))
* **atc:** add GlobHelper ([f169328](https://github.com/atc-net/atc/commit/f1693283c150ef8613d1e6cff967c903c524e9b0))
* **atc:** add GuidHelper.CreateDeterministic ([41e1afa](https://github.com/atc-net/atc/commit/41e1afae572d396e73396c28a82789b93f718e8a))
* **atc:** add HttpStatusCode.ToEnumName ([686e74b](https://github.com/atc-net/atc/commit/686e74b23402340b5dd9d36d660ca791a313a42b))
* **atc:** add JsonSerializerOptions.CopyTo ([8faf07d](https://github.com/atc-net/atc/commit/8faf07da6e2f30fcfd5648ba576c4185bf3c52b7))
* **atc:** add NugetFeedClient ([a08d6c8](https://github.com/atc-net/atc/commit/a08d6c8ed2ff1b2f6fcd7015249d168291a718d1))
* **atc:** add SearchQueryHelper for parsing free-text searches ([5eb3c8b](https://github.com/atc-net/atc/commit/5eb3c8bf3bde51fce62c248c296ea34c3315fd70))
* **atc:** add SplitIntoWords, ToCasingStyle and InvariantCasingHelper ([63d75f7](https://github.com/atc-net/atc/commit/63d75f7a87169588f095f75ddc5152ded92b5774))
* **atc:** add string.ToEnumOrDefault ([303acfa](https://github.com/atc-net/atc/commit/303acfa032c74d879769c691bc89f8a9b8507139))
* **atc:** add TrimToNull string extension ([3006bdc](https://github.com/atc-net/atc/commit/3006bdc08bb35238dc3f6851e40ad25677765ecb))
* **atc:** run tools without hanging and find executables on PATH ([b95dc22](https://github.com/atc-net/atc/commit/b95dc22d61ba8de5bf9e94a781b8e64955bc65f9))
* **atc:** support JsonStringEnumMemberName and lenient nullable enums ([2f472e5](https://github.com/atc-net/atc/commit/2f472e52027b3ad4476a6c978fd6524518d6b3bf))

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
