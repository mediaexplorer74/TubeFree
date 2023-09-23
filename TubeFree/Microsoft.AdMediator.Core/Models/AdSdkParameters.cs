// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Models.AdSdkParameters
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using Microsoft.AdMediator.Core.Utilities;

namespace Microsoft.AdMediator.Core.Models
{
  public class AdSdkParameters
  {
    private readonly IParameterDictionary<string, IParameterDictionary<string, object>> parameters;

    public AdSdkParameters() => this.parameters = (IParameterDictionary<string, IParameterDictionary<string, object>>) new ParameterDictionary<string, IParameterDictionary<string, object>>();

    public IParameterDictionary<string, object> this[string key]
    {
      get
      {
        if (this.parameters.ContainsKey(key))
          return this.parameters[key];
        ParameterDictionary<string, object> parameterDictionary = new ParameterDictionary<string, object>();
        this.parameters[key] = (IParameterDictionary<string, object>) parameterDictionary;
        return this.parameters[key];
      }
      set => this.parameters[key] = value;
    }
  }
}
