using System.Collections.ObjectModel;

namespace TubeFreeApp
{
  public class ListaVideoSalvati
  {
    private ObservableCollection<ModelVideoSalvato> _listaVideoSalvati;

    public ObservableCollection<ModelVideoSalvato> listaVideoSalvati
    {
      get => this._listaVideoSalvati;
      set => this._listaVideoSalvati = value;
    }

    public ListaVideoSalvati()
    {
        this._listaVideoSalvati = new ObservableCollection<ModelVideoSalvato>();
    }
  }
}
