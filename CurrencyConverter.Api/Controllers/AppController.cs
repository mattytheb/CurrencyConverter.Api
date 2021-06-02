using System.Collections.Generic;
using CurrencyConverter.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using CurrencyConverter.Api.Data.Entities;
using CurrencyConverter.Api.Repository;
using CurrencyConverter.Api.Services;

namespace CurrencyConverter.Api.Controllers
{
    public class AppController : Controller
    {
        private readonly ILogger<AppController> _logger;
        private readonly ConverterService _converterService;
        private readonly IAppRepository _repository;
        private readonly IMapper _mapper;

        public AppController(ILogger<AppController> logger, ConverterService converterService, IAppRepository repository, IMapper mapper)
        {
            _logger = logger;
            _converterService = converterService;
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Currency Conversion";

            var allCurrencies = await _repository.GetAllCurrenciesAsync();

            var currencies = _mapper.Map<IEnumerable<Currency>, IEnumerable<CurrencyViewModel>>(allCurrencies);

            var conversion = new ConversionViewModel {Currencies = currencies};

            return View(conversion);
        }

        [HttpPost]
        public IActionResult Index(ConversionViewModel model)
        {
            var success = _converterService.GetCurrencyData(model);

            if (!success)
            {
                //need to tell user currency code failed
                return RedirectToAction("Index");
            }

            return RedirectToAction("Conversion", model);
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact Us";

            return View();
        }

        public IActionResult Conversion(ConversionViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult Conversion(string convertAnother)
        {
            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
