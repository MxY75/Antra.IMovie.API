using Microsoft.AspNetCore.Mvc;

namespace ImovieCRMAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        List<Employee> emps = new List<Employee>{ new Employee() { Id = 1, Name = "Smith", Salary = 6000, Department = "IT" },
                new Employee() { Id = 2, Name = "Emma", Salary = 9900, Department = "HR" },
                new Employee() { Id = 3, Name = "Eva", Salary = 800, Department = "PD" },
                new Employee() { Id = 4, Name = "Tony", Salary = 6000, Department = "IT" },
                new Employee() { Id = 5, Name = "Mia", Salary = 10000, Department = "IT" }};


        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }




        [HttpGet(Name = "GetWatherForecast")]
        public string Get() {

            return "Welcome to Webapi";
        }

        // [HttpGet(Name="GetUserName")]
        [HttpGet]
        [Route("getname/{name}")]
        public string GetMasssageWithName(string name) {

            return "Weclome" + name;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllEmps() {
            //throw new Exception();


            return Ok(emps);

        }
        [HttpGet]
        [Route("GetById/{id:int:max(5):min(1)}")]
        public IActionResult GetById(int id) {

            return Ok(emps.FirstOrDefault(e => e.Id == id));

        }
        [HttpGet]
        [Route("GetByNameId/{id}/{name}")]
        public IActionResult Get(int id, string name) {
            string result = $"Employee name = {name} and id = {id}";
            return Ok(result);
        }
        [HttpGet("GetByNameCity")]
        public IActionResult Get(string name ="", string city ="") {

            string result =  "mehtod with query string";
            return Ok(result);
        
        }
        [HttpPost]
        public IActionResult Post(int id, Employee emp) {
            emps.Add(emp);
            return Ok(emps); 
        }
    }
}