<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.Data.SemVer

<br />

## SemanticVersion
Represents a version object, compliant with the Semantic Version standard 2.0 (http://semver.org).

>```csharp
>public class SemanticVersion : IComparable, IComparable<SemanticVersion>, IEquatable<SemanticVersion>
>```

### Static Methods

#### Parse
>```csharp
>SemanticVersion Parse(string input, bool looseMode = False)
>```
><b>Summary:</b> Construct a new semantic version from a version string.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`input`&nbsp;&nbsp;-&nbsp;&nbsp;The version string.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`looseMode`&nbsp;&nbsp;-&nbsp;&nbsp;When true, be more forgiving of some invalid version specifications.<br />
>
><b>Returns:</b> The SemanticVersion
#### TryParse
>```csharp
>bool TryParse(string input, out SemanticVersion result)
>```
><b>Summary:</b> Try to construct a new semantic version from a version string.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`input`&nbsp;&nbsp;-&nbsp;&nbsp;The version string.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`result`&nbsp;&nbsp;-&nbsp;&nbsp;The Version, or null when parse fails.<br />
>
><b>Returns:</b> A boolean indicating success of the parse operation.
#### TryParse
>```csharp
>bool TryParse(string input, bool looseMode, out SemanticVersion result)
>```
><b>Summary:</b> Try to construct a new semantic version from a version string.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`input`&nbsp;&nbsp;-&nbsp;&nbsp;The version string.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`result`&nbsp;&nbsp;-&nbsp;&nbsp;The Version, or null when parse fails.<br />
>
><b>Returns:</b> A boolean indicating success of the parse operation.
### Properties

#### Build
>```csharp
>Build
>```
><b>Summary:</b> The build string, or null for no build version.
#### IsPreRelease
>```csharp
>IsPreRelease
>```
><b>Summary:</b> Whether this version is a pre-release.
#### IsStrictMode
>```csharp
>IsStrictMode
>```
><b>Summary:</b> Whether this version is a strict SemVer2.0.
#### Major
>```csharp
>Major
>```
><b>Summary:</b> The major part of the version.
>
><b>Remarks:</b> Increment the major version part - when you make incompatible API changes.
#### Minor
>```csharp
>Minor
>```
><b>Summary:</b> The minor part of the version.uu
>
><b>Remarks:</b> Increment the minor version part - when you add functionality in a backwards compatible manner.
#### Patch
>```csharp
>Patch
>```
><b>Summary:</b> The patch part of the version.
>
><b>Remarks:</b> Increment the patch version part - when you make backwards compatible bug fixes.
#### PreRelease
>```csharp
>PreRelease
>```
><b>Summary:</b> The pre-release string, or null for no pre-release version.
### Methods

#### BaseVersion
>```csharp
>SemanticVersion BaseVersion()
>```
><b>Summary:</b> Returns this version without any pre-release or build version.
>
><b>Returns:</b> The base version
#### CompareTo
>```csharp
>int CompareTo(object obj)
>```
><b>Summary:</b> Compares two versions are semantically.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`obj`&nbsp;&nbsp;-&nbsp;&nbsp;The other.<br />
#### CompareTo
>```csharp
>int CompareTo(SemanticVersion other)
>```
><b>Summary:</b> Compares two versions are semantically.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`obj`&nbsp;&nbsp;-&nbsp;&nbsp;The other.<br />
#### CompareTo
>```csharp
>int CompareTo(SemanticVersion otherVersion, int significantParts, int startingPart, bool looseMode = False)
>```
><b>Summary:</b> Compares two versions are semantically.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`obj`&nbsp;&nbsp;-&nbsp;&nbsp;The other.<br />
#### Equals
>```csharp
>bool Equals(SemanticVersion other)
>```
><b>Summary:</b> Test whether two versions are semantically equivalent.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`other`&nbsp;&nbsp;-&nbsp;&nbsp;The other.<br />
#### Equals
>```csharp
>bool Equals(object obj)
>```
><b>Summary:</b> Test whether two versions are semantically equivalent.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`other`&nbsp;&nbsp;-&nbsp;&nbsp;The other.<br />
#### GetHashCode
>```csharp
>int GetHashCode()
>```
><b>Summary:</b> Calculate a hash code for the version.
#### GreaterThan
>```csharp
>bool GreaterThan(SemanticVersion otherVersion, int significantParts = 4, int startingPart = 1, bool looseMode = False)
>```
><b>Summary:</b> Greater than.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`otherVersion`&nbsp;&nbsp;-&nbsp;&nbsp;The other version.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`significantParts`&nbsp;&nbsp;-&nbsp;&nbsp;The significant parts.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`startingPart`&nbsp;&nbsp;-&nbsp;&nbsp;The starting part.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`looseMode`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [loose mode].<br />
#### GreaterThanOrEqualTo
>```csharp
>bool GreaterThanOrEqualTo(SemanticVersion otherVersion, int significantParts = 4, int startingPart = 1)
>```
><b>Summary:</b> Greater than or equal.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`otherVersion`&nbsp;&nbsp;-&nbsp;&nbsp;The other version.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`significantParts`&nbsp;&nbsp;-&nbsp;&nbsp;The significant parts.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`startingPart`&nbsp;&nbsp;-&nbsp;&nbsp;The starting part.<br />
#### IsNewerThan
>```csharp
>bool IsNewerThan(SemanticVersion otherVersion, bool withinMinorReleaseOnly = False, bool looseMode = False)
>```
><b>Summary:</b> Is newer than.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`otherVersion`&nbsp;&nbsp;-&nbsp;&nbsp;The other version.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`withinMinorReleaseOnly`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [within minor release only].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`looseMode`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [loose mode].<br />
#### ToString
>```csharp
>string ToString()
>```
#### ToVersion
>```csharp
>Version ToVersion()
>```
><b>Summary:</b> Converts to `System.Version` based on Major, Minor and Patch.
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
