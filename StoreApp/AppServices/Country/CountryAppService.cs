using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreApp.AppServices.Country.Dtos;
using StoreApp.Entities;

namespace StoreApp.AppServices.Country
{
    public class CountryAppService : ICountryAppService
    {
        private readonly StoreAppContext _db;
        private readonly IMapper _objectMapper;
        public CountryAppService(StoreAppContext db, IMapper mapper)
        {
            _db = db;
            _objectMapper = mapper;
        }

        public async Task<bool> Create(CreateCountryDto input)
        {
            //Entities.Country country = new Entities.Country { Name = input.Name };

            var  country=  _objectMapper.Map<Entities.Country>(input);

            _db.Countries.Add(country);

            return  await _db.SaveChangesAsync() == 1;
        }

        public async Task<bool> Edit(CreateCountryDto input)
        {

            var objFromDb = await _db.Countries.FindAsync(input.Id);
           // var country = _objectMapper.Map<Entities.Country>(input);


            _objectMapper.Map(input, objFromDb);

            // replace
           // _db.Countries.Update(country);

            return await _db.SaveChangesAsync() == 1;
        }

        public async Task<IList<CountryDto>> GetAll()
        {
            var countries = await _db.Countries.ToListAsync();


            //  AutoMapper 

            var output = _objectMapper.Map<List<CountryDto>>(countries);

            //var output = countries.Select(c => new CountryDto() { Id = c.Id, Name = c.Name });

            return output.ToList();

        }

        public async Task<CreateCountryDto> GetCountryForEdit(int id)
        {
             var country=  await _db.Countries.FindAsync(id);

           return _objectMapper.Map<CreateCountryDto>(country);
        }

        public async Task<List<CountryDto>> GetTopCountries(int rows)
        {
            var countries = await _db.Countries.OrderByDescending(s=>s.Id).Take(rows).ToListAsync();


            //  AutoMapper 

            var output = _objectMapper.Map<List<CountryDto>>(countries);

            //var output = countries.Select(c => new CountryDto() { Id = c.Id, Name = c.Name });

            return output.ToList();
        }
    }
}
