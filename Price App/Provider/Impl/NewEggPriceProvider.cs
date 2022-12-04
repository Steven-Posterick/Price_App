using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;
using Price_App.Model;

namespace Price_App.Provider.Impl;

public interface INewEggPriceProvider : IPriceProvider { }
public class NewEggPriceProvider : HtmlWebProvider, INewEggPriceProvider
{
    private const string newEggUrl = "https://www.newegg.com/p/pl?d=";


    public async Task<PricedItem> GetPricedItems(string modelId)
    {
        string url = $"{newEggUrl}{HttpUtility.HtmlEncode(modelId)}";
        var document = await LoadDocument(url);

        var priceText = document.DocumentNode
          .Descendants()
            .Where(x => x.HasClass("price"))
            .Select(FindDescendentFirst)
            .FirstOrDefault(x => x != null)?.InnerHtml ?? "";

        HtmlNode? FindDescendentFirst(HtmlNode? node)
        {
            if (node == null) return null;

            return node.Name == "span" ? node : FindDescendentFirst(node.Descendants().FirstOrDefault(x => x.Name != "link"));
        }

        decimal? price = null;
        if (decimal.TryParse(priceText.Replace("$", ""), out var priceDecimal))
            price = priceDecimal;

        var websiteList = document.DocumentNode
           .Descendants()
           .Where(x => x.HasClass("price-current"))
           .SelectMany(x => x.Descendants())
           .Where(x => x.Attributes["href"] != null)
           .Select(x => x.Attributes["href"].Value)
           .ToList();

        var websiteUrl = websiteList.Count == 0 ? "" : $"{websiteList.First()}";
        return new PricedItem("NewEgg", price, websiteUrl);


    }
}