// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Html.HtmlForeignExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Mathml;
using AngleSharp.Dom.Svg;
using AngleSharp.Extensions;
using AngleSharp.Html;
using System;
using System.Collections.Generic;

namespace AngleSharp.Parser.Html
{
  internal static class HtmlForeignExtensions
  {
    private static readonly Dictionary<string, string> svgAttributeNames = new Dictionary<string, string>((IEqualityComparer<string>) StringComparer.Ordinal)
    {
      {
        "attributename",
        "attributeName"
      },
      {
        "attributetype",
        "attributeType"
      },
      {
        "basefrequency",
        "baseFrequency"
      },
      {
        "baseprofile",
        "baseProfile"
      },
      {
        "calcmode",
        "calcMode"
      },
      {
        "clippathunits",
        "clipPathUnits"
      },
      {
        "contentscripttype",
        "contentScriptType"
      },
      {
        "contentstyletype",
        "contentStyleType"
      },
      {
        "diffuseconstant",
        "diffuseConstant"
      },
      {
        "edgemode",
        "edgeMode"
      },
      {
        "externalresourcesrequired",
        "externalResourcesRequired"
      },
      {
        "filterres",
        "filterRes"
      },
      {
        "filterunits",
        "filterUnits"
      },
      {
        "glyphref",
        "glyphRef"
      },
      {
        "gradienttransform",
        "gradientTransform"
      },
      {
        "gradientunits",
        "gradientUnits"
      },
      {
        "kernelmatrix",
        "kernelMatrix"
      },
      {
        "kernelunitlength",
        "kernelUnitLength"
      },
      {
        "keypoints",
        "keyPoints"
      },
      {
        "keysplines",
        "keySplines"
      },
      {
        "keytimes",
        "keyTimes"
      },
      {
        "lengthadjust",
        "lengthAdjust"
      },
      {
        "limitingconeangle",
        "limitingConeAngle"
      },
      {
        "markerheight",
        "markerHeight"
      },
      {
        "markerunits",
        "markerUnits"
      },
      {
        "markerwidth",
        "markerWidth"
      },
      {
        "maskcontentunits",
        "maskContentUnits"
      },
      {
        "maskunits",
        "maskUnits"
      },
      {
        "numoctaves",
        "numOctaves"
      },
      {
        "pathlength",
        "pathLength"
      },
      {
        "patterncontentunits",
        "patternContentUnits"
      },
      {
        "patterntransform",
        "patternTransform"
      },
      {
        "patternunits",
        "patternUnits"
      },
      {
        "pointsatx",
        "pointsAtX"
      },
      {
        "pointsaty",
        "pointsAtY"
      },
      {
        "pointsatz",
        "pointsAtZ"
      },
      {
        "preservealpha",
        "preserveAlpha"
      },
      {
        "preserveaspectratio",
        "preserveAspectRatio"
      },
      {
        "primitiveunits",
        "primitiveUnits"
      },
      {
        "refx",
        "refX"
      },
      {
        "refy",
        "refY"
      },
      {
        "repeatcount",
        "repeatCount"
      },
      {
        "repeatdur",
        "repeatDur"
      },
      {
        "requiredextensions",
        "requiredExtensions"
      },
      {
        "requiredfeatures",
        "requiredFeatures"
      },
      {
        "specularconstant",
        "specularConstant"
      },
      {
        "specularexponent",
        "specularExponent"
      },
      {
        "spreadmethod",
        "spreadMethod"
      },
      {
        "startoffset",
        "startOffset"
      },
      {
        "stddeviation",
        "stdDeviation"
      },
      {
        "stitchtiles",
        "stitchTiles"
      },
      {
        "surfacescale",
        "surfaceScale"
      },
      {
        "systemlanguage",
        "systemLanguage"
      },
      {
        "tablevalues",
        "tableValues"
      },
      {
        "targetx",
        "targetX"
      },
      {
        "targety",
        "targetY"
      },
      {
        "textlength",
        "textLength"
      },
      {
        "viewbox",
        "viewBox"
      },
      {
        "viewtarget",
        "viewTarget"
      },
      {
        "xchannelselector",
        "xChannelSelector"
      },
      {
        "ychannelselector",
        "yChannelSelector"
      },
      {
        "zoomandpan",
        "zoomAndPan"
      }
    };
    private static readonly Dictionary<string, string> svgAdjustedTagNames = new Dictionary<string, string>((IEqualityComparer<string>) StringComparer.Ordinal)
    {
      {
        "altglyph",
        "altGlyph"
      },
      {
        "altglyphdef",
        "altGlyphDef"
      },
      {
        "altglyphitem",
        "altGlyphItem"
      },
      {
        "animatecolor",
        "animateColor"
      },
      {
        "animatemotion",
        "animateMotion"
      },
      {
        "animatetransform",
        "animateTransform"
      },
      {
        "clippath",
        "clipPath"
      },
      {
        "feblend",
        "feBlend"
      },
      {
        "fecolormatrix",
        "feColorMatrix"
      },
      {
        "fecomponenttransfer",
        "feComponentTransfer"
      },
      {
        "fecomposite",
        "feComposite"
      },
      {
        "feconvolvematrix",
        "feConvolveMatrix"
      },
      {
        "fediffuselighting",
        "feDiffuseLighting"
      },
      {
        "fedisplacementmap",
        "feDisplacementMap"
      },
      {
        "fedistantlight",
        "feDistantLight"
      },
      {
        "feflood",
        "feFlood"
      },
      {
        "fefunca",
        "feFuncA"
      },
      {
        "fefuncb",
        "feFuncB"
      },
      {
        "fefuncg",
        "feFuncG"
      },
      {
        "fefuncr",
        "feFuncR"
      },
      {
        "fegaussianblur",
        "feGaussianBlur"
      },
      {
        "feimage",
        "feImage"
      },
      {
        "femerge",
        "feMerge"
      },
      {
        "femergenode",
        "feMergeNode"
      },
      {
        "femorphology",
        "feMorphology"
      },
      {
        "feoffset",
        "feOffset"
      },
      {
        "fepointlight",
        "fePointLight"
      },
      {
        "fespecularlighting",
        "feSpecularLighting"
      },
      {
        "fespotlight",
        "feSpotLight"
      },
      {
        "fetile",
        "feTile"
      },
      {
        "feturbulence",
        "feTurbulence"
      },
      {
        "foreignobject",
        "foreignObject"
      },
      {
        "glyphref",
        "glyphRef"
      },
      {
        "lineargradient",
        "linearGradient"
      },
      {
        "radialgradient",
        "radialGradient"
      },
      {
        "textpath",
        "textPath"
      }
    };

    public static string SanatizeSvgTagName(this string localName)
    {
      string str = (string) null;
      return HtmlForeignExtensions.svgAdjustedTagNames.TryGetValue(localName, out str) ? str : localName;
    }

    public static MathElement Setup(this MathElement element, HtmlTagToken tag)
    {
      int count = tag.Attributes.Count;
      for (int index = 0; index < count; ++index)
      {
        KeyValuePair<string, string> attribute = tag.Attributes[index];
        string key = attribute.Key;
        attribute = tag.Attributes[index];
        string str = attribute.Value;
        element.AdjustAttribute(key.AdjustToMathAttribute(), str);
      }
      return element;
    }

    public static SvgElement Setup(this SvgElement element, HtmlTagToken tag)
    {
      int count = tag.Attributes.Count;
      for (int index = 0; index < count; ++index)
      {
        KeyValuePair<string, string> attribute = tag.Attributes[index];
        string key = attribute.Key;
        attribute = tag.Attributes[index];
        string str = attribute.Value;
        element.AdjustAttribute(key.AdjustToSvgAttribute(), str);
      }
      return element;
    }

    public static void AdjustAttribute(this Element element, string name, string value)
    {
      if (HtmlForeignExtensions.IsXLinkAttribute(name))
        element.SetAttribute(NamespaceNames.XLinkUri, name.Substring(name.IndexOf(':') + 1), value);
      else if (HtmlForeignExtensions.IsXmlAttribute(name))
        element.SetAttribute(NamespaceNames.XmlUri, name, value);
      else if (HtmlForeignExtensions.IsXmlNamespaceAttribute(name))
        element.SetAttribute(NamespaceNames.XmlNsUri, name, value);
      else
        element.SetOwnAttribute(name, value);
    }

    public static string AdjustToMathAttribute(this string attributeName) => attributeName.Is("definitionurl") ? "definitionURL" : attributeName;

    public static string AdjustToSvgAttribute(this string attributeName)
    {
      string str = (string) null;
      return HtmlForeignExtensions.svgAttributeNames.TryGetValue(attributeName, out str) ? str : attributeName;
    }

    private static bool IsXmlNamespaceAttribute(string name)
    {
      if (name.Length <= 4)
        return false;
      return name.Is(NamespaceNames.XmlNsPrefix) || name.Is("xmlns:xlink");
    }

    private static bool IsXmlAttribute(string name)
    {
      if (name.Length <= 7 || !"xml:".EqualsSubset(name, 0, 4))
        return false;
      return TagNames.Base.EqualsSubset(name, 4, 4) || AttributeNames.Lang.EqualsSubset(name, 4, 4) || AttributeNames.Space.EqualsSubset(name, 4, 5);
    }

    private static bool IsXLinkAttribute(string name)
    {
      if (name.Length <= 9 || !"xlink:".EqualsSubset(name, 0, 6))
        return false;
      return AttributeNames.Actuate.EqualsSubset(name, 6, 7) || AttributeNames.Arcrole.EqualsSubset(name, 6, 7) || AttributeNames.Href.EqualsSubset(name, 6, 4) || AttributeNames.Role.EqualsSubset(name, 6, 4) || AttributeNames.Show.EqualsSubset(name, 6, 4) || AttributeNames.Type.EqualsSubset(name, 6, 4) || AttributeNames.Title.EqualsSubset(name, 6, 5);
    }

    private static bool EqualsSubset(this string a, string b, int index, int length) => string.Compare(a, 0, b, index, length, StringComparison.Ordinal) == 0;
  }
}
