using MRuby.Net.Native;
using System;

namespace MRuby.Net.Irb
{
    class Program
    {
        static void Main()
        {
            var mrb = MrbMethods.mrb_open();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "exit") break;

                try
                {
                    var result = MrbMethods.mrb_load_string(mrb, line);
                    Console.WriteLine(result.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception caught: " + ex.Message);
                }
            }

            MrbMethods.mrb_close(mrb);
        }
    }
}
