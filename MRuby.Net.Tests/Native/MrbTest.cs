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
        public void Can_run_some_code_and_get_a_Fixnum_back()
        {
            var env = Mrb.Open();

            var value = Mrb.LoadString(env, "10 + 20");
            Assert.Equal(MrbValueType.Fixnum, value.ValueType);
            Assert.Equal(30U, value.ValuePart1);

            Mrb.Close(env);
        }

        [Fact]
        public void Can_run_some_code_and_get_nil_back()
        {
            var env = Mrb.Open();

            var value = Mrb.LoadString(env, "nil");
            Assert.True(value.IsNil);

            Mrb.Close(env);
        }

        [Fact]
        public void Can_run_some_code_and_get_false_back()
        {
            var env = Mrb.Open();

            var value = Mrb.LoadString(env, "false");
            Assert.True(value.IsFalse);

            Mrb.Close(env);
        }

        [Fact]
        public void Raises_an_exception_for_invalid_code()
        {
            var env = Mrb.Open();

            var value = Mrb.LoadString(env, "this is just some junk (not valid Ruby code)");
            Assert.True(value.IsNil);

            // TODO: This is hard to check in "pure CLR" (using P/Invoke); we don't want to have to duplicate a lot of the mruby
            // TODO: internals on the CLR side. Perhaps we have to consider the C++/CLR track after all...
            // if (mrb->exc) {

            Mrb.Close(env);
        }
    }
}
