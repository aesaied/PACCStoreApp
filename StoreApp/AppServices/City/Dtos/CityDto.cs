using System.ComponentModel;

namespace StoreApp.AppServices.City.Dtos
{
    public class CityDto
    {

        public int Id { get; set; }

        public required string Name { get; set; }


        [DisplayName("Country")]
        public required string CountryName { get; set; }
    }
}
