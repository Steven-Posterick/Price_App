using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Price_App.Helper;
using Price_App.Model;
using Price_App.Service;

namespace Price_App.ViewModel;

public class PriceViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private readonly IPriceService _priceService;

    public PriceViewModel(IPriceService priceService)
    {
        _priceService = priceService;
    }

    public ICommand SearchWebsiteCommand => CommandHelper.CreateAsyncCommand(OnSearchWebsite);
    public ICommand SelectItemCommand => CommandHelper.CreateAsyncCommand<ScrapedItem>(OnSelectItem);

    public ObservableCollection<ScrapedItem> ScrapedItems { get; } = new ObservableCollection<ScrapedItem>();

    public ObservableCollection<PricedItem> PricedItems { get; } = new ObservableCollection<PricedItem>();

    private string _description;
    public string Description
    {
        get => _description;
        set
        {
            _description = value;
            OnPropertyChanged(nameof(Description));
        }
    }

    private async Task OnSearchWebsite()
    {
        ScrapedItems.Clear();


        var scrapedItems = await _priceService.GetScrapedItems(Description);
        // Show results

        scrapedItems.ForEach(x => ScrapedItems.Add(x));
    }

    private async Task OnSelectItem(ScrapedItem item)
    {
        // TODO: Add Population when an item is selected.
        PricedItems.Clear();
        var pricedItems = await _priceService.GetPricedItems(item);
        
        pricedItems.ForEach(x => PricedItems.Add(x));

        
    }
}