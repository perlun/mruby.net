using System;
using System.Runtime.InteropServices;
using MRuby.Net.Native;
using Xunit;

namespace MRuby.Net.Tests.Native
{
    public class MrbTest
    {
        [Fact]
        public void Can_Close_an_environment_previously_openeded_with_Open()
        {
            var env = Mrb.Open();
            Mrb.Close(env);
        }

        [Fact]
        public void Can_run_some_dummy_code()
        {
            var env = Mrb.Open();
            
            // TODO: This raises exceptions. Why? We are marshalling as the "right" string type, so it should really work, but
            // TODO: for whatever reason, it doesn't...
            Mrb.LoadString(env, "10 + 20");

            Mrb.Close(env);
        }
    }
}
