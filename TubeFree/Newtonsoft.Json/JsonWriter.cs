﻿// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.JsonWriter
// Assembly: Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: A4A4D6C6-3EFA-4DC8-AAEA-DA1EC7F2D4DE
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Newtonsoft.Json.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Newtonsoft.Json
{
  public abstract class JsonWriter : IDisposable
  {
    private static readonly JsonWriter.State[][] StateArray;
    internal static readonly JsonWriter.State[][] StateArrayTempate = new JsonWriter.State[8][]
    {
      new JsonWriter.State[10]
      {
        JsonWriter.State.Error,
        JsonWriter.State.Error,
        JsonWriter.State.Error,
        JsonWriter.State.Error,
        JsonWriter.State.Error,
        JsonWriter.State.Error,
        JsonWriter.State.Error,
        JsonWriter.State.Error,
        JsonWriter.State.Error,
        JsonWriter.State.Error
      },
      new JsonWriter.State[10]
      {
        JsonWriter.State.ObjectStart,
        JsonWriter.State.ObjectStart,
        JsonWriter.State.Error,
        JsonWriter.State.Error,
        JsonWriter.State.ObjectStart,
        JsonWriter.State.ObjectStart,
        JsonWriter.State.ObjectStart,
        JsonWriter.State.ObjectStart,
        JsonWriter.State.Error,
        JsonWriter.State.Error
      },
      new JsonWriter.State[10]
      {
        JsonWriter.State.ArrayStart,
        JsonWriter.State.ArrayStart,
        JsonWriter.State.Error,
        JsonWriter.State.Error,
        JsonWriter.State.ArrayStart,
        JsonWriter.State.ArrayStart,
        JsonWriter.State.ArrayStart,
        JsonWriter.State.ArrayStart,
        JsonWriter.State.Error,
        JsonWriter.State.Error
      },
      new JsonWriter.State[10]
      {
        JsonWriter.State.ConstructorStart,
        JsonWriter.State.ConstructorStart,
        JsonWriter.State.Error,
        JsonWriter.State.Error,
        JsonWriter.State.ConstructorStart,
        JsonWriter.State.ConstructorStart,
        JsonWriter.State.ConstructorStart,
        JsonWriter.State.ConstructorStart,
        JsonWriter.State.Error,
        JsonWriter.State.Error
      },
      new JsonWriter.State[10]
      {
        JsonWriter.State.Property,
        JsonWriter.State.Error,
        JsonWriter.State.Property,
        JsonWriter.State.Property,
        JsonWriter.State.Error,
        JsonWriter.State.Error,
        JsonWriter.State.Error,
        JsonWriter.State.Error,
        JsonWriter.State.Error,
        JsonWriter.State.Error
      },
      new JsonWriter.State[10]
      {
        JsonWriter.State.Start,
        JsonWriter.State.Property,
        JsonWriter.State.ObjectStart,
        JsonWriter.State.Object,
        JsonWriter.State.ArrayStart,
        JsonWriter.State.Array,
        JsonWriter.State.Constructor,
        JsonWriter.State.Constructor,
        JsonWriter.State.Error,
        JsonWriter.State.Error
      },
      new JsonWriter.State[10]
      {
        JsonWriter.State.Start,
        JsonWriter.State.Property,
        JsonWriter.State.ObjectStart,
        JsonWriter.State.Object,
        JsonWriter.State.ArrayStart,
        JsonWriter.State.Array,
        JsonWriter.State.Constructor,
        JsonWriter.State.Constructor,
        JsonWriter.State.Error,
        JsonWriter.State.Error
      },
      new JsonWriter.State[10]
      {
        JsonWriter.State.Start,
        JsonWriter.State.Object,
        JsonWriter.State.Error,
        JsonWriter.State.Error,
        JsonWriter.State.Array,
        JsonWriter.State.Array,
        JsonWriter.State.Constructor,
        JsonWriter.State.Constructor,
        JsonWriter.State.Error,
        JsonWriter.State.Error
      }
    };
    private List<JsonPosition> _stack;
    private JsonPosition _currentPosition;
    private JsonWriter.State _currentState;
    private Formatting _formatting;
    private DateFormatHandling _dateFormatHandling;
    private DateTimeZoneHandling _dateTimeZoneHandling;
    private StringEscapeHandling _stringEscapeHandling;
    private FloatFormatHandling _floatFormatHandling;
    private string _dateFormatString;
    private CultureInfo _culture;

    internal Task AutoCompleteAsync(
      JsonToken tokenBeingWritten,
      CancellationToken cancellationToken)
    {
      JsonWriter.State currentState = this._currentState;
      JsonWriter.State state = JsonWriter.StateArray[(int) tokenBeingWritten][(int) currentState];
      this._currentState = state != JsonWriter.State.Error ? state : throw JsonWriterException.Create(this, "Token {0} in state {1} would result in an invalid JSON object.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) tokenBeingWritten.ToString(), (object) currentState.ToString()), (Exception) null);
      if (this._formatting == Formatting.Indented)
      {
        switch (currentState)
        {
          case JsonWriter.State.Start:
            break;
          case JsonWriter.State.Property:
            return this.WriteIndentSpaceAsync(cancellationToken);
          case JsonWriter.State.Object:
            if (tokenBeingWritten == JsonToken.PropertyName)
              return this.AutoCompleteAsync(cancellationToken);
            if (tokenBeingWritten != JsonToken.Comment)
              return this.WriteValueDelimiterAsync(cancellationToken);
            break;
          case JsonWriter.State.ArrayStart:
          case JsonWriter.State.ConstructorStart:
            return this.WriteIndentAsync(cancellationToken);
          case JsonWriter.State.Array:
          case JsonWriter.State.Constructor:
            return tokenBeingWritten != JsonToken.Comment ? this.AutoCompleteAsync(cancellationToken) : this.WriteIndentAsync(cancellationToken);
          default:
            if (tokenBeingWritten == JsonToken.PropertyName)
              return this.WriteIndentAsync(cancellationToken);
            break;
        }
      }
      else if (tokenBeingWritten != JsonToken.Comment)
      {
        switch (currentState)
        {
          case JsonWriter.State.Object:
          case JsonWriter.State.Array:
          case JsonWriter.State.Constructor:
            return this.WriteValueDelimiterAsync(cancellationToken);
        }
      }
      return AsyncUtils.CompletedTask;
    }

    private async Task AutoCompleteAsync(CancellationToken cancellationToken)
    {
      ConfiguredTaskAwaitable configuredTaskAwaitable = this.WriteValueDelimiterAsync(cancellationToken).ConfigureAwait(false);
      await configuredTaskAwaitable;
      configuredTaskAwaitable = this.WriteIndentAsync(cancellationToken).ConfigureAwait(false);
      await configuredTaskAwaitable;
    }

    public virtual Task CloseAsync(CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.Close();
      return AsyncUtils.CompletedTask;
    }

    public virtual Task FlushAsync(CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.Flush();
      return AsyncUtils.CompletedTask;
    }

    protected virtual Task WriteEndAsync(JsonToken token, CancellationToken cancellationToken)
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteEnd(token);
      return AsyncUtils.CompletedTask;
    }

    protected virtual Task WriteIndentAsync(CancellationToken cancellationToken)
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteIndent();
      return AsyncUtils.CompletedTask;
    }

    protected virtual Task WriteValueDelimiterAsync(CancellationToken cancellationToken)
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValueDelimiter();
      return AsyncUtils.CompletedTask;
    }

    protected virtual Task WriteIndentSpaceAsync(CancellationToken cancellationToken)
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteIndentSpace();
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteRawAsync(string json, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteRaw(json);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteEndAsync(CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteEnd();
      return AsyncUtils.CompletedTask;
    }

    internal Task WriteEndInternalAsync(CancellationToken cancellationToken)
    {
      JsonContainerType jsonContainerType = this.Peek();
      switch (jsonContainerType)
      {
        case JsonContainerType.Object:
          return this.WriteEndObjectAsync(cancellationToken);
        case JsonContainerType.Array:
          return this.WriteEndArrayAsync(cancellationToken);
        case JsonContainerType.Constructor:
          return this.WriteEndConstructorAsync(cancellationToken);
        default:
          return cancellationToken.IsCancellationRequested ? cancellationToken.FromCanceled() : throw JsonWriterException.Create(this, "Unexpected type when writing end: " + (object) jsonContainerType, (Exception) null);
      }
    }

    internal Task InternalWriteEndAsync(JsonContainerType type, CancellationToken cancellationToken)
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      int levelsToComplete = this.CalculateLevelsToComplete(type);
      while (levelsToComplete-- > 0)
      {
        JsonToken closeTokenForType = this.GetCloseTokenForType(this.Pop());
        if (this._currentState == JsonWriter.State.Property)
        {
          Task task = this.WriteNullAsync(cancellationToken);
          if (!task.IsCompletedSucessfully())
            return AwaitProperty(task, levelsToComplete, closeTokenForType, cancellationToken);
        }
        if (this._formatting == Formatting.Indented && this._currentState != JsonWriter.State.ObjectStart && this._currentState != JsonWriter.State.ArrayStart)
        {
          Task task = this.WriteIndentAsync(cancellationToken);
          if (!task.IsCompletedSucessfully())
            return AwaitIndent(task, levelsToComplete, closeTokenForType, cancellationToken);
        }
        Task task1 = this.WriteEndAsync(closeTokenForType, cancellationToken);
        if (!task1.IsCompletedSucessfully())
          return AwaitEnd(task1, levelsToComplete, cancellationToken);
        this.UpdateCurrentState();
      }
      return AsyncUtils.CompletedTask;

      async Task AwaitProperty(
        Task task,
        int LevelsToComplete,
        JsonToken token,
        CancellationToken CancellationToken)
      {
        ConfiguredTaskAwaitable configuredTaskAwaitable = task.ConfigureAwait(false);
        await configuredTaskAwaitable;
        if (this._formatting == Formatting.Indented && this._currentState != JsonWriter.State.ObjectStart && this._currentState != JsonWriter.State.ArrayStart)
        {
          configuredTaskAwaitable = this.WriteIndentAsync(CancellationToken).ConfigureAwait(false);
          await configuredTaskAwaitable;
        }
        configuredTaskAwaitable = this.WriteEndAsync(token, CancellationToken).ConfigureAwait(false);
        await configuredTaskAwaitable;
        this.UpdateCurrentState();
        configuredTaskAwaitable = AwaitRemaining(LevelsToComplete, CancellationToken).ConfigureAwait(false);
        await configuredTaskAwaitable;
      }

      async Task AwaitIndent(
        Task task,
        int LevelsToComplete,
        JsonToken token,
        CancellationToken CancellationToken)
      {
        ConfiguredTaskAwaitable configuredTaskAwaitable = task.ConfigureAwait(false);
        await configuredTaskAwaitable;
        configuredTaskAwaitable = this.WriteEndAsync(token, CancellationToken).ConfigureAwait(false);
        await configuredTaskAwaitable;
        this.UpdateCurrentState();
        configuredTaskAwaitable = AwaitRemaining(LevelsToComplete, CancellationToken).ConfigureAwait(false);
        await configuredTaskAwaitable;
      }

      async Task AwaitEnd(Task task, int LevelsToComplete, CancellationToken CancellationToken)
      {
        ConfiguredTaskAwaitable configuredTaskAwaitable = task.ConfigureAwait(false);
        await configuredTaskAwaitable;
        this.UpdateCurrentState();
        configuredTaskAwaitable = AwaitRemaining(LevelsToComplete, CancellationToken).ConfigureAwait(false);
        await configuredTaskAwaitable;
      }

      async Task AwaitRemaining(int LevelsToComplete, CancellationToken CancellationToken)
      {
        while (LevelsToComplete-- > 0)
        {
          JsonToken token = this.GetCloseTokenForType(this.Pop());
          ConfiguredTaskAwaitable configuredTaskAwaitable;
          if (this._currentState == JsonWriter.State.Property)
          {
            configuredTaskAwaitable = this.WriteNullAsync(CancellationToken).ConfigureAwait(false);
            await configuredTaskAwaitable;
          }
          if (this._formatting == Formatting.Indented && this._currentState != JsonWriter.State.ObjectStart && this._currentState != JsonWriter.State.ArrayStart)
          {
            configuredTaskAwaitable = this.WriteIndentAsync(CancellationToken).ConfigureAwait(false);
            await configuredTaskAwaitable;
          }
          configuredTaskAwaitable = this.WriteEndAsync(token, CancellationToken).ConfigureAwait(false);
          await configuredTaskAwaitable;
          this.UpdateCurrentState();
        }
      }
    }

    public virtual Task WriteEndArrayAsync(CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteEndArray();
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteEndConstructorAsync(CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteEndConstructor();
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteEndObjectAsync(CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteEndObject();
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteNullAsync(CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteNull();
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WritePropertyNameAsync(string name, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WritePropertyName(name);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WritePropertyNameAsync(
      string name,
      bool escape,
      CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WritePropertyName(name, escape);
      return AsyncUtils.CompletedTask;
    }

    internal Task InternalWritePropertyNameAsync(string name, CancellationToken cancellationToken)
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this._currentPosition.PropertyName = name;
      return this.AutoCompleteAsync(JsonToken.PropertyName, cancellationToken);
    }

    public virtual Task WriteStartArrayAsync(CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteStartArray();
      return AsyncUtils.CompletedTask;
    }

    internal async Task InternalWriteStartAsync(
      JsonToken token,
      JsonContainerType container,
      CancellationToken cancellationToken)
    {
      this.UpdateScopeWithFinishedValue();
      await this.AutoCompleteAsync(token, cancellationToken).ConfigureAwait(false);
      this.Push(container);
    }

    public virtual Task WriteCommentAsync(string text, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteComment(text);
      return AsyncUtils.CompletedTask;
    }

    internal Task InternalWriteCommentAsync(CancellationToken cancellationToken) => this.AutoCompleteAsync(JsonToken.Comment, cancellationToken);

    public virtual Task WriteRawValueAsync(string json, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteRawValue(json);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteStartConstructorAsync(string name, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteStartConstructor(name);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteStartObjectAsync(CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteStartObject();
      return AsyncUtils.CompletedTask;
    }

    public Task WriteTokenAsync(JsonReader reader, CancellationToken cancellationToken = default (CancellationToken)) => this.WriteTokenAsync(reader, true, cancellationToken);

    public Task WriteTokenAsync(
      JsonReader reader,
      bool writeChildren,
      CancellationToken cancellationToken = default (CancellationToken))
    {
      ValidationUtils.ArgumentNotNull((object) reader, nameof (reader));
      return this.WriteTokenAsync(reader, writeChildren, true, true, cancellationToken);
    }

    public Task WriteTokenAsync(JsonToken token, CancellationToken cancellationToken = default (CancellationToken)) => this.WriteTokenAsync(token, (object) null, cancellationToken);

    public Task WriteTokenAsync(JsonToken token, object value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      switch (token)
      {
        case JsonToken.None:
          return AsyncUtils.CompletedTask;
        case JsonToken.StartObject:
          return this.WriteStartObjectAsync(cancellationToken);
        case JsonToken.StartArray:
          return this.WriteStartArrayAsync(cancellationToken);
        case JsonToken.StartConstructor:
          ValidationUtils.ArgumentNotNull(value, nameof (value));
          return this.WriteStartConstructorAsync(value.ToString(), cancellationToken);
        case JsonToken.PropertyName:
          ValidationUtils.ArgumentNotNull(value, nameof (value));
          return this.WritePropertyNameAsync(value.ToString(), cancellationToken);
        case JsonToken.Comment:
          return this.WriteCommentAsync(value?.ToString(), cancellationToken);
        case JsonToken.Raw:
          return this.WriteRawValueAsync(value?.ToString(), cancellationToken);
        case JsonToken.Integer:
          ValidationUtils.ArgumentNotNull(value, nameof (value));
          return this.WriteValueAsync(Convert.ToInt64(value, (IFormatProvider) CultureInfo.InvariantCulture), cancellationToken);
        case JsonToken.Float:
          ValidationUtils.ArgumentNotNull(value, nameof (value));
          if (value is Decimal num1)
            return this.WriteValueAsync(num1, cancellationToken);
          if (value is double num2)
            return this.WriteValueAsync(num2, cancellationToken);
          object obj;
          return (obj = value) is float ? this.WriteValueAsync((float) obj, cancellationToken) : this.WriteValueAsync(Convert.ToDouble(value, (IFormatProvider) CultureInfo.InvariantCulture), cancellationToken);
        case JsonToken.String:
          ValidationUtils.ArgumentNotNull(value, nameof (value));
          return this.WriteValueAsync(value.ToString(), cancellationToken);
        case JsonToken.Boolean:
          ValidationUtils.ArgumentNotNull(value, nameof (value));
          return this.WriteValueAsync(Convert.ToBoolean(value, (IFormatProvider) CultureInfo.InvariantCulture), cancellationToken);
        case JsonToken.Null:
          return this.WriteNullAsync(cancellationToken);
        case JsonToken.Undefined:
          return this.WriteUndefinedAsync(cancellationToken);
        case JsonToken.EndObject:
          return this.WriteEndObjectAsync(cancellationToken);
        case JsonToken.EndArray:
          return this.WriteEndArrayAsync(cancellationToken);
        case JsonToken.EndConstructor:
          return this.WriteEndConstructorAsync(cancellationToken);
        case JsonToken.Date:
          ValidationUtils.ArgumentNotNull(value, nameof (value));
          return value is DateTimeOffset dateTimeOffset ? this.WriteValueAsync(dateTimeOffset, cancellationToken) : this.WriteValueAsync(Convert.ToDateTime(value, (IFormatProvider) CultureInfo.InvariantCulture), cancellationToken);
        case JsonToken.Bytes:
          ValidationUtils.ArgumentNotNull(value, nameof (value));
          return value is Guid guid ? this.WriteValueAsync(guid, cancellationToken) : this.WriteValueAsync((byte[]) value, cancellationToken);
        default:
          throw MiscellaneousUtils.CreateArgumentOutOfRangeException(nameof (token), (object) token, "Unexpected token type.");
      }
    }

    internal virtual async Task WriteTokenAsync(
      JsonReader reader,
      bool writeChildren,
      bool writeDateConstructorAsDate,
      bool writeComments,
      CancellationToken cancellationToken)
    {
      JsonWriter writer = this;
      int initialDepth = writer.CalculateWriteTokenInitialDepth(reader);
      bool flag;
      do
      {
        ConfiguredTaskAwaitable configuredTaskAwaitable;
        if (writeDateConstructorAsDate && reader.TokenType == JsonToken.StartConstructor && string.Equals(reader.Value.ToString(), "Date", StringComparison.Ordinal))
        {
          configuredTaskAwaitable = writer.WriteConstructorDateAsync(reader, cancellationToken).ConfigureAwait(false);
          await configuredTaskAwaitable;
        }
        else if (writeComments || reader.TokenType != JsonToken.Comment)
        {
          configuredTaskAwaitable = writer.WriteTokenAsync(reader.TokenType, reader.Value, cancellationToken).ConfigureAwait(false);
          await configuredTaskAwaitable;
        }
        flag = initialDepth - 1 < reader.Depth - (JsonTokenUtils.IsEndToken(reader.TokenType) ? 1 : 0) & writeChildren;
        if (flag)
          flag = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);
      }
      while (flag);
      if (initialDepth < writer.CalculateWriteTokenFinalDepth(reader))
        throw JsonWriterException.Create(writer, "Unexpected end when reading token.", (Exception) null);
    }

    internal async Task WriteTokenSyncReadingAsync(
      JsonReader reader,
      CancellationToken cancellationToken)
    {
      JsonWriter writer = this;
      int initialDepth = writer.CalculateWriteTokenInitialDepth(reader);
      bool flag;
      do
      {
        if (reader.TokenType == JsonToken.StartConstructor && string.Equals(reader.Value.ToString(), "Date", StringComparison.Ordinal))
          writer.WriteConstructorDate(reader);
        else
          writer.WriteToken(reader.TokenType, reader.Value);
        flag = initialDepth - 1 < reader.Depth - (JsonTokenUtils.IsEndToken(reader.TokenType) ? 1 : 0);
        if (flag)
          flag = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);
      }
      while (flag);
      if (initialDepth < writer.CalculateWriteTokenFinalDepth(reader))
        throw JsonWriterException.Create(writer, "Unexpected end when reading token.", (Exception) null);
    }

    private async Task WriteConstructorDateAsync(
      JsonReader reader,
      CancellationToken cancellationToken)
    {
      JsonWriter writer = this;
      ConfiguredTaskAwaitable<bool> configuredTaskAwaitable = reader.ReadAsync(cancellationToken).ConfigureAwait(false);
      if (!await configuredTaskAwaitable)
        throw JsonWriterException.Create(writer, "Unexpected end when reading date constructor.", (Exception) null);
      DateTime date = reader.TokenType == JsonToken.Integer ? DateTimeUtils.ConvertJavaScriptTicksToDateTime((long) reader.Value) : throw JsonWriterException.Create(writer, "Unexpected token when reading date constructor. Expected Integer, got " + (object) reader.TokenType, (Exception) null);
      configuredTaskAwaitable = reader.ReadAsync(cancellationToken).ConfigureAwait(false);
      if (!await configuredTaskAwaitable)
        throw JsonWriterException.Create(writer, "Unexpected end when reading date constructor.", (Exception) null);
      if (reader.TokenType != JsonToken.EndConstructor)
        throw JsonWriterException.Create(writer, "Unexpected token when reading date constructor. Expected EndConstructor, got " + (object) reader.TokenType, (Exception) null);
      await writer.WriteValueAsync(date, cancellationToken).ConfigureAwait(false);
    }

    public virtual Task WriteValueAsync(bool value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(bool? value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(byte value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(byte? value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(byte[] value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(char value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(char? value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(DateTime value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(DateTime? value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(DateTimeOffset value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(DateTimeOffset? value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(Decimal value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(Decimal? value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(double value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(double? value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(float value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(float? value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(Guid value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(Guid? value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(int value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(int? value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(long value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(long? value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(object value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    [CLSCompliant(false)]
    public virtual Task WriteValueAsync(sbyte value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    [CLSCompliant(false)]
    public virtual Task WriteValueAsync(sbyte? value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(short value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(short? value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(string value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(TimeSpan value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(TimeSpan? value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    [CLSCompliant(false)]
    public virtual Task WriteValueAsync(uint value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    [CLSCompliant(false)]
    public virtual Task WriteValueAsync(uint? value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    [CLSCompliant(false)]
    public virtual Task WriteValueAsync(ulong value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    [CLSCompliant(false)]
    public virtual Task WriteValueAsync(ulong? value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteValueAsync(Uri value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    [CLSCompliant(false)]
    public virtual Task WriteValueAsync(ushort value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    [CLSCompliant(false)]
    public virtual Task WriteValueAsync(ushort? value, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteValue(value);
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteUndefinedAsync(CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteUndefined();
      return AsyncUtils.CompletedTask;
    }

    public virtual Task WriteWhitespaceAsync(string ws, CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.WriteWhitespace(ws);
      return AsyncUtils.CompletedTask;
    }

    internal Task InternalWriteValueAsync(JsonToken token, CancellationToken cancellationToken)
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      this.UpdateScopeWithFinishedValue();
      return this.AutoCompleteAsync(token, cancellationToken);
    }

    protected Task SetWriteStateAsync(
      JsonToken token,
      object value,
      CancellationToken cancellationToken)
    {
      if (cancellationToken.IsCancellationRequested)
        return cancellationToken.FromCanceled();
      switch (token)
      {
        case JsonToken.StartObject:
          return this.InternalWriteStartAsync(token, JsonContainerType.Object, cancellationToken);
        case JsonToken.StartArray:
          return this.InternalWriteStartAsync(token, JsonContainerType.Array, cancellationToken);
        case JsonToken.StartConstructor:
          return this.InternalWriteStartAsync(token, JsonContainerType.Constructor, cancellationToken);
        case JsonToken.PropertyName:
          return value is string name ? this.InternalWritePropertyNameAsync(name, cancellationToken) : throw new ArgumentException("A name is required when setting property name state.", nameof (value));
        case JsonToken.Comment:
          return this.InternalWriteCommentAsync(cancellationToken);
        case JsonToken.Raw:
          return AsyncUtils.CompletedTask;
        case JsonToken.Integer:
        case JsonToken.Float:
        case JsonToken.String:
        case JsonToken.Boolean:
        case JsonToken.Null:
        case JsonToken.Undefined:
        case JsonToken.Date:
        case JsonToken.Bytes:
          return this.InternalWriteValueAsync(token, cancellationToken);
        case JsonToken.EndObject:
          return this.InternalWriteEndAsync(JsonContainerType.Object, cancellationToken);
        case JsonToken.EndArray:
          return this.InternalWriteEndAsync(JsonContainerType.Array, cancellationToken);
        case JsonToken.EndConstructor:
          return this.InternalWriteEndAsync(JsonContainerType.Constructor, cancellationToken);
        default:
          throw new ArgumentOutOfRangeException(nameof (token));
      }
    }

    internal static Task WriteValueAsync(
      JsonWriter writer,
      PrimitiveTypeCode typeCode,
      object value,
      CancellationToken cancellationToken)
    {
      switch (typeCode)
      {
        case PrimitiveTypeCode.Char:
          return writer.WriteValueAsync((char) value, cancellationToken);
        case PrimitiveTypeCode.CharNullable:
          return writer.WriteValueAsync(value == null ? new char?() : new char?((char) value), cancellationToken);
        case PrimitiveTypeCode.Boolean:
          return writer.WriteValueAsync((bool) value, cancellationToken);
        case PrimitiveTypeCode.BooleanNullable:
          return writer.WriteValueAsync(value == null ? new bool?() : new bool?((bool) value), cancellationToken);
        case PrimitiveTypeCode.SByte:
          return writer.WriteValueAsync((sbyte) value, cancellationToken);
        case PrimitiveTypeCode.SByteNullable:
          return writer.WriteValueAsync(value == null ? new sbyte?() : new sbyte?((sbyte) value), cancellationToken);
        case PrimitiveTypeCode.Int16:
          return writer.WriteValueAsync((short) value, cancellationToken);
        case PrimitiveTypeCode.Int16Nullable:
          return writer.WriteValueAsync(value == null ? new short?() : new short?((short) value), cancellationToken);
        case PrimitiveTypeCode.UInt16:
          return writer.WriteValueAsync((ushort) value, cancellationToken);
        case PrimitiveTypeCode.UInt16Nullable:
          return writer.WriteValueAsync(value == null ? new ushort?() : new ushort?((ushort) value), cancellationToken);
        case PrimitiveTypeCode.Int32:
          return writer.WriteValueAsync((int) value, cancellationToken);
        case PrimitiveTypeCode.Int32Nullable:
          return writer.WriteValueAsync(value == null ? new int?() : new int?((int) value), cancellationToken);
        case PrimitiveTypeCode.Byte:
          return writer.WriteValueAsync((byte) value, cancellationToken);
        case PrimitiveTypeCode.ByteNullable:
          return writer.WriteValueAsync(value == null ? new byte?() : new byte?((byte) value), cancellationToken);
        case PrimitiveTypeCode.UInt32:
          return writer.WriteValueAsync((uint) value, cancellationToken);
        case PrimitiveTypeCode.UInt32Nullable:
          return writer.WriteValueAsync(value == null ? new uint?() : new uint?((uint) value), cancellationToken);
        case PrimitiveTypeCode.Int64:
          return writer.WriteValueAsync((long) value, cancellationToken);
        case PrimitiveTypeCode.Int64Nullable:
          return writer.WriteValueAsync(value == null ? new long?() : new long?((long) value), cancellationToken);
        case PrimitiveTypeCode.UInt64:
          return writer.WriteValueAsync((ulong) value, cancellationToken);
        case PrimitiveTypeCode.UInt64Nullable:
          return writer.WriteValueAsync(value == null ? new ulong?() : new ulong?((ulong) value), cancellationToken);
        case PrimitiveTypeCode.Single:
          return writer.WriteValueAsync((float) value, cancellationToken);
        case PrimitiveTypeCode.SingleNullable:
          return writer.WriteValueAsync(value == null ? new float?() : new float?((float) value), cancellationToken);
        case PrimitiveTypeCode.Double:
          return writer.WriteValueAsync((double) value, cancellationToken);
        case PrimitiveTypeCode.DoubleNullable:
          return writer.WriteValueAsync(value == null ? new double?() : new double?((double) value), cancellationToken);
        case PrimitiveTypeCode.DateTime:
          return writer.WriteValueAsync((DateTime) value, cancellationToken);
        case PrimitiveTypeCode.DateTimeNullable:
          return writer.WriteValueAsync(value == null ? new DateTime?() : new DateTime?((DateTime) value), cancellationToken);
        case PrimitiveTypeCode.DateTimeOffset:
          return writer.WriteValueAsync((DateTimeOffset) value, cancellationToken);
        case PrimitiveTypeCode.DateTimeOffsetNullable:
          return writer.WriteValueAsync(value == null ? new DateTimeOffset?() : new DateTimeOffset?((DateTimeOffset) value), cancellationToken);
        case PrimitiveTypeCode.Decimal:
          return writer.WriteValueAsync((Decimal) value, cancellationToken);
        case PrimitiveTypeCode.DecimalNullable:
          return writer.WriteValueAsync(value == null ? new Decimal?() : new Decimal?((Decimal) value), cancellationToken);
        case PrimitiveTypeCode.Guid:
          return writer.WriteValueAsync((Guid) value, cancellationToken);
        case PrimitiveTypeCode.GuidNullable:
          return writer.WriteValueAsync(value == null ? new Guid?() : new Guid?((Guid) value), cancellationToken);
        case PrimitiveTypeCode.TimeSpan:
          return writer.WriteValueAsync((TimeSpan) value, cancellationToken);
        case PrimitiveTypeCode.TimeSpanNullable:
          return writer.WriteValueAsync(value == null ? new TimeSpan?() : new TimeSpan?((TimeSpan) value), cancellationToken);
        case PrimitiveTypeCode.Uri:
          return writer.WriteValueAsync((Uri) value, cancellationToken);
        case PrimitiveTypeCode.String:
          return writer.WriteValueAsync((string) value, cancellationToken);
        case PrimitiveTypeCode.Bytes:
          return writer.WriteValueAsync((byte[]) value, cancellationToken);
        default:
          if (value == null)
            return writer.WriteNullAsync(cancellationToken);
          throw JsonWriter.CreateUnsupportedTypeException(writer, value);
      }
    }

    internal static JsonWriter.State[][] BuildStateArray()
    {
      List<JsonWriter.State[]> list = ((IEnumerable<JsonWriter.State[]>) JsonWriter.StateArrayTempate).ToList<JsonWriter.State[]>();
      JsonWriter.State[] stateArray1 = JsonWriter.StateArrayTempate[0];
      JsonWriter.State[] stateArray2 = JsonWriter.StateArrayTempate[7];
      foreach (ulong num in EnumUtils.GetEnumValuesAndNames(typeof (JsonToken)).Values)
      {
        if (list.Count <= (int) num)
        {
          switch ((JsonToken) num)
          {
            case JsonToken.Integer:
            case JsonToken.Float:
            case JsonToken.String:
            case JsonToken.Boolean:
            case JsonToken.Null:
            case JsonToken.Undefined:
            case JsonToken.Date:
            case JsonToken.Bytes:
              list.Add(stateArray2);
              continue;
            default:
              list.Add(stateArray1);
              continue;
          }
        }
      }
      return list.ToArray();
    }

    static JsonWriter() => JsonWriter.StateArray = JsonWriter.BuildStateArray();

    public bool CloseOutput { get; set; }

    public bool AutoCompleteOnClose { get; set; }

    protected internal int Top
    {
      get
      {
        List<JsonPosition> stack = this._stack;
        int count = stack != null ? __nonvirtual (stack.Count) : 0;
        if (this.Peek() != JsonContainerType.None)
          ++count;
        return count;
      }
    }

    public WriteState WriteState
    {
      get
      {
        switch (this._currentState)
        {
          case JsonWriter.State.Start:
            return WriteState.Start;
          case JsonWriter.State.Property:
            return WriteState.Property;
          case JsonWriter.State.ObjectStart:
          case JsonWriter.State.Object:
            return WriteState.Object;
          case JsonWriter.State.ArrayStart:
          case JsonWriter.State.Array:
            return WriteState.Array;
          case JsonWriter.State.ConstructorStart:
          case JsonWriter.State.Constructor:
            return WriteState.Constructor;
          case JsonWriter.State.Closed:
            return WriteState.Closed;
          case JsonWriter.State.Error:
            return WriteState.Error;
          default:
            throw JsonWriterException.Create(this, "Invalid state: " + (object) this._currentState, (Exception) null);
        }
      }
    }

    internal string ContainerPath => this._currentPosition.Type == JsonContainerType.None || this._stack == null ? string.Empty : JsonPosition.BuildPath(this._stack, new JsonPosition?());

    public string Path => this._currentPosition.Type == JsonContainerType.None ? string.Empty : JsonPosition.BuildPath(this._stack, (this._currentState == JsonWriter.State.ArrayStart || this._currentState == JsonWriter.State.ConstructorStart ? 0 : (this._currentState != JsonWriter.State.ObjectStart ? 1 : 0)) != 0 ? new JsonPosition?(this._currentPosition) : new JsonPosition?());

    public Formatting Formatting
    {
      get => this._formatting;
      set => this._formatting = value >= Formatting.None && value <= Formatting.Indented ? value : throw new ArgumentOutOfRangeException(nameof (value));
    }

    public DateFormatHandling DateFormatHandling
    {
      get => this._dateFormatHandling;
      set => this._dateFormatHandling = value >= DateFormatHandling.IsoDateFormat && value <= DateFormatHandling.MicrosoftDateFormat ? value : throw new ArgumentOutOfRangeException(nameof (value));
    }

    public DateTimeZoneHandling DateTimeZoneHandling
    {
      get => this._dateTimeZoneHandling;
      set => this._dateTimeZoneHandling = value >= DateTimeZoneHandling.Local && value <= DateTimeZoneHandling.RoundtripKind ? value : throw new ArgumentOutOfRangeException(nameof (value));
    }

    public StringEscapeHandling StringEscapeHandling
    {
      get => this._stringEscapeHandling;
      set
      {
        this._stringEscapeHandling = value >= StringEscapeHandling.Default && value <= StringEscapeHandling.EscapeHtml ? value : throw new ArgumentOutOfRangeException(nameof (value));
        this.OnStringEscapeHandlingChanged();
      }
    }

    internal virtual void OnStringEscapeHandlingChanged()
    {
    }

    public FloatFormatHandling FloatFormatHandling
    {
      get => this._floatFormatHandling;
      set => this._floatFormatHandling = value >= FloatFormatHandling.String && value <= FloatFormatHandling.DefaultValue ? value : throw new ArgumentOutOfRangeException(nameof (value));
    }

    public string DateFormatString
    {
      get => this._dateFormatString;
      set => this._dateFormatString = value;
    }

    public CultureInfo Culture
    {
      get => this._culture ?? CultureInfo.InvariantCulture;
      set => this._culture = value;
    }

    protected JsonWriter()
    {
      this._currentState = JsonWriter.State.Start;
      this._formatting = Formatting.None;
      this._dateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind;
      this.CloseOutput = true;
      this.AutoCompleteOnClose = true;
    }

    internal void UpdateScopeWithFinishedValue()
    {
      if (!this._currentPosition.HasIndex)
        return;
      ++this._currentPosition.Position;
    }

    private void Push(JsonContainerType value)
    {
      if (this._currentPosition.Type != JsonContainerType.None)
      {
        if (this._stack == null)
          this._stack = new List<JsonPosition>();
        this._stack.Add(this._currentPosition);
      }
      this._currentPosition = new JsonPosition(value);
    }

    private JsonContainerType Pop()
    {
      JsonPosition currentPosition = this._currentPosition;
      if (this._stack != null && this._stack.Count > 0)
      {
        this._currentPosition = this._stack[this._stack.Count - 1];
        this._stack.RemoveAt(this._stack.Count - 1);
      }
      else
        this._currentPosition = new JsonPosition();
      return currentPosition.Type;
    }

    private JsonContainerType Peek() => this._currentPosition.Type;

    public abstract void Flush();

    public virtual void Close()
    {
      if (!this.AutoCompleteOnClose)
        return;
      this.AutoCompleteAll();
    }

    public virtual void WriteStartObject() => this.InternalWriteStart(JsonToken.StartObject, JsonContainerType.Object);

    public virtual void WriteEndObject() => this.InternalWriteEnd(JsonContainerType.Object);

    public virtual void WriteStartArray() => this.InternalWriteStart(JsonToken.StartArray, JsonContainerType.Array);

    public virtual void WriteEndArray() => this.InternalWriteEnd(JsonContainerType.Array);

    public virtual void WriteStartConstructor(string name) => this.InternalWriteStart(JsonToken.StartConstructor, JsonContainerType.Constructor);

    public virtual void WriteEndConstructor() => this.InternalWriteEnd(JsonContainerType.Constructor);

    public virtual void WritePropertyName(string name) => this.InternalWritePropertyName(name);

    public virtual void WritePropertyName(string name, bool escape) => this.WritePropertyName(name);

    public virtual void WriteEnd() => this.WriteEnd(this.Peek());

    public void WriteToken(JsonReader reader) => this.WriteToken(reader, true);

    public void WriteToken(JsonReader reader, bool writeChildren)
    {
      ValidationUtils.ArgumentNotNull((object) reader, nameof (reader));
      this.WriteToken(reader, writeChildren, true, true);
    }

    public void WriteToken(JsonToken token, object value)
    {
      switch (token)
      {
        case JsonToken.None:
          break;
        case JsonToken.StartObject:
          this.WriteStartObject();
          break;
        case JsonToken.StartArray:
          this.WriteStartArray();
          break;
        case JsonToken.StartConstructor:
          ValidationUtils.ArgumentNotNull(value, nameof (value));
          this.WriteStartConstructor(value.ToString());
          break;
        case JsonToken.PropertyName:
          ValidationUtils.ArgumentNotNull(value, nameof (value));
          this.WritePropertyName(value.ToString());
          break;
        case JsonToken.Comment:
          this.WriteComment(value?.ToString());
          break;
        case JsonToken.Raw:
          this.WriteRawValue(value?.ToString());
          break;
        case JsonToken.Integer:
          ValidationUtils.ArgumentNotNull(value, nameof (value));
          this.WriteValue(Convert.ToInt64(value, (IFormatProvider) CultureInfo.InvariantCulture));
          break;
        case JsonToken.Float:
          ValidationUtils.ArgumentNotNull(value, nameof (value));
          if (value is Decimal num1)
          {
            this.WriteValue(num1);
            break;
          }
          if (value is double num2)
          {
            this.WriteValue(num2);
            break;
          }
          object obj;
          if ((obj = value) is float)
          {
            this.WriteValue((float) obj);
            break;
          }
          this.WriteValue(Convert.ToDouble(value, (IFormatProvider) CultureInfo.InvariantCulture));
          break;
        case JsonToken.String:
          ValidationUtils.ArgumentNotNull(value, nameof (value));
          this.WriteValue(value.ToString());
          break;
        case JsonToken.Boolean:
          ValidationUtils.ArgumentNotNull(value, nameof (value));
          this.WriteValue(Convert.ToBoolean(value, (IFormatProvider) CultureInfo.InvariantCulture));
          break;
        case JsonToken.Null:
          this.WriteNull();
          break;
        case JsonToken.Undefined:
          this.WriteUndefined();
          break;
        case JsonToken.EndObject:
          this.WriteEndObject();
          break;
        case JsonToken.EndArray:
          this.WriteEndArray();
          break;
        case JsonToken.EndConstructor:
          this.WriteEndConstructor();
          break;
        case JsonToken.Date:
          ValidationUtils.ArgumentNotNull(value, nameof (value));
          if (value is DateTimeOffset dateTimeOffset)
          {
            this.WriteValue(dateTimeOffset);
            break;
          }
          this.WriteValue(Convert.ToDateTime(value, (IFormatProvider) CultureInfo.InvariantCulture));
          break;
        case JsonToken.Bytes:
          ValidationUtils.ArgumentNotNull(value, nameof (value));
          if (value is Guid guid)
          {
            this.WriteValue(guid);
            break;
          }
          this.WriteValue((byte[]) value);
          break;
        default:
          throw MiscellaneousUtils.CreateArgumentOutOfRangeException(nameof (token), (object) token, "Unexpected token type.");
      }
    }

    public void WriteToken(JsonToken token) => this.WriteToken(token, (object) null);

    internal virtual void WriteToken(
      JsonReader reader,
      bool writeChildren,
      bool writeDateConstructorAsDate,
      bool writeComments)
    {
      int tokenInitialDepth = this.CalculateWriteTokenInitialDepth(reader);
      do
      {
        if (writeDateConstructorAsDate && reader.TokenType == JsonToken.StartConstructor && string.Equals(reader.Value.ToString(), "Date", StringComparison.Ordinal))
          this.WriteConstructorDate(reader);
        else if (writeComments || reader.TokenType != JsonToken.Comment)
          this.WriteToken(reader.TokenType, reader.Value);
      }
      while (tokenInitialDepth - 1 < reader.Depth - (JsonTokenUtils.IsEndToken(reader.TokenType) ? 1 : 0) & writeChildren && reader.Read());
      if (tokenInitialDepth < this.CalculateWriteTokenFinalDepth(reader))
        throw JsonWriterException.Create(this, "Unexpected end when reading token.", (Exception) null);
    }

    private int CalculateWriteTokenInitialDepth(JsonReader reader)
    {
      JsonToken tokenType = reader.TokenType;
      if (tokenType == JsonToken.None)
        return -1;
      return !JsonTokenUtils.IsStartToken(tokenType) ? reader.Depth + 1 : reader.Depth;
    }

    private int CalculateWriteTokenFinalDepth(JsonReader reader)
    {
      JsonToken tokenType = reader.TokenType;
      if (tokenType == JsonToken.None)
        return -1;
      return !JsonTokenUtils.IsEndToken(tokenType) ? reader.Depth : reader.Depth - 1;
    }

    private void WriteConstructorDate(JsonReader reader)
    {
      DateTime dateTime;
      string errorMessage;
      if (!JavaScriptUtils.TryGetDateFromConstructorJson(reader, out dateTime, out errorMessage))
        throw JsonWriterException.Create(this, errorMessage, (Exception) null);
      this.WriteValue(dateTime);
    }

    private void WriteEnd(JsonContainerType type)
    {
      switch (type)
      {
        case JsonContainerType.Object:
          this.WriteEndObject();
          break;
        case JsonContainerType.Array:
          this.WriteEndArray();
          break;
        case JsonContainerType.Constructor:
          this.WriteEndConstructor();
          break;
        default:
          throw JsonWriterException.Create(this, "Unexpected type when writing end: " + (object) type, (Exception) null);
      }
    }

    private void AutoCompleteAll()
    {
      while (this.Top > 0)
        this.WriteEnd();
    }

    private JsonToken GetCloseTokenForType(JsonContainerType type)
    {
      switch (type)
      {
        case JsonContainerType.Object:
          return JsonToken.EndObject;
        case JsonContainerType.Array:
          return JsonToken.EndArray;
        case JsonContainerType.Constructor:
          return JsonToken.EndConstructor;
        default:
          throw JsonWriterException.Create(this, "No close token for type: " + (object) type, (Exception) null);
      }
    }

    private void AutoCompleteClose(JsonContainerType type)
    {
      int levelsToComplete = this.CalculateLevelsToComplete(type);
      for (int index = 0; index < levelsToComplete; ++index)
      {
        JsonToken closeTokenForType = this.GetCloseTokenForType(this.Pop());
        if (this._currentState == JsonWriter.State.Property)
          this.WriteNull();
        if (this._formatting == Formatting.Indented && this._currentState != JsonWriter.State.ObjectStart && this._currentState != JsonWriter.State.ArrayStart)
          this.WriteIndent();
        this.WriteEnd(closeTokenForType);
        this.UpdateCurrentState();
      }
    }

    private int CalculateLevelsToComplete(JsonContainerType type)
    {
      int num1 = 0;
      if (this._currentPosition.Type == type)
      {
        num1 = 1;
      }
      else
      {
        int num2 = this.Top - 2;
        for (int index = num2; index >= 0; --index)
        {
          if (this._stack[num2 - index].Type == type)
          {
            num1 = index + 2;
            break;
          }
        }
      }
      return num1 != 0 ? num1 : throw JsonWriterException.Create(this, "No token to close.", (Exception) null);
    }

    private void UpdateCurrentState()
    {
      JsonContainerType jsonContainerType = this.Peek();
      switch (jsonContainerType)
      {
        case JsonContainerType.None:
          this._currentState = JsonWriter.State.Start;
          break;
        case JsonContainerType.Object:
          this._currentState = JsonWriter.State.Object;
          break;
        case JsonContainerType.Array:
          this._currentState = JsonWriter.State.Array;
          break;
        case JsonContainerType.Constructor:
          this._currentState = JsonWriter.State.Array;
          break;
        default:
          throw JsonWriterException.Create(this, "Unknown JsonType: " + (object) jsonContainerType, (Exception) null);
      }
    }

    protected virtual void WriteEnd(JsonToken token)
    {
    }

    protected virtual void WriteIndent()
    {
    }

    protected virtual void WriteValueDelimiter()
    {
    }

    protected virtual void WriteIndentSpace()
    {
    }

    internal void AutoComplete(JsonToken tokenBeingWritten)
    {
      JsonWriter.State state = JsonWriter.StateArray[(int) tokenBeingWritten][(int) this._currentState];
      if (state == JsonWriter.State.Error)
        throw JsonWriterException.Create(this, "Token {0} in state {1} would result in an invalid JSON object.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) tokenBeingWritten.ToString(), (object) this._currentState.ToString()), (Exception) null);
      if ((this._currentState == JsonWriter.State.Object || this._currentState == JsonWriter.State.Array || this._currentState == JsonWriter.State.Constructor) && tokenBeingWritten != JsonToken.Comment)
        this.WriteValueDelimiter();
      if (this._formatting == Formatting.Indented)
      {
        if (this._currentState == JsonWriter.State.Property)
          this.WriteIndentSpace();
        if (this._currentState == JsonWriter.State.Array || this._currentState == JsonWriter.State.ArrayStart || this._currentState == JsonWriter.State.Constructor || this._currentState == JsonWriter.State.ConstructorStart || tokenBeingWritten == JsonToken.PropertyName && this._currentState != JsonWriter.State.Start)
          this.WriteIndent();
      }
      this._currentState = state;
    }

    public virtual void WriteNull() => this.InternalWriteValue(JsonToken.Null);

    public virtual void WriteUndefined() => this.InternalWriteValue(JsonToken.Undefined);

    public virtual void WriteRaw(string json) => this.InternalWriteRaw();

    public virtual void WriteRawValue(string json)
    {
      this.UpdateScopeWithFinishedValue();
      this.AutoComplete(JsonToken.Undefined);
      this.WriteRaw(json);
    }

    public virtual void WriteValue(string value) => this.InternalWriteValue(JsonToken.String);

    public virtual void WriteValue(int value) => this.InternalWriteValue(JsonToken.Integer);

    [CLSCompliant(false)]
    public virtual void WriteValue(uint value) => this.InternalWriteValue(JsonToken.Integer);

    public virtual void WriteValue(long value) => this.InternalWriteValue(JsonToken.Integer);

    [CLSCompliant(false)]
    public virtual void WriteValue(ulong value) => this.InternalWriteValue(JsonToken.Integer);

    public virtual void WriteValue(float value) => this.InternalWriteValue(JsonToken.Float);

    public virtual void WriteValue(double value) => this.InternalWriteValue(JsonToken.Float);

    public virtual void WriteValue(bool value) => this.InternalWriteValue(JsonToken.Boolean);

    public virtual void WriteValue(short value) => this.InternalWriteValue(JsonToken.Integer);

    [CLSCompliant(false)]
    public virtual void WriteValue(ushort value) => this.InternalWriteValue(JsonToken.Integer);

    public virtual void WriteValue(char value) => this.InternalWriteValue(JsonToken.String);

    public virtual void WriteValue(byte value) => this.InternalWriteValue(JsonToken.Integer);

    [CLSCompliant(false)]
    public virtual void WriteValue(sbyte value) => this.InternalWriteValue(JsonToken.Integer);

    public virtual void WriteValue(Decimal value) => this.InternalWriteValue(JsonToken.Float);

    public virtual void WriteValue(DateTime value) => this.InternalWriteValue(JsonToken.Date);

    public virtual void WriteValue(DateTimeOffset value) => this.InternalWriteValue(JsonToken.Date);

    public virtual void WriteValue(Guid value) => this.InternalWriteValue(JsonToken.String);

    public virtual void WriteValue(TimeSpan value) => this.InternalWriteValue(JsonToken.String);

    public virtual void WriteValue(int? value)
    {
      if (!value.HasValue)
        this.WriteNull();
      else
        this.WriteValue(value.GetValueOrDefault());
    }

    [CLSCompliant(false)]
    public virtual void WriteValue(uint? value)
    {
      if (!value.HasValue)
        this.WriteNull();
      else
        this.WriteValue(value.GetValueOrDefault());
    }

    public virtual void WriteValue(long? value)
    {
      if (!value.HasValue)
        this.WriteNull();
      else
        this.WriteValue(value.GetValueOrDefault());
    }

    [CLSCompliant(false)]
    public virtual void WriteValue(ulong? value)
    {
      if (!value.HasValue)
        this.WriteNull();
      else
        this.WriteValue(value.GetValueOrDefault());
    }

    public virtual void WriteValue(float? value)
    {
      if (!value.HasValue)
        this.WriteNull();
      else
        this.WriteValue(value.GetValueOrDefault());
    }

    public virtual void WriteValue(double? value)
    {
      if (!value.HasValue)
        this.WriteNull();
      else
        this.WriteValue(value.GetValueOrDefault());
    }

    public virtual void WriteValue(bool? value)
    {
      if (!value.HasValue)
        this.WriteNull();
      else
        this.WriteValue(value.GetValueOrDefault());
    }

    public virtual void WriteValue(short? value)
    {
      if (!value.HasValue)
        this.WriteNull();
      else
        this.WriteValue(value.GetValueOrDefault());
    }

    [CLSCompliant(false)]
    public virtual void WriteValue(ushort? value)
    {
      if (!value.HasValue)
        this.WriteNull();
      else
        this.WriteValue(value.GetValueOrDefault());
    }

    public virtual void WriteValue(char? value)
    {
      if (!value.HasValue)
        this.WriteNull();
      else
        this.WriteValue(value.GetValueOrDefault());
    }

    public virtual void WriteValue(byte? value)
    {
      if (!value.HasValue)
        this.WriteNull();
      else
        this.WriteValue(value.GetValueOrDefault());
    }

    [CLSCompliant(false)]
    public virtual void WriteValue(sbyte? value)
    {
      if (!value.HasValue)
        this.WriteNull();
      else
        this.WriteValue(value.GetValueOrDefault());
    }

    public virtual void WriteValue(Decimal? value)
    {
      if (!value.HasValue)
        this.WriteNull();
      else
        this.WriteValue(value.GetValueOrDefault());
    }

    public virtual void WriteValue(DateTime? value)
    {
      if (!value.HasValue)
        this.WriteNull();
      else
        this.WriteValue(value.GetValueOrDefault());
    }

    public virtual void WriteValue(DateTimeOffset? value)
    {
      if (!value.HasValue)
        this.WriteNull();
      else
        this.WriteValue(value.GetValueOrDefault());
    }

    public virtual void WriteValue(Guid? value)
    {
      if (!value.HasValue)
        this.WriteNull();
      else
        this.WriteValue(value.GetValueOrDefault());
    }

    public virtual void WriteValue(TimeSpan? value)
    {
      if (!value.HasValue)
        this.WriteNull();
      else
        this.WriteValue(value.GetValueOrDefault());
    }

    public virtual void WriteValue(byte[] value)
    {
      if (value == null)
        this.WriteNull();
      else
        this.InternalWriteValue(JsonToken.Bytes);
    }

    public virtual void WriteValue(Uri value)
    {
      if (value == (Uri) null)
        this.WriteNull();
      else
        this.InternalWriteValue(JsonToken.String);
    }

    public virtual void WriteValue(object value)
    {
      if (value == null)
        this.WriteNull();
      else
        JsonWriter.WriteValue(this, ConvertUtils.GetTypeCode(value.GetType()), value);
    }

    public virtual void WriteComment(string text) => this.InternalWriteComment();

    public virtual void WriteWhitespace(string ws) => this.InternalWriteWhitespace(ws);

    void IDisposable.Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!(this._currentState != JsonWriter.State.Closed & disposing))
        return;
      this.Close();
    }

    internal static void WriteValue(JsonWriter writer, PrimitiveTypeCode typeCode, object value)
    {
      switch (typeCode)
      {
        case PrimitiveTypeCode.Char:
          writer.WriteValue((char) value);
          break;
        case PrimitiveTypeCode.CharNullable:
          writer.WriteValue(value == null ? new char?() : new char?((char) value));
          break;
        case PrimitiveTypeCode.Boolean:
          writer.WriteValue((bool) value);
          break;
        case PrimitiveTypeCode.BooleanNullable:
          writer.WriteValue(value == null ? new bool?() : new bool?((bool) value));
          break;
        case PrimitiveTypeCode.SByte:
          writer.WriteValue((sbyte) value);
          break;
        case PrimitiveTypeCode.SByteNullable:
          writer.WriteValue(value == null ? new sbyte?() : new sbyte?((sbyte) value));
          break;
        case PrimitiveTypeCode.Int16:
          writer.WriteValue((short) value);
          break;
        case PrimitiveTypeCode.Int16Nullable:
          writer.WriteValue(value == null ? new short?() : new short?((short) value));
          break;
        case PrimitiveTypeCode.UInt16:
          writer.WriteValue((ushort) value);
          break;
        case PrimitiveTypeCode.UInt16Nullable:
          writer.WriteValue(value == null ? new ushort?() : new ushort?((ushort) value));
          break;
        case PrimitiveTypeCode.Int32:
          writer.WriteValue((int) value);
          break;
        case PrimitiveTypeCode.Int32Nullable:
          writer.WriteValue(value == null ? new int?() : new int?((int) value));
          break;
        case PrimitiveTypeCode.Byte:
          writer.WriteValue((byte) value);
          break;
        case PrimitiveTypeCode.ByteNullable:
          writer.WriteValue(value == null ? new byte?() : new byte?((byte) value));
          break;
        case PrimitiveTypeCode.UInt32:
          writer.WriteValue((uint) value);
          break;
        case PrimitiveTypeCode.UInt32Nullable:
          writer.WriteValue(value == null ? new uint?() : new uint?((uint) value));
          break;
        case PrimitiveTypeCode.Int64:
          writer.WriteValue((long) value);
          break;
        case PrimitiveTypeCode.Int64Nullable:
          writer.WriteValue(value == null ? new long?() : new long?((long) value));
          break;
        case PrimitiveTypeCode.UInt64:
          writer.WriteValue((ulong) value);
          break;
        case PrimitiveTypeCode.UInt64Nullable:
          writer.WriteValue(value == null ? new ulong?() : new ulong?((ulong) value));
          break;
        case PrimitiveTypeCode.Single:
          writer.WriteValue((float) value);
          break;
        case PrimitiveTypeCode.SingleNullable:
          writer.WriteValue(value == null ? new float?() : new float?((float) value));
          break;
        case PrimitiveTypeCode.Double:
          writer.WriteValue((double) value);
          break;
        case PrimitiveTypeCode.DoubleNullable:
          writer.WriteValue(value == null ? new double?() : new double?((double) value));
          break;
        case PrimitiveTypeCode.DateTime:
          writer.WriteValue((DateTime) value);
          break;
        case PrimitiveTypeCode.DateTimeNullable:
          writer.WriteValue(value == null ? new DateTime?() : new DateTime?((DateTime) value));
          break;
        case PrimitiveTypeCode.DateTimeOffset:
          writer.WriteValue((DateTimeOffset) value);
          break;
        case PrimitiveTypeCode.DateTimeOffsetNullable:
          writer.WriteValue(value == null ? new DateTimeOffset?() : new DateTimeOffset?((DateTimeOffset) value));
          break;
        case PrimitiveTypeCode.Decimal:
          writer.WriteValue((Decimal) value);
          break;
        case PrimitiveTypeCode.DecimalNullable:
          writer.WriteValue(value == null ? new Decimal?() : new Decimal?((Decimal) value));
          break;
        case PrimitiveTypeCode.Guid:
          writer.WriteValue((Guid) value);
          break;
        case PrimitiveTypeCode.GuidNullable:
          writer.WriteValue(value == null ? new Guid?() : new Guid?((Guid) value));
          break;
        case PrimitiveTypeCode.TimeSpan:
          writer.WriteValue((TimeSpan) value);
          break;
        case PrimitiveTypeCode.TimeSpanNullable:
          writer.WriteValue(value == null ? new TimeSpan?() : new TimeSpan?((TimeSpan) value));
          break;
        case PrimitiveTypeCode.Uri:
          writer.WriteValue((Uri) value);
          break;
        case PrimitiveTypeCode.String:
          writer.WriteValue((string) value);
          break;
        case PrimitiveTypeCode.Bytes:
          writer.WriteValue((byte[]) value);
          break;
        default:
          if (value != null)
            throw JsonWriter.CreateUnsupportedTypeException(writer, value);
          writer.WriteNull();
          break;
      }
    }

    private static JsonWriterException CreateUnsupportedTypeException(
      JsonWriter writer,
      object value)
    {
      return JsonWriterException.Create(writer, "Unsupported type: {0}. Use the JsonSerializer class to get the object's JSON representation.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) value.GetType()), (Exception) null);
    }

    protected void SetWriteState(JsonToken token, object value)
    {
      switch (token)
      {
        case JsonToken.StartObject:
          this.InternalWriteStart(token, JsonContainerType.Object);
          break;
        case JsonToken.StartArray:
          this.InternalWriteStart(token, JsonContainerType.Array);
          break;
        case JsonToken.StartConstructor:
          this.InternalWriteStart(token, JsonContainerType.Constructor);
          break;
        case JsonToken.PropertyName:
          if (!(value is string name))
            throw new ArgumentException("A name is required when setting property name state.", nameof (value));
          this.InternalWritePropertyName(name);
          break;
        case JsonToken.Comment:
          this.InternalWriteComment();
          break;
        case JsonToken.Raw:
          this.InternalWriteRaw();
          break;
        case JsonToken.Integer:
        case JsonToken.Float:
        case JsonToken.String:
        case JsonToken.Boolean:
        case JsonToken.Null:
        case JsonToken.Undefined:
        case JsonToken.Date:
        case JsonToken.Bytes:
          this.InternalWriteValue(token);
          break;
        case JsonToken.EndObject:
          this.InternalWriteEnd(JsonContainerType.Object);
          break;
        case JsonToken.EndArray:
          this.InternalWriteEnd(JsonContainerType.Array);
          break;
        case JsonToken.EndConstructor:
          this.InternalWriteEnd(JsonContainerType.Constructor);
          break;
        default:
          throw new ArgumentOutOfRangeException(nameof (token));
      }
    }

    internal void InternalWriteEnd(JsonContainerType container) => this.AutoCompleteClose(container);

    internal void InternalWritePropertyName(string name)
    {
      this._currentPosition.PropertyName = name;
      this.AutoComplete(JsonToken.PropertyName);
    }

    internal void InternalWriteRaw()
    {
    }

    internal void InternalWriteStart(JsonToken token, JsonContainerType container)
    {
      this.UpdateScopeWithFinishedValue();
      this.AutoComplete(token);
      this.Push(container);
    }

    internal void InternalWriteValue(JsonToken token)
    {
      this.UpdateScopeWithFinishedValue();
      this.AutoComplete(token);
    }

    internal void InternalWriteWhitespace(string ws)
    {
      if (ws != null && !StringUtils.IsWhiteSpace(ws))
        throw JsonWriterException.Create(this, "Only white space characters should be used.", (Exception) null);
    }

    internal void InternalWriteComment() => this.AutoComplete(JsonToken.Comment);

    internal enum State
    {
      Start,
      Property,
      ObjectStart,
      Object,
      ArrayStart,
      Array,
      ConstructorStart,
      Constructor,
      Closed,
      Error,
    }
  }
}
