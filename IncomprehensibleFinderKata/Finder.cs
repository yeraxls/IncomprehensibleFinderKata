using System;
using System.Collections.Generic;
using System.Linq;

namespace IncomprehensibleFinderKata
{
    public class Finder
    {
        private List<Person> _p;

        public Finder(List<Person> p)
        {
            _p = p;
        }

        public Couple Find(Criteria criteria)
        {
            var tr = new List<Couple>();
            _p.ForEach(person => tr.AddRange(CreateModels(_p, person)));

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
            Couple answer = tr[0];
            tr.ForEach(result =>
            {
                switch (criteria)
                {
                    case Criteria.Clossest:
                        if (result.Difference < answer.Difference)
                            answer = result;
                        break;

                    case Criteria.Farthest:
                        if (result.Difference > answer.Difference)
                            answer = result;
                        break;
                }
            });

            return answer;
        }
    }
}