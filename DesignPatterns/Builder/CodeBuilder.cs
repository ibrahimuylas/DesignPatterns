// You are asked to implement the Builder design pattern for rendering simple chunks of code.
   
// Sample use of the builder you are asked to create:
   
// var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
// Console.WriteLine(cb);
// The expected output of the above code is:
   
// public class Person
// {
//     public string Name;
//     public int Age;
// }
// Please observe the same placement of curly braces and use two-space indentation.
                                                                               

using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace DesignPatterns.Builder
{
    class Field
    {
        public string Type, Name;

        public override string ToString()
        {
            return $"public {Type} {Name}";
        }
    }

    class Class
    {
        public string Name;
        public List<Field> Fields = new List<Field>();

        public Class()
        {

        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"public class {Name}").AppendLine("{");
            foreach (var f in Fields)
                sb.AppendLine($"  {f};");
            sb.AppendLine("}");
            return sb.ToString();
        }
    }

    public class CodeBuilder
    {
        public CodeBuilder(string rootName)
        {
            theClass.Name = rootName;
        }

        public CodeBuilder AddField(string name, string type)
        {
            theClass.Fields.Add(new Field { Name = name, Type = type });
            return this;
        }

        public override string ToString()
        {
            return theClass.ToString();
        }

        private Class theClass = new Class();
    }
}
