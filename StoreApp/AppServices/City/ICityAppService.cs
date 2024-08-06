using StoreApp.AppServices.City.Dtos;

namespace StoreApp.AppServices.City
{
    public interface ICityAppService: IApplicationService
    {
        Task<bool> Create(CreateCityDto input);
        Task<bool> Edit(CreateCityDto input);
        Task<IList<CityDto>> GetAll();
        Task<CreateCityDto> GetCityForEdit(int id);
        Task<List<CityDto>> GetTopCities(int rows);
    }
}