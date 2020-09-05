<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.CodeDocumentation

<br />


## AtcCodeDocumentationAssemblyTypeInitializer

```csharp
public class AtcCodeDocumentationAssemblyTypeInitializer
```


<br />


## DocumentationHelper
DocumentationHelper.


```csharp
public static class DocumentationHelper
```

### Static Methods


#### CollectExportedTypesWithMissingCommentsFromAssembly

```csharp
TypeComments[] CollectExportedTypesWithMissingCommentsFromAssembly(Assembly assembly, List<Type> excludeTypes = null)
```
<p><b>Summary:</b> Collects the exported types with missing comments from assembly.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeTypes`&nbsp;&nbsp;-&nbsp;&nbsp;The exclude types.<br />
#### CollectExportedTypesWithMissingCommentsFromAssemblyAndGenerateText

```csharp
string CollectExportedTypesWithMissingCommentsFromAssemblyAndGenerateText(Assembly assembly, List<Type> excludeTypes = null, bool useFullName = False)
```
<p><b>Summary:</b> Collects the exported types with missing comments from assembly and generate text.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeTypes`&nbsp;&nbsp;-&nbsp;&nbsp;The exclude types.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
#### CollectExportedTypesWithMissingCommentsFromAssemblyAndGenerateTextLines

```csharp
string[] CollectExportedTypesWithMissingCommentsFromAssemblyAndGenerateTextLines(Assembly assembly, List<Type> excludeTypes = null, bool useFullName = False)
```
<p><b>Summary:</b> Collects the exported types with missing comments from assembly and generate text lines.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`excludeTypes`&nbsp;&nbsp;-&nbsp;&nbsp;The exclude types.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
#### CollectExportedTypeWithCommentsFromType

```csharp
TypeComments CollectExportedTypeWithCommentsFromType(Type type)
```
<p><b>Summary:</b> Collects the type of the exported type with comments from.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />

<br />


## MemberType
MemberType.


```csharp
public enum MemberType
```


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


```csharp
public class TypeComments
```

### Properties


#### BeautifyHtmlName

```csharp
BeautifyHtmlName
```
<p><b>Summary:</b> Gets the name of the beautify HTML.</p>

#### CommentLookup

```csharp
CommentLookup
```
<p><b>Summary:</b> Gets the comment lookup.</p>

#### FullName

```csharp
FullName
```
<p><b>Summary:</b> Gets the full name.</p>

#### HasComments

```csharp
HasComments
```
<p><b>Summary:</b> Gets a value indicating whether this instance has comments.</p>

#### Name

```csharp
Name
```
<p><b>Summary:</b> Gets the name.</p>

#### Namespace

```csharp
Namespace
```
<p><b>Summary:</b> Gets the namespace.</p>

#### Type

```csharp
Type
```
<p><b>Summary:</b> Gets the type.</p>

### Methods


#### GetEvents

```csharp
EventInfo[] GetEvents()
```
#### GetFields

```csharp
FieldInfo[] GetFields()
```
#### GetMethods

```csharp
MethodInfo[] GetMethods()
```
#### GetProperties

```csharp
PropertyInfo[] GetProperties()
```
#### GetStaticEvents

```csharp
EventInfo[] GetStaticEvents()
```
#### GetStaticFields

```csharp
FieldInfo[] GetStaticFields()
```
#### GetStaticMethods

```csharp
MethodInfo[] GetStaticMethods()
```
#### GetStaticProperties

```csharp
PropertyInfo[] GetStaticProperties()
```
#### GetXmlDocumentComments

```csharp
XmlDocumentComment[] GetXmlDocumentComments()
```
<p><b>Summary:</b> Gets the XML document comments.</p>

#### ToString

```csharp
string ToString()
```
<p><b>Summary:</b> Converts to string.</p>

<p><b>Returns:</b> A string that represents this instance.</p>


<br />


## XmlDocumentComment
XmlDocumentComment.


```csharp
public class XmlDocumentComment
```

### Properties


#### ClassName

```csharp
ClassName
```
<p><b>Summary:</b> Gets or sets the name of the class.</p>

#### Code

```csharp
Code
```
<p><b>Summary:</b> Gets or sets the code.</p>

#### Example

```csharp
Example
```
<p><b>Summary:</b> Gets or sets the example.</p>

#### MemberName

```csharp
MemberName
```
<p><b>Summary:</b> Gets or sets the name of the member.</p>

#### MemberType

```csharp
MemberType
```
<p><b>Summary:</b> Gets or sets the type of the member.</p>

#### Parameters

```csharp
Parameters
```
<p><b>Summary:</b> Gets or sets the parameters.</p>

#### Remarks

```csharp
Remarks
```
<p><b>Summary:</b> Gets or sets the remarks.</p>

#### Returns

```csharp
Returns
```
<p><b>Summary:</b> Gets or sets the returns.</p>

#### Summary

```csharp
Summary
```
<p><b>Summary:</b> Gets or sets the summary.</p>

### Methods


#### ToString

```csharp
string ToString()
```
<p><b>Summary:</b> Converts to string.</p>

<p><b>Returns:</b> A string that represents this instance.</p>

<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
