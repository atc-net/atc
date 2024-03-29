<div style='text-align: right'>
[References](Index.md)
</div>

# References extended

## [Atc.CodeDocumentation](Atc.CodeDocumentation.md)

- [AtcCodeDocumentationAssemblyTypeInitializer](Atc.CodeDocumentation.md#atccodedocumentationassemblytypeinitializer)
- [Constants](Atc.CodeDocumentation.md#constants)
  -  Static Fields
     - string UndefinedDescription
- [DocumentationHelper](Atc.CodeDocumentation.md#documentationhelper)
  -  Static Methods
     - CollectExportedTypeWithCommentsFromType(Type type)
     - CollectExportedTypesWithMissingCommentsFromAssembly(Assembly assembly, List&lt;Type&gt; excludeTypes = null)
     - CollectExportedTypesWithMissingCommentsFromAssemblyAndGenerateText(Assembly assembly, List&lt;Type&gt; excludeTypes = null, bool useFullName = False)
     - CollectExportedTypesWithMissingCommentsFromAssemblyAndGenerateTextLines(Assembly assembly, List&lt;Type&gt; excludeTypes = null, bool useFullName = False)
- [MemberType](Atc.CodeDocumentation.md#membertype)
- [TypeComments](Atc.CodeDocumentation.md#typecomments)
  -  Properties
     - BeautifyHtmlName
     - CommentLookup
     - FullName
     - HasComments
     - Name
     - Namespace
     - Type
  -  Methods
     - GetXmlDocumentComments()
     - ToString()

## [Atc.CodeDocumentation.CodeComment](Atc.CodeDocumentation.CodeComment.md)

- [CodeDocumentationTags](Atc.CodeDocumentation.CodeComment.md#codedocumentationtags)
  -  Properties
     - Code
     - Example
     - Exceptions
     - Parameters
     - Remark
     - Return
     - Summary
  -  Methods
     - ToString()
- [CodeDocumentationTagsGenerator](Atc.CodeDocumentation.CodeComment.md#codedocumentationtagsgenerator)
  -  Methods
     - GenerateTags(ushort indentSpaces, CodeDocumentationTags codeDocumentationTags)
     - ShouldGenerateTags(CodeDocumentationTags codeDocumentationTags)
- [ICodeDocumentationTagsGenerator](Atc.CodeDocumentation.CodeComment.md#icodedocumentationtagsgenerator)
  -  Methods
     - GenerateTags(ushort indentSpaces, CodeDocumentationTags codeDocumentationTags)
     - ShouldGenerateTags(CodeDocumentationTags codeDocumentationTags)

## [Atc.CodeDocumentation.Markdown](Atc.CodeDocumentation.Markdown.md)

- [MarkdownCodeDocGenerator](Atc.CodeDocumentation.Markdown.md#markdowncodedocgenerator)
  -  Static Methods
     - Run(Assembly assemblyToCodeDoc, DirectoryInfo outputPath = null)

## [Atc.CodeDocumentation.XmlDocument](Atc.CodeDocumentation.XmlDocument.md)

- [XmlDocumentComment](Atc.CodeDocumentation.XmlDocument.md#xmldocumentcomment)
  -  Properties
     - ClassName
     - Code
     - Example
     - MemberName
     - MemberType
     - Parameters
     - Remarks
     - Returns
     - Summary
  -  Methods
     - ToString()

<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
