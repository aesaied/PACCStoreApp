using StoreApp.AppServices.City.Dtos;


namespace StoreApp.Models
{
    public class CityViewModel
    {


        public required IList<CityDto> Cities { get; set; }
    }
}
