using Currency.Api.Enums;
using Currency.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Currency.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CurrenciesController : ControllerBase
{
    private static readonly List<CurrencyPair> currencyPairs = new List<CurrencyPair>
    {
        new CurrencyPair
        {
            BaseCurrency = CurrencyCode.EUR.ToString(),
            QouteCurrency = CurrencyCode.USD.ToString(),
            Rate = 1.07
        },
        new CurrencyPair
        {
            BaseCurrency = CurrencyCode.EUR.ToString(),
            QouteCurrency = CurrencyCode.GBP.ToString(),
            Rate = 0.83
        },
        new CurrencyPair
        {
            BaseCurrency = CurrencyCode.USD.ToString(),
            QouteCurrency = CurrencyCode.EUR.ToString(),
            Rate = 1/1.07
        },
        new CurrencyPair
        {
            BaseCurrency = CurrencyCode.USD.ToString(),
            QouteCurrency = CurrencyCode.GBP.ToString(),
            Rate = 0.78
        },
        new CurrencyPair
        {
            BaseCurrency = CurrencyCode.GBP.ToString(),
            QouteCurrency = CurrencyCode.EUR.ToString(),
            Rate = 1/0.83
        },
        new CurrencyPair
        {
            BaseCurrency = CurrencyCode.GBP.ToString(),
            QouteCurrency = CurrencyCode.USD.ToString(),
            Rate = 1/0.78
        }
    };

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CurrencyPair>), StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<CurrencyPair>> GetCurrecyPairs()
    {
        return Ok(currencyPairs.ToList());
    }

    [HttpGet("from/{baseCurrency}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(IEnumerable<CurrencyPair>), StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<CurrencyPair>> GetPairByBaseCurrency(string baseCurrency)
    {
        var pairs = currencyPairs.Where(p => p.BaseCurrency.ToString() == baseCurrency.ToUpper());
        if (pairs == null)
        {
            return NotFound();
        }

        return Ok(pairs);
    }

    [HttpGet("quote/{baseCurrency}/{quoteCurrency}/{amount}")]
    public ActionResult<CurrencyPair> GetQuote(
        string baseCurrency, 
        string qouteCurrency, 
        double amount)
    {
        var pair = currencyPairs
            .FirstOrDefault(p => 
                (p.BaseCurrency.ToString() == baseCurrency.ToUpper()) && 
                (p.QouteCurrency.ToString() == qouteCurrency.ToUpper()));
        
        if (pair == null)
        {
            return NotFound();
        }

        double result = amount * pair.Rate;
        return Ok(result);
    }

    [HttpPut("{baseCurrency}/{qouteCurrency}/{rate}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CurrencyPair), StatusCodes.Status200OK)]
    public IActionResult UpdateRate(
        string baseCurrency, 
        string qouteCurrency, 
        double rate)
    {
        var pair = currencyPairs
            .FirstOrDefault(p =>
                (p.BaseCurrency.ToString() == baseCurrency.ToUpper()) &&
                (p.QouteCurrency.ToString() == qouteCurrency.ToUpper()));

        if (pair == null)
        {
            return NotFound();
        }
        else
        {
            pair.Rate = rate;
        }


        var inverse = currencyPairs
            .FirstOrDefault(p =>
                (p.BaseCurrency.ToString() == qouteCurrency.ToUpper()) &&
                (p.QouteCurrency.ToString() == baseCurrency.ToUpper()));

        if (inverse == null)
        {
            return NotFound();
        }
        else
        {
            inverse.Rate = 1 / rate;
        }

        return Ok(pair);
    }
}
