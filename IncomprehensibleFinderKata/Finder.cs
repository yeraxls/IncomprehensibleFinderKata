using System;
using System.Collections.Generic;
using System.Linq;

namespace IncomprehensibleFinderKata
{
    public class Finder
    {
        private List<Person> people;

        public Finder(List<Person> person)
        {
            people = person ?? throw new ArgumentNullException(nameof(person));
        }
        public Couple Find(Criteria criteria)
        {
            var tr = new List<Couple>();
            people.ForEach(person => tr.AddRange(CreateModels(people, person)));

            if (tr.Count < 1)
                return new Couple();

            return AdjustCouple(tr, criteria);

        }

        public List<Couple> CreateModels(List<Person> persons, Person person)
        {
            return persons.Where(p => p.BirthDate < person.BirthDate).Select(p => new Couple
            {
                PersonMinor = p,
                PersonMajor = person,
                Difference = person.BirthDate - p.BirthDate
            }).ToList();
        }

        public Couple AdjustCouple(List<Couple> tr, Criteria criteria)
        {
            if(criteria == Criteria.Clossest)
                return tr.OrderBy(e => e.Difference).FirstOrDefault();
            else
                return tr.OrderByDescending(e => e.Difference).FirstOrDefault();
        }
    }
}