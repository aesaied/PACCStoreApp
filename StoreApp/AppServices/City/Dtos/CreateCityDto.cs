using StoreApp.Settings;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StoreApp.AppServices.City.Dtos
{
    public class CreateCityDto
    {

        public int? Id { get; set; }

        [Required(ErrorMessage = "Must fill name")]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "City name", Prompt = "Please fill city name (i.e Jerusalem)")]

        [RegularExpression(StoreAppSettings.ValidNameExpression, ErrorMessage = "Name is invalid!")]
        public required string Name { get; set; }


        [DisplayName("Country")]
        public int CountryId { get; set; }
    }
}
