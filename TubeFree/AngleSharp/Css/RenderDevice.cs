// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.RenderDevice
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

namespace AngleSharp.Css
{
  public class RenderDevice
  {
    public RenderDevice(int width, int height)
    {
      this.DeviceWidth = width;
      this.DeviceHeight = height;
      this.ViewPortWidth = width;
      this.ViewPortHeight = height;
      this.ColorBits = 32;
      this.MonochromeBits = 0;
      this.Resolution = 96;
      this.DeviceType = RenderDevice.Kind.Screen;
      this.IsInterlaced = false;
      this.IsGrid = false;
      this.Frequency = 60;
    }

    public IConfiguration Options { get; set; }

    public int ViewPortWidth { get; set; }

    public int ViewPortHeight { get; set; }

    public bool IsInterlaced { get; set; }

    public bool IsGrid { get; set; }

    public int DeviceWidth { get; private set; }

    public int DeviceHeight { get; private set; }

    public int Resolution { get; set; }

    public int Frequency { get; set; }

    public int ColorBits { get; set; }

    public int MonochromeBits { get; set; }

    public RenderDevice.Kind DeviceType { get; set; }

    public enum Kind : byte
    {
      Screen,
      Printer,
      Speech,
      Other,
    }
  }
}
