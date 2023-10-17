// Decompiled with JetBrains decompiler
// Type: AngleSharp.Services.Default.AttributeSelectorFactory
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Dom.Css;
using System.Collections.Generic;

namespace AngleSharp.Services.Default
{
  public class AttributeSelectorFactory : IAttributeSelectorFactory
  {
    private readonly Dictionary<string, AttributeSelectorFactory.Creator> _creators = new Dictionary<string, AttributeSelectorFactory.Creator>()
    {
      {
        CombinatorSymbols.Exactly,
        new AttributeSelectorFactory.Creator(SimpleSelector.AttrMatch)
      },
      {
        CombinatorSymbols.InList,
        new AttributeSelectorFactory.Creator(SimpleSelector.AttrList)
      },
      {
        CombinatorSymbols.InToken,
        new AttributeSelectorFactory.Creator(SimpleSelector.AttrHyphen)
      },
      {
        CombinatorSymbols.Begins,
        new AttributeSelectorFactory.Creator(SimpleSelector.AttrBegins)
      },
      {
        CombinatorSymbols.Ends,
        new AttributeSelectorFactory.Creator(SimpleSelector.AttrEnds)
      },
      {
        CombinatorSymbols.InText,
        new AttributeSelectorFactory.Creator(SimpleSelector.AttrContains)
      },
      {
        CombinatorSymbols.Unlike,
        new AttributeSelectorFactory.Creator(SimpleSelector.AttrNotMatch)
      }
    };

    public void Register(string combinator, AttributeSelectorFactory.Creator creator) => this._creators.Add(combinator, creator);

    public AttributeSelectorFactory.Creator Unregister(string combinator)
    {
      AttributeSelectorFactory.Creator creator = (AttributeSelectorFactory.Creator) null;
      if (this._creators.TryGetValue(combinator, out creator))
        this._creators.Remove(combinator);
      return creator;
    }

    protected virtual ISelector CreateDefault(
      string name,
      string value,
      string prefix,
      bool insensitive)
    {
      return (ISelector) SimpleSelector.AttrAvailable(name, value);
    }

    public ISelector Create(
      string combinator,
      string name,
      string value,
      string prefix,
      bool insensitive)
    {
      AttributeSelectorFactory.Creator creator = (AttributeSelectorFactory.Creator) null;
      return this._creators.TryGetValue(combinator, out creator) ? creator(name, value, prefix, insensitive) : this.CreateDefault(name, value, prefix, insensitive);
    }

    public delegate ISelector Creator(string name, string value, string prefix, bool insensitive);
  }
}
