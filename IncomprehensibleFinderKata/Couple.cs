using System;

namespace IncomprehensibleFinderKata
{
    public class Couple
    {
        public Person PersonMinor { get; set; }
        public Person PersonMajor { get; set; }
        public TimeSpan Difference { get; set; }
    }
}