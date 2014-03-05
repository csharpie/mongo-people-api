namespace MongoPeopleAPI.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Configuration;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;

    public class PersonRepository : IPersonRepository
    {
        private readonly MongoClient _client;
        private readonly MongoServer _server;
        private readonly MongoDatabase _database;
        private readonly MongoCollection<Person> _people;

        private static readonly string ConnectionString = WebConfigurationManager.AppSettings["dbConnStr"];

        public PersonRepository()
            : this(ConnectionString)
        {

        }

        public PersonRepository(string connection)
        {
            _client = new MongoClient(connection);
            _server = _client.GetServer();
            _database = _server.GetDatabase("people");
            _people = _database.GetCollection<Person>("people");
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return _people.FindAll();
        }

        public Person GetPerson(string id)
        {
            var query = Query.EQ("_id", id);
            return _people.Find(query).FirstOrDefault();
        }

        public Person AddPerson(Person person)
        {
            _people.Insert(person);
            return person;
        }

        public bool RemovePerson(string id)
        {
            var query = Query.EQ("_id", id);
            var result = _people.Remove(query);
            return result.DocumentsAffected == 1;
        }

        public bool UpdatePerson(string id, Person person)
        {
            var query = Query.EQ("_id", id);
            var update = new UpdateBuilder();
            var activities = new BsonArray();

            if (person.FirstName != null)
                update.Set("first_name", person.FirstName);
            if (person.LastName != null)
                update.Set("last_name", person.LastName);
            if (person.Activities.Count == 0)
                update.Unset("activities");
            else if (person.Activities != null)
            {
                foreach (var activity in person.Activities)
                {
                    activities.Add(activity);
                }
                update.Set("activities", activities);
            }
            if(person.FavoriteHobby != null)
                update.Set("favorite_hobby", person.FavoriteHobby);
            
            var result = _people.Update(query, update);
            return result.UpdatedExisting;
        }
    }
}