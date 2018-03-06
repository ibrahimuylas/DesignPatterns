using System;
using DesignPatterns.Builder;

namespace DesignPatterns
{
    class Program
    {
        enum DesignOperatins
        {
            Unknown = 0,
            SOLID = 1,
            Builder = 2,
            Factory = 3,
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Press");
            Console.WriteLine($" - { (int)DesignOperatins.SOLID} for SOLID");
            Console.WriteLine($" - { (int)DesignOperatins.Builder} for Builder");
            Console.WriteLine($" - { (int)DesignOperatins.Factory} for Factory");

            DesignOperatins process = getDesignOperation();
            switch (process)
            {
                case DesignOperatins.SOLID:

                    break;
                case DesignOperatins.Builder:
                    //Console.WriteLine(new CodeBuilder("Person").AddField("Name","string").AddField("Age","int"));
                    new CustomerBuilderDemo().Run();
                    break;
                case DesignOperatins.Factory:
                    var pf = new Factory.PersonFactory();
                    var p1 = pf.GetPerson("ibrahim");
                    Console.WriteLine(p1);
                    var p2 = pf.GetPerson("simge");
                    Console.WriteLine(p2);
                    break;
                default:
                    break;
            }

            Console.ReadKey();
        }

        static DesignOperatins getDesignOperation()
        {
            DesignOperatins op = DesignOperatins.Unknown;
            do
            {
                try
                {
                    op = (DesignOperatins)Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    op = DesignOperatins.Unknown;
                }
                finally
                {
                    if (!operationIsValid(op))
                    {
                        Console.WriteLine("Invalid operation. Please retry.");
                    }
                }
            } while (!operationIsValid(op));

            return op;
        }

        private static bool operationIsValid(DesignOperatins op)
        {
            return (op == DesignOperatins.SOLID || op == DesignOperatins.Builder|| op == DesignOperatins.Factory);
        }
    }
}
