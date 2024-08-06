using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StoreApp.AppServices.Country;

namespace StoreApp
{



    public class CountryListViewComponent: ViewComponent
    {

        private readonly ICountryAppService _countryAppService;
        public CountryListViewComponent(ICountryAppService countryAppService)
        {
                _countryAppService = countryAppService;
        }


        public async Task<IViewComponentResult> InvokeAsync(int numRows=5, string display="list")
        {

            var topCountries = await _countryAppService.GetTopCountries(numRows);

            if (display == "table")
            {
                return View("table",topCountries);
            }

            
            return View(topCountries); 
        }
    }
}
