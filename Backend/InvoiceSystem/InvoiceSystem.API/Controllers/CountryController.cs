using InvoiceSystem.APPLICATION.Services;
using InvoiceSystem.DOMAIN.Entities;
using InvoiceSystem.DOMAIN.Utilities.CommonCRUD;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InvoiceSystem.API.Controllers
{
    [Route("api/v1/country")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly CountryService _service;

        public CountryController(CountryService service)
        {
            _service = service;
        }

        [HttpGet]
        public ObjectResult FindAll([FromQuery(Name = "page")] int page, [FromQuery(Name = "size")] int size)
        {
            Page<Country> data = (Page<Country>)_service.FindAll(page - 1, size);
            Debug.WriteLine(data.GetTotalElements());
            Debug.WriteLine(data.GetContent());
            return Ok(data.GetContent());
        }
    }
}
