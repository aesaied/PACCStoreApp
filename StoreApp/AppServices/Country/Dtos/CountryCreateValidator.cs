using FluentValidation;
using Microsoft.EntityFrameworkCore;
using StoreApp.Entities;

namespace StoreApp.AppServices.Country.Dtos
{
    public class CountryCreateValidator : AbstractValidator<CreateCountryDto>
    {
        private readonly StoreAppContext _db;

       
        public CountryCreateValidator(StoreAppContext db)
        {
            _db = db;


            RuleFor(c => c.Name)

                .Custom((name, context) =>
                {

                    var country = context.InstanceToValidate;

                    bool isExists = _db.Countries.Where(c => c.Name == name && c.Id!=country.Id).Any();

                    if (isExists)
                    {
                        context.AddFailure($"Country name '{name}' is already used!");

                    }


                });//.When(s=>!s.Id.HasValue || s.Id==0);
        }
    }
}
