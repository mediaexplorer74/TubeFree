// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Location
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using System;

namespace AngleSharp.Dom
{
  internal sealed class Location : ILocation, IUrlUtilities
  {
    private readonly Url _url;

    public event EventHandler<Location.LocationChangedEventArgs> Changed;

    internal Location()
      : this(string.Empty)
    {
    }

    internal Location(string url)
      : this(new Url(url))
    {
    }

    internal Location(Url url) => this._url = url ?? new Url(string.Empty);

    public Url Original => this._url;

    public string Origin => this._url.Origin;

    public bool IsRelative => this._url.IsRelative;

    public string UserName
    {
      get => this._url.UserName;
      set => this._url.UserName = value;
    }

    public string Password
    {
      get => this._url.Password;
      set => this._url.Password = value;
    }

    public string Hash
    {
      get => Location.NonEmptyPrefix(this._url.Fragment, "#");
      set
      {
        string href = this._url.Href;
        if (value != null)
        {
          if (value.Has('#'))
            value = value.Substring(1);
          else if (value.Length == 0)
            value = (string) null;
        }
        if (!(value != this._url.Fragment))
          return;
        this._url.Fragment = value;
        this.RaiseChanged(href, true);
      }
    }

    public string Host
    {
      get => this._url.Host;
      set
      {
        string href = this._url.Href;
        if (!(value != this._url.Host))
          return;
        this._url.Host = value;
        this.RaiseChanged(href, false);
      }
    }

    public string HostName
    {
      get => this._url.HostName;
      set
      {
        string href = this._url.Href;
        if (!(value != this._url.HostName))
          return;
        this._url.HostName = value;
        this.RaiseChanged(href, false);
      }
    }

    public string Href
    {
      get => this._url.Href;
      set
      {
        string href = this._url.Href;
        if (!(value != this._url.Href))
          return;
        this._url.Href = value;
        this.RaiseChanged(href, false);
      }
    }

    public string PathName
    {
      get
      {
        string data = this._url.Data;
        return !string.IsNullOrEmpty(data) ? data : "/" + this._url.Path;
      }
      set
      {
        string href = this._url.Href;
        if (!(value != this._url.Path))
          return;
        this._url.Path = value;
        this.RaiseChanged(href, false);
      }
    }

    public string Port
    {
      get => this._url.Port;
      set
      {
        string href = this._url.Href;
        if (!(value != this._url.Port))
          return;
        this._url.Port = value;
        this.RaiseChanged(href, false);
      }
    }

    public string Protocol
    {
      get => Location.NonEmptyPostfix(this._url.Scheme, ":");
      set
      {
        string href = this._url.Href;
        if (!(value != this._url.Scheme))
          return;
        this._url.Scheme = value;
        this.RaiseChanged(href, false);
      }
    }

    public string Search
    {
      get => Location.NonEmptyPrefix(this._url.Query, "?");
      set
      {
        string href = this._url.Href;
        if (!(value != this._url.Query))
          return;
        this._url.Query = value;
        this.RaiseChanged(href, false);
      }
    }

    public void Assign(string url) => this._url.Href = url;

    public void Replace(string url) => this._url.Href = url;

    public void Reload() => this._url.Href = this.Href;

    public override string ToString() => this._url.Href;

    private void RaiseChanged(string oldAddress, bool hashChanged)
    {
      EventHandler<Location.LocationChangedEventArgs> changed = this.Changed;
      if (changed == null)
        return;
      changed((object) this, new Location.LocationChangedEventArgs(hashChanged, oldAddress, this._url.Href));
    }

    private static string NonEmptyPrefix(string check, string prefix) => !string.IsNullOrEmpty(check) ? prefix + check : string.Empty;

    private static string NonEmptyPostfix(string check, string postfix) => !string.IsNullOrEmpty(check) ? check + postfix : string.Empty;

    public sealed class LocationChangedEventArgs : EventArgs
    {
      public LocationChangedEventArgs(
        bool hashChanged,
        string previousLocation,
        string currentLocation)
      {
        this.IsHashChanged = hashChanged;
        this.PreviousLocation = previousLocation;
        this.CurrentLocation = currentLocation;
      }

      public bool IsHashChanged { get; private set; }

      public string PreviousLocation { get; private set; }

      public string CurrentLocation { get; private set; }
    }
  }
}
