// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.NamingStrategy
// Assembly: Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: A4A4D6C6-3EFA-4DC8-AAEA-DA1EC7F2D4DE
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Newtonsoft.Json.dll

namespace Newtonsoft.Json.Serialization
{
  public abstract class NamingStrategy
  {
    public bool ProcessDictionaryKeys { get; set; }

    public bool ProcessExtensionDataNames { get; set; }

    public bool OverrideSpecifiedNames { get; set; }

    public virtual string GetPropertyName(string name, bool hasSpecifiedName) => hasSpecifiedName && !this.OverrideSpecifiedNames ? name : this.ResolvePropertyName(name);

    public virtual string GetExtensionDataName(string name) => !this.ProcessExtensionDataNames ? name : this.ResolvePropertyName(name);

    public virtual string GetDictionaryKey(string key) => !this.ProcessDictionaryKeys ? key : this.ResolvePropertyName(key);

    protected abstract string ResolvePropertyName(string name);

    public override int GetHashCode() => ((this.GetType().GetHashCode() * 397 ^ this.ProcessDictionaryKeys.GetHashCode()) * 397 ^ this.ProcessExtensionDataNames.GetHashCode()) * 397 ^ this.OverrideSpecifiedNames.GetHashCode();

    public override bool Equals(object obj) => this.Equals(obj as NamingStrategy);

    protected bool Equals(NamingStrategy other) => other != null && this.GetType() == other.GetType() && this.ProcessDictionaryKeys == other.ProcessDictionaryKeys && this.ProcessExtensionDataNames == other.ProcessExtensionDataNames && this.OverrideSpecifiedNames == other.OverrideSpecifiedNames;
  }
}
