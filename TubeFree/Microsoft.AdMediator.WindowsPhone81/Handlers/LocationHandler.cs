// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.WindowsPhone81.Handlers.LocationHandler
// Assembly: Microsoft.AdMediator.WindowsPhone81, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1C586D37-9142-43D0-8912-08FBC7AC3DDA
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.WindowsPhone81.dll

using Microsoft.AdMediator.Core.Handlers;
using Microsoft.AdMediator.Core.Models;
using System;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace Microsoft.AdMediator.WindowsPhone81.Handlers
{
  internal class LocationHandler : ILocationHandler
  {
    private readonly Geolocator locator;
    private readonly TimeSpan maxAgeTimeSpan = TimeSpan.FromHours(6.0);
    private readonly TimeSpan timeOut = TimeSpan.FromSeconds(30.0);

    public LocationHandler()
    {
      this.locator = new Geolocator();
      this.locator.put_DesiredAccuracy((PositionAccuracy) 0);
    }

    public async Task<Location> GetLocationAsync()
    {
      if (this.locator.LocationStatus == 3 || this.locator.LocationStatus == 5 || this.locator.LocationStatus == 2)
        return (Location) null;
      Geoposition geopositionAsync = await this.locator.GetGeopositionAsync(this.maxAgeTimeSpan, this.timeOut);
      return new Location()
      {
        Latitude = geopositionAsync.Coordinate.Point.Position.Latitude,
        Longitude = geopositionAsync.Coordinate.Point.Position.Longitude,
        Geoposition = (object) geopositionAsync
      };
    }
  }
}
