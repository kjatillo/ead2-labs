namespace Currency.Client.Models;

class CurrencyPair
{
    public string BaseCurrency { get; set; }
    public string QouteCurrency { get; set; }
    public double Rate { get; set; }
}
