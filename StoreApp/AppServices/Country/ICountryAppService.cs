using StoreApp.AppServices.Country.Dtos;

namespace StoreApp.AppServices.Country
{
    public interface ICountryAppService: IApplicationService
    {
        Task<IList<CountryDto>> GetAll();

        Task<bool> Create(CreateCountryDto input);
        Task<CreateCountryDto> GetCountryForEdit(int id);
        Task<bool> Edit(CreateCountryDto input);
        Task<List<CountryDto>> GetTopCountries(int v);
    }
}