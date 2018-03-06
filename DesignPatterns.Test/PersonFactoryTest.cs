using System;
using DesignPatterns.Factory;
using Xunit;

namespace DesignPatterns.Test
{
    public class PersonFactoryTest
    {

        [Fact]
        public void GetPersonTest()
        {
            var pf = new PersonFactory();
            var p1 = pf.GetPerson("ibrahim");
            Assert.Equal("ibrahim", p1.Name);
            Assert.Equal(0, p1.Id);
            var p2 = pf.GetPerson("simge");
            Assert.Equal("simge", p2.Name);
            Assert.Equal(1, p2.Id);
        }

    }
}
