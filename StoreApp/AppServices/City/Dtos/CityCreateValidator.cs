using FluentValidation;
using Microsoft.EntityFrameworkCore;
using StoreApp.AppServices.City.Dtos;
using StoreApp.Entities;

namespace StoreApp.AppServices.City.Dtos
{
    public class CityCreateValidator:AbstractValidator<CreateCityDto>
    {
        private readonly StoreAppContext _db;

       
        public CityCreateValidator(StoreAppContext db)
        {
            _db = db;


            RuleFor(c => c.Name)

                .Custom((name, context) =>
                {

                    var country = context.InstanceToValidate;

                    bool isExists = _db.Cities.Where(c => c.Name == name && c.Id!=country.Id).Any();

                    if (isExists)
                    {
                        context.AddFailure($"City name '{name}' is already used!");

                    }


                });//.When(s=>!s.Id.HasValue || s.Id==0);
        }
    }
}
