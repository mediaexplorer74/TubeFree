// Decompiled with JetBrains decompiler
// Type: TubeFreeApp.ModelVideoSalvato
// Assembly: TubeFree8-1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B4DCF786-D976-4451-B6A4-B664A1A9ABDC
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\TubeFree8-1.exe

using Windows.UI.Xaml.Media;

namespace TubeFreeApp
{
  public class ModelVideoSalvato
  {
    private string _title;
    private string _author;
    private string _size;
    private ImageSource _immagineSource;
    private string _immagine;

    public string Title
    {
      get => this._title;
      set => this._title = value;
    }

    public string Author
    {
      get => this._author;
      set => this._author = value;
    }

    public string Size
    {
      get => this._size;
      set => this._size = value + "MB";
    }

    public ImageSource ImmagineSource
    {
      get => this._immagineSource;
      set => this._immagineSource = value;
    }

    public string Immagine
    {
      get => this._immagine;
      set => this._immagine = value;
    }
  }
}
