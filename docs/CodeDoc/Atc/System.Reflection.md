<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# System.Reflection

<br />


## AssemblyExtensions
Extensions for the `System.Reflection.Assembly` class.


```csharp
public static class AssemblyExtensions
```

### Static Methods


#### GetBeautifiedName

```csharp
string GetBeautifiedName(this Assembly assembly)
```
<p><b>Summary:</b> Gets the beautified name of the assembly.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly.<br />
#### GetExportedTypeByName

```csharp
Type GetExportedTypeByName(this Assembly assembly, string typeName)
```
<p><b>Summary:</b> Gets the name of the exported type by typeName.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`typeName`&nbsp;&nbsp;-&nbsp;&nbsp;Name of the type.<br />
#### GetTypesInheritingFromType

```csharp
Type[] GetTypesInheritingFromType(this Assembly assembly, Type type)
```
<p><b>Summary:</b> Gets the types inheriting from a specific type.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type from which other types are inheriting.<br />
#### IsDebugBuild

```csharp
bool IsDebugBuild(this Assembly assembly)
```
<p><b>Summary:</b> Diagnostics a assembly to find out, is this complied a debug assembly.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly.<br />
<p><b>Returns:</b> true if assembly is a debug compilation, false if the assembly is a release compilation.</p>


<br />


## FieldInfoExtensions
Extensions for the `System.Reflection.FieldInfo` class.


```csharp
public static class FieldInfoExtensions
```

### Static Methods


#### BeautifyName

```csharp
string BeautifyName(this FieldInfo fieldInfo, bool useFullName = False, bool useHtmlFormat = False, bool includeReturnType = False)
```
<p><b>Summary:</b> Beautifies the name.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fieldInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The field information.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useHtmlFormat`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use HTML format].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeReturnType`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [include return type].<br />

<br />


## MemberInfoExtensions
Extensions for the `System.Reflection.MemberInfo` class.


```csharp
public static class MemberInfoExtensions
```

### Static Methods


#### GetUnderlyingType

```csharp
Type GetUnderlyingType(this MemberInfo member)
```
<p><b>Summary:</b> Gets the type of the underlying.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`member`&nbsp;&nbsp;-&nbsp;&nbsp;The member.<br />
#### HasExcludeFromCodeCoverageAttribute

```csharp
bool HasExcludeFromCodeCoverageAttribute(this MemberInfo memberInfo)
```
<p><b>Summary:</b> Determines whether [has exclude from code coverage attribute].</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`memberInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The member information.<br />
<p><b>Returns:</b> true if [has exclude from code coverage attribute] [the specified member information]; otherwise, false.</p>

#### HasIgnoreDisplayAttribute

```csharp
bool HasIgnoreDisplayAttribute(this MemberInfo memberInfo)
```
<p><b>Summary:</b> Determines whether [has ignore display attribute].</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`memberInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The member information.<br />
<p><b>Returns:</b> true if [has ignore display attribute] [the specified member information]; otherwise, false.</p>

#### HasRequiredAttribute

```csharp
bool HasRequiredAttribute(this MemberInfo memberInfo)
```
<p><b>Summary:</b> Determines whether [has required attribute].</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`memberInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The member information.<br />
<p><b>Returns:</b> true if [has required attribute] [the specified member information]; otherwise, false.</p>

#### IsPropertyWithSetter

```csharp
bool IsPropertyWithSetter(this MemberInfo member)
```
<p><b>Summary:</b> Determines whether [is property with setter].</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`member`&nbsp;&nbsp;-&nbsp;&nbsp;The member.<br />

<br />


## MethodInfoExtensions
Extensions for the `System.Reflection.MethodInfo` class.


```csharp
public static class MethodInfoExtensions
```

### Static Methods


#### BeautifyName

```csharp
string BeautifyName(this MethodInfo methodInfo, bool useFullName = False, bool useHtmlFormat = False, bool includeReturnType = False)
```
<p><b>Summary:</b> Beautifies the name.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`methodInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The method information.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useHtmlFormat`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use HTML format].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeReturnType`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [include return type].<br />
#### HasDeclaringTypeValidationAttributes

```csharp
bool HasDeclaringTypeValidationAttributes(this MethodInfo methodInfo)
```
<p><b>Summary:</b> Determines whether [has declaring type validation attributes].</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`methodInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The method information.<br />
<p><b>Returns:</b> true if [has declaring type validation attributes] [the specified method information]; otherwise, false.</p>

#### HasGenericParameters

```csharp
bool HasGenericParameters(this MethodInfo methodInfo)
```
<p><b>Summary:</b> Determines whether [has generic parameters].</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`methodInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The method information.<br />
<p><b>Returns:</b> true if [has generic parameters] [the specified method information]; otherwise, false.</p>

#### IsOverride

```csharp
bool IsOverride(this MethodInfo methodInfo)
```
<p><b>Summary:</b> Determines whether this instance is override.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`methodInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The method information.<br />
<p><b>Returns:</b> true if the specified method information is override; otherwise, false.</p>


<br />


## PropertyInfoExtensions
Extensions for the `System.Reflection.PropertyInfo` class.


```csharp
public static class PropertyInfoExtensions
```

### Static Methods


#### BeautifyName

```csharp
string BeautifyName(this PropertyInfo propertyInfo)
```
<p><b>Summary:</b> Beautifies the name.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`propertyInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The property information.<br />
#### GetDescription

```csharp
string GetDescription(this PropertyInfo propertyInfo, bool useLocalizedIfPossible = True)
```
<p><b>Summary:</b> Gets the description.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`propertyInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The property information.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useLocalizedIfPossible`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use localized if possible].<br />
#### GetName

```csharp
string GetName(this PropertyInfo propertyInfo)
```
<p><b>Summary:</b> Gets the name.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`propertyInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The property information.<br />
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
