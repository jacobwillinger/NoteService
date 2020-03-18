using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteService.Utilities
{
    public class MongoHelper
    {
        public static IMongoClient MongoClient = new MongoClient("mongodb://localhost:27017");
        public static IMongoCollection<T> GetCollection<T>() { return MongoClient.GetDatabase("test").GetCollection<T>(typeof(T).Name); }
    }
}
