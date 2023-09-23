// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Css.CssSelectorConstructor
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Dom;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Html;
using AngleSharp.Extensions;
using AngleSharp.Services;
using System;
using System.Collections.Generic;

namespace AngleSharp.Parser.Css
{
  internal sealed class CssSelectorConstructor
  {
    private static readonly Dictionary<string, Func<CssSelectorConstructor, CssSelectorConstructor.FunctionState>> pseudoClassFunctions = new Dictionary<string, Func<CssSelectorConstructor, CssSelectorConstructor.FunctionState>>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase)
    {
      {
        PseudoClassNames.NthChild,
        (Func<CssSelectorConstructor, CssSelectorConstructor.FunctionState>) (ctx => (CssSelectorConstructor.FunctionState) new CssSelectorConstructor.ChildFunctionState<FirstChildSelector>(ctx))
      },
      {
        PseudoClassNames.NthLastChild,
        (Func<CssSelectorConstructor, CssSelectorConstructor.FunctionState>) (ctx => (CssSelectorConstructor.FunctionState) new CssSelectorConstructor.ChildFunctionState<LastChildSelector>(ctx))
      },
      {
        PseudoClassNames.NthOfType,
        (Func<CssSelectorConstructor, CssSelectorConstructor.FunctionState>) (ctx => (CssSelectorConstructor.FunctionState) new CssSelectorConstructor.ChildFunctionState<FirstTypeSelector>(ctx, false))
      },
      {
        PseudoClassNames.NthLastOfType,
        (Func<CssSelectorConstructor, CssSelectorConstructor.FunctionState>) (ctx => (CssSelectorConstructor.FunctionState) new CssSelectorConstructor.ChildFunctionState<LastTypeSelector>(ctx, false))
      },
      {
        PseudoClassNames.NthColumn,
        (Func<CssSelectorConstructor, CssSelectorConstructor.FunctionState>) (ctx => (CssSelectorConstructor.FunctionState) new CssSelectorConstructor.ChildFunctionState<FirstColumnSelector>(ctx, false))
      },
      {
        PseudoClassNames.NthLastColumn,
        (Func<CssSelectorConstructor, CssSelectorConstructor.FunctionState>) (ctx => (CssSelectorConstructor.FunctionState) new CssSelectorConstructor.ChildFunctionState<LastColumnSelector>(ctx, false))
      },
      {
        PseudoClassNames.Not,
        (Func<CssSelectorConstructor, CssSelectorConstructor.FunctionState>) (ctx => (CssSelectorConstructor.FunctionState) new CssSelectorConstructor.NotFunctionState(ctx))
      },
      {
        PseudoClassNames.Dir,
        (Func<CssSelectorConstructor, CssSelectorConstructor.FunctionState>) (ctx => (CssSelectorConstructor.FunctionState) new CssSelectorConstructor.DirFunctionState())
      },
      {
        PseudoClassNames.Lang,
        (Func<CssSelectorConstructor, CssSelectorConstructor.FunctionState>) (ctx => (CssSelectorConstructor.FunctionState) new CssSelectorConstructor.LangFunctionState())
      },
      {
        PseudoClassNames.Contains,
        (Func<CssSelectorConstructor, CssSelectorConstructor.FunctionState>) (ctx => (CssSelectorConstructor.FunctionState) new CssSelectorConstructor.ContainsFunctionState())
      },
      {
        PseudoClassNames.Has,
        (Func<CssSelectorConstructor, CssSelectorConstructor.FunctionState>) (ctx => (CssSelectorConstructor.FunctionState) new CssSelectorConstructor.HasFunctionState(ctx))
      },
      {
        PseudoClassNames.Matches,
        (Func<CssSelectorConstructor, CssSelectorConstructor.FunctionState>) (ctx => (CssSelectorConstructor.FunctionState) new CssSelectorConstructor.MatchesFunctionState(ctx))
      },
      {
        PseudoClassNames.HostContext,
        (Func<CssSelectorConstructor, CssSelectorConstructor.FunctionState>) (ctx => (CssSelectorConstructor.FunctionState) new CssSelectorConstructor.HostContextFunctionState(ctx))
      }
    };
    private readonly Stack<CssCombinator> _combinators;
    private CssSelectorConstructor.State _state;
    private ISelector _temp;
    private ListSelector _group;
    private ComplexSelector _complex;
    private string _attrName;
    private string _attrValue;
    private bool _attrInsensitive;
    private string _attrOp;
    private string _attrNs;
    private bool _valid;
    private bool _invoked;
    private bool _nested;
    private bool _ready;
    private IAttributeSelectorFactory _attributeSelector;
    private IPseudoElementSelectorFactory _pseudoElementSelector;
    private IPseudoClassSelectorFactory _pseudoClassSelector;

    public CssSelectorConstructor(
      IAttributeSelectorFactory attributeSelector,
      IPseudoClassSelectorFactory pseudoClassSelector,
      IPseudoElementSelectorFactory pseudoElementSelector)
    {
      this._combinators = new Stack<CssCombinator>();
      this.Reset(attributeSelector, pseudoClassSelector, pseudoElementSelector);
    }

    public bool IsValid => this._invoked && this._valid && this._ready;

    public bool IsNested => this._nested;

    public ISelector GetResult()
    {
      if (!this.IsValid)
        return (ISelector) new UnknownSelector();
      if (this._complex != null)
      {
        this._complex.ConcludeSelector(this._temp);
        this._temp = (ISelector) this._complex;
        this._complex = (ComplexSelector) null;
      }
      if (this._group == null || this._group.Length == 0)
        return this._temp ?? (ISelector) SimpleSelector.All;
      if (this._temp == null && this._group.Length == 1)
        return this._group[0];
      if (this._temp != null)
      {
        this._group.Add(this._temp);
        this._temp = (ISelector) null;
      }
      return (ISelector) this._group;
    }

    public void Apply(CssToken token)
    {
      if (token.Type == CssTokenType.Comment)
        return;
      this._invoked = true;
      switch (this._state)
      {
        case CssSelectorConstructor.State.Data:
          this.OnData(token);
          break;
        case CssSelectorConstructor.State.Attribute:
          this.OnAttribute(token);
          break;
        case CssSelectorConstructor.State.AttributeOperator:
          this.OnAttributeOperator(token);
          break;
        case CssSelectorConstructor.State.AttributeValue:
          this.OnAttributeValue(token);
          break;
        case CssSelectorConstructor.State.AttributeEnd:
          this.OnAttributeEnd(token);
          break;
        case CssSelectorConstructor.State.Class:
          this.OnClass(token);
          break;
        case CssSelectorConstructor.State.PseudoClass:
          this.OnPseudoClass(token);
          break;
        case CssSelectorConstructor.State.PseudoElement:
          this.OnPseudoElement(token);
          break;
        default:
          this._valid = false;
          break;
      }
    }

    public CssSelectorConstructor Reset(
      IAttributeSelectorFactory attributeSelector,
      IPseudoClassSelectorFactory pseudoClassSelector,
      IPseudoElementSelectorFactory pseudoElementSelector)
    {
      this._attrName = (string) null;
      this._attrValue = (string) null;
      this._attrNs = (string) null;
      this._attrInsensitive = false;
      this._attrOp = string.Empty;
      this._state = CssSelectorConstructor.State.Data;
      this._combinators.Clear();
      this._temp = (ISelector) null;
      this._group = (ListSelector) null;
      this._complex = (ComplexSelector) null;
      this._valid = true;
      this._nested = false;
      this._invoked = false;
      this._ready = true;
      this._attributeSelector = attributeSelector;
      this._pseudoClassSelector = pseudoClassSelector;
      this._pseudoElementSelector = pseudoElementSelector;
      return this;
    }

    private void OnData(CssToken token)
    {
      switch (token.Type)
      {
        case CssTokenType.Hash:
          this.Insert((ISelector) SimpleSelector.Id(token.Data));
          this._ready = true;
          break;
        case CssTokenType.Ident:
          this.Insert((ISelector) SimpleSelector.Type(token.Data));
          this._ready = true;
          break;
        case CssTokenType.Delim:
          this.OnDelim(token);
          break;
        case CssTokenType.SquareBracketOpen:
          this._attrName = (string) null;
          this._attrValue = (string) null;
          this._attrOp = string.Empty;
          this._attrNs = (string) null;
          this._state = CssSelectorConstructor.State.Attribute;
          this._ready = false;
          break;
        case CssTokenType.Colon:
          this._state = CssSelectorConstructor.State.PseudoClass;
          this._ready = false;
          break;
        case CssTokenType.Comma:
          this.InsertOr();
          this._ready = false;
          break;
        case CssTokenType.Whitespace:
          this.Insert(CssCombinator.Descendent);
          break;
        default:
          this._valid = false;
          break;
      }
    }

    private void OnAttribute(CssToken token)
    {
      if (token.Type == CssTokenType.Whitespace)
        return;
      if (token.Type == CssTokenType.Ident || token.Type == CssTokenType.String)
      {
        this._state = CssSelectorConstructor.State.AttributeOperator;
        this._attrName = token.Data;
      }
      else if (token.Type == CssTokenType.Delim && token.Data.Is(CombinatorSymbols.Pipe))
      {
        this._state = CssSelectorConstructor.State.Attribute;
        this._attrNs = string.Empty;
      }
      else if (token.Type == CssTokenType.Delim && token.Data.Is(Keywords.Asterisk))
      {
        this._state = CssSelectorConstructor.State.AttributeOperator;
        this._attrName = token.ToValue();
      }
      else
      {
        this._state = CssSelectorConstructor.State.Data;
        this._valid = false;
      }
    }

    private void OnAttributeOperator(CssToken token)
    {
      if (token.Type == CssTokenType.Whitespace)
        return;
      if (token.Type == CssTokenType.SquareBracketClose)
      {
        this._state = CssSelectorConstructor.State.AttributeValue;
        this.OnAttributeEnd(token);
      }
      else if (token.Type == CssTokenType.Match || token.Type == CssTokenType.Delim)
      {
        this._state = CssSelectorConstructor.State.AttributeValue;
        this._attrOp = token.ToValue();
        if (!(this._attrOp == CombinatorSymbols.Pipe))
          return;
        this._attrNs = this._attrName;
        this._attrName = (string) null;
        this._attrOp = string.Empty;
        this._state = CssSelectorConstructor.State.Attribute;
      }
      else
      {
        this._state = CssSelectorConstructor.State.AttributeEnd;
        this._valid = false;
      }
    }

    private void OnAttributeValue(CssToken token)
    {
      if (token.Type == CssTokenType.Whitespace)
        return;
      if (token.Type == CssTokenType.Ident || token.Type == CssTokenType.String || token.Type == CssTokenType.Number)
      {
        this._state = CssSelectorConstructor.State.AttributeEnd;
        this._attrValue = token.Data;
      }
      else
      {
        this._state = CssSelectorConstructor.State.Data;
        this._valid = false;
      }
    }

    private void OnAttributeEnd(CssToken token)
    {
      if (!this._attrInsensitive && token.Type == CssTokenType.Ident && token.Data == "i")
      {
        this._attrInsensitive = true;
      }
      else
      {
        if (token.Type == CssTokenType.Whitespace)
          return;
        this._state = CssSelectorConstructor.State.Data;
        this._ready = true;
        if (token.Type == CssTokenType.SquareBracketClose)
        {
          ISelector selector = this._attributeSelector.Create(this._attrOp, this._attrName, this._attrValue, this._attrNs, this._attrInsensitive);
          this._attrInsensitive = false;
          this.Insert(selector);
        }
        else
          this._valid = false;
      }
    }

    private void OnPseudoClass(CssToken token)
    {
      this._state = CssSelectorConstructor.State.Data;
      this._ready = true;
      if (token.Type == CssTokenType.Colon)
      {
        this._state = CssSelectorConstructor.State.PseudoElement;
      }
      else
      {
        if (token.Type == CssTokenType.Function)
        {
          ISelector pseudoFunction = this.GetPseudoFunction(token as CssFunctionToken);
          if (pseudoFunction != null)
          {
            this.Insert(pseudoFunction);
            return;
          }
        }
        else if (token.Type == CssTokenType.Ident)
        {
          ISelector selector = this._pseudoClassSelector.Create(token.Data);
          if (selector != null)
          {
            this.Insert(selector);
            return;
          }
        }
        this._valid = false;
      }
    }

    private void OnPseudoElement(CssToken token)
    {
      this._state = CssSelectorConstructor.State.Data;
      this._ready = true;
      if (token.Type == CssTokenType.Ident)
      {
        ISelector selector = this._pseudoElementSelector.Create(token.Data);
        if (selector != null)
        {
          this._valid = this._valid && !this._nested;
          this.Insert(selector);
          return;
        }
      }
      this._valid = false;
    }

    private void OnClass(CssToken token)
    {
      this._state = CssSelectorConstructor.State.Data;
      this._ready = true;
      if (token.Type == CssTokenType.Ident)
        this.Insert((ISelector) SimpleSelector.Class(token.Data));
      else
        this._valid = false;
    }

    private void InsertOr()
    {
      if (this._temp == null)
        return;
      if (this._group == null)
        this._group = new ListSelector();
      if (this._complex != null)
      {
        this._complex.ConcludeSelector(this._temp);
        this._group.Add((ISelector) this._complex);
        this._complex = (ComplexSelector) null;
      }
      else
        this._group.Add(this._temp);
      this._temp = (ISelector) null;
    }

    private void Insert(ISelector selector)
    {
      if (this._temp != null)
      {
        if (this._combinators.Count == 0)
        {
          if (!(this._temp is CompoundSelector compoundSelector1))
          {
            CompoundSelector compoundSelector = new CompoundSelector();
            compoundSelector.Add(this._temp);
            compoundSelector1 = compoundSelector;
          }
          compoundSelector1.Add(selector);
          this._temp = (ISelector) compoundSelector1;
        }
        else
        {
          if (this._complex == null)
            this._complex = new ComplexSelector();
          this._complex.AppendSelector(this._temp, this.GetCombinator());
          this._temp = selector;
        }
      }
      else
      {
        this._combinators.Clear();
        this._temp = selector;
      }
    }

    private CssCombinator GetCombinator()
    {
      while (this._combinators.Count > 1 && this._combinators.Peek() == CssCombinator.Descendent)
        this._combinators.Pop();
      if (this._combinators.Count <= 1)
        return this._combinators.Pop();
      CssCombinator combinator = this._combinators.Pop();
      CssCombinator cssCombinator = this._combinators.Pop();
      if (combinator == CssCombinator.Child && cssCombinator == CssCombinator.Child)
      {
        if (this._combinators.Count == 0 || this._combinators.Peek() != CssCombinator.Child)
          combinator = CssCombinator.Descendent;
        else if (this._combinators.Pop() == CssCombinator.Child)
          combinator = CssCombinator.Deep;
      }
      else if (combinator == CssCombinator.Namespace && cssCombinator == CssCombinator.Namespace)
        combinator = CssCombinator.Column;
      else
        this._combinators.Push(cssCombinator);
      while (this._combinators.Count > 0)
        this._valid = this._combinators.Pop() == CssCombinator.Descendent && this._valid;
      return combinator;
    }

    private void Insert(CssCombinator cssCombinator) => this._combinators.Push(cssCombinator);

    private void OnDelim(CssToken token)
    {
      switch (token.Data[0])
      {
        case '*':
          this.Insert((ISelector) SimpleSelector.All);
          this._ready = true;
          break;
        case '+':
          this.Insert(CssCombinator.AdjacentSibling);
          this._ready = false;
          break;
        case ',':
          this.InsertOr();
          this._ready = false;
          break;
        case '.':
          this._state = CssSelectorConstructor.State.Class;
          this._ready = false;
          break;
        case '>':
          this.Insert(CssCombinator.Child);
          this._ready = false;
          break;
        case '|':
          if (this._combinators.Count > 0 && this._combinators.Peek() == CssCombinator.Descendent)
            this.Insert((ISelector) SimpleSelector.Type(string.Empty));
          this.Insert(CssCombinator.Namespace);
          this._ready = false;
          break;
        case '~':
          this.Insert(CssCombinator.Sibling);
          this._ready = false;
          break;
        default:
          this._valid = false;
          break;
      }
    }

    private ISelector GetPseudoFunction(CssFunctionToken arguments)
    {
      Func<CssSelectorConstructor, CssSelectorConstructor.FunctionState> func = (Func<CssSelectorConstructor, CssSelectorConstructor.FunctionState>) null;
      if (CssSelectorConstructor.pseudoClassFunctions.TryGetValue(arguments.Data, out func))
      {
        using (CssSelectorConstructor.FunctionState functionState = func(this))
        {
          this._ready = false;
          foreach (CssToken token in arguments)
          {
            if (functionState.Finished(token))
            {
              ISelector pseudoFunction = functionState.Produce();
              if (this._nested && functionState is CssSelectorConstructor.NotFunctionState)
                pseudoFunction = (ISelector) null;
              this._ready = true;
              return pseudoFunction;
            }
          }
        }
      }
      return (ISelector) null;
    }

    private CssSelectorConstructor CreateChild()
    {
      CssSelectorConstructor child = Pool.NewSelectorConstructor(this._attributeSelector, this._pseudoClassSelector, this._pseudoElementSelector);
      child._invoked = true;
      return child;
    }

    private enum State : byte
    {
      Data,
      Attribute,
      AttributeOperator,
      AttributeValue,
      AttributeEnd,
      Class,
      PseudoClass,
      PseudoElement,
    }

    private abstract class FunctionState : IDisposable
    {
      public bool Finished(CssToken token) => this.OnToken(token);

      public abstract ISelector Produce();

      protected abstract bool OnToken(CssToken token);

      public virtual void Dispose()
      {
      }
    }

    private sealed class NotFunctionState : CssSelectorConstructor.FunctionState
    {
      private readonly CssSelectorConstructor _selector;

      public NotFunctionState(CssSelectorConstructor parent)
      {
        this._selector = parent.CreateChild();
        this._selector._nested = true;
      }

      protected override bool OnToken(CssToken token)
      {
        if (token.Type == CssTokenType.RoundBracketClose && this._selector._state == CssSelectorConstructor.State.Data)
          return true;
        this._selector.Apply(token);
        return false;
      }

      public override ISelector Produce()
      {
        int num = this._selector.IsValid ? 1 : 0;
        ISelector sel = this._selector.GetResult();
        if (num == 0)
          return (ISelector) null;
        return (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => !sel.Match(el)), PseudoClassNames.Not.CssFunction(sel.Text));
      }

      public override void Dispose()
      {
        base.Dispose();
        this._selector.ToPool();
      }
    }

    private sealed class HasFunctionState : CssSelectorConstructor.FunctionState
    {
      private readonly CssSelectorConstructor _nested;

      public HasFunctionState(CssSelectorConstructor parent) => this._nested = parent.CreateChild();

      protected override bool OnToken(CssToken token)
      {
        if (token.Type == CssTokenType.RoundBracketClose && this._nested._state == CssSelectorConstructor.State.Data)
          return true;
        this._nested.Apply(token);
        return false;
      }

      public override ISelector Produce()
      {
        int num = this._nested.IsValid ? 1 : 0;
        ISelector sel = this._nested.GetResult();
        if (num == 0)
          return (ISelector) null;
        return (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.ChildNodes.QuerySelector(sel) != null), PseudoClassNames.Has.CssFunction(sel.Text));
      }

      public override void Dispose()
      {
        base.Dispose();
        this._nested.ToPool();
      }
    }

    private sealed class MatchesFunctionState : CssSelectorConstructor.FunctionState
    {
      private readonly CssSelectorConstructor _selector;

      public MatchesFunctionState(CssSelectorConstructor parent) => this._selector = parent.CreateChild();

      protected override bool OnToken(CssToken token)
      {
        if (token.Type == CssTokenType.RoundBracketClose && this._selector._state == CssSelectorConstructor.State.Data)
          return true;
        this._selector.Apply(token);
        return false;
      }

      public override ISelector Produce()
      {
        int num = this._selector.IsValid ? 1 : 0;
        ISelector sel = this._selector.GetResult();
        if (num == 0)
          return (ISelector) null;
        return (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => sel.Match(el)), PseudoClassNames.Matches.CssFunction(sel.Text));
      }

      public override void Dispose()
      {
        base.Dispose();
        this._selector.ToPool();
      }
    }

    private sealed class DirFunctionState : CssSelectorConstructor.FunctionState
    {
      private bool _valid;
      private string _value;

      public DirFunctionState()
      {
        this._valid = true;
        this._value = (string) null;
      }

      protected override bool OnToken(CssToken token)
      {
        if (token.Type == CssTokenType.Ident)
        {
          this._value = token.Data;
        }
        else
        {
          if (token.Type == CssTokenType.RoundBracketClose)
            return true;
          if (token.Type != CssTokenType.Whitespace)
            this._valid = false;
        }
        return false;
      }

      public override ISelector Produce() => this._valid && this._value != null ? (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el is IHtmlElement && this._value.Isi(((IHtmlElement) el).Direction)), PseudoClassNames.Dir.CssFunction(this._value)) : (ISelector) null;
    }

    private sealed class LangFunctionState : CssSelectorConstructor.FunctionState
    {
      private bool valid;
      private string value;

      public LangFunctionState()
      {
        this.valid = true;
        this.value = (string) null;
      }

      protected override bool OnToken(CssToken token)
      {
        if (token.Type == CssTokenType.Ident)
        {
          this.value = token.Data;
        }
        else
        {
          if (token.Type == CssTokenType.RoundBracketClose)
            return true;
          if (token.Type != CssTokenType.Whitespace)
            this.valid = false;
        }
        return false;
      }

      public override ISelector Produce() => this.valid && this.value != null ? (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el is IHtmlElement && ((IHtmlElement) el).Language.StartsWith(this.value, StringComparison.OrdinalIgnoreCase)), PseudoClassNames.Lang.CssFunction(this.value)) : (ISelector) null;
    }

    private sealed class ContainsFunctionState : CssSelectorConstructor.FunctionState
    {
      private bool _valid;
      private string _value;

      public ContainsFunctionState()
      {
        this._valid = true;
        this._value = (string) null;
      }

      protected override bool OnToken(CssToken token)
      {
        if (token.Type == CssTokenType.Ident || token.Type == CssTokenType.String)
        {
          this._value = token.Data;
        }
        else
        {
          if (token.Type == CssTokenType.RoundBracketClose)
            return true;
          if (token.Type != CssTokenType.Whitespace)
            this._valid = false;
        }
        return false;
      }

      public override ISelector Produce() => this._valid && this._value != null ? (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.TextContent.Contains(this._value)), PseudoClassNames.Contains.CssFunction(this._value)) : (ISelector) null;
    }

    private sealed class HostContextFunctionState : CssSelectorConstructor.FunctionState
    {
      private readonly CssSelectorConstructor _selector;

      public HostContextFunctionState(CssSelectorConstructor parent) => this._selector = parent.CreateChild();

      protected override bool OnToken(CssToken token)
      {
        if (token.Type == CssTokenType.RoundBracketClose && this._selector._state == CssSelectorConstructor.State.Data)
          return true;
        this._selector.Apply(token);
        return false;
      }

      public override ISelector Produce()
      {
        int num = this._selector.IsValid ? 1 : 0;
        ISelector sel = this._selector.GetResult();
        if (num == 0)
          return (ISelector) null;
        return (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el =>
        {
          for (IElement element = el.Parent is IShadowRoot parent2 ? parent2.Host : (IElement) null; element != null; element = element.ParentElement)
          {
            if (sel.Match(element))
              return true;
          }
          return false;
        }), PseudoClassNames.HostContext.CssFunction(sel.Text));
      }

      public override void Dispose()
      {
        base.Dispose();
        this._selector.ToPool();
      }
    }

    private sealed class ChildFunctionState<T> : CssSelectorConstructor.FunctionState where T : ChildSelector, ISelector, new()
    {
      private readonly CssSelectorConstructor _parent;
      private bool _valid;
      private int _step;
      private int _offset;
      private int _sign;
      private CssSelectorConstructor.ChildFunctionState<T>.ParseState _state;
      private CssSelectorConstructor _nested;
      private bool _allowOf;

      public ChildFunctionState(CssSelectorConstructor parent, bool withOptionalSelector = true)
      {
        this._parent = parent;
        this._allowOf = withOptionalSelector;
        this._valid = true;
        this._sign = 1;
        this._state = CssSelectorConstructor.ChildFunctionState<T>.ParseState.Initial;
      }

      public override ISelector Produce()
      {
        int num = !this._valid ? 1 : (this._nested == null ? 0 : (!this._nested.IsValid ? 1 : 0));
        CssSelectorConstructor nested = this._nested;
        ISelector kind = (nested != null ? nested.ToPool() : (ISelector) null) ?? (ISelector) SimpleSelector.All;
        return num != 0 ? (ISelector) null : (ISelector) new T().With(this._step, this._offset, kind);
      }

      protected override bool OnToken(CssToken token)
      {
        switch (this._state)
        {
          case CssSelectorConstructor.ChildFunctionState<T>.ParseState.Initial:
            return this.OnInitial(token);
          case CssSelectorConstructor.ChildFunctionState<T>.ParseState.AfterInitialSign:
            return this.OnAfterInitialSign(token);
          case CssSelectorConstructor.ChildFunctionState<T>.ParseState.Offset:
            return this.OnOffset(token);
          case CssSelectorConstructor.ChildFunctionState<T>.ParseState.BeforeOf:
            return this.OnBeforeOf(token);
          default:
            return this.OnAfter(token);
        }
      }

      private bool OnAfterInitialSign(CssToken token)
      {
        if (token.Type == CssTokenType.Number)
          return this.OnOffset(token);
        if (token.Type == CssTokenType.Dimension)
        {
          CssUnitToken cssUnitToken = (CssUnitToken) token;
          this._valid = this._valid && cssUnitToken.Unit.Isi("n") && int.TryParse(token.Data, out this._step);
          this._step *= this._sign;
          this._sign = 1;
          this._state = CssSelectorConstructor.ChildFunctionState<T>.ParseState.Offset;
          return false;
        }
        if (token.Type == CssTokenType.Ident && token.Data.Isi("n"))
        {
          this._step = this._sign;
          this._sign = 1;
          this._state = CssSelectorConstructor.ChildFunctionState<T>.ParseState.Offset;
          return false;
        }
        if (this._state == CssSelectorConstructor.ChildFunctionState<T>.ParseState.Initial && token.Type == CssTokenType.Ident && token.Data.Isi("-n"))
        {
          this._step = -1;
          this._state = CssSelectorConstructor.ChildFunctionState<T>.ParseState.Offset;
          return false;
        }
        this._valid = false;
        return token.Type == CssTokenType.RoundBracketClose;
      }

      private bool OnAfter(CssToken token)
      {
        if (token.Type == CssTokenType.RoundBracketClose && this._nested._state == CssSelectorConstructor.State.Data)
          return true;
        this._nested.Apply(token);
        return false;
      }

      private bool OnBeforeOf(CssToken token)
      {
        if (token.Type == CssTokenType.Whitespace)
          return false;
        if (token.Data.Isi(Keywords.Of))
        {
          this._valid = this._allowOf;
          this._state = CssSelectorConstructor.ChildFunctionState<T>.ParseState.AfterOf;
          this._nested = this._parent.CreateChild();
          return false;
        }
        if (token.Type == CssTokenType.RoundBracketClose)
          return true;
        this._valid = false;
        return false;
      }

      private bool OnOffset(CssToken token)
      {
        if (token.Type == CssTokenType.Whitespace)
          return false;
        if (token.Type != CssTokenType.Number)
          return this.OnBeforeOf(token);
        this._valid = this._valid && ((CssNumberToken) token).IsInteger && int.TryParse(token.Data, out this._offset);
        this._offset *= this._sign;
        this._state = CssSelectorConstructor.ChildFunctionState<T>.ParseState.BeforeOf;
        return false;
      }

      private bool OnInitial(CssToken token)
      {
        if (token.Type == CssTokenType.Whitespace)
          return false;
        if (token.Data.Isi(Keywords.Odd))
        {
          this._state = CssSelectorConstructor.ChildFunctionState<T>.ParseState.BeforeOf;
          this._step = 2;
          this._offset = 1;
          return false;
        }
        if (token.Data.Isi(Keywords.Even))
        {
          this._state = CssSelectorConstructor.ChildFunctionState<T>.ParseState.BeforeOf;
          this._step = 2;
          this._offset = 0;
          return false;
        }
        if (token.Type != CssTokenType.Delim || !token.Data.IsOneOf("+", "-"))
          return this.OnAfterInitialSign(token);
        this._sign = token.Data == "-" ? -1 : 1;
        this._state = CssSelectorConstructor.ChildFunctionState<T>.ParseState.AfterInitialSign;
        return false;
      }

      private enum ParseState : byte
      {
        Initial,
        AfterInitialSign,
        Offset,
        BeforeOf,
        AfterOf,
      }
    }
  }
}
