using MRuby.Net.Native;
using System;

namespace MRuby.Net.Irb
{
    class Program
    {
        static void Main()
        {
            var env = MrbMethods.mrb_open();
            MrbMethods.mrb_load_string(env, "p 'Hello World from Ruby'; nil;");
            MrbMethods.mrb_close(env);

            Console.ReadKey();
        }
    }
}
