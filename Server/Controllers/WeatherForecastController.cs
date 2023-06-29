using BlazorApp1.Server.Repository;
using BlazorApp1.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Net;
using System.Text.Json;

namespace BlazorApp1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMongoClient _mongoClient;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IMongoClient mongoClient)       
        {
            _logger = logger;
            _mongoClient = mongoClient;
            
        }

        [HttpGet]
        [Route("DoStuff")]
        public Thing DoStuff()
        {
            Thing thing = new Thing();
            thing.Name = "Thing Name";
            return thing;
        }

        [HttpGet]
        [Route("DoListStuff")]
        public List<Thing> DoListStuff()
        {
            List<Thing> thingList = new List<Thing>();
            thingList.Add(new Thing() { Name = "Thing1" });
            thingList.Add(new Thing() { Name = "Thing2" });
            return thingList;
        }

        [HttpGet]
        [Route("MongoClientCheck")]
        public async Task<IActionResult> MongoClientCheck()
        {
            try
            {
                var result = _mongoClient.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                return Ok("You successfully connected to MongoDB!");
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"An error occured: {ex.Message}"); 
            }
        }

        /*[HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            try
            {
                _userRepository.Add(user);
                return Ok($"The following user has been created: {user.Username}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Unsuccessful creation of new User.");
            }
        }*/
    }
}