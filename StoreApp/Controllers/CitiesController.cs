using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using StoreApp.AppServices.City;
using StoreApp.AppServices.City.Dtos;
using StoreApp.AppServices.Country;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class CitiesController : Controller
    {

        private readonly ICityAppService _cityAppService;
        private readonly ICountryAppService _countryAppService;
        public CitiesController(ICityAppService cityAppService, ICountryAppService countryAppService)
        {
            _cityAppService = cityAppService;
            _countryAppService = countryAppService;
        }
        public async Task<IActionResult> Index(CityFilterInput input)
        {
            var data = await _cityAppService.GetAll(input);

            var model = new CityViewModel() { Cities = data, Filter=input };

            await FillLookups();
            return View(model);
        }


        private async Task FillLookups()
        {

            var countries=  await _countryAppService.GetAll();

            var selectList = new SelectList(countries, "Id", "Name");

            ViewData["CountryList"] = selectList;
        }


        [HttpGet]
        public  async Task<IActionResult> Create()
        {
            await FillLookups();

            return View();

        }



        [HttpPost]
        public async Task<IActionResult> Create(CreateCityDto input)
        {
            if (ModelState.IsValid)
            {

                if (input.Name == "test")
                {
                    ModelState.AddModelError("", "Name !='test'");
                }

                if (ModelState.IsValid)
                {

                    bool result = await _cityAppService.Create(input);

                    if (result)
                    {
                        this.SetMessage("Inserted Successfully!", MessageType.Success);
                        return RedirectToAction("Index");
                    }

                }
            }

            await FillLookups();
            return View(input);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var cityEdit = await _cityAppService.GetCityForEdit(id);

            if (cityEdit == null)
            {

                return RedirectToAction(nameof(Index));
            }
            await FillLookups();
            return View(cityEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CreateCityDto input)
        {


            if (ModelState.IsValid)
            {

                await _cityAppService.Edit(input);

                this.SetMessage("Updated Successfully!", MessageType.Success);

                return RedirectToAction(nameof(Index));
            }

            await FillLookups();
            return View(input);
        }
    }
}
