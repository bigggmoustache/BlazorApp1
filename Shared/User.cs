using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorApp1.Shared
{
    public class User
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        public string Username { get; set; }
        public string Password { get; set; } = "";
        public string Email { get; set; } = "";
        public List<string> Servers { get; set; } = new List<string>();


        // TODO : Add additional properties as needed
    }
}

