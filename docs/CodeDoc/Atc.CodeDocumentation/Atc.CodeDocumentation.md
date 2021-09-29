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

## DocumentationHelper
DocumentationHelper.

>```csharp
>public static class DocumentationHelper
>```

### Static Methods

#### CollectExportedTypesWithMissingCommentsFromAssembly
>```csharp
>TypeComments[] CollectExportedTypesWithMissingCommentsFromAssembly(Assembly assembly, List<Type> excludeTypes = null)
>```
><b>Summary:</b> Collects the exported types with missing comments from assembly.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeTypes`&nbsp;&nbsp;-&nbsp;&nbsp;The exclude types.<br />
#### CollectExportedTypesWithMissingCommentsFromAssemblyAndGenerateText
>```csharp
>string CollectExportedTypesWithMissingCommentsFromAssemblyAndGenerateText(Assembly assembly, List<Type> excludeTypes = null, bool useFullName = False)
>```
><b>Summary:</b> Collects the exported types with missing comments from assembly and generate text.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeTypes`&nbsp;&nbsp;-&nbsp;&nbsp;The exclude types.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
#### CollectExportedTypesWithMissingCommentsFromAssemblyAndGenerateTextLines
>```csharp
>string[] CollectExportedTypesWithMissingCommentsFromAssemblyAndGenerateTextLines(Assembly assembly, List<Type> excludeTypes = null, bool useFullName = False)
>```
><b>Summary:</b> Collects the exported types with missing comments from assembly and generate text lines.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeTypes`&nbsp;&nbsp;-&nbsp;&nbsp;The exclude types.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
#### CollectExportedTypeWithCommentsFromType
>```csharp
>TypeComments CollectExportedTypeWithCommentsFromType(Type type)
>```
><b>Summary:</b> Collects the type of the exported type with comments from.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />

<br />

## MemberType
MemberType.

>```csharp
>public enum MemberType
>```


| Value | Name | Description | Summary | 
| --- | --- | --- | --- | 
| 0 | None | None | The none. | 
| 69 | Event | Event | The event. | 
| 70 | Field | Field | The field. | 
| 77 | Method | Method | The method. | 
| 80 | Property | Property | The property. | 
| 84 | Type | Type | The type. | 



<br />

## TypeComments
TypeComments.

>```csharp
>public class TypeComments
>```

### Properties

#### BeautifyHtmlName
>```csharp
>BeautifyHtmlName
>```
><b>Summary:</b> Gets the name of the beautify HTML.
#### CommentLookup
>```csharp
>CommentLookup
>```
><b>Summary:</b> Gets the comment lookup.
#### FullName
>```csharp
>FullName
>```
><b>Summary:</b> Gets the full name.
#### HasComments
>```csharp
>HasComments
>```
><b>Summary:</b> Gets a value indicating whether this instance has comments.
#### Name
>```csharp
>Name
>```
><b>Summary:</b> Gets the name.
#### Namespace
>```csharp
>Namespace
>```
><b>Summary:</b> Gets the namespace.
#### Type
>```csharp
>Type
>```
><b>Summary:</b> Gets the type.
### Methods

#### GetXmlDocumentComments
>```csharp
>XmlDocumentComment[] GetXmlDocumentComments()
>```
><b>Summary:</b> Gets the XML document comments.
#### ToString
>```csharp
>string ToString()
>```
><b>Summary:</b> Converts to string.
>
><b>Returns:</b> A string that represents this instance.

<br />

## XmlDocumentComment
XmlDocumentComment.

>```csharp
>public class XmlDocumentComment
>```

### Properties

#### ClassName
>```csharp
>ClassName
>```
><b>Summary:</b> Gets or sets the name of the class.
#### Code
>```csharp
>Code
>```
><b>Summary:</b> Gets or sets the code.
#### Example
>```csharp
>Example
>```
><b>Summary:</b> Gets or sets the example.
#### MemberName
>```csharp
>MemberName
>```
><b>Summary:</b> Gets or sets the name of the member.
#### MemberType
>```csharp
>MemberType
>```
><b>Summary:</b> Gets or sets the type of the member.
#### Parameters
>```csharp
>Parameters
>```
><b>Summary:</b> Gets or sets the parameters.
#### Remarks
>```csharp
>Remarks
>```
><b>Summary:</b> Gets or sets the remarks.
#### Returns
>```csharp
>Returns
>```
><b>Summary:</b> Gets or sets the returns.
#### Summary
>```csharp
>Summary
>```
><b>Summary:</b> Gets or sets the summary.
### Methods

#### ToString
>```csharp
>string ToString()
>```
><b>Summary:</b> Converts to string.
>
><b>Returns:</b> A string that represents this instance.
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
