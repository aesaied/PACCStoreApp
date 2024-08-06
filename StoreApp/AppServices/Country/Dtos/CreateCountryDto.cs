using StoreApp.Settings;
using System.ComponentModel.DataAnnotations;

namespace StoreApp.AppServices.Country.Dtos
{
    public class CreateCountryDto
    {

        public int? Id { get; set; }


        [Required(ErrorMessage ="Must fill name")]
        [StringLength(100, MinimumLength =2)]
        [Display(Name ="Country name", Prompt ="Please fill country name (i.e Palestine)")]

        [RegularExpression(StoreAppSettings.ValidNameExpression,ErrorMessage = "Name is invalid!")]
        public required string Name { get; set; }  
    }
}
