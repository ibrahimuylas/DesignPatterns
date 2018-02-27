using System;

namespace DesignPatterns
{
    class Program
    {
        enum DesignOperatins
        {
            Unknown = 0,
            SOLID = 1
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Press");
            Console.WriteLine($" - { (int)DesignOperatins.SOLID} for SOLID");

            DesignOperatins process = getDesignOperation();
            switch (process)
            {
                case DesignOperatins.SOLID:

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
            return (op == DesignOperatins.SOLID);
        }
    }
}
