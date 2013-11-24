using System;
using MRuby.Net;

namespace Irb
{
    public class Program
    {
        private static void Main()
        {
            using (var mruby = new MRubyEnvironment())
            {
                Console.WriteLine("Welcome to MRuby.Net Interactive Ruby (irb). Enter 'exit' on a line by itself to exit.");

                while (true)
                {
                    var line = Console.ReadLine();
                    if (line == "exit") break;

                    try
                    {
                        var result = mruby.Evaluate(line);
                        Console.WriteLine(result.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception caught: " + ex.Message);
                    }
                }
            }
        }
    }
}
