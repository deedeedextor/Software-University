namespace DefiningClasses
{
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        private List<Person> people = new List<Person>();

        public void AddMember(Person member)
        {
            this.people.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.people.OrderByDescending(p => p.Age).FirstOrDefault();
        }

        public List<Person> PeopleOverThirty()
        {
            return this.people.Where(p => p.Age > 30).ToList();
        }
    }
}
