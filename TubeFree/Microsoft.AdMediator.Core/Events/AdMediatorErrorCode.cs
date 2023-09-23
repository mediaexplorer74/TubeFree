// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Events.AdMediatorErrorCode
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

namespace Microsoft.AdMediator.Core.Events
{
  public enum AdMediatorErrorCode
  {
    Unknown,
    NoAdAvailable,
    NetworkFailure,
    ClientConfiguration,
    ServerSideError,
    InvalidServerResponse,
    RefreshNotAllowed,
    Success,
    InvalidRequest,
    StaleInterstitial,
    Canceled,
    ClickInProgress,
    DownloadInProgress,
    PhoneDialerError,
    DeviceIdentityError,
    DeviceCapabilityError,
    MissingParameters,
    InvalidUserId,
    UnknownPublisherId,
    AdSdkTimeout,
    AdAdapterError,
    AdSdkConfigurationError,
    AdSdkError,
    ConfigurationError,
    AdMediatorNotStarted,
    AdMediatorNotLoaded,
    InvalidId,
    TooManyAdsOnScreen,
    Unauthorized,
    InvalidAdArea,
    InvalidOs,
    InternalError,
    CreativeError,
    MraidOperationFailure,
    FileOperationFailure,
    ParseToBOMFailure,
    ValidationFailure,
  }
}
