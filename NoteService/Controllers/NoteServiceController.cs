using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using NoteService.Models;
using NoteService.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteServiceController : ControllerBase
    {
        private static readonly List<Note> _notes = new List<Note>();
        private static readonly IMongoCollection<Note> _collection = MongoHelper.GetCollection<Note>();
        public NoteServiceController()
        {

        }

        [HttpGet("{name}")]
        public async Task<Note> GetByName(string name)
        {
            return new Note();
        }


        [HttpGet]
        public async Task<IEnumerable<Note>> GetAllNotes()
        {
            return await _collection.Find(Builders<Note>.Filter.Empty).ToListAsync();
        }

        [HttpPost]
        public async Task InsertNote([FromBody]Note note)
        {
            var filter = Builders<Note>.Filter
                .Eq(n => n.Id, note.Id);

            var update = Builders<Note>.Update
                .Set(n => n.Text, note.Text)
                .Set(n => n.ModifiedDate, DateTime.Now)
                //.SetOnInsert(n => n.Id, ObjectId.GenerateNewId())
                .SetOnInsert(n => n.CreatedDate, DateTime.Now);

            await _collection.InsertOneAsync(note, new InsertOneOptions {


            });
        }
        //[HttpPatch]
        //public Note ModifyNote([FromBody]Note note)
        //{
        //    var realNote = _notes.Where(x => x.Id == note.Id).FirstOrDefault();
        //    // update in database
        //    realNote.Text = note.Text;
        //    realNote.ModifiedDate = DateTime.Now;
        //    return realNote;
        //}
        [HttpDelete()]
        public async Task DeleteNote([FromBody]ObjectId id)
        {
            var filter = Builders<Note>.Filter.Eq(n => n.Id, id);
            await _collection.DeleteOneAsync(filter);
        }
    }
}
