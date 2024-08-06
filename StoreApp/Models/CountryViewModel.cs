using StoreApp.AppServices.Country.Dtos;

namespace StoreApp.Models
{
    public class CountryViewModel
    {

        public required IList<CountryDto> Countries { get; set; }
    }
}
