using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.Web.Http;
using Windows.Web.Http.Headers;
using Buffer = Windows.Storage.Streams.Buffer;

namespace TubeFreeApp
{
  public class CoreDownload : INotifyPropertyChanged
  {
    private string _Url;
    private string _Nome;
    private string _titolo;
    private string _author;
    private int _LunghezzaFileSalvato;
    private int _LunghezzaTotale;
    private bool _Esiste;
    private bool _Terminato;
    private string _textBlockNome;
    private string _textBlockPercentuale;
    private string _textBlockStato;
    private string _textBlockStatic;
    private string _textBlockTotal;
    private double _percentuale;
    private string _immagine;
    private string _music;
    private string _videoId;
    private CoreDownload.Tipo _tipoFile;
    private HttpResponseMessage response;
    private StorageFolder storageFolder;
    private StorageFile imgFil;
    private FileRandomAccessStream fs;
    private IInputStream inputStream;

    public event CoreDownload.FinitoEventHandler Finito;

    public string Url
    {
      get => this._Url;
      set => this._Url = value;
    }

    public string Nome
    {
      get => this._Nome;
      set
      {
        string str = new string(Path.GetInvalidFileNameChars())
                    + new string(Path.GetInvalidPathChars());
        int index = 0;
        while (index < str.Length)
        {
          char ch = str[index];
          if (Operators.CompareString(Conversions.ToString(ch), ":", false) == 0
                        | Operators.CompareString(Conversions.ToString(ch), "!", false) == 0)
            value = value.Replace(Conversions.ToString(ch), " ");
          value = value.Replace(Conversions.ToString(ch), "");
          checked { ++index; }
        }
        this._Nome = value;
      }
    }

    public string Titolo
    {
      get => this._titolo;
      set
      {
        string str = new string(Path.GetInvalidFileNameChars()) 
                    + new string(Path.GetInvalidPathChars());
        int index = 0;
        while (index < str.Length)
        {
            char ch = str[index];

            if (Operators.CompareString(Conversions.ToString(ch), ":", false) == 0
                            | Operators.CompareString(Conversions.ToString(ch), "!", false) == 0)
            {
                value = value.Replace(Conversions.ToString(ch), " ");
            }

            value = value.Replace(Conversions.ToString(ch), "");
            checked { ++index; }
        }

        this._titolo = value;
      }
    }

    public string Author
    {
      get => this._author;
      set => this._author = value;
    }

    public int LunghezzaFileSalvato
    {
      get => this._LunghezzaFileSalvato;
      set => this._LunghezzaFileSalvato = value;
    }

    public int LunghezzaTotale
    {
      get => this._LunghezzaTotale;
      set => this._LunghezzaTotale = value;
    }

    public bool Esiste
    {
      get => this._Esiste;
      set => this._Esiste = value;
    }

    public bool Terminato
    {
      get => this._Terminato;
      set => this._Terminato = value;
    }

    public string TextBlockNome
    {
      get => this._textBlockNome;
      set => this._textBlockNome = value;
    }

    public string TextBlockPercentuale
    {
      get => this._textBlockPercentuale;
      set => this._textBlockPercentuale = value;
    }

    public string TextBlockStato
    {
      get => this._textBlockStato;
      set
      {
        this._textBlockStato = value;
        PropertyChangedEventHandler propertyChangedEvent = this.PropertyChangedEvent;
        if (propertyChangedEvent == null)
          return;
        propertyChangedEvent((object) this, new PropertyChangedEventArgs(nameof (TextBlockStato)));
      }
    }

    public string TextBlockStatic
    {
      get => this._textBlockStatic;
      set => this._textBlockStatic = value;
    }

    public string TextBlockTotal
    {
      get => this._textBlockTotal;
      set
      {
        this._textBlockTotal = value;
        PropertyChangedEventHandler propertyChangedEvent = this.PropertyChangedEvent;
        if (propertyChangedEvent == null)
          return;
        propertyChangedEvent((object) this, new PropertyChangedEventArgs(nameof (TextBlockTotal)));
      }
    }

    public double Percentuale
    {
      get => this._percentuale;
      set
      {
        this._percentuale = value;
        PropertyChangedEventHandler propertyChangedEvent = this.PropertyChangedEvent;
        if (propertyChangedEvent == null)
          return;
        propertyChangedEvent((object) this, new PropertyChangedEventArgs(nameof (Percentuale)));
      }
    }

    public string Immagine
    {
      get => this._immagine;
      set => this._immagine = value;
    }

    public string Music
    {
      get => this._music;
      set => this._music = value;
    }

    public string VideoId
    {
      get => this._videoId;
      set => this._videoId = value;
    }

    public CoreDownload.Tipo TipoFile
    {
      get => this._tipoFile;
      set => this._tipoFile = value;
    }

    public virtual DispatcherTimer timer
    {
      get => this._timer;
      [MethodImpl((MethodImplOptions) 32)] set
      {
        EventHandler<object> eventHandler = new EventHandler<object>(this.timer_Tick);
        DispatcherTimer timer1 = this._timer;
        if (timer1 != null)
          WindowsRuntimeMarshal.RemoveEventHandler<EventHandler<object>>(new Action<EventRegistrationToken>(timer1.remove_Tick), eventHandler);
        this._timer = value;
        DispatcherTimer timer2 = this._timer;
        if (timer2 == null)
          return;
        WindowsRuntimeMarshal.AddEventHandler<EventHandler<object>>(new Func<EventHandler<object>, EventRegistrationToken>(timer2.add_Tick), new Action<EventRegistrationToken>(timer2.remove_Tick), eventHandler);
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public CoreDownload(string url, string name)
    {
      this._textBlockPercentuale = "0";
      this._music = "";
      this.timer = new DispatcherTimer();
      this.Url = url;
      this.Titolo = name;
      this.timer.Interval = TimeSpan.FromMilliseconds(100.0);
      this.timer.Start();
    }

    public async Task Scarica()
    {
      try
      {
        HttpClient httpClient = new HttpClient();
        ((ICollection<HttpProductInfoHeaderValue>) httpClient.DefaultRequestHeaders.UserAgent)
         .Add(new HttpProductInfoHeaderValue(
          "Mozilla/5.0 (Windows; U; Windows NT 5.0; en-US; rv: 1.8) Gecko/20051111 Firefox/1.5"));
        ((IDictionary<string, string>) httpClient.DefaultRequestHeaders).Add("Method", "GET");
        if (this.Url == null | Operators.CompareString(this.Url, "", false) == 0)
        {
          //TODO
          // ISSUE: reference to a compiler-generated field
          //CoreDownload.FinitoEventHandler finitoEvent = this.FinitoEvent;
          //if (finitoEvent != null)
          //  finitoEvent(this);
          ((Collection<CoreDownload>) App.listaDownloading).Remove(this);
          App.downloading = false;
          return;
        }
        CoreDownload coreDownload = this;
        HttpResponseMessage response = coreDownload.response;

        coreDownload.response = await httpClient.GetAsync(new Uri(this.Url), (HttpCompletionOption) 1);
        coreDownload = (CoreDownload) null;
        if (this.TipoFile == CoreDownload.Tipo.Music)
        {
          coreDownload = this;
          StorageFolder storageFolder = coreDownload.storageFolder;
          coreDownload.storageFolder = (StorageFolder)
                        await App.localFolder.GetItemAsync(App.musicFolder);
          coreDownload = (CoreDownload) null;
          coreDownload = this;
          StorageFile imgFil = coreDownload.imgFil;
          coreDownload.imgFil = await this.storageFolder.CreateFileAsync(this.Titolo + ".mp3",
              (CreationCollisionOption) 1);
          coreDownload = (CoreDownload) null;
          coreDownload = this;
          FileRandomAccessStream fs = coreDownload.fs;
          coreDownload.fs = (FileRandomAccessStream) 
                        await this.imgFil.OpenAsync((FileAccessMode) 1);
          coreDownload = (CoreDownload) null;
        }
        else if (this.TipoFile == CoreDownload.Tipo.Youtube)
        {
          coreDownload = this;
          StorageFolder storageFolder = coreDownload.storageFolder;

          coreDownload.storageFolder = (StorageFolder)
                        await App.localFolder.GetItemAsync(App.videoFolder);
          coreDownload = (CoreDownload) null;
          coreDownload = this;
          StorageFile imgFil = coreDownload.imgFil;
          coreDownload.imgFil = await this.storageFolder.CreateFileAsync(
              this.Titolo + ".mp4", (CreationCollisionOption) 1);
          coreDownload = (CoreDownload) null;
          coreDownload = this;
          FileRandomAccessStream fs = coreDownload.fs;

          coreDownload.fs = (FileRandomAccessStream) 
                        await this.imgFil.OpenAsync((FileAccessMode) 1);

          coreDownload = (CoreDownload) null;
        }
        else if (this.TipoFile == CoreDownload.Tipo.Foto)
        {
          coreDownload = this;
          StorageFolder storageFolder = coreDownload.storageFolder;
          coreDownload.storageFolder = (StorageFolder) 
                        await App.localFolder.GetItemAsync(App.picturFolder);
          coreDownload = (CoreDownload) null;
          coreDownload = this;
          StorageFile imgFil = coreDownload.imgFil;
          coreDownload.imgFil = await this.storageFolder.CreateFileAsync(
              this.Titolo + ".png", (CreationCollisionOption) 1);
          coreDownload = (CoreDownload) null;
          coreDownload = this;
          FileRandomAccessStream fs = coreDownload.fs;
          coreDownload.fs = (FileRandomAccessStream) 
                        await this.imgFil.OpenAsync((FileAccessMode) 1);
          coreDownload = (CoreDownload) null;
        }
        this.LunghezzaTotale = checked ((int) this.response.Content.Headers.ContentLength.Value);
        this.inputStream = this.response.Content.ReadAsInputStreamAsync().GetResults();
        ulong num = 0;
        while (true)
        {
          IBuffer source = (IBuffer) new Buffer(126334U);
          source = await this.inputStream.ReadAsync(
              source, source.Capacity, (InputStreamOptions) 0);
          if (source.Length != 0U)
          {
            checked { num += (ulong) source.Length; }
            this.TextBlockStato = Conversions.ToString(Math.Round((double) num / 1048576.0, 10));
            Decimal d;
            try
            {
              d = Decimal.Divide(Decimal.Multiply(new Decimal(num), 100M),
                  new Decimal(this.LunghezzaTotale));
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              ProjectData.ClearProjectError();
            }
            this.TextBlockPercentuale = Conversions.ToString(Decimal.Truncate(d));
            this.Percentuale = Convert.ToDouble(Decimal.Truncate(d));
            Decimal num1 = new Decimal(Math.Round((double) num / 1048576.0, 10));
            Decimal num2 = new Decimal(Math.Round((double) this.LunghezzaTotale / 1048576.0, 2));
            this.TextBlockStato = num1.ToString("0.00").Replace(",", ".") + "MB/" + num2.ToString("0.00").Replace(",", ".") + "MB";
            int num3 = (int) await this.fs.WriteAsync(source);
            int num4 = await this.fs.FlushAsync() ? 1 : 0;
            await source.AsStream().FlushAsync();
          }
          else
            break;
        }
        this.fs.Dispose();
        ((IDisposable) this.inputStream).Dispose();
        this.response.Dispose();
        this.inputStream = (IInputStream) null;
        this.response = (HttpResponseMessage) null;
        this.storageFolder = (StorageFolder) null;
        this.imgFil = (StorageFile) null;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      ((Collection<CoreDownload>) App.listaDownloading).Remove(this);
      
        //TODO
        // ISSUE: reference to a compiler-generated field
        //CoreDownload.FinitoEventHandler finitoEvent1 = this.FinitoEvent;      
        //if (finitoEvent1 != null)
        //  finitoEvent1(this);
      
      App.downloading = false;
    }

    private void timer_Tick(object sender, object e)
    {
    }

    public async void Arresta()
    {
      try
      {
        ((IDisposable) this.inputStream).Dispose();
        this.response.Dispose();
        await this.imgFil.DeleteAsync();
        this.inputStream = (IInputStream) null;
        this.response = (HttpResponseMessage) null;
        this.storageFolder = (StorageFolder) null;
        this.imgFil = (StorageFile) null;
        ((Collection<CoreDownload>) App.listaDownloading).Remove(this);
        App.downloading = false;
        
        //TODO        
        // ISSUE: reference to a compiler-generated field
        //CoreDownload.FinitoEventHandler finitoEvent = this.FinitoEvent;
        //if (finitoEvent == null)
        //  return;
        //finitoEvent(this);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ((Collection<CoreDownload>) App.listaDownloading).Remove(this);
        App.downloading = false;
        
        //TODO        
        // ISSUE: reference to a compiler-generated field
        //CoreDownload.FinitoEventHandler finitoEvent = this.FinitoEvent;
        //if (finitoEvent != null)
        //  finitoEvent(this);
        ProjectData.ClearProjectError();
      }
    }

    public delegate void FinitoEventHandler(CoreDownload obj);

    public enum Tipo
    {
      Music,
      Foto,
      Youtube,
    }
  }
}
