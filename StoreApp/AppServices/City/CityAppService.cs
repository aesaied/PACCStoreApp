using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StoreApp.AppServices.City.Dtos;

using StoreApp.Entities;

namespace StoreApp.AppServices.City
{
    public class CityAppService : ICityAppService
    {

        private readonly StoreAppContext _db;
        private readonly IMapper _objectMapper;
        public CityAppService(StoreAppContext db, IMapper mapper)
        {
            _db = db;
            _objectMapper = mapper;
        }

        public async Task<bool> Create(CreateCityDto input)
        {
            //Entities.Country country = new Entities.Country { Name = input.Name };

            var city = _objectMapper.Map<Entities.City>(input);

            _db.Cities.Add(city);

            return await _db.SaveChangesAsync() == 1;
        }

        public async Task<bool> Edit(CreateCityDto input)
        {

            var objFromDb = await _db.Cities.FindAsync(input.Id);
            // var country = _objectMapper.Map<Entities.Country>(input);


            _objectMapper.Map(input, objFromDb);

            // replace
            // _db.Countries.Update(country);

            return await _db.SaveChangesAsync() == 1;
        }

        public async Task<IList<CityDto>> GetAll(CityFilterInput input)
        {

            var data =  _db.Cities.AsQueryable();


            if (!string.IsNullOrWhiteSpace(input.Search) && input.CountryId != null && input.CountryId.Any())
            {
                data = data.Where(s => (s.Name.Contains(input.Search.Trim()) || input.CountryId.Contains(s.CountryId)));
                return await data.ProjectTo<CityDto>(_objectMapper.ConfigurationProvider).ToListAsync();
               
            }
            if (!string.IsNullOrWhiteSpace(input.Search))
            {
                data = data.Where(s => s.Name.Contains(input.Search.Trim()));
            }

            if (input.CountryId != null  && input.CountryId.Any()) 
            {

                // and countyId in (,,,,)
                data = data.Where(s => input.CountryId.Contains(s.CountryId));
            }

            return await data.ProjectTo<CityDto>(_objectMapper.ConfigurationProvider).ToListAsync();




        }

        public async Task<CreateCityDto> GetCityForEdit(int id)
        {
            var country = await _db.Cities.FindAsync(id);

            return _objectMapper.Map<CreateCityDto>(country);
        }

        public async Task<List<CityDto>> GetTopCities(int rows)
        {
            var cities = await _db.Cities.Include(s=>s.Country).OrderByDescending(s => s.Id).Take(rows).ToListAsync();


            //  AutoMapper 

            var output = _objectMapper.Map<List<CityDto>>(cities);

            //var output = countries.Select(c => new CountryDto() { Id = c.Id, Name = c.Name });

            return output.ToList();
        }
    }
}

