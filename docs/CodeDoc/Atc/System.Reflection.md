<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# System.Reflection

<br />

## AssemblyExtensions
Extensions for the `System.Reflection.Assembly` class.

>```csharp
>public static class AssemblyExtensions
>```

### Static Methods

#### GetBeautifiedName
>```csharp
>string GetBeautifiedName(this Assembly assembly)
>```
><b>Summary:</b> Gets a beautified name of the assembly by replacing dots with spaces.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly to beautify.<br />
>
><b>Returns:</b> The beautified assembly name with dots replaced by spaces.
#### GetExportedTypeByName
>```csharp
>Type GetExportedTypeByName(this Assembly assembly, string typeName)
>```
><b>Summary:</b> Gets an exported type from the assembly by its type name.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly to search.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`typeName`&nbsp;&nbsp;-&nbsp;&nbsp;The name of the type to find.<br />
>
><b>Returns:</b> The type if found; otherwise, null.
#### GetFileVersion
>```csharp
>Version GetFileVersion(this Assembly assembly)
>```
><b>Summary:</b> Gets the file version of the assembly.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly to query.<br />
>
><b>Returns:</b> The file version, or 1.0.0.0 if the version cannot be determined.
#### GetResourceManagers
>```csharp
>ResourceManager[] GetResourceManagers(this Assembly assembly)
>```
><b>Summary:</b> Gets all resource managers from the assembly.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly to search for resource managers.<br />
>
><b>Returns:</b> An array of resource managers sorted by base name.
#### GetTypesInheritingFromType
>```csharp
>Type[] GetTypesInheritingFromType(this Assembly assembly, Type type)
>```
><b>Summary:</b> Gets all types in the assembly that inherit from a specific type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly to search.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`type`&nbsp;&nbsp;-&nbsp;&nbsp;The base type to search for inherited types.<br />
>
><b>Returns:</b> An array of types that inherit from the specified type.
#### IsDebugBuild
>```csharp
>bool IsDebugBuild(this Assembly assembly)
>```
><b>Summary:</b> Diagnostics a assembly to find out, is this complied a debug assembly.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`assembly`&nbsp;&nbsp;-&nbsp;&nbsp;The assembly.<br />
>
><b>Returns:</b> <see langword="true" /> if assembly is a debug compilation, <see langword="false" /> if the assembly is a release compilation.

<br />

## FieldInfoExtensions
Extensions for the `System.Reflection.FieldInfo` class.

>```csharp
>public static class FieldInfoExtensions
>```

### Static Methods

#### BeautifyName
>```csharp
>string BeautifyName(this FieldInfo fieldInfo, bool useFullName = False, bool useHtmlFormat = False, bool includeReturnType = False)
>```
><b>Summary:</b> Beautifies the name.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`fieldInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The field information.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [use full name].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useHtmlFormat`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [use HTML format].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeReturnType`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [include return type].<br />

<br />

## MemberInfoExtensions
Extensions for the `System.Reflection.MemberInfo` class.

>```csharp
>public static class MemberInfoExtensions
>```

### Static Methods

#### AnyCustomAttributes
>```csharp
>bool AnyCustomAttributes(this MemberInfo element)
>```
><b>Summary:</b> Determines whether the member has any custom attributes of the specified type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`element`&nbsp;&nbsp;-&nbsp;&nbsp;The member to check for custom attributes.<br />
>
><b>Returns:</b> <see langword="true" /> if the member has one or more custom attributes of type `T`; otherwise, <see langword="false" />.
#### GetUnderlyingType
>```csharp
>Type GetUnderlyingType(this MemberInfo member)
>```
><b>Summary:</b> Gets the underlying type of the member (event, field, method return, or property type).
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`member`&nbsp;&nbsp;-&nbsp;&nbsp;The member whose underlying type to retrieve.<br />
>
><b>Returns:</b> The underlying type of the member.
#### HasCompilerGeneratedAttribute
>```csharp
>bool HasCompilerGeneratedAttribute(this MemberInfo memberInfo)
>```
><b>Summary:</b> Determines whether the member has the CompilerGenerated attribute.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`memberInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The member information to check.<br />
>
><b>Returns:</b> <see langword="true" /> if the member has the CompilerGenerated attribute; otherwise, <see langword="false" />.
#### HasExcludeFromCodeCoverageAttribute
>```csharp
>bool HasExcludeFromCodeCoverageAttribute(this MemberInfo memberInfo)
>```
><b>Summary:</b> Determines whether [has exclude from code coverage attribute].
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`memberInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The member information.<br />
>
><b>Returns:</b> <see langword="true" /> if [has exclude from code coverage attribute] [the specified member information]; otherwise, <see langword="false" />.
#### HasIgnoreDisplayAttribute
>```csharp
>bool HasIgnoreDisplayAttribute(this MemberInfo memberInfo)
>```
><b>Summary:</b> Determines whether [has ignore display attribute].
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`memberInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The member information.<br />
>
><b>Returns:</b> <see langword="true" /> if [has ignore display attribute] [the specified member information]; otherwise, <see langword="false" />.
#### HasRequiredAttribute
>```csharp
>bool HasRequiredAttribute(this MemberInfo memberInfo)
>```
><b>Summary:</b> Determines whether [has required attribute].
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`memberInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The member information.<br />
>
><b>Returns:</b> <see langword="true" /> if [has required attribute] [the specified member information]; otherwise, <see langword="false" />.
#### IsPropertyWithSetter
>```csharp
>bool IsPropertyWithSetter(this MemberInfo member)
>```
><b>Summary:</b> Determines whether the member is a property with a setter method.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`member`&nbsp;&nbsp;-&nbsp;&nbsp;The member to check.<br />
>
><b>Returns:</b> <see langword="true" /> if the member is a property with a setter; otherwise, <see langword="false" />.

<br />

## MethodInfoExtensions
Extensions for the `System.Reflection.MethodInfo` class.

>```csharp
>public static class MethodInfoExtensions
>```

### Static Methods

#### BeautifyName
>```csharp
>string BeautifyName(this MethodInfo methodInfo, bool useFullName = False, bool useHtmlFormat = False, bool includeReturnType = False)
>```
><b>Summary:</b> Beautifies the name.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`methodInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The method information.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useFullName`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [use full name].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useHtmlFormat`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [use HTML format].<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`includeReturnType`&nbsp;&nbsp;-&nbsp;&nbsp;if set to  [include return type].<br />
#### HasDeclaringTypeValidationAttributes
>```csharp
>bool HasDeclaringTypeValidationAttributes(this MethodInfo methodInfo)
>```
><b>Summary:</b> Determines whether [has declaring type validation attributes].
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`methodInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The method information.<br />
>
><b>Returns:</b> <see langword="true" /> if [has declaring type validation attributes] [the specified method information]; otherwise, <see langword="false" />.
#### HasGenericParameters
>```csharp
>bool HasGenericParameters(this MethodInfo methodInfo)
>```
><b>Summary:</b> Determines whether [has generic parameters].
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`methodInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The method information.<br />
>
><b>Returns:</b> <see langword="true" /> if [has generic parameters] [the specified method information]; otherwise, <see langword="false" />.
#### IsOverride
>```csharp
>bool IsOverride(this MethodInfo methodInfo)
>```
><b>Summary:</b> Determines whether this instance is override.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`methodInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The method information.<br />
>
><b>Returns:</b> <see langword="true" /> if the specified method information is override; otherwise, <see langword="false" />.

<br />

## PropertyInfoExtensions
Extensions for the `System.Reflection.PropertyInfo` class.

>```csharp
>public static class PropertyInfoExtensions
>```

### Static Methods

#### BeautifyName
>```csharp
>string BeautifyName(this PropertyInfo propertyInfo)
>```
><b>Summary:</b> Gets a beautified name of the property's type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`propertyInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The property information.<br />
>
><b>Returns:</b> A beautified string representation of the property's type.
#### GetDescription
>```csharp
>string GetDescription(this PropertyInfo propertyInfo, bool useLocalizedIfPossible = True)
>```
><b>Summary:</b> Gets the description of the property from various description attributes or the property name.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`propertyInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The property information.<br />
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`useLocalizedIfPossible`&nbsp;&nbsp;-&nbsp;&nbsp;If set to , attempts to use localized description first.<br />
>
><b>Returns:</b> The description of the property.
#### GetName
>```csharp
>string GetName(this PropertyInfo propertyInfo)
>```
><b>Summary:</b> Gets the display name of the property from DisplayName, Display, or the property name itself.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`propertyInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The property information.<br />
>
><b>Returns:</b> The display name of the property.
#### IsNullable
>```csharp
>bool IsNullable(this PropertyInfo propertyInfo)
>```
><b>Summary:</b> Determines whether the property type is a nullable value type.
>
><b>Parameters:</b><br>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`propertyInfo`&nbsp;&nbsp;-&nbsp;&nbsp;The property information.<br />
>
><b>Returns:</b> <see langword="true" /> if the property is a nullable value type; otherwise, <see langword="false" />.
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
