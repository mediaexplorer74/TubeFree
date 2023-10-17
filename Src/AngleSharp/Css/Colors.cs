// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.Colors
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css.Values;
using System;
using System.Collections.Generic;

namespace AngleSharp.Css
{
  public static class Colors
  {
    private static readonly Dictionary<string, Color> TheColors = new Dictionary<string, Color>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase)
    {
      {
        "aliceblue",
        new Color((byte) 240, (byte) 248, byte.MaxValue)
      },
      {
        "antiquewhite",
        new Color((byte) 250, (byte) 235, (byte) 215)
      },
      {
        "aqua",
        new Color((byte) 0, byte.MaxValue, byte.MaxValue)
      },
      {
        "aquamarine",
        new Color((byte) 127, byte.MaxValue, (byte) 212)
      },
      {
        "azure",
        new Color((byte) 240, byte.MaxValue, byte.MaxValue)
      },
      {
        "beige",
        new Color((byte) 245, (byte) 245, (byte) 220)
      },
      {
        "bisque",
        new Color(byte.MaxValue, (byte) 228, (byte) 196)
      },
      {
        "black",
        new Color((byte) 0, (byte) 0, (byte) 0)
      },
      {
        "blanchedalmond",
        new Color(byte.MaxValue, (byte) 235, (byte) 205)
      },
      {
        "blue",
        new Color((byte) 0, (byte) 0, byte.MaxValue)
      },
      {
        "blueviolet",
        new Color((byte) 138, (byte) 43, (byte) 226)
      },
      {
        "brown",
        new Color((byte) 165, (byte) 42, (byte) 42)
      },
      {
        "burlywood",
        new Color((byte) 222, (byte) 184, (byte) 135)
      },
      {
        "cadetblue",
        new Color((byte) 95, (byte) 158, (byte) 160)
      },
      {
        "chartreuse",
        new Color((byte) 127, byte.MaxValue, (byte) 0)
      },
      {
        "chocolate",
        new Color((byte) 210, (byte) 105, (byte) 30)
      },
      {
        "coral",
        new Color(byte.MaxValue, (byte) 127, (byte) 80)
      },
      {
        "cornflowerblue",
        new Color((byte) 100, (byte) 149, (byte) 237)
      },
      {
        "cornsilk",
        new Color(byte.MaxValue, (byte) 248, (byte) 220)
      },
      {
        "crimson",
        new Color((byte) 220, (byte) 20, (byte) 60)
      },
      {
        "cyan",
        new Color((byte) 0, byte.MaxValue, byte.MaxValue)
      },
      {
        "darkblue",
        new Color((byte) 0, (byte) 0, (byte) 139)
      },
      {
        "darkcyan",
        new Color((byte) 0, (byte) 139, (byte) 139)
      },
      {
        "darkgoldenrod",
        new Color((byte) 184, (byte) 134, (byte) 11)
      },
      {
        "darkgray",
        new Color((byte) 169, (byte) 169, (byte) 169)
      },
      {
        "darkgreen",
        new Color((byte) 0, (byte) 100, (byte) 0)
      },
      {
        "darkgrey",
        new Color((byte) 169, (byte) 169, (byte) 169)
      },
      {
        "darkkhaki",
        new Color((byte) 189, (byte) 183, (byte) 107)
      },
      {
        "darkmagenta",
        new Color((byte) 139, (byte) 0, (byte) 139)
      },
      {
        "darkolivegreen",
        new Color((byte) 85, (byte) 107, (byte) 47)
      },
      {
        "darkorange",
        new Color(byte.MaxValue, (byte) 140, (byte) 0)
      },
      {
        "darkorchid",
        new Color((byte) 153, (byte) 50, (byte) 204)
      },
      {
        "darkred",
        new Color((byte) 139, (byte) 0, (byte) 0)
      },
      {
        "darksalmon",
        new Color((byte) 233, (byte) 150, (byte) 122)
      },
      {
        "darkseagreen",
        new Color((byte) 143, (byte) 188, (byte) 143)
      },
      {
        "darkslateblue",
        new Color((byte) 72, (byte) 61, (byte) 139)
      },
      {
        "darkslategray",
        new Color((byte) 47, (byte) 79, (byte) 79)
      },
      {
        "darkslategrey",
        new Color((byte) 47, (byte) 79, (byte) 79)
      },
      {
        "darkturquoise",
        new Color((byte) 0, (byte) 206, (byte) 209)
      },
      {
        "darkviolet",
        new Color((byte) 148, (byte) 0, (byte) 211)
      },
      {
        "deeppink",
        new Color(byte.MaxValue, (byte) 20, (byte) 147)
      },
      {
        "deepskyblue",
        new Color((byte) 0, (byte) 191, byte.MaxValue)
      },
      {
        "dimgray",
        new Color((byte) 105, (byte) 105, (byte) 105)
      },
      {
        "dimgrey",
        new Color((byte) 105, (byte) 105, (byte) 105)
      },
      {
        "dodgerblue",
        new Color((byte) 30, (byte) 144, byte.MaxValue)
      },
      {
        "firebrick",
        new Color((byte) 178, (byte) 34, (byte) 34)
      },
      {
        "floralwhite",
        new Color(byte.MaxValue, (byte) 250, (byte) 240)
      },
      {
        "forestgreen",
        new Color((byte) 34, (byte) 139, (byte) 34)
      },
      {
        "fuchsia",
        new Color(byte.MaxValue, (byte) 0, byte.MaxValue)
      },
      {
        "gainsboro",
        new Color((byte) 220, (byte) 220, (byte) 220)
      },
      {
        "ghostwhite",
        new Color((byte) 248, (byte) 248, byte.MaxValue)
      },
      {
        "gold",
        new Color(byte.MaxValue, (byte) 215, (byte) 0)
      },
      {
        "goldenrod",
        new Color((byte) 218, (byte) 165, (byte) 32)
      },
      {
        "gray",
        new Color((byte) 128, (byte) 128, (byte) 128)
      },
      {
        "green",
        new Color((byte) 0, (byte) 128, (byte) 0)
      },
      {
        "greenyellow",
        new Color((byte) 173, byte.MaxValue, (byte) 47)
      },
      {
        "grey",
        new Color((byte) 128, (byte) 128, (byte) 128)
      },
      {
        "honeydew",
        new Color((byte) 240, byte.MaxValue, (byte) 240)
      },
      {
        "hotpink",
        new Color(byte.MaxValue, (byte) 105, (byte) 180)
      },
      {
        "indianred",
        new Color((byte) 205, (byte) 92, (byte) 92)
      },
      {
        "indigo",
        new Color((byte) 75, (byte) 0, (byte) 130)
      },
      {
        "ivory",
        new Color(byte.MaxValue, byte.MaxValue, (byte) 240)
      },
      {
        "khaki",
        new Color((byte) 240, (byte) 230, (byte) 140)
      },
      {
        "lavender",
        new Color((byte) 230, (byte) 230, (byte) 250)
      },
      {
        "lavenderblush",
        new Color(byte.MaxValue, (byte) 240, (byte) 245)
      },
      {
        "lawngreen",
        new Color((byte) 124, (byte) 252, (byte) 0)
      },
      {
        "lemonchiffon",
        new Color(byte.MaxValue, (byte) 250, (byte) 205)
      },
      {
        "lightblue",
        new Color((byte) 173, (byte) 216, (byte) 230)
      },
      {
        "lightcoral",
        new Color((byte) 240, (byte) 128, (byte) 128)
      },
      {
        "lightcyan",
        new Color((byte) 224, byte.MaxValue, byte.MaxValue)
      },
      {
        "lightgoldenrodyellow",
        new Color((byte) 250, (byte) 250, (byte) 210)
      },
      {
        "lightgray",
        new Color((byte) 211, (byte) 211, (byte) 211)
      },
      {
        "lightgreen",
        new Color((byte) 144, (byte) 238, (byte) 144)
      },
      {
        "lightgrey",
        new Color((byte) 211, (byte) 211, (byte) 211)
      },
      {
        "lightpink",
        new Color(byte.MaxValue, (byte) 182, (byte) 193)
      },
      {
        "lightsalmon",
        new Color(byte.MaxValue, (byte) 160, (byte) 122)
      },
      {
        "lightseagreen",
        new Color((byte) 32, (byte) 178, (byte) 170)
      },
      {
        "lightskyblue",
        new Color((byte) 135, (byte) 206, (byte) 250)
      },
      {
        "lightslategray",
        new Color((byte) 119, (byte) 136, (byte) 153)
      },
      {
        "lightslategrey",
        new Color((byte) 119, (byte) 136, (byte) 153)
      },
      {
        "lightsteelblue",
        new Color((byte) 176, (byte) 196, (byte) 222)
      },
      {
        "lightyellow",
        new Color(byte.MaxValue, byte.MaxValue, (byte) 224)
      },
      {
        "lime",
        new Color((byte) 0, byte.MaxValue, (byte) 0)
      },
      {
        "limegreen",
        new Color((byte) 50, (byte) 205, (byte) 50)
      },
      {
        "linen",
        new Color((byte) 250, (byte) 240, (byte) 230)
      },
      {
        "magenta",
        new Color(byte.MaxValue, (byte) 0, byte.MaxValue)
      },
      {
        "maroon",
        new Color((byte) 128, (byte) 0, (byte) 0)
      },
      {
        "mediumaquamarine",
        new Color((byte) 102, (byte) 205, (byte) 170)
      },
      {
        "mediumblue",
        new Color((byte) 0, (byte) 0, (byte) 205)
      },
      {
        "mediumorchid",
        new Color((byte) 186, (byte) 85, (byte) 211)
      },
      {
        "mediumpurple",
        new Color((byte) 147, (byte) 112, (byte) 219)
      },
      {
        "mediumseagreen",
        new Color((byte) 60, (byte) 179, (byte) 113)
      },
      {
        "mediumslateblue",
        new Color((byte) 123, (byte) 104, (byte) 238)
      },
      {
        "mediumspringgreen",
        new Color((byte) 0, (byte) 250, (byte) 154)
      },
      {
        "mediumturquoise",
        new Color((byte) 72, (byte) 209, (byte) 204)
      },
      {
        "mediumvioletred",
        new Color((byte) 199, (byte) 21, (byte) 133)
      },
      {
        "midnightblue",
        new Color((byte) 25, (byte) 25, (byte) 112)
      },
      {
        "mintcream",
        new Color((byte) 245, byte.MaxValue, (byte) 250)
      },
      {
        "mistyrose",
        new Color(byte.MaxValue, (byte) 228, (byte) 225)
      },
      {
        "moccasin",
        new Color(byte.MaxValue, (byte) 228, (byte) 181)
      },
      {
        "navajowhite",
        new Color(byte.MaxValue, (byte) 222, (byte) 173)
      },
      {
        "navy",
        new Color((byte) 0, (byte) 0, (byte) 128)
      },
      {
        "oldlace",
        new Color((byte) 253, (byte) 245, (byte) 230)
      },
      {
        "olive",
        new Color((byte) 128, (byte) 128, (byte) 0)
      },
      {
        "olivedrab",
        new Color((byte) 107, (byte) 142, (byte) 35)
      },
      {
        "orange",
        new Color(byte.MaxValue, (byte) 165, (byte) 0)
      },
      {
        "orangered",
        new Color(byte.MaxValue, (byte) 69, (byte) 0)
      },
      {
        "orchid",
        new Color((byte) 218, (byte) 112, (byte) 214)
      },
      {
        "palegoldenrod",
        new Color((byte) 238, (byte) 232, (byte) 170)
      },
      {
        "palegreen",
        new Color((byte) 152, (byte) 251, (byte) 152)
      },
      {
        "paleturquoise",
        new Color((byte) 175, (byte) 238, (byte) 238)
      },
      {
        "palevioletred",
        new Color((byte) 219, (byte) 112, (byte) 147)
      },
      {
        "papayawhip",
        new Color(byte.MaxValue, (byte) 239, (byte) 213)
      },
      {
        "peachpuff",
        new Color(byte.MaxValue, (byte) 218, (byte) 185)
      },
      {
        "peru",
        new Color((byte) 205, (byte) 133, (byte) 63)
      },
      {
        "pink",
        new Color(byte.MaxValue, (byte) 192, (byte) 203)
      },
      {
        "plum",
        new Color((byte) 221, (byte) 160, (byte) 221)
      },
      {
        "powderblue",
        new Color((byte) 176, (byte) 224, (byte) 230)
      },
      {
        "purple",
        new Color((byte) 128, (byte) 0, (byte) 128)
      },
      {
        "rebeccapurple",
        new Color((byte) 102, (byte) 51, (byte) 153)
      },
      {
        "red",
        new Color(byte.MaxValue, (byte) 0, (byte) 0)
      },
      {
        "rosybrown",
        new Color((byte) 188, (byte) 143, (byte) 143)
      },
      {
        "royalblue",
        new Color((byte) 65, (byte) 105, (byte) 225)
      },
      {
        "saddlebrown",
        new Color((byte) 139, (byte) 69, (byte) 19)
      },
      {
        "salmon",
        new Color((byte) 250, (byte) 128, (byte) 114)
      },
      {
        "sandybrown",
        new Color((byte) 244, (byte) 164, (byte) 96)
      },
      {
        "seagreen",
        new Color((byte) 46, (byte) 139, (byte) 87)
      },
      {
        "seashell",
        new Color(byte.MaxValue, (byte) 245, (byte) 238)
      },
      {
        "sienna",
        new Color((byte) 160, (byte) 82, (byte) 45)
      },
      {
        "silver",
        new Color((byte) 192, (byte) 192, (byte) 192)
      },
      {
        "skyblue",
        new Color((byte) 135, (byte) 206, (byte) 235)
      },
      {
        "slateblue",
        new Color((byte) 106, (byte) 90, (byte) 205)
      },
      {
        "slategray",
        new Color((byte) 112, (byte) 128, (byte) 144)
      },
      {
        "slategrey",
        new Color((byte) 112, (byte) 128, (byte) 144)
      },
      {
        "snow",
        new Color(byte.MaxValue, (byte) 250, (byte) 250)
      },
      {
        "springgreen",
        new Color((byte) 0, byte.MaxValue, (byte) 127)
      },
      {
        "steelblue",
        new Color((byte) 70, (byte) 130, (byte) 180)
      },
      {
        "tan",
        new Color((byte) 210, (byte) 180, (byte) 140)
      },
      {
        "teal",
        new Color((byte) 0, (byte) 128, (byte) 128)
      },
      {
        "thistle",
        new Color((byte) 216, (byte) 191, (byte) 216)
      },
      {
        "tomato",
        new Color(byte.MaxValue, (byte) 99, (byte) 71)
      },
      {
        "turquoise",
        new Color((byte) 64, (byte) 224, (byte) 208)
      },
      {
        "violet",
        new Color((byte) 238, (byte) 130, (byte) 238)
      },
      {
        "wheat",
        new Color((byte) 245, (byte) 222, (byte) 179)
      },
      {
        "white",
        new Color(byte.MaxValue, byte.MaxValue, byte.MaxValue)
      },
      {
        "whitesmoke",
        new Color((byte) 245, (byte) 245, (byte) 245)
      },
      {
        "yellow",
        new Color(byte.MaxValue, byte.MaxValue, (byte) 0)
      },
      {
        "yellowgreen",
        new Color((byte) 154, (byte) 205, (byte) 50)
      },
      {
        "transparent",
        new Color((byte) 0, (byte) 0, (byte) 0, (byte) 0)
      },
      {
        "activeborder",
        new Color(byte.MaxValue, byte.MaxValue, byte.MaxValue)
      },
      {
        "activecaption",
        new Color((byte) 204, (byte) 204, (byte) 204)
      },
      {
        "appworkspace",
        new Color(byte.MaxValue, byte.MaxValue, byte.MaxValue)
      },
      {
        "background",
        new Color((byte) 99, (byte) 99, (byte) 206)
      },
      {
        "buttonface",
        new Color((byte) 221, (byte) 221, (byte) 221)
      },
      {
        "buttonhighlight",
        new Color((byte) 221, (byte) 221, (byte) 221)
      },
      {
        "buttonshadow",
        new Color((byte) 136, (byte) 136, (byte) 136)
      },
      {
        "buttontext",
        new Color((byte) 0, (byte) 0, (byte) 0)
      },
      {
        "captiontext",
        new Color((byte) 0, (byte) 0, (byte) 0)
      },
      {
        "graytext",
        new Color((byte) 128, (byte) 128, (byte) 128)
      },
      {
        "highlight",
        new Color((byte) 181, (byte) 213, byte.MaxValue)
      },
      {
        "highlighttext",
        new Color((byte) 0, (byte) 0, (byte) 0)
      },
      {
        "inactiveborder",
        new Color(byte.MaxValue, byte.MaxValue, byte.MaxValue)
      },
      {
        "inactivecaption",
        new Color(byte.MaxValue, byte.MaxValue, byte.MaxValue)
      },
      {
        "inactivecaptiontext",
        new Color((byte) 127, (byte) 127, (byte) 127)
      },
      {
        "infobackground",
        new Color((byte) 251, (byte) 252, (byte) 197)
      },
      {
        "infotext",
        new Color((byte) 0, (byte) 0, (byte) 0)
      },
      {
        "menu",
        new Color((byte) 247, (byte) 247, (byte) 247)
      },
      {
        "menutext",
        new Color((byte) 0, (byte) 0, (byte) 0)
      },
      {
        "scrollbar",
        new Color(byte.MaxValue, byte.MaxValue, byte.MaxValue)
      },
      {
        "threeddarkshadow",
        new Color((byte) 102, (byte) 102, (byte) 102)
      },
      {
        "threedface",
        new Color(byte.MaxValue, byte.MaxValue, byte.MaxValue)
      },
      {
        "threedhighlight",
        new Color((byte) 221, (byte) 221, (byte) 221)
      },
      {
        "threedlightshadow",
        new Color((byte) 192, (byte) 192, (byte) 192)
      },
      {
        "threedshadow",
        new Color((byte) 136, (byte) 136, (byte) 136)
      },
      {
        "window",
        new Color(byte.MaxValue, byte.MaxValue, byte.MaxValue)
      },
      {
        "windowframe",
        new Color((byte) 204, (byte) 204, (byte) 204)
      },
      {
        "windowtext",
        new Color((byte) 0, (byte) 0, (byte) 0)
      }
    };

    public static IEnumerable<string> Names => (IEnumerable<string>) Colors.TheColors.Keys;

    public static Color? GetColor(string name)
    {
      Color color = new Color();
      return Colors.TheColors.TryGetValue(name, out color) ? new Color?(color) : new Color?();
    }

    public static string GetName(Color color)
    {
      foreach (KeyValuePair<string, Color> theColor in Colors.TheColors)
      {
        if (theColor.Value.Equals(color))
          return theColor.Key;
      }
      return (string) null;
    }
  }
}
