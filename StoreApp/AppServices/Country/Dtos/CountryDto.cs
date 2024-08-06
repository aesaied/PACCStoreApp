using System.ComponentModel;

namespace StoreApp.AppServices.Country.Dtos
{
    public class CountryDto
    {
        [DisplayName("ID#")]
        public int Id { get; set; }


        [DisplayName("Country Name")]
        public string Name { get; set; }
    }
}
