using System;
using System.Collections.Generic;
using Xunit;

namespace IncomprehensibleFinderKata.Tests
{
    public class FinderTests
    {
        [Fact]
        public void Returns_Empty_Results_When_Given_Empty_List()
        {
            var list = new List<Person>();
            var finder = new Finder(list);

            var result = finder.Find(Criteria.Clossest);

            Assert.Null(result.PersonMinor);
            Assert.Null(result.PersonMajor);
        }

        [Fact]
        public void Returns_Empty_Results_When_Given_One_Person()
        {
            var list = new List<Person>() { sue };
            var finder = new Finder(list);

            var result = finder.Find(Criteria.Clossest);

            Assert.Null(result.PersonMinor);
            Assert.Null(result.PersonMajor);
        }

        [Fact]
        public void Returns_Closest_Two_For_Two_People()
        {
            var list = new List<Person>() { sue, greg };
            var finder = new Finder(list);

            var result = finder.Find(Criteria.Clossest);

            Assert.Same(sue, result.PersonMinor);
            Assert.Same(greg, result.PersonMajor);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Two_People()
        {
            var list = new List<Person>() { greg, mike };
            var finder = new Finder(list);

            var result = finder.Find(Criteria.Farthest);

            Assert.Same(greg, result.PersonMinor);
            Assert.Same(mike, result.PersonMajor);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Four_People()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };
            var finder = new Finder(list);

            var result = finder.Find(Criteria.Farthest);

            Assert.Same(sue, result.PersonMinor);
            Assert.Same(sarah, result.PersonMajor);
        }

        [Fact]
        public void Returns_Closest_Two_For_Four_People()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };
            var finder = new Finder(list);

            var result = finder.Find(Criteria.Clossest);

            Assert.Same(sue, result.PersonMinor);
            Assert.Same(greg, result.PersonMajor);
        }
        [Fact]
        public void Create_model()
        {
            var list = new List<Person>() { greg, mike, sue };
            var finder = new Finder(list);

            var result = finder.CreateModels(list, sarah);

            Assert.Equal(3, result.Count);
        }

        Person sue = new Person() { Name = "Sue", BirthDate = new DateTime(1950, 1, 1) };
        Person greg = new Person() { Name = "Greg", BirthDate = new DateTime(1952, 6, 1) };
        Person sarah = new Person() { Name = "Sarah", BirthDate = new DateTime(1982, 1, 1) };
        Person mike = new Person() { Name = "Mike", BirthDate = new DateTime(1979, 1, 1) };
    }
}