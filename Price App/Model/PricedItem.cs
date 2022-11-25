namespace Price_App.Model;

public class PricedItem
{
    public PricedItem(string provider, decimal? price)
    {
        Provider = provider;
        Price = price;
    }

    public string Provider { get; set; }
    public decimal? Price { get; set; }
}