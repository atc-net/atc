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


#### GetExportedTypeByName

```csharp
Type GetExportedTypeByName(this Assembly assembly, string typeName)
```
<p><b>Summary:</b> Gets the name of the exported type by.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`typeName`&nbsp;&nbsp;-&nbsp;&nbsp;Name of the type.<br />
#### GetPrettyName

```csharp
string GetPrettyName(this Assembly assembly)
```
<p><b>Summary:</b> Gets the name of the pretty.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly.<br />
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

<br />


## TypeExtensions
Extensions for the `System.Type` class.


```csharp
public static class TypeExtensions
```

### Static Methods


#### BeautifyName

```csharp
string BeautifyName(this Type type, bool useFullName = False, bool useHtmlFormat = False, bool useGenericParameterNamesAsT = False, bool useSuffixQuestionMarkForGeneric = False)
```
<p><b>Summary:</b> Beautifies the name.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useHtmlFormat`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use HTML format].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useGenericParameterNamesAsT`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use generic parameter names as t].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useSuffixQuestionMarkForGeneric`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use suffix question mark for generic].<br />
#### BeautifyTypeName

```csharp
string BeautifyTypeName(this Type type, bool useFullName = False)
```
<p><b>Summary:</b> Beautifies the name of the type.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
#### BeautifyTypeOfName

```csharp
string BeautifyTypeOfName(this Type type, bool useFullName = False, bool useHtmlFormat = False)
```
<p><b>Summary:</b> Beautifies the name of the type of.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useHtmlFormat`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use HTML format].<br />
#### GetAttribute

```csharp
T GetAttribute(this Type type)
```
<p><b>Summary:</b> Gets the attribute.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
#### GetAttributes

```csharp
IEnumerable<T> GetAttributes(this Type type)
```
<p><b>Summary:</b> Gets the attributes.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
#### GetBaseTypeGenericArgumentType

```csharp
Type GetBaseTypeGenericArgumentType(this Type type)
```
<p><b>Summary:</b> Gets the type of the base type generic argument.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
#### GetBaseTypeGenericArgumentTypes

```csharp
Type[] GetBaseTypeGenericArgumentTypes(this Type type)
```
<p><b>Summary:</b> Gets the base type generic argument types.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
#### GetNameWithoutGenericType

```csharp
string GetNameWithoutGenericType(this Type type, bool useFullName = False)
```
<p><b>Summary:</b> Get the name of the type without generic part.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [use full name].<br />
#### GetPrivateDeclaredOnlyMethod

```csharp
MethodInfo GetPrivateDeclaredOnlyMethod(this Type type, string name)
```
<p><b>Summary:</b> Gets the private declared only method.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`name`&nbsp;&nbsp;-&nbsp;&nbsp;The name.<br />
#### GetPrivateDeclaredOnlyMethods

```csharp
MethodInfo[] GetPrivateDeclaredOnlyMethods(this Type type)
```
<p><b>Summary:</b> Gets the private declared only methods.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
#### GetPublicDeclaredOnlyMethods

```csharp
MethodInfo[] GetPublicDeclaredOnlyMethods(this Type type)
```
<p><b>Summary:</b> Gets the public declared only methods.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
<p><b>Remarks:</b> Use: BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly.</p>

#### HasValidationAttributes

```csharp
bool HasValidationAttributes(this Type type)
```
<p><b>Summary:</b> Determines whether [has validation attributes].</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
<p><b>Returns:</b> true if [has validation attributes] [the specified type]; otherwise, false.</p>

#### IsDelegate

```csharp
bool IsDelegate(this Type type)
```
<p><b>Summary:</b> Determines whether this instance is delegate.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
<p><b>Returns:</b> true if the specified type is delegate; otherwise, false.</p>

#### IsInheritedFrom

```csharp
bool IsInheritedFrom(this Type type, Type inheritType)
```
<p><b>Summary:</b> Determines whether [is inherited from] [the specified inherit type].</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`inheritType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the inherit.<br />
<p><b>Returns:</b> true if [is inherited from] [the specified inherit type]; otherwise, false.</p>

#### IsInheritedFromGenericWithArgumentType

```csharp
bool IsInheritedFromGenericWithArgumentType(this Type type, Type inheritType, Type argumentType, bool matchAlsoOnArgumentTypeInterface = True)
```
<p><b>Summary:</b> Determines whether [is inherited from generic with argument type] [the specified inherit type].</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`inheritType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the inherit.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`argumentType`&nbsp;&nbsp;-&nbsp;&nbsp;Type of the argument.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`matchAlsoOnArgumentTypeInterface`&nbsp;&nbsp;-&nbsp;&nbsp;if set to true [match also on argument type interface].<br />
<p><b>Returns:</b> true if [is inherited from generic with argument type] [the specified inherit type]; otherwise, false.</p>

#### IsNullable

```csharp
bool IsNullable(this Type type)
```
<p><b>Summary:</b> Determines whether this instance is nullable.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
<p><b>Returns:</b> true if the specified type is nullable; otherwise, false.</p>

#### IsSimple

```csharp
bool IsSimple(this Type type)
```
<p><b>Summary:</b> Determines whether this instance is simple.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
<p><b>Returns:</b> true if the specified type is simple; otherwise, false.</p>

#### TryGetAttribute

```csharp
T TryGetAttribute(this Type type)
```
<p><b>Summary:</b> Tries the get attribute.</p>

<b>Parameters</b>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The type.<br />
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
