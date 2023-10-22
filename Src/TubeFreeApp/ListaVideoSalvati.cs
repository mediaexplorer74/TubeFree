// Decompiled with JetBrains decompiler
// Type: TubeFreeApp.ListaVideoSalvati
// Assembly: TubeFree8-1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B4DCF786-D976-4451-B6A4-B664A1A9ABDC
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\TubeFree8-1.exe

using System.Collections.ObjectModel;

namespace TubeFreeApp
{
  public class ListaVideoSalvati
  {
    private ObservableCollection<ModelVideoSalvato> _listaVideoSalvati;

    public ObservableCollection<ModelVideoSalvato> ListaVideoSalvati
    {
      get => this._listaVideoSalvati;
      set => this._listaVideoSalvati = value;
    }

    public ListaVideoSalvati() => this._listaVideoSalvati = new ObservableCollection<ModelVideoSalvato>();
  }
}
