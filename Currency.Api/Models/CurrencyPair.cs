using Currency.Api.Enums;

namespace Currency.Api.Models;

public class CurrencyPair
{
    public string BaseCurrency { get; set; }
    public string QouteCurrency { get; set; }
    public double Rate { get; set; }
}
