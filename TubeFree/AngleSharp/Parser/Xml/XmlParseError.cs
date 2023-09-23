// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Xml.XmlParseError
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

namespace AngleSharp.Parser.Xml
{
  internal enum XmlParseError : ushort
  {
    EOF = 0,
    UndefinedMarkupDeclaration = 30, // 0x001E
    CharacterReferenceInvalidNumber = 56, // 0x0038
    CharacterReferenceInvalidCode = 57, // 0x0039
    CharacterReferenceNotTerminated = 58, // 0x003A
    DoctypeInvalid = 69, // 0x0045
    TagClosingMismatch = 118, // 0x0076
    XmlMissingRoot = 512, // 0x0200
    XmlDoctypeAfterContent = 513, // 0x0201
    XmlDeclarationInvalid = 514, // 0x0202
    XmlDeclarationMisplaced = 515, // 0x0203
    XmlDeclarationVersionUnsupported = 516, // 0x0204
    XmlInvalidStartTag = 517, // 0x0205
    XmlInvalidEndTag = 518, // 0x0206
    XmlLtInAttributeValue = 519, // 0x0207
    XmlUniqueAttribute = 520, // 0x0208
    XmlInvalidPI = 521, // 0x0209
    XmlValidationFailed = 528, // 0x0210
    XmlInvalidCharData = 529, // 0x0211
    XmlInvalidName = 530, // 0x0212
    XmlInvalidPubId = 531, // 0x0213
    XmlInvalidAttribute = 532, // 0x0214
    XmlInvalidComment = 533, // 0x0215
    DtdInvalid = 768, // 0x0300
    DtdPEReferenceInvalid = 769, // 0x0301
    DtdNameInvalid = 770, // 0x0302
    DtdDeclInvalid = 771, // 0x0303
    DtdTypeInvalid = 772, // 0x0304
    DtdEntityInvalid = 773, // 0x0305
    DtdAttListInvalid = 774, // 0x0306
    DtdTypeContent = 775, // 0x0307
    DtdUniqueElementViolated = 776, // 0x0308
    DtdConditionInvalid = 777, // 0x0309
    DtdTextDeclInvalid = 784, // 0x0310
    DtdNotationInvalid = 785, // 0x0311
    DtdPEReferenceRecursion = 786, // 0x0312
  }
}
