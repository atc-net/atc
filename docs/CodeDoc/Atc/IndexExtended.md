[![NuGet](https://img.shields.io/nuget/v/atc.svg?style=flat-square)](http://www.nuget.org/packages/atc)
[![NuGet](https://img.shields.io/nuget/dt/atc.svg?style=flat-square)](http://www.nuget.org/packages/atc)

<div style='text-align: right'>

[References](Index.md)

</div>


# References extended

## [Atc](Atc.md)

- [AtcAssemblyTypeInitializer](Atc.md#atcassemblytypeinitializer)
- [GlobalizationConstants](Atc.md#globalizationconstants)
  -  Static Fields
     - CultureInfo DanishCultureInfo
     - CultureInfo EnglishCultureInfo
     - string DateTimeIso8601
- [GlobalizationLcidConstants](Atc.md#globalizationlcidconstants)
  -  Static Fields
     - int Invariant
     - int UnitedStates
     - int GreatBritain
     - int Denmark
     - int Germany
- [IgnoreDisplayAttribute](Atc.md#ignoredisplayattribute)
- [LetterAccentType](Atc.md#letteraccenttype)
- [LocalizedDescriptionAttribute](Atc.md#localizeddescriptionattribute)
  -  Properties
     - Description
- [NumericAlphaComparer](Atc.md#numericalphacomparer)
  -  Methods
     - Compare(string x, string y)
- [TupleEqualityComparer&lt;T1, T2&gt;](Atc.md#tupleequalitycomparer&lt;t1-t2&gt;)
  -  Methods
     - Equals(Tuple&lt;T1, T2&gt; x, Tuple&lt;T1, T2&gt; y)
     - GetHashCode(Tuple&lt;T1, T2&gt; obj)

## [Atc.Collections](Atc.Collections.md)

- [ConcurrentHashSet&lt;T&gt;](Atc.Collections.md#concurrenthashset&lt;t&gt;)
  -  Properties
     - Count
  -  Methods
     - GetEnumerator()
     - TryAdd(T item)
     - TryRemove(T item)
     - Contains(T item)
     - Clear()
     - FirstOrDefault(Func&lt;T, bool&gt; predicate)
     - Dispose()
     - Dispose(bool disposing)

## [Atc.Enums](Atc.Enums.md)

- [DateTimeDiffCompareType](Atc.Enums.md#datetimediffcomparetype)

## [Atc.Extensions.BaseTypes](Atc.Extensions.BaseTypes.md)

- [DateTimeExtensions](Atc.Extensions.BaseTypes.md#datetimeextensions)
  -  Static Methods
     - ToIso8601Date(this DateTime dateTime)
     - IsBetween(this DateTime date, DateTime startDate, DateTime endDate)
     - GetPrettyTimeDiff(this DateTime startDate, int decimalPrecision = 3)
     - GetPrettyTimeDiff(this DateTime startDate, DateTime endDate, int decimalPrecision = 3)
     - GetWeekNumber(this DateTime date)
     - DateTimeDiff(this DateTime startDate, DateTime endDate, DateTimeDiffCompareType howToCompare)
     - ToIso8601UtcDate(this DateTime dateTime)

## [Atc.Helpers](Atc.Helpers.md)

- [ReflectionHelper](Atc.Helpers.md#reflectionhelper)
  -  Static Methods
     - SetPrivateField(object target, string fieldName, object value)
- [SimpleTypeHelper](Atc.Helpers.md#simpletypehelper)
  -  Static Fields
     - Type[] PrimitiveTypes
     - Type[] SimpleTypes
     - Dictionary&lt;Type, string&gt; BeautifySimpleTypeLookup
     - Dictionary&lt;Type, string&gt; BeautifySimpleTypeArrayLookup
  -  Static Methods
     - GetBeautifyTypeName(Type type)
     - GetBeautifyTypeNameByRef(Type type)
     - GetBeautifyArrayTypeName(Type type)

## [System](System.md)

- [AppDomainExtensions](System.md#appdomainextensions)
  -  Static Methods
     - GetAllExportedTypes(this AppDomain appDomain)
     - GetExportedTypeByName(this AppDomain appDomain, string typeName)
     - GetExportedPropertyTypeByName(this AppDomain appDomain, string typeName, string propertyName)
- [ArgumentNullOrDefaultException](System.md#argumentnullordefaultexception)
- [ArgumentNullOrDefaultPropertyException](System.md#argumentnullordefaultpropertyexception)
- [ArgumentNullPropertyException](System.md#argumentnullpropertyexception)
- [ArgumentPropertyException](System.md#argumentpropertyexception)
- [ArgumentPropertyNullException](System.md#argumentpropertynullexception)
- [EnumExtensions](System.md#enumextensions)
  -  Static Methods
     - IsSet(this Enum enumeration, Enum matchTo)
     - GetName(this Enum enumeration)
     - GetDescription(this Enum enumeration, bool useLocalizedIfPossible = True)
- [ExceptionExtensions](System.md#exceptionextensions)
  -  Static Methods
     - GetMessage(this Exception exception, bool includeInnerMessage = False, bool includeExceptionName = False)
     - GetLastInnerMessage(this Exception exception, bool includeExceptionName = False)
     - Flatten(this Exception exception, string message = , bool includeStackTrace = False)
     - ToXml(this Exception exception)
- [IntegerExtensions](System.md#integerextensions)
  -  Static Methods
     - IsEqual(this int? a, int? b)
     - IsEven(this int number)
     - IsOdd(this int number)
     - IsPrime(this int number)
     - IsBinarySequence(this int number)
     - GetMonthNameByMonthNumber(this int month, bool pascalCased = False)
     - GetNumberOfWeeksByYear(this int year)
     - GetFirstDayOfWeekNumberByYear(this int year, int weekNumber)
     - GetLastDayOfWeekNumberByYear(this int year, int weekNumber)
- [StringExtensions](System.md#stringextensions)
  -  Static Methods
     - IndexersOf(this string value, string pattern, bool ignoreCaseSensitive = True, bool useEndOfPatternToMatch = False)
     - WordCount(this string value)
     - GetStringFormatParameterNumericCount(this string value)
     - GetStringFormatParameterLiteralCount(this string value)
     - GetStringFormatParameterTemplatePlaceholders(this string value)
     - SetStringFormatParameterTemplatePlaceholders(this string value, Dictionary&lt;string, string&gt; replacements)
     - ParseDateFromIso8601(this string value)
     - TryParseDateFromIso8601(this string value, out DateTime dateTime)
     - TryParseDate(this string value, out DateTime dateTime)
     - TryParseDate(this string value, out DateTime dateTime, CultureInfo cultureInfo, DateTimeStyles dateTimeStyles = None)
     - Base64Encode(this string value)
     - Base64Decode(this string base64EData)
     - JavaScriptEncode(this string javaScript, bool htmlEncode)
     - JavaScriptDecode(this string javaScript, bool htmlDecode)
     - XmlEncode(this string xml)
     - XmlDecode(this string xml)
     - Alphabetize(this string value)
     - NormalizeAccents(this string value)
     - NormalizeAccents(this string value, LetterAccentType letterAccentType, bool decode, bool forLower, bool forUpper)
     - NormalizePascalCase(this string value)
     - Humanize(this string value)
     - CamelCase(this string value)
     - PascalCase(this string value, bool removeSeparators = False)
     - PascalCase(this string value, char[] separators, bool removeSeparators = False)
     - EnsureFirstLetterToUpper(this string value)
     - EnsureFirstLetterToLower(this string value)
     - EnsureSingular(this string value)
     - EnsurePlural(this string value)
     - EnsureFirstLetterToUpperAndSingular(this string value)
     - EnsureFirstLetterToUpperAndPlural(this string value)
     - Contains(this string value, string containsValue, bool ignoreCaseSensitive = True)
     - Cut(this string value, int maxLength, string appendValue = ...)
     - ReplaceAt(this string value, int index, char newChar)
     - ReplaceMany(this string value, IDictionary&lt;string, string&gt; replacements)
     - ReplaceMany(this string value, char[] chars, char replacement)
     - RemoveStart(this string value, string startValue, bool ignoreCaseSensitive = True)
     - RemoveEnd(this string value, string endValue, bool ignoreCaseSensitive = True)
     - RemoveEndingSlashIfExist(this string value)
     - RemoveDataCrap(this string value)
     - Truncate(this string value, int maxLength, string appendValue = ...)
     - TrimSpecial(this string value)
     - TrimExtended(this string value)
     - ToLines(this string value)
     - ToStream(this string value)
     - ToStreamFromBase64(this string base64Data)
- [StringHasIsExtensions](System.md#stringhasisextensions)
  -  Static Methods
     - HasHtmlTags(this string value)
     - IsEqual(this string a, string b, StringComparison stringComparison = Ordinal, bool treatNullAsEmpty = True, bool useNormalizeAccents = False)
     - IsTrue(this string value)
     - IsFalse(this string value)
     - IsAlphaOnly(this string value)
     - IsAlphaNumericOnly(this string value)
     - IsDate(this string value)
     - IsDate(this string value, CultureInfo cultureInfo)
     - IsDigitOnly(this string value)
     - IsFormatJson(this string value)
     - IsFormatXml(this string value)
     - IsGuid(this string value)
     - IsGuid(this string value, out Guid output)
     - IsKey(this string value)
     - IsLengthEven(this string value)
     - IsNumericOnly(this string value)
     - IsSentence(this string value)
     - IsStringFormatParametersBalanced(this string value, bool isNumeric = True)
     - IsWord(this string value)
     - IsCompanyCvrNumber(this string cvrNumber)
     - IsCompanyPNumber(this string pNumber)
     - IsPersonCprNumber(this string cprNumber)
     - IsEmailAddress(this string value)
- [SwitchCaseDefaultException](System.md#switchcasedefaultexception)
- [TypeExtensions](System.md#typeextensions)
  -  Static Methods
     - HasValidationAttributes(this Type type)
     - IsDelegate(this Type type)
     - IsNullable(this Type type)
     - IsSimple(this Type type)
     - IsInheritedFrom(this Type type, Type inheritType)
     - IsInheritedFromGenericWithArgumentType(this Type type, Type inheritType, Type argumentType, bool matchAlsoOnArgumentTypeInterface = True)
     - GetBaseTypeGenericArgumentType(this Type type)
     - GetBaseTypeGenericArgumentTypes(this Type type)
     - GetPublicDeclaredOnlyMethods(this Type type)
     - GetPrivateDeclaredOnlyMethods(this Type type)
     - GetPrivateDeclaredOnlyMethod(this Type type, string name)
     - GetNameWithoutGenericType(this Type type, bool useFullName = False)
     - BeautifyTypeOfName(this Type type, bool useFullName = False, bool useHtmlFormat = False)
     - BeautifyName(this Type type, bool useFullName = False, bool useHtmlFormat = False, bool useGenericParameterNamesAsT = False, bool useSuffixQuestionMarkForGeneric = False)
     - BeautifyTypeName(this Type type, bool useFullName = False)
     - TryGetEnumType(this Type type, out Type enumType)
     - IsSubClassOfRawGeneric(this Type baseType, Type derivedType)
     - GetAttribute(this Type type)
     - TryGetAttribute(this Type type)
     - GetAttributes(this Type type)
- [UnexpectedTypeException](System.md#unexpectedtypeexception)

## [System.Net](System.Net.md)

- [HttpStatusCodeExtensions](System.Net.md#httpstatuscodeextensions)
  -  Static Methods
     - ToNormalizedString(this HttpStatusCode httpStatusCode)

## [System.Reflection](System.Reflection.md)

- [AssemblyExtensions](System.Reflection.md#assemblyextensions)
  -  Static Methods
     - IsDebugBuild(this Assembly assembly)
     - GetExportedTypeByName(this Assembly assembly, string typeName)
     - GetBeautifiedName(this Assembly assembly)
- [FieldInfoExtensions](System.Reflection.md#fieldinfoextensions)
  -  Static Methods
     - BeautifyName(this FieldInfo fieldInfo, bool useFullName = False, bool useHtmlFormat = False, bool includeReturnType = False)
- [MemberInfoExtensions](System.Reflection.md#memberinfoextensions)
  -  Static Methods
     - HasIgnoreDisplayAttribute(this MemberInfo memberInfo)
     - HasRequiredAttribute(this MemberInfo memberInfo)
     - IsPropertyWithSetter(this MemberInfo member)
     - GetUnderlyingType(this MemberInfo member)
- [MethodInfoExtensions](System.Reflection.md#methodinfoextensions)
  -  Static Methods
     - IsOverride(this MethodInfo methodInfo)
     - HasDeclaringTypeValidationAttributes(this MethodInfo methodInfo)
     - HasGenericParameters(this MethodInfo methodInfo)
     - BeautifyName(this MethodInfo methodInfo, bool useFullName = False, bool useHtmlFormat = False, bool includeReturnType = False)
- [PropertyInfoExtensions](System.Reflection.md#propertyinfoextensions)
  -  Static Methods
     - BeautifyName(this PropertyInfo propertyInfo)
     - GetName(this PropertyInfo propertyInfo)
     - GetDescription(this PropertyInfo propertyInfo, bool useLocalizedIfPossible = True)

## [System.Security.Claims](System.Security.Claims.md)

- [ClaimsPrincipalExtensions](System.Security.Claims.md#claimsprincipalextensions)
  -  Static Methods
     - GetIdentity(this ClaimsPrincipal principal)

<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>

