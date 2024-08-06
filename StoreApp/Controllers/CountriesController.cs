using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StoreApp.AppServices.Country;
using StoreApp.AppServices.Country.Dtos;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class CountriesController : Controller
    {

        private readonly ICountryAppService _countryAppService;
        public CountriesController(ICountryAppService countryAppService)
        {
            _countryAppService = countryAppService;
        }
        public async Task< IActionResult> Index()
        {
            var  data =await  _countryAppService.GetAll();

            var model = new CountryViewModel() { Countries = data };
            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {

            return View();

        }



        [HttpPost]
        public async Task<IActionResult> Create(CreateCountryDto input)
        {
            if (ModelState.IsValid) {

                if (input.Name == "test")
                {
                    ModelState.AddModelError("", "Name !='test'");
                }

                if (ModelState.IsValid)
                {

                    bool result = await _countryAppService.Create(input);

                    if (result)
                    {
                        this.SetMessage("Inserted Successfully!", MessageType.Success);
                        return RedirectToAction("Index");
                    }

                }
            }


            return View(input);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var countryEdit =await _countryAppService.GetCountryForEdit(id);

            if (countryEdit == null) {

                return RedirectToAction(nameof(Index));
            }

            return View(countryEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CreateCountryDto input)
        {


            if (ModelState.IsValid)
            {

                await _countryAppService.Edit(input);

                this.SetMessage("Updated Successfully!", MessageType.Success);
               

                return RedirectToAction(nameof(Index)); 
            }


            return View(input);
        }
    }
}
