using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_MAS.DTO;
using Datos.Base.Definiciones;
using Datoss.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace API_MAS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMASRepository _IMASRepository;
        public EmployeeController(ILogger<EmployeeController> logger, IMASRepository mASRepository)
        {
            _logger = logger;
            _IMASRepository = mASRepository;
        }

        [HttpGet]
        public string Get()
        {
            return "API MAS";
        }

        [HttpPost]
        public string Post(SearchDTO searchDTO)
        {
            var ListResult= _IMASRepository.Get(searchDTO.searchValue.ToLower());
            string result = JsonConvert.SerializeObject(ListResult);
            return result;
        }
    }
}
