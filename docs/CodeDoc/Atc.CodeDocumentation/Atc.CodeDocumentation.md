<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.CodeDocumentation

<br />

## AtcCodeDocumentationAssemblyTypeInitializer

>```csharp
>public static class AtcCodeDocumentationAssemblyTypeInitializer
>```


<br />

## Constants
Provides constant values used throughout the code documentation system.

>```csharp
>public static class Constants
>```

### Static Fields

#### UndefinedDescription
>```csharp
>string UndefinedDescription
>```
><b>Summary:</b> The default text used when a description is not defined or cannot be found in the XML documentation.

<br />

## DocumentationHelper
Provides public API methods for collecting and analyzing XML documentation comments from assemblies and types.

>```csharp
>public static class DocumentationHelper
>```

### Static Methods

#### CollectExportedTypeWithCommentsFromType
>```csharp
>TypeComments CollectExportedTypeWithCommentsFromType(Type type)
>```
><b>Summary:</b> Collects XML documentation comments for a specific type from its assembly.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type to collect documentation for.<br />
>
><b>Returns:</b> The type comments, or <see langword="null" /> if the type was not found.
#### CollectExportedTypesWithMissingCommentsFromAssembly
>```csharp
>TypeComments[] CollectExportedTypesWithMissingCommentsFromAssembly(Assembly assembly, List<Type> excludeTypes = null)
>```
><b>Summary:</b> Collects all public types from an assembly that are missing XML documentation comments.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly to scan for types.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeTypes`&nbsp;&nbsp;-&nbsp;&nbsp;Optional list of types to exclude from the results.<br />
>
><b>Returns:</b> An array of type comments for types missing documentation.
#### CollectExportedTypesWithMissingCommentsFromAssemblyAndGenerateText
>```csharp
>string CollectExportedTypesWithMissingCommentsFromAssemblyAndGenerateText(Assembly assembly, List<Type> excludeTypes = null, bool useFullName = False)
>```
><b>Summary:</b> Collects all public types from an assembly that are missing XML documentation and generates a formatted text report.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly to scan for types.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeTypes`&nbsp;&nbsp;-&nbsp;&nbsp;Optional list of types to exclude from the results.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;If , uses fully qualified type names in the output; otherwise uses simple names.<br />
>
><b>Returns:</b> A string containing one type name per line for all types missing documentation.
#### CollectExportedTypesWithMissingCommentsFromAssemblyAndGenerateTextLines
>```csharp
>string[] CollectExportedTypesWithMissingCommentsFromAssemblyAndGenerateTextLines(Assembly assembly, List<Type> excludeTypes = null, bool useFullName = False)
>```
><b>Summary:</b> Collects all public types from an assembly that are missing XML documentation and generates an array of type names.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly to scan for types.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeTypes`&nbsp;&nbsp;-&nbsp;&nbsp;Optional list of types to exclude from the results.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;If , uses fully qualified type names in the output; otherwise uses simple names.<br />
>
><b>Returns:</b> An array of type name strings, one per type missing documentation.

<br />

## MemberType
Represents the different types of members that can be documented in XML documentation comments. Each value corresponds to the member type prefix used in XML documentation names.

>```csharp
>public enum MemberType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | Represents no member type. | 
| 69 | Event | Event | Represents an event member (E: prefix in XML documentation). | 
| 70 | Field | Field | Represents a field member (F: prefix in XML documentation). | 
| 77 | Method | Method | Represents a method member (M: prefix in XML documentation). | 
| 80 | Property | Property | Represents a property member (P: prefix in XML documentation). | 
| 84 | Type | Type | Represents a type member such as a class, struct, interface, or enum (T: prefix in XML documentation). | 



<br />

## TypeComments
Represents a type along with its associated XML documentation comments and member information.

>```csharp
>public class TypeComments
>```

### Properties

#### BeautifyHtmlName
>```csharp
>BeautifyHtmlName
>```
><b>Summary:</b> Gets the HTML-formatted beautified name of the type.
#### CommentLookup
>```csharp
>CommentLookup
>```
><b>Summary:</b> Gets the lookup table mapping class names to their XML documentation comments.
#### FullName
>```csharp
>FullName
>```
><b>Summary:</b> Gets the fully qualified name of the type.
#### HasComments
>```csharp
>HasComments
>```
><b>Summary:</b> Gets a value indicating whether this type has XML documentation comments.
#### Name
>```csharp
>Name
>```
><b>Summary:</b> Gets the simple name of the type.
#### Namespace
>```csharp
>Namespace
>```
><b>Summary:</b> Gets the namespace of the type.
#### Type
>```csharp
>Type
>```
><b>Summary:</b> Gets the `System.Type` being documented.
### Methods

#### GetXmlDocumentComments
>```csharp
>XmlDocumentComment[] GetXmlDocumentComments()
>```
><b>Summary:</b> Retrieves all XML documentation comments associated with this type.
>
><b>Returns:</b> An array of XML documentation comments, or <see langword="null" /> if no comments exist.
#### ToString
>```csharp
>string ToString()
>```
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
