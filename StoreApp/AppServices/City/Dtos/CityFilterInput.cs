namespace StoreApp.AppServices.City.Dtos
{
    public class CityFilterInput
    {

        public required string Search { get; set; }

        public required List<int> CountryId { get; set; }    
    }
}
