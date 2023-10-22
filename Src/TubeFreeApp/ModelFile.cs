// Decompiled with JetBrains decompiler
// Type: TubeFreeApp.ModelFile
// Assembly: TubeFree8-1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B4DCF786-D976-4451-B6A4-B664A1A9ABDC
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\TubeFree8-1.exe

using Windows.UI.Xaml.Media;

namespace TubeFreeApp
{
  public class ModelFile
  {
    private string _nome;
    private string _durata;
    private string _bitRate;
    private string _size;
    private string _immagine;
    private ImageSource _immagineSource;

    public string Nome
    {
      get => this._nome;
      set => this._nome = value;
    }

    public string Durata
    {
      get => this._durata;
      set => this._durata = value;
    }

    public string BitRate
    {
      get => this._bitRate;
      set => this._bitRate = value;
    }

    public string Size
    {
      get => this._size;
      set
      {
        if (!value.Contains("MB"))
          this._size = value + " MB";
        else
          this._size = value;
      }
    }

    public string Immagine
    {
      get => this._immagine;
      set => this._immagine = value;
    }

    public ImageSource ImmagineSource
    {
      get => this._immagineSource;
      set => this._immagineSource = value;
    }

    public ModelFile(string nom, string durata, string bitR)
    {
      this._nome = "";
      this._durata = "";
      this._bitRate = "";
      this._size = "";
      this.Nome = nom;
      this.BitRate = bitR;
    }

    public ModelFile()
    {
      this._nome = "";
      this._durata = "";
      this._bitRate = "";
      this._size = "";
    }
  }
}
