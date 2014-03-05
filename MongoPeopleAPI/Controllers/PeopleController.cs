namespace MongoPeopleAPI.Controllers
{
    using System.Net;
    using System.Web.Http;
    using System.Collections.Generic;
    using Models;

    public class PeopleController : ApiController
    {
        private static readonly IPersonRepository People = new PersonRepository();

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return People.GetAllPeople();
        }

        [HttpGet]
        public Person Get(string id)
        {
            var person = People.GetPerson(id);
            if (person == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return person;
        }

        [HttpPost]
        public Person Post(Person value)
        {
            var person = People.AddPerson(value);
            return person;
        }

        [HttpPut]
        public void Put(string id, Person value)
        {
            if (!People.UpdatePerson(id, value))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        [HttpDelete]
        public void Delete(string id)
        {
            if (!People.RemovePerson(id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}