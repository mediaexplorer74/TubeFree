// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssDeclarationRule
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using AngleSharp.Parser.Css;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AngleSharp.Dom.Css
{
  internal abstract class CssDeclarationRule : 
    CssRule,
    ICssProperties,
    IEnumerable<ICssProperty>,
    IEnumerable
  {
    private readonly string _name;

    internal CssDeclarationRule(CssRuleType type, string name, CssParser parser)
      : base(type, parser)
    {
      this._name = name;
    }

    public string this[string propertyName] => this.GetValue(propertyName);

    public IEnumerable<CssProperty> Declarations => this.Children.OfType<CssProperty>();

    public int Length => this.Declarations.Count<CssProperty>();

    public string GetPropertyValue(string propertyName) => this.GetValue(propertyName);

    public string GetPropertyPriority(string propertyName) => (string) null;

    public void SetProperty(string propertyName, string propertyValue, string priority = null) => this.SetValue(propertyName, propertyValue);

    public string RemoveProperty(string propertyName)
    {
      foreach (CssProperty declaration in this.Declarations)
      {
        if (declaration.HasValue && declaration.Name.Is(propertyName))
        {
          string str = declaration.Value;
          this.RemoveChild((ICssNode) declaration);
          return str;
        }
      }
      return (string) null;
    }

    public IEnumerator<ICssProperty> GetEnumerator() => (IEnumerator<ICssProperty>) this.Declarations.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

    internal void SetProperty(CssProperty property)
    {
      foreach (CssProperty declaration in this.Declarations)
      {
        if (declaration.Name.Is(property.Name))
        {
          this.ReplaceChild((ICssNode) declaration, (ICssNode) property);
          return;
        }
      }
      this.AppendChild((ICssNode) property);
    }

    public override void ToCss(TextWriter writer, IStyleFormatter formatter)
    {
      CssDeclarationRule.FormatTransporter rules = new CssDeclarationRule.FormatTransporter(this.Declarations);
      string str = formatter.Style("@" + this._name, (IStyleFormattable) rules);
      writer.Write(str);
    }

    protected abstract CssProperty CreateNewProperty(string name);

    protected string GetValue(string propertyName)
    {
      foreach (CssProperty declaration in this.Declarations)
      {
        if (declaration.HasValue && declaration.Name.Is(propertyName))
          return declaration.Value;
      }
      return string.Empty;
    }

    protected void SetValue(string propertyName, string valueText)
    {
      foreach (CssProperty declaration in this.Declarations)
      {
        if (declaration.Name.Is(propertyName))
        {
          CssValue newValue = this.Parser.ParseValue(valueText);
          declaration.TrySetValue(newValue);
          return;
        }
      }
      CssProperty newProperty = this.CreateNewProperty(propertyName);
      if (newProperty == null)
        return;
      CssValue newValue1 = this.Parser.ParseValue(valueText);
      newProperty.TrySetValue(newValue1);
      this.AppendChild((ICssNode) newProperty);
    }

    private struct FormatTransporter : IStyleFormattable
    {
      private readonly IEnumerable<CssProperty> _properties;

      public FormatTransporter(IEnumerable<CssProperty> properties) => this._properties = properties.Where<CssProperty>((Func<CssProperty, bool>) (m => m.HasValue));

      public void ToCss(TextWriter writer, IStyleFormatter formatter)
      {
        IEnumerable<string> declarations = this._properties.Select<CssProperty, string>((Func<CssProperty, string>) (m => m.ToCss(formatter)));
        string str = formatter.Declarations(declarations);
        writer.Write(str);
      }
    }
  }
}
