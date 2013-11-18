using MRuby.Net.Native;
using System;

namespace MRuby.Net.Irb
{
    class Program
    {
        static void Main(string[] args)
        {
            var env = Mrb.Open();
            var result = Mrb.LoadString(env, "p 'Hello World from Ruby'; nil;");
            Mrb.Close(env);

            Console.ReadKey();
        }
    }
}
