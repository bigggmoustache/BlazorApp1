using BlazorApp1.Server.Repository;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using BlazorApp1.Shared;
using System.Text.Json;
using MongoDB.Bson;
using BlazorApp1.Server.Repository.Interfaces;

namespace BlazorApp1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMongoClient _mongoClient;
        private readonly IRepository<User> _userRepository;

        public UserController(IMongoClient mongoClient, IRepository<User> userRepository)
        {
            _mongoClient = mongoClient;
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser([FromBody] User user)
        {
            _userRepository.Add(user);
            return Ok($"The following user has been created: {user.Username}");
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> GetUser(string id)
        {
            try
            {
                _userRepository.GetById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Unsuccessful query of new User.");
            }
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
    }
}
