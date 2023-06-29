using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorApp1.Shared;
using MongoDB.Driver;

namespace BlazorApp1.Server.Repository

{
    public class UserRepository : MongoRepository<User>
    {
        public UserRepository(IMongoDatabase database) : base(database, "Users")
        {
        }
    }
}
