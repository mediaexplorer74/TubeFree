﻿// Decompiled with JetBrains decompiler
// Type: AngleSharp.Url
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using AngleSharp.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngleSharp
{
  public sealed class Url : IEquatable<Url>
  {
    private static readonly string currentDirectory = ".";
    private static readonly string currentDirectoryAlternative = "%2e";
    private static readonly string upperDirectory = "..";
    private static readonly string[] upperDirectoryAlternatives = new string[3]
    {
      "%2e%2e",
      ".%2e",
      "%2e."
    };
    private static readonly Url DefaultBase = new Url(string.Empty, string.Empty, string.Empty);
    private string _fragment;
    private string _query;
    private string _path;
    private string _scheme;
    private string _port;
    private string _host;
    private string _username;
    private string _password;
    private bool _relative;
    private string _schemeData;
    private bool _error;

    private Url(string scheme, string host, string port)
    {
      this._schemeData = string.Empty;
      this._path = string.Empty;
      this._scheme = scheme;
      this._host = host;
      this._port = port;
      this._relative = ProtocolNames.IsRelative(this._scheme);
    }

    public Url(string address) => this._error = this.ParseUrl(address);

    public Url(Url baseAddress, string relativeAddress) => this._error = this.ParseUrl(relativeAddress, baseAddress);

    public Url(Url address)
    {
      this._fragment = address._fragment;
      this._query = address._query;
      this._path = address._path;
      this._scheme = address._scheme;
      this._port = address._port;
      this._host = address._host;
      this._username = address._username;
      this._password = address._password;
      this._relative = address._relative;
      this._schemeData = address._schemeData;
    }

    public static Url Create(string address) => new Url(address);

    public static Url Convert(Uri uri) => new Url(uri.OriginalString);

    public string Origin
    {
      get
      {
        if (this._scheme.Is(ProtocolNames.Blob))
        {
          Url url = new Url(this._schemeData);
          if (!url.IsInvalid)
            return url.Origin;
        }
        else if (ProtocolNames.IsOriginable(this._scheme))
        {
          StringBuilder sb = Pool.NewStringBuilder();
          if (!string.IsNullOrEmpty(this._host))
          {
            if (!string.IsNullOrEmpty(this._scheme))
              sb.Append(this._scheme).Append(':');
            sb.Append('/').Append('/').Append(this._host);
            if (!string.IsNullOrEmpty(this._port))
              sb.Append(':').Append(this._port);
          }
          return sb.ToPool();
        }
        return (string) null;
      }
    }

    public bool IsInvalid => this._error;

    public bool IsRelative => this._relative && string.IsNullOrEmpty(this._scheme);

    public bool IsAbsolute => !this.IsRelative;

    public string UserName
    {
      get => this._username;
      set => this._username = value;
    }

    public string Password
    {
      get => this._password;
      set => this._password = value;
    }

    public string Data => this._schemeData;

    public string Fragment
    {
      get => this._fragment;
      set
      {
        if (value == null)
          this._fragment = (string) null;
        else
          this.ParseFragment(value, 0, value.Length);
      }
    }

    public string Host
    {
      get => this.HostName + (string.IsNullOrEmpty(this._port) ? string.Empty : ":" + this._port);
      set
      {
        string input = value ?? string.Empty;
        this.ParseHostName(input, 0, input.Length, onlyPort: true);
      }
    }

    public string HostName
    {
      get => this._host;
      set
      {
        string input = value ?? string.Empty;
        this.ParseHostName(input, 0, input.Length, true);
      }
    }

    public string Href
    {
      get => this.Serialize();
      set => this._error = this.ParseUrl(value ?? string.Empty);
    }

    public string Path
    {
      get => this._path;
      set
      {
        string input = value ?? string.Empty;
        this.ParsePath(input, 0, input.Length, true);
      }
    }

    public string Port
    {
      get => this._port;
      set
      {
        string input = value ?? string.Empty;
        this.ParsePort(input, 0, input.Length, true);
      }
    }

    public string Scheme
    {
      get => this._scheme;
      set
      {
        string input = value ?? string.Empty;
        this.ParseScheme(input, input.Length, true);
      }
    }

    public string Query
    {
      get => this._query;
      set
      {
        string input = value ?? string.Empty;
        this.ParseQuery(input, 0, input.Length, true);
      }
    }

    public override int GetHashCode() => base.GetHashCode();

    public override bool Equals(object obj) => obj is Url other && this.Equals(other);

    public bool Equals(Url other) => this._fragment.Is(other._fragment) && this._query.Is(other._query) && this._path.Is(other._path) && this._scheme.Isi(other._scheme) && this._port.Is(other._port) && this._host.Isi(other._host) && this._username.Is(other._username) && this._password.Is(other._password) && this._schemeData.Is(other._schemeData);

    public static implicit operator Uri(Url value) => new Uri(value.Serialize(), value.IsRelative ? UriKind.Relative : UriKind.Absolute);

    public override string ToString() => this.Serialize();

    private string Serialize()
    {
      StringBuilder sb = Pool.NewStringBuilder();
      if (!string.IsNullOrEmpty(this._scheme))
        sb.Append(this._scheme).Append(':');
      if (this._relative)
      {
        if (!string.IsNullOrEmpty(this._host) || !string.IsNullOrEmpty(this._scheme))
        {
          sb.Append('/').Append('/');
          if (!string.IsNullOrEmpty(this._username) || this._password != null)
          {
            sb.Append(this._username);
            if (this._password != null)
              sb.Append(':').Append(this._password);
            sb.Append('@');
          }
          sb.Append(this._host);
          if (!string.IsNullOrEmpty(this._port))
            sb.Append(':').Append(this._port);
          sb.Append('/');
        }
        sb.Append(this._path);
      }
      else
        sb.Append(this._schemeData);
      if (this._query != null)
        sb.Append('?').Append(this._query);
      if (this._fragment != null)
        sb.Append('#').Append(this._fragment);
      return sb.ToPool();
    }

    private bool ParseUrl(string input, Url baseUrl = null)
    {
      this.Reset(baseUrl ?? Url.DefaultBase);
      string input1 = input.Trim();
      int length = input1.Length;
      return !this.ParseScheme(input1, length);
    }

    private void Reset(Url baseUrl)
    {
      this._schemeData = string.Empty;
      this._scheme = baseUrl._scheme;
      this._host = baseUrl._host;
      this._path = baseUrl._path;
      this._port = baseUrl._port;
      this._relative = ProtocolNames.IsRelative(this._scheme);
    }

    private bool ParseScheme(string input, int length, bool onlyScheme = false)
    {
      if (length > 0 && input[0].IsLetter())
      {
        for (int index1 = 1; index1 < length; ++index1)
        {
          char c = input[index1];
          if (!c.IsAlphanumericAscii())
          {
            switch (c)
            {
              case '+':
              case '-':
              case '.':
                continue;
              case ':':
                string scheme = this._scheme;
                this._scheme = input.Substring(0, index1).ToLowerInvariant();
                if (onlyScheme)
                  return true;
                this._relative = ProtocolNames.IsRelative(this._scheme);
                if (this._scheme.Is(ProtocolNames.File))
                {
                  this._host = string.Empty;
                  this._port = string.Empty;
                  return this.RelativeState(input, index1 + 1, length);
                }
                if (!this._relative)
                {
                  this._host = string.Empty;
                  this._port = string.Empty;
                  this._path = string.Empty;
                  return this.ParseSchemeData(input, index1 + 1, length);
                }
                if (this._scheme.Is(scheme))
                {
                  int index2;
                  if ((index2 = index1 + 1) >= length)
                    return false;
                  return input[index2] == '/' && index2 + 2 < length && input[index2 + 1] == '/' ? this.IgnoreSlashesState(input, index2 + 2, length) : this.RelativeState(input, index2, length);
                }
                if (index1 + 1 < length && input[++index1] == '/' && ++index1 < length && input[index1] == '/')
                  ++index1;
                return this.IgnoreSlashesState(input, index1, length);
              default:
                goto label_21;
            }
          }
        }
      }
label_21:
      return !onlyScheme && this.RelativeState(input, 0, length);
    }

    private bool ParseSchemeData(string input, int index, int length)
    {
      StringBuilder stringBuilder = Pool.NewStringBuilder();
      for (; index < length; ++index)
      {
        char c = input[index];
        switch (c)
        {
          case '#':
            this._schemeData = stringBuilder.ToPool();
            return this.ParseFragment(input, index + 1, length);
          case '%':
            if (index + 2 < length && input[index + 1].IsHex() && input[index + 2].IsHex())
            {
              stringBuilder.Append(input[index++]);
              stringBuilder.Append(input[index++]);
              stringBuilder.Append(input[index]);
              break;
            }
            goto default;
          case '?':
            this._schemeData = stringBuilder.ToPool();
            return this.ParseQuery(input, index + 1, length);
          default:
            if (c.IsInRange(32, 126))
            {
              stringBuilder.Append(c);
              break;
            }
            if (c != '\t' && c != '\n' && c != '\r')
            {
              index += Url.Utf8PercentEncode(stringBuilder, input, index);
              break;
            }
            break;
        }
      }
      this._schemeData = stringBuilder.ToPool();
      return true;
    }

    private bool RelativeState(string input, int index, int length)
    {
      this._relative = true;
      if (index == length)
        return true;
      switch (input[index])
      {
        case '#':
          return this.ParseFragment(input, index + 1, length);
        case '/':
        case '\\':
          if (index == length - 1)
            return this.ParsePath(input, index, length);
          if (input[++index].IsOneOf('/', '\\'))
            return this._scheme.Is(ProtocolNames.File) ? this.ParseFileHost(input, index + 1, length) : this.IgnoreSlashesState(input, index + 1, length);
          if (this._scheme.Is(ProtocolNames.File))
          {
            this._host = string.Empty;
            this._port = string.Empty;
          }
          return this.ParsePath(input, index - 1, length);
        case '?':
          return this.ParseQuery(input, index + 1, length);
        default:
          if (input[index].IsLetter() && this._scheme.Is(ProtocolNames.File) && index + 1 < length && input[index + 1].IsOneOf(':', '/') && (index + 2 == length || input[index + 2].IsOneOf('/', '\\', '#', '?')))
          {
            this._host = string.Empty;
            this._path = string.Empty;
            this._port = string.Empty;
          }
          return this.ParsePath(input, index, length);
      }
    }

    private bool IgnoreSlashesState(string input, int index, int length)
    {
      for (; index < length; ++index)
      {
        if (!input[index].IsOneOf('\\', '/'))
          return this.ParseAuthority(input, index, length);
      }
      return false;
    }

    private bool ParseAuthority(string input, int index, int length)
    {
      int index1 = index;
      StringBuilder stringBuilder = Pool.NewStringBuilder();
      string str1 = (string) null;
      string str2 = (string) null;
      for (; index < length; ++index)
      {
        char c = input[index];
        if (c == '@')
        {
          if (str1 == null)
            str1 = stringBuilder.ToString();
          else
            str2 = stringBuilder.ToString();
          this._username = str1;
          this._password = str2;
          stringBuilder.Append("%40");
          index1 = index + 1;
        }
        else if (c == ':' && str1 == null)
        {
          str1 = stringBuilder.ToString();
          str2 = string.Empty;
          stringBuilder.Clear();
        }
        else if (c == '%' && index + 2 < length && input[index + 1].IsHex() && input[index + 2].IsHex())
          stringBuilder.Append(input[index++]).Append(input[index++]).Append(input[index]);
        else if (!c.IsOneOf('\t', '\n', '\r'))
        {
          if (!c.IsOneOf('/', '\\', '#', '?'))
          {
            switch (c)
            {
              case '#':
              case '?':
                stringBuilder.Append(c);
                continue;
              case ':':
                index += Url.Utf8PercentEncode(stringBuilder, input, index);
                continue;
              default:
                if (!c.IsNormalPathCharacter())
                  goto case ':';
                else
                  goto case '#';
            }
          }
          else
            break;
        }
      }
      stringBuilder.ToPool();
      return this.ParseHostName(input, index1, length);
    }

    private bool ParseFileHost(string input, int index, int length)
    {
      int num = index;
      this._path = string.Empty;
      for (; index < length; ++index)
      {
        switch (input[index])
        {
          case '#':
          case '/':
          case '?':
          case '\\':
            goto label_4;
          default:
            continue;
        }
      }
label_4:
      int length1 = index - num;
      if (length1 == 2 && input[num].IsLetter() && input[num + 1].IsOneOf('|', ':'))
        return this.ParsePath(input, index - 2, length);
      if (length1 != 0)
        this._host = Url.SanatizeHost(input, num, length1);
      return this.ParsePath(input, index, length);
    }

    private bool ParseHostName(string input, int index, int length, bool onlyHost = false, bool onlyPort = false)
    {
      bool flag1 = false;
      int start = index;
      for (; index < length; ++index)
      {
        switch (input[index])
        {
          case '#':
          case '/':
          case '?':
          case '\\':
            this._host = Url.SanatizeHost(input, start, index - start);
            bool flag2 = string.IsNullOrEmpty(this._host);
            if (onlyHost)
              return !flag2;
            this._port = string.Empty;
            return this.ParsePath(input, index, length) && !flag2;
          case ':':
            if (!flag1)
            {
              this._host = Url.SanatizeHost(input, start, index - start);
              return onlyHost || this.ParsePort(input, index + 1, length, onlyPort);
            }
            break;
          case '[':
            flag1 = true;
            break;
          case ']':
            flag1 = false;
            break;
        }
      }
      this._host = Url.SanatizeHost(input, start, index - start);
      if (!onlyHost)
      {
        this._path = string.Empty;
        this._query = (string) null;
        this._fragment = (string) null;
      }
      return true;
    }

    private bool ParsePort(string input, int index, int length, bool onlyPort = false)
    {
      int start = index;
      for (; index < length; ++index)
      {
        char c = input[index];
        switch (c)
        {
          case '#':
          case '/':
          case '?':
          case '\\':
            goto label_6;
          default:
            if (!c.IsDigit() && c != '\t' && c != '\n' && c != '\r')
              return false;
            continue;
        }
      }
label_6:
      this._port = Url.SanatizePort(input, start, index - start);
      if (PortNumbers.GetDefaultPort(this._scheme) == this._port)
        this._port = string.Empty;
      if (onlyPort)
        return true;
      this._path = string.Empty;
      return this.ParsePath(input, index, length);
    }

    private bool ParsePath(string input, int index, int length, bool onlyPath = false)
    {
      int num = index;
      if (index < length && (input[index] == '/' || input[index] == '\\'))
        ++index;
      List<string> values = new List<string>();
      if (!onlyPath && !string.IsNullOrEmpty(this._path) && index - num == 0)
      {
        string[] collection = this._path.Split('/');
        if (collection.Length > 1)
        {
          values.AddRange((IEnumerable<string>) collection);
          values.RemoveAt(collection.Length - 1);
        }
      }
      int count = values.Count;
      StringBuilder stringBuilder = Pool.NewStringBuilder();
      for (; index <= length; ++index)
      {
        char c = index == length ? char.MaxValue : input[index];
        bool flag1 = !onlyPath && (c == '#' || c == '?');
        if (((c == char.MaxValue || c == '/' ? 1 : (c == '\\' ? 1 : 0)) | (flag1 ? 1 : 0)) != 0)
        {
          string current = stringBuilder.ToString();
          bool flag2 = false;
          stringBuilder.Clear();
          if (current.Isi(Url.currentDirectoryAlternative))
            current = Url.currentDirectory;
          else if (current.Isi(Url.upperDirectoryAlternatives[0]) || current.Isi(Url.upperDirectoryAlternatives[1]) || current.Isi(Url.upperDirectoryAlternatives[2]))
            current = Url.upperDirectory;
          if (current.Is(Url.upperDirectory))
          {
            if (values.Count > 0)
              values.RemoveAt(values.Count - 1);
            flag2 = true;
          }
          else if (!current.Is(Url.currentDirectory))
          {
            if (this._scheme.Is(ProtocolNames.File) && values.Count == count && current.Length == 2 && current[0].IsLetter() && current[1] == '|')
            {
              current = current.Replace('|', ':');
              values.Clear();
            }
            values.Add(current);
          }
          else
            flag2 = true;
          if (flag2 && c != '/' && c != '\\')
            values.Add(string.Empty);
          if (flag1)
            break;
        }
        else if (c == '%' && index + 2 < length && input[index + 1].IsHex() && input[index + 2].IsHex())
        {
          stringBuilder.Append(input[index++]);
          stringBuilder.Append(input[index++]);
          stringBuilder.Append(input[index]);
        }
        else if (c != '\t' && c != '\n' && c != '\r')
        {
          if (c.IsNormalPathCharacter())
            stringBuilder.Append(c);
          else
            index += Url.Utf8PercentEncode(stringBuilder, input, index);
        }
      }
      stringBuilder.ToPool();
      this._path = string.Join("/", (IEnumerable<string>) values);
      if (index >= length)
        return true;
      return input[index] == '?' ? this.ParseQuery(input, index + 1, length) : this.ParseFragment(input, index + 1, length);
    }

    private bool ParseQuery(string input, int index, int length, bool onlyQuery = false)
    {
      StringBuilder stringBuilder = Pool.NewStringBuilder();
      bool flag = false;
      for (; index < length; ++index)
      {
        char c = input[index];
        flag = !onlyQuery && input[index] == '#';
        if (!flag)
        {
          if (c.IsNormalQueryCharacter())
            stringBuilder.Append(c);
          else
            index += Url.Utf8PercentEncode(stringBuilder, input, index);
        }
        else
          break;
      }
      this._query = stringBuilder.ToPool();
      return !flag || this.ParseFragment(input, index + 1, length);
    }

    private bool ParseFragment(string input, int index, int length)
    {
      StringBuilder sb = Pool.NewStringBuilder();
      for (; index < length; ++index)
      {
        char ch = input[index];
        switch (ch)
        {
          case char.MinValue:
          case '\t':
          case '\n':
          case '\r':
          case char.MaxValue:
            continue;
          default:
            sb.Append(ch);
            continue;
        }
      }
      this._fragment = sb.ToPool();
      return true;
    }

    private static int Utf8PercentEncode(StringBuilder buffer, string source, int index)
    {
      int length = char.IsSurrogatePair(source, index) ? 2 : 1;
      foreach (byte num in TextEncoding.Utf8.GetBytes(source.Substring(index, length)))
        buffer.Append('%').Append(num.ToString("X2"));
      return length - 1;
    }

    private static string SanatizeHost(string hostName, int start, int length)
    {
      if (length > 1 && hostName[start] == '[' && hostName[start + length - 1] == ']')
        return hostName.Substring(start, length);
      byte[] bytes = new byte[4 * length];
      int count = 0;
      int num1 = start + length;
      for (int index = start; index < num1; ++index)
      {
        switch (hostName[index])
        {
          case char.MinValue:
          case '\t':
          case '\n':
          case '\r':
          case ' ':
          case '#':
          case '/':
          case ':':
          case '?':
          case '@':
          case '[':
          case '\\':
          case ']':
            continue;
          case '%':
            if (index + 2 < num1 && hostName[index + 1].IsHex() && hostName[index + 2].IsHex())
            {
              int num2 = hostName[index + 1].FromHex() * 16 + hostName[index + 2].FromHex();
              bytes[count++] = (byte) num2;
              index += 2;
              continue;
            }
            bytes[count++] = (byte) 37;
            continue;
          case '.':
            bytes[count++] = (byte) hostName[index];
            continue;
          default:
            char minValue = char.MinValue;
            if (Symbols.Punycode.TryGetValue(hostName[index], out minValue))
            {
              bytes[count++] = (byte) minValue;
              continue;
            }
            if (!hostName[index].IsAlphanumericAscii())
            {
              int length1 = index + 1 >= num1 || !char.IsSurrogatePair(hostName, index) ? 1 : 2;
              if (length1 != 1 || hostName[index] == '-' || char.IsLetterOrDigit(hostName[index]))
              {
                foreach (byte num3 in TextEncoding.Utf8.GetBytes(hostName.Substring(index, length1)))
                  bytes[count++] = num3;
                index += length1 - 1;
                continue;
              }
              continue;
            }
            bytes[count++] = (byte) char.ToLowerInvariant(hostName[index]);
            continue;
        }
      }
      return TextEncoding.Utf8.GetString(bytes, 0, count);
    }

    private static string SanatizePort(string port, int start, int length)
    {
      char[] chArray = new char[length];
      int length1 = 0;
      int num = start + length;
      for (int index = start; index < num; ++index)
      {
        switch (port[index])
        {
          case '\t':
          case '\n':
          case '\r':
            continue;
          default:
            if (length1 == 1 && chArray[0] == '0')
            {
              chArray[0] = port[index];
              continue;
            }
            chArray[length1++] = port[index];
            continue;
        }
      }
      return new string(chArray, 0, length1);
    }
  }
}
