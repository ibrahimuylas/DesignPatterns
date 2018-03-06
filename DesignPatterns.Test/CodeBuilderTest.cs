using System;
using DesignPatterns.Builder;
using Xunit;

namespace DesignPatterns.Test
{
    public class CodeBuilderTest
    {
        private string Preprocess(string s)
        {
            return s.Trim().Replace("\r\n", "\n");
        }

        [Fact]
        public void EmptyTest()
        {
            var cb = new CodeBuilder("Foo");
            Assert.Equal(Preprocess(cb.ToString()), "public class Foo\n{\n}");
        }

        [Fact]
        public void PersonTest()
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Assert.Equal(Preprocess(cb.ToString()),
                @"public class Person
{
  public string Name;123
  public int Age;
}"
              );
        }
    }
}
