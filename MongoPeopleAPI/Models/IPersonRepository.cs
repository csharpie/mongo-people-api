namespace MongoPeopleAPI.Models
{
    using System.Collections.Generic;

    public interface IPersonRepository
    {
        IEnumerable<Person> GetAllPeople();

        Person GetPerson(string id);

        Person AddPerson(Person person);

        bool RemovePerson(string id);

        bool UpdatePerson(string id, Person person);
    }
}