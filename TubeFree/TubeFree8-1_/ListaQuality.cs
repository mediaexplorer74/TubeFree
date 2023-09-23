// Decompiled with JetBrains decompiler
// Type: TubeFree8_1.ListaQuality
// Assembly: TubeFree8-1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B4DCF786-D976-4451-B6A4-B664A1A9ABDC
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\TubeFree8-1.exe

using System.Collections.ObjectModel;

namespace TubeFree8_1
{
  public class ListaQuality
  {
    private ObservableCollection<ModelQuality> _listaQ;

    public ListaQuality() => this._listaQ = new ObservableCollection<ModelQuality>();

    public ObservableCollection<ModelQuality> ListaQ
    {
      get => this._listaQ;
      set => this._listaQ = value;
    }
  }
}
