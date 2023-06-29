using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared
{
    public class Thing
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; } = "";
    }
}
